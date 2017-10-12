/***********************************************************************
 * Module:  TipoDeScript.cs
 * Author:  Administrator
 * Purpose: Definition of the Enum Labs.GestorActualizacionBD.Core.TipoDeScript
 ***********************************************************************/

using System;

namespace Labs.GestorActualizacionBD.Framework
{
   public enum TipoDeScript
   {
      Script,
      Table,
      Column,
      Constraint,
      StoredProcedure,
      Function,
      View
   }
}