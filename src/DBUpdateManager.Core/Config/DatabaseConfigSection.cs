using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUpdateManager.Core.Config
{
    public class DatabaseConfigSection
    {
        private const string kConnectionString = "Password={3}; User ID={2}; Initial Catalog={1}; Data Source={0}";

        public string Type { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Name { get; set; }
        public string Schema { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string GetConnectionString()
        {
            string cnnStr = string.Format(kConnectionString,
                                           this.Host,
                                           this.Name,
                                           this.User,
                                           this.Password);

            return cnnStr;
        }
    }
}
