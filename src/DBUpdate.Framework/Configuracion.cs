using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Labs.GestorActualizacionBD.Framework
{
    public class Configuracion : DinamoSoftware.Foundation.Configuracion
    {
        /// <summary>
        /// Singleton de la configuracion del framework.
        /// </summary>
        public static Configuracion Instancia = new Configuracion();

        private const string kConfigurationFile = "GestorIncidencias.cfg.xml";
        private const string kConnectionStringKey = "ConnectionString";
        private const string kCarpetaDeIncidenciasKey = "CarpetaDeIncidencias";

        private const string kSeccionDBUpdateManager = "Labs.GestorActualizacionBD";

        private string _ConnectionString = string.Empty;
        private string _CarpetaIncidencias = string.Empty;

        /// <summary>
        /// Construye la instancia, busca el archivo de configuracion y lo valida.
        /// </summary>
        public Configuracion()
        {
            bool existeArchivoCfg = false;

            string configDir = string.Empty;
            string configLocation = string.Empty;

            configDir = ConfigurationManager.AppSettings["DirectorioConfiguraciones"];
            if (!string.IsNullOrEmpty(configDir))
            {
                configLocation = System.IO.Path.Combine(configDir, kConfigurationFile);
                if (File.Exists(configLocation))
                {
                    existeArchivoCfg = true;
                }
            }

            if (!existeArchivoCfg)
            {
                configDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (configDir != null)
                {
                    configLocation = System.IO.Path.Combine(configDir, kConfigurationFile);
                    if (File.Exists(configLocation))
                    {
                        existeArchivoCfg = true;
                    }
                }
            }

            if (existeArchivoCfg)
            {

                this.Configurar(configLocation);

                try
                {
                    this.ControlarConfiguracionCompleta(kSeccionDBUpdateManager,
                        new string[] { kConnectionStringKey, kCarpetaDeIncidenciasKey });
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error leyendo archivo de configuracion: " + configLocation, ex);
                }

                _ConnectionString = this.Settings.Configs[kSeccionDBUpdateManager].GetString(kConnectionStringKey);
                _CarpetaIncidencias = this.Settings.Configs[kSeccionDBUpdateManager].GetString(kCarpetaDeIncidenciasKey);
            }

        }

        /// <summary>
        /// Connection String para acceder a la base de datos.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
                this.Settings.Configs[kSeccionDBUpdateManager].Set(kConnectionStringKey, value);
                this.Settings.Save();
            }
        }

        /// <summary>
        /// Carpeta que contiene las incidendcias, las mismas se agrupan en carpetas
        /// </summary>
        public string CarpetaDeIncidencias
        {
            get
            {
                return _CarpetaIncidencias;
            }

            set
            {
                _CarpetaIncidencias = value;
                this.Settings.Configs[kSeccionDBUpdateManager].Set(kCarpetaDeIncidenciasKey, value);
                this.Settings.Save();
            }

        }
    }
}
