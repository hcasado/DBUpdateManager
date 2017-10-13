using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdateManager.Core.Issue;

namespace DBUpdateManager.Core.Script
{
    public class ScriptEntity
    {
        public IssueEntity IssueEntity;
        public Int32 Secuencia;
        public String Nombre;
        public String UpFile;
        public String UpSql;
        public String DownFile;
        public String DownSql;

        public ScriptTypeEnum Tipo;


        public void Merge(ScriptEntity script)
        {
            if (string.IsNullOrEmpty(this.UpSql))
            {
                this.UpSql = script.UpSql;
            }

            if (string.IsNullOrEmpty(this.DownSql))
            {
                this.DownSql = script.DownSql;
            }

            if (string.IsNullOrEmpty(this.UpFile))
            {
                this.UpFile = script.UpFile;
            }


            if (string.IsNullOrEmpty(this.DownFile))
            {
                this.DownFile = script.DownFile;
            }


        }
    }
}
