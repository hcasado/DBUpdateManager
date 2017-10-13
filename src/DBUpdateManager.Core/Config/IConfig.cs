using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUpdateManager.Core.Config
{
    interface IConfig
    {
        string ScriptRootFolder { get; }
        string ConnectionString { get; }
    }
}
