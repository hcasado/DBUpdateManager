using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

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
    }
}
