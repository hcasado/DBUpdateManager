using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUpdateManager.Core.Script
{
    public enum ScriptTypeEnum
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
