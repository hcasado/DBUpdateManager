/***********************************************************************
 * Module:  Incidencia.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Labs.GestorActualizacionBD.Core.Incidencia
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Labs.GestorActualizacionBD.Framework
{
    public class Incidencia
    {
        public Int32 Secuencia;
        public String Nombre;
        public Int32 Nro;
        public IDictionary<Int32, Script> Scripts = new Dictionary<Int32, Script>();
        public String PathFisico;
        public Boolean Aplicada { get; set; }


        public void Merge(Incidencia incidencia)
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