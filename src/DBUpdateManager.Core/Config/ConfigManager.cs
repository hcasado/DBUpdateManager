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
        private const string kConfigurationFile = "DBUpdateManager.config.json";

        public ConfigEntity ReadConfig()
        {
            string json = string.Empty;
            try
            {
                json = new StreamReader(kConfigurationFile).ReadToEnd();
            }
            catch (FileNotFoundException fex)
            {
                throw new ApplicationException("configuration file not found: " + kConfigurationFile, fex);
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
                new StreamWriter(kConfigurationFile).Write(json);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("error writing file: " + kConfigurationFile, ex);
            }
        }

    }
}
