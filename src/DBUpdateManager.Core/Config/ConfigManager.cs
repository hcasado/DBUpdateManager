using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DBUpdateManager.Core.Config
{
    public class ConfigManager
    {
        public static string CurrentConfigFileFullPath = string.Empty;
        private string configFileFullPath = string.Empty;

        public ConfigManager(string configFileFullPath)
        {
            this.configFileFullPath = configFileFullPath;
        }

        public ConfigManager()
        {
            if (string.IsNullOrWhiteSpace(ConfigManager.CurrentConfigFileFullPath))
            {
                throw new ApplicationException("must specify config file");
            }

            this.configFileFullPath = ConfigManager.CurrentConfigFileFullPath;
        }

        public ConfigEntity ReadConfig()
        {
            string json = string.Empty;
            try
            {
                json = new StreamReader(configFileFullPath).ReadToEnd();
            }
            catch (FileNotFoundException fex)
            {
                throw new ApplicationException("configuration file not found: " + configFileFullPath, fex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var entity = JsonConvert.DeserializeObject<ConfigEntity>(json);
            return entity;
        }

        public void WriteConfig(ConfigEntity entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            try
            {
                new StreamWriter(configFileFullPath).Write(json);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("error writing file: " + configFileFullPath, ex);
            }
        }

    }
}
