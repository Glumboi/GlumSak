using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.ConfigIni.Core
{
    public static class ConfigVars
    {
        public static bool GetWebConfig()
        {
            if (ConfigIni.GetConfig("WebConfig", "config") == "False" ||
                ConfigIni.GetConfig("WebConfig", "config") == "false")
            {
                return false;
            }

            return true;
        }
    }
}
