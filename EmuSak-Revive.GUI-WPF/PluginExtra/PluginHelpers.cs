using EmuSak_Revive.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI_WPF.PluginExtra
{
    internal static class PluginHelpers
    {
        public static List<Plugin> autorunPlugins = new List<Plugin>();
        public static List<Plugin> plugins = new List<Plugin>();

        public static Plugin GetPluginByName(string nameOfPlugin)
        {
            foreach (var item in plugins)
            {
                if (item.PluginName == nameOfPlugin)
                {
                    return item;
                }
            }

            return null;
        }

        public static IEnumerable<Plugin> GetPlugins(string pluginsPath, IntPtr windowHandle)
        {
            foreach (string item in Directory.GetDirectories(pluginsPath))
            {
                string[] files = Directory.GetFiles(item);
                string iniOfPlugin = string.Empty;
                List<string> dllPaths = new List<string>();

                foreach (string file in files)
                {
                    if (file.Contains(".dll"))
                    {
                        dllPaths.Add(file);
                    }

                    if (file.Contains(".ini"))
                    {
                        iniOfPlugin = file;
                    }
                }

                yield return new Plugin(windowHandle, dllPaths, iniOfPlugin);
            }
        }
    }
}