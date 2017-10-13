using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DBUpdateManager.Core.Script
{
    public class ScriptFactory
    {
        private const string errorAlParsearElArchvo = "Se ha producido un error al parsear el archivo {0} que se encuentra en la carpeta {1}";
        private int _SecuenciaScriptImplementacion = 0;
        private string _NombreScriptImplementacion = string.Empty;
        private string _DireccionScriptImplementacion = string.Empty;
        private ScriptTypeEnum _TipoScriptImplementacion = ScriptTypeEnum.Script;
        private string _ScriptImplementacion = string.Empty;

        private int _SecuenciaScriptDesimplementacion = 0;
        private string _NombreScriptDesimplementacion = string.Empty;
        private string _DireccionScriptDesimplementacion = string.Empty;
        private ScriptTypeEnum _TipoScriptDesimplementacion = ScriptTypeEnum.Script;
        private string _ScriptDesimplementacion = string.Empty;


        public ScriptEntity Crear(FileInfo archivoDeImplementacion, FileInfo archivoDeDesimplementacion)
        {
            bool scriptImplementacionOk = ParsearScriptImplementacion(archivoDeImplementacion);
            bool scriptDesimplementacionOk = ParsearScriptDesimplementacion(archivoDeDesimplementacion);

            if (!scriptDesimplementacionOk)
            {
                throw new ApplicationException(string.Format(errorAlParsearElArchvo, archivoDeDesimplementacion.Name, archivoDeDesimplementacion.DirectoryName));
            }

            if (!scriptImplementacionOk)
            {
                throw new ApplicationException(string.Format(errorAlParsearElArchvo, archivoDeImplementacion.Name, archivoDeImplementacion.DirectoryName));
            }

            if (_TipoScriptImplementacion != _TipoScriptDesimplementacion)
            {
                throw new ApplicationException("El tipo de script no coincide en los archivos " + archivoDeImplementacion + " y " + archivoDeDesimplementacion);
            }

            if (_SecuenciaScriptImplementacion != _SecuenciaScriptDesimplementacion)
            {
                throw new ApplicationException("El numero de secuencia no coincide en los archivos " + archivoDeImplementacion + " y " + archivoDeDesimplementacion);
            }

            if (_NombreScriptImplementacion != _NombreScriptDesimplementacion)
            {
                throw new ApplicationException("El nombre del script no coincide en los archivos " + archivoDeImplementacion + " y " + archivoDeDesimplementacion);
            }

            ScriptEntity script = new ScriptEntity();
            script.Secuencia = _SecuenciaScriptImplementacion;
            script.Nombre = _NombreScriptImplementacion;
            script.Tipo = _TipoScriptImplementacion;

            script.UpFile = archivoDeImplementacion.Name;
            script.UpSql = _ScriptImplementacion;

            script.DownFile = archivoDeDesimplementacion.Name;
            script.DownSql = _ScriptDesimplementacion;

            return script;

        }

        public bool ParsearScriptImplementacion(FileInfo archivo)
        {
            string tipo = LeerParametro("tipo", archivo);
            string nombre = LeerParametro("nombre", archivo);
            string secuencia = LeerParametro("secuencia", archivo);
            string direcion = LeerParametro("direccion", archivo);
            string script = LeerScript(archivo);

            bool parseOk = true;

            if (parseOk && !VerificarTipo(tipo)) { parseOk = false; }
            if (parseOk && !VerificarSecuencia(secuencia)) { parseOk = false; }
            if (parseOk && (nombre.Length == 0)) { parseOk = false; }
            if (parseOk && !VerificarDireccion(direcion)) { parseOk = false; }
            if (parseOk && (script.Length == 0)) { parseOk = false; }

            if (parseOk)
            {
                _TipoScriptImplementacion = (ScriptTypeEnum)Enum.Parse(typeof(ScriptTypeEnum), tipo, true);
                _SecuenciaScriptImplementacion = int.Parse(secuencia);
                _NombreScriptImplementacion = nombre;
                _DireccionScriptImplementacion = direcion;
                _ScriptImplementacion = script;
            }

            return parseOk;

        }

        public bool ParsearScriptDesimplementacion(FileInfo archivo)
        {
            string tipo = LeerParametro("tipo", archivo);
            string nombre = LeerParametro("nombre", archivo);
            string secuencia = LeerParametro("secuencia", archivo);
            string direcion = LeerParametro("direccion", archivo);
            string script = LeerScript(archivo);

            bool parseOk = true;

            if (parseOk && !VerificarTipo(tipo)) { parseOk = false; }
            if (parseOk && !VerificarSecuencia(secuencia)) { parseOk = false; }
            if (parseOk && (nombre.Length == 0)) { parseOk = false; }
            if (parseOk && !VerificarDireccion(direcion)) { parseOk = false; }
            if (parseOk && (script.Length == 0)) { parseOk = false; }

            if (parseOk)
            {
                _TipoScriptDesimplementacion = (ScriptTypeEnum)Enum.Parse(typeof(ScriptTypeEnum), tipo, true);
                _SecuenciaScriptDesimplementacion = int.Parse(secuencia);
                _NombreScriptDesimplementacion = nombre;
                _DireccionScriptDesimplementacion = direcion;
                _ScriptDesimplementacion = script;
            }

            return parseOk;
        }

        private string LeerParametro(string parametro, FileInfo archivo)
        {
            StreamReader sr = archivo.OpenText();
            string valor = string.Empty;
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("@param"))
                {
                    if (line.Contains(parametro))
                    {
                        int idx = line.IndexOf(parametro);
                        string valorCrudo = line.Substring(idx + parametro.Length + 1);
                        valor = valorCrudo.Trim();

                        break;
                    }
                }

            }

            return valor;
        }

        private string LeerScript(FileInfo archivo)
        {
            StreamReader sr = archivo.OpenText();
            string abrirComentario = "/*";
            string cerrarComentario = "*/";
            bool comentario = false;

            StringBuilder script = new StringBuilder();

            string linea = string.Empty;
            while ((linea = sr.ReadLine()) != null)
            {
                if (linea.Contains(abrirComentario))
                {
                    comentario = true;

                    if (linea.Contains(cerrarComentario))
                    {
                        comentario = false;
                    }

                }
                else if (linea.Contains(cerrarComentario))
                {
                    comentario = false;

                }
                else
                {
                    if (!comentario)
                    {
                        script.AppendLine(linea);
                    }

                }

            }

            return script.ToString();

        }

        /// <summary>
        /// Verifica que el tipo de script indicado sea uno de los que se encuentran definidos.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private bool VerificarTipo(string tipo)
        {
            string[] names = Enum.GetNames(typeof(ScriptTypeEnum));
            bool verificado = false;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().Equals(tipo.ToLower()))
                {
                    verificado = true;
                    break;
                }
            }

            if (verificado && (tipo.Length == 0))
            {
                verificado = false;
            }

            return verificado;
        }

        private bool VerificarDireccion(string direcion)
        {
            bool verificado = false;

            if (direcion == "up")
            {
                verificado = true;
            }

            if (!verificado && (direcion == "down"))
            {
                verificado = true;
            }

            if (!verificado && (direcion.Length > 0))
            {
                verificado = true;
            }


            return verificado;
        }

        private bool VerificarSecuencia(string secuencia)
        {
            int i = 0;
            bool verificado = false;

            verificado = int.TryParse(secuencia, out i);

            return verificado;
        }


    }
}
