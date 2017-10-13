using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUpdateManager.Core.Script;

namespace DBUpdateManager.Core.Issue
{
    public class IssueEntity
    {
        public Int32 Secuencia;
        public String Nombre;
        public Int32 Nro;
        public IDictionary<Int32, ScriptEntity> Scripts = new Dictionary<Int32, ScriptEntity>();
        public String PathFisico;
        public Boolean Aplicada { get; set; }


        public void Merge(IssueEntity incidencia)
        {
            if (string.IsNullOrEmpty(this.PathFisico))
            {
                this.PathFisico = incidencia.PathFisico;
            }

            foreach (var se in this.Scripts) //por cada script entry
            {
                se.Value.Merge(incidencia.Scripts[se.Key]);
            }

            this.Nro = incidencia.Nro;
            this.Secuencia = incidencia.Secuencia;
            this.Nombre = incidencia.Nombre;

        }
    }
}
