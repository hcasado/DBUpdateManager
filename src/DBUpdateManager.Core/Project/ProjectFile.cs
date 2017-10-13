using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdateManager.Core.Config;

namespace DBUpdateManager.Core.Project
{
    public class ProjectFile
    {
        private const string kFileExtension = "djp";

        public string Name { get; set; }
        public string Location { get; set; }
        public ConfigEntity Content { get; set; }

        public ProjectFile()
        {
            this.Content = new ConfigEntity();
        }

        public string GetFullPath()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Location);
            sb.Append("\\");
            sb.Append(this.Name);
            sb.Append(".");
            sb.Append(ProjectFile.kFileExtension);

            return sb.ToString();

        }


    }
}
