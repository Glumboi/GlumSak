using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.GUI.Generics
{
    internal class LangLoader
    {
        /// <summary>
        /// A simple method that creates a settings window to load the languages,
        /// used til a better way is found
        /// </summary>
        public static void Run()
        {
            SettingsWindow langLoader = new SettingsWindow();
            try
            {
                langLoader.LoadSettings();
                langLoader.Dispose();
            }
            catch (Exception)
            {
                langLoader.Dispose();
            }
        }
    }
}