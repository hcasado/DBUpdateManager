/***********************************************************************
 * Module:  Script.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Labs.GestorActualizacionBD.Core.Script
 ***********************************************************************/

using System;

namespace Labs.GestorActualizacionBD.Framework
{
    public class Script
    {
        public Incidencia Incidencia;
        public Int32 Secuencia;
        public String Nombre;
        public String UpFile;
        public String UpSql;
        public String DownFile;
        public String DownSql;

        public TipoDeScript Tipo;


        public void Merge(Script script)
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