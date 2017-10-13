using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdateManager.Core.Db;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using DBUpdateManager.Core.Script;

namespace DBUpdateManager.Core.Issue
{
    public class IssueManager : TransactionManager
    {
        private const string kExisteTablaLog = "select count(1) from dbo.sysobjects where id = object_id('__bitacora_de_actualizacion')";

        private const string kLeerIncidenciasSql = "select nro_incidencia, secuencia_script, nombre_script from __bitacora_de_actualizacion order by nro_incidencia, secuencia_script";

        private const string kExisteIncidencia = "select count(1) from __bitacora_de_actualizacion order by nro_incidencia, nombre_script";

        private const string kActualizarLogBD =
            "insert into __bitacora_de_actualizacion " +
            "(id, nro_incidencia , nombre_script," +
            " tipo_script, secuencia_script, fecha_aplicacion) " +
            " values (newid(), {0}, '{1}', '{2}', {3}, getdate())";

        private const string kRevertirLogDB = "delete from __bitacora_de_actualizacion " +
                                                "where nro_incidencia = {0} and nombre_script = '{1}'";

        private const string kIncrementarVersionBD = "update __versiones " +
                                                        "set version = convert(varchar, convert(int, version) + 1 ) " +
                                                        "where nombre = 'BD' ";

        private const string kDecrementarVersionBD = "update __versiones " +
                                                        "set version = convert(varchar, convert(int, version) - 1 ) " +
                                                        "where nombre = 'BD' ";


        public IssueManager()
        {

        }

        public List<IssueEntity> LeerIncidenciasAplicadas()
        {
            List<IssueEntity> listaIncidencias = new List<IssueEntity>();
            var ds = new DataSet();
            int existeTablaLog = 0;
            // carga el dataset
            var m = new DBUpdateManager.Core.Config.ConfigManager();

            var config = new DBUpdateManager.Core.Config.ConfigManager();
            using (SqlConnection cnn = new SqlConnection(config.ReadConfig().ConnectionString))
            {
                cnn.Open();

                using (SqlCommand cmd = new SqlCommand(kExisteTablaLog, cnn))
                {
                    existeTablaLog = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (existeTablaLog > 0)
                {
                    using (SqlCommand cmd = new SqlCommand(kLeerIncidenciasSql, cnn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
                else
                {
                    throw new ApplicationException("No existe la tabla __bitacora_de_actualizacion en la base de datos.");
                }
            }

            //procesa el dataset.
            if (ds.Tables.Count > 0)
            {
                try
                {
                    DataTable dt = ds.Tables[0];

                    int nro_incidencia = 0;
                    IssueEntity incidencia = null;
                    ScriptEntity script = null;

                    foreach (DataRow dr in dt.Rows)
                    {
                        script = new ScriptEntity();
                        script.Nombre = dr["nombre_script"].ToString();
                        if (nro_incidencia != Convert.ToInt32(dr["nro_incidencia"]))
                        {
                            // agregar incidencia a la lista
                            if (incidencia != null)
                            {
                                listaIncidencias.Add(incidencia);
                            }

                            // crear una nueva incidencia
                            incidencia = new IssueEntity();
                            nro_incidencia = Convert.ToInt32(dr["nro_incidencia"]);
                            incidencia.Nro = nro_incidencia;
                            incidencia.Nombre = nro_incidencia.ToString();
                            incidencia.Aplicada = true;
                        }

                        script.Secuencia = Convert.ToInt32(dr["secuencia_script"]);
                        script.Nombre = Convert.ToString(dr["nombre_script"]);
                        script.IssueEntity = incidencia;
                        incidencia.Scripts.Add(script.Secuencia, script);
                    }
                    // agregar incidencia a la lista
                    if (incidencia != null)
                    {
                        listaIncidencias.Add(incidencia);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("No se ha podido leer el contenido de la tabla __bitacora_de_actualizacion", ex);
                }

            }

            return listaIncidencias;
        }

        public List<IssueEntity> CrearIncidencias(DirectoryInfo directorio)
        {
            List<IssueEntity> incidencias = new List<IssueEntity>();


            var factory = new IssueFactory();
            foreach (DirectoryInfo di in directorio.GetDirectories())
            {
                if (!di.Name.StartsWith("."))
                {
                    IssueEntity i = factory.Crear(di);
                    if (i != null) incidencias.Add(i);
                }
            }

            return incidencias;
        }

        /// <summary>
        /// Registrar aplicacion del script.
        /// </summary>
        /// <param name="script"></param>
        public void RegistrarAplicacionDeScript(ScriptEntity script)
        {
            string sqlCmd = string.Format(kActualizarLogBD,
                    script.IssueEntity.Nro,
                    script.Nombre,
                    script.Tipo.ToString().ToLower().ToLower(),
                    script.Secuencia);

            SqlCommand cmdLog = new SqlCommand(sqlCmd, this._Cnn, _Tnx);
            cmdLog.CommandType = CommandType.Text;
            cmdLog.ExecuteNonQuery();

            SqlCommand cmdInc = new SqlCommand(kIncrementarVersionBD, _Cnn, _Tnx);
            cmdInc.CommandType = CommandType.Text;
            cmdInc.ExecuteNonQuery();
        }

        /// <summary>
        /// Registrar reversion del script.
        /// </summary>
        /// <param name="script"></param>
        public void RegistrarReversionDeScript(ScriptEntity script)
        {
            string sqlCmd = string.Format(kRevertirLogDB, script.IssueEntity.Nro, script.Nombre);

            SqlCommand cmdLog = new SqlCommand(sqlCmd, _Cnn, _Tnx);
            cmdLog.CommandType = CommandType.Text;
            cmdLog.ExecuteNonQuery();

            SqlCommand cmdInc = new SqlCommand(kIncrementarVersionBD, _Cnn, _Tnx);
            cmdInc.CommandType = CommandType.Text;
            cmdInc.ExecuteNonQuery();
        }

        /// <summary>
        /// Aplica un script sql
        /// </summary>
        /// <param name="script"></param>
        public void AplicarScript(ScriptEntity script)
        {
            List<String> sqlList = new List<string>(0);

            if (script.Tipo == ScriptTypeEnum.Script)
            {
                var sqlArray = script.UpSql.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var sql in sqlArray)
                {
                    if (!string.IsNullOrEmpty(sql.Trim()))
                    {
                        sqlList.Add(sql.Trim());
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(script.UpSql.Trim()))
                {
                    sqlList.Add(script.UpSql.Trim());
                }

            }


            //ejecutar desde la lista de sql a ejecutar
            foreach (var sql in sqlList)
            {
                SqlCommand cmd = new SqlCommand(sql, _Cnn, _Tnx);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }

            RegistrarAplicacionDeScript(script);
        }

        /// <summary>
        /// Revierte los cambios aplicados por un script
        /// </summary>
        /// <param name="script"></param>
        public void RevertirScript(ScriptEntity script)
        {

            List<String> sqlList = new List<string>(0);

            if (script.Tipo == ScriptTypeEnum.Script)
            {
                var sqlArray = script.DownSql.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var sql in sqlArray)
                {
                    if (!string.IsNullOrEmpty(sql.Trim()))
                    {
                        sqlList.Add(sql.Trim());
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(script.UpSql.Trim()))
                {
                    sqlList.Add(script.DownSql.Trim());
                }

            }


            //ejecutar desde la lista de sql a ejecutar
            foreach (var sql in sqlList)
            {
                SqlCommand cmd = new SqlCommand(sql, _Cnn, _Tnx);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }

            RegistrarReversionDeScript(script);

        }

    }
}
