using Bunifu.UI.WinForms;
using EmuSak_Revive.ConfigIni.Core;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = System.Windows.Forms.Application;

namespace EmuSak_Revive.Language
{
    public static class Lang
    {
        public static List<string> Languages { get => _languages; }
        private static List<string> _languages = new List<string>();

        private static List<string> languageIniPaths = new List<string>();

        private static IniParser iniParser;

        public static void LoadLanguageConfigs()
        {
            string iniFolder = Environment.CurrentDirectory + @"\Language";
            string[] files = new string[] { };

            try
            {
                files = Directory.GetFiles(iniFolder, "*.ini", SearchOption.AllDirectories);
            }
            catch (Exception)
            {
                return;
            }

            foreach (var file in files)
            {
                _languages.Add(Path.GetFileName(file).Split('.').First());
                languageIniPaths.Add(file);
            }
        }

        public static string GetSingeString(string sectioon, string key)
        {
            return iniParser.GetSetting(sectioon, key);
        }

        public static List<string> GetLangIniSettings(int index)
        {
            List<string> res = new List<string>();

            string LangFile = languageIniPaths[index];

            iniParser = new IniParser(LangFile);

            var section = iniParser.EnumSection("language");

            foreach (var str in section)
            {
                var checkedStr = !str.Contains(';') ? str + " = " + iniParser.GetSetting("language", str) : string.Empty;
                if (!string.IsNullOrWhiteSpace(checkedStr))
                {
                    res.Add(checkedStr);
                }
            }

            return res;
        }

        public static void LoadLanguage(Control ctrl, int index)
        {
            string LangFile = languageIniPaths[index];

            iniParser = new IniParser(LangFile);

            var section = iniParser.EnumSection("language");
            var langDict = section.ToDictionary(k => k, k => iniParser.GetSetting("language", k));

            SetControlText(ctrl, langDict);
        }

        private static void SetControlText(Control ctrl, Dictionary<string, string> langDict)
        {
            if (langDict.TryGetValue(ctrl.Name, out string text))
            {
                Type tbType = typeof(BunifuTextBox);
                if (tbType.IsAssignableFrom(ctrl.GetType()))
                {
                    ctrl.GetType().GetProperty("PlaceholderText").SetValue(ctrl, text);
                }
                ctrl.Text = text;
            }

            foreach (Control child in ctrl.Controls)
            {
                SetControlText(child, langDict);
            }
        }
    }
}