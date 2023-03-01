using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI_WPF.Extensions
{
    internal class GetSettingsProperty
    {
        public static bool GetAutoUpdate()
        {
            return Properties.Settings.Default.CheckForUpdatesOnStartup;
        }
    }
}