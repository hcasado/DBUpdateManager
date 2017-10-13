using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUpdateManager.Core.Config
{
    public class ConfigEntity : IConfig
    {

        public string CarpetaDeIncidencias
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }
    }
}
