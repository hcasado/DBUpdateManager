using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdateManager.Core.Script;
using System.IO;

namespace DBUpdateManager.Core.Issue
{
    public class IssueFactory
    {
        private const string kFilter = "*.sql";
        private List<ScriptEntity> _ScriptList = null;

        public IssueEntity Crear(DirectoryInfo directorio)
        {

            _ScriptList = null;
            _ScriptList = new List<ScriptEntity>();

            string prefix;
            for (int i = 1; i <= 9999; i++)
            {
                prefix = i.ToString().PadLeft(4, '0');
                FileInfo[] files = directorio.GetFiles(prefix + kFilter);
                if (files.Length == 0)
                {
                    break;
                }

                ProcesarScripts(directorio.Name, prefix, files);

            }

            //TODO: validar que no existan mas archivos que los procesados.


            IssueEntity incidencia = new IssueEntity();
            incidencia.Secuencia = 1;
            try
            {
                incidencia.Nro = Convert.ToInt32(directorio.Name);
                incidencia.PathFisico = directorio.FullName;
            }
            catch (FormatException fe)
            {
                // ignoramos el directorio que esta mal nombrado
                return null;

                //TODO: podemos poner un aviso al usuario de los directorios no procesados.
            }


            incidencia.Nombre = directorio.Name;

            foreach (ScriptEntity s in _ScriptList)
            {
                s.IssueEntity = incidencia;
                incidencia.Scripts.Add(s.Secuencia, s);
            }

            _ScriptList.Clear();

            return incidencia;

        }


        /// <summary>
        /// Valida que existan 2 archivos.
        /// </summary>
        /// <param name="directorio">Nombre del directorio donde se encuentran los scripts</param>
        /// <param name="secuencia">numero de secuencia</param>
        /// <param name="files">nombre de los archivos</param>
        private void ProcesarScripts(string directorio, string secuencia, FileInfo[] files)
        {
            if (files.Length != 2)
            {
                string mensaje = string.Format("Se requieren 2 scripts con numero de secuencia {0} en el direcotrio {1}.", secuencia, directorio);
                throw new ApplicationException(mensaje);
            }

            ScriptFactory scriptFactory = new ScriptFactory();
            FileInfo implementacion = null, desimplementacion = null;

            if (files[0].Name.Contains("_up.sql"))
            {
                implementacion = files[0];
            }

            if (files[1].Name.Contains("_up.sql"))
            {
                implementacion = files[1];
            }

            if (files[0].Name.Contains("_down.sql"))
            {
                desimplementacion = files[0];
            }

            if (files[1].Name.Contains("_down.sql"))
            {
                desimplementacion = files[0];
            }

            if (implementacion == null || desimplementacion == null)
            {
                string mensaje = string.Format("Dentro del directorio {0} la secuencia {1} " +
                                                "tiene mal formado el postfijo '_down.sql' o '_up.sql', " +
                                                "revíse el nombre de los archivos de dicha secuancia.",
                                                directorio, secuencia, files[0].Name, files[1].Name);
                throw new ApplicationException(mensaje);
            }

            ScriptEntity script = scriptFactory.Crear(implementacion, desimplementacion);
            _ScriptList.Add(script);

        }


    }
}
