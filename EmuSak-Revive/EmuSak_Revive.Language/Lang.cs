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

        public static void LoadLanguageTabs(int index, TabPage page)
        {
            string LangFile = languageIniPaths[index];

            iniParser = new IniParser(LangFile);

            var section = iniParser.EnumSection("language");

            foreach (var str in section)
            {
                Control ctn = page.Controls[str];

                if (ctn is Control && page.Contains(ctn))
                {
                    if (ctn is Guna2TextBox)
                    {
                        var tb = (Guna2TextBox)ctn;
                        tb.PlaceholderText = iniParser.GetSetting("language", str);
                    }
                    ctn.Text = iniParser.GetSetting("language", str);
                }
                if (!(ctn is Control) && Application.OpenForms[str] != null)
                {
                    Application.OpenForms[str].Text = iniParser.GetSetting("language", str);
                }
            }
        }

        public static void LoadLanguage(int index, Form frm)
        {
            string LangFile = languageIniPaths[index];

            iniParser = new IniParser(LangFile);

            var section = iniParser.EnumSection("language");

            foreach (var str in section)
            {
                Control ctn = frm.Controls[str];

                if (ctn is Control && frm.Contains(ctn))
                {
                    if (ctn is BunifuTextBox)
                    {
                        var tb = (BunifuTextBox)ctn;
                        tb.PlaceholderText = iniParser.GetSetting("language", str);
                    }
                    ctn.Text = iniParser.GetSetting("language", str);
                }
                if (!(ctn is Control) && Application.OpenForms[str] != null)
                {
                    Application.OpenForms[str].Text = iniParser.GetSetting("language", str);
                }
            }
        }
    }
}