using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using DBUpdateManager.Core.Config;

namespace DBUpdateManager.Core.Project
{
    public class ProjectManager
    {
        public void Save(ProjectFile file) 
        {
            using (var sw = new StreamWriter(file.GetFullPath()))
            {
                var json = JsonConvert.SerializeObject(file.Content);
                sw.Write(json);
            }
        }

        public ProjectFile Load(string fullpath)
        {
            ProjectFile projectFile = null;

            using (var sr = new StreamReader(fullpath)) {

                projectFile = new ProjectFile();
                var json = sr.ReadToEnd();
                projectFile.Content = JsonConvert.DeserializeObject<ConfigEntity>(json);
            }

            return projectFile;

        }
    }
}
