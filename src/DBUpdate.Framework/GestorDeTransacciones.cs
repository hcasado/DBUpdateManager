/***********************************************************************
 * Module:  GestorDeActualizacionBD.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Labs.GestorActualizacionBD.Core.GestorDeActualizacionBD
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Labs.GestorActualizacionBD.Framework
{
    public class GestorDeTransacciones
    {

        protected SqlConnection _Cnn = null;
        protected SqlTransaction _Tnx = null;

        public GestorDeTransacciones()
        {

        }

        public void BeginTransaction()
        {
            _Cnn = new SqlConnection(Configuracion.Instancia.ConnectionString);
            _Cnn.Open();

            //IsolationLevel.ReadUncommitted allows mix DMLs and DDLs into same db script.
            _Tnx = _Cnn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void SaveTransaction(string savePointName)
        {
            _Tnx.Save(savePointName);
        }

        public void CommitTransaction()
        {
            _Tnx.Commit();
            _Cnn.Close();
            _Tnx = null;
            _Cnn = null;
        }

        public void RollbackTransaction()
        {
            _Tnx.Rollback();
            _Cnn.Close();
            _Tnx = null;
            _Cnn = null;
        }


        public void EjecutarSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, _Cnn, _Tnx);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();            
        }
    }
}