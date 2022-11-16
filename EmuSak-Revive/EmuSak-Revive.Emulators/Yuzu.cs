using Glumboi.UI.Toast;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.Emulators
{
    public static class Yuzu
    {
        private static List<string> games = new List<string>();
        public static List<string> Games
        {
            get { return games; }
            set { games = value; }
        }

        public static string KeysLoc { get => keysLoc; }
        public static string PortableKeysLoc { get => portableKeysLoc; }
        public static string CustomNandLoc { get => customNandLoc; }
        public static string FirmwareLoc { get => firmwareLoc; }
        public static string PortableYuzuPath { get => portableYuzuPath; }
        public static bool PortableYuzu { get => !string.IsNullOrWhiteSpace(portableYuzuPath); }

        static string portableYuzuPath = string.Empty;
        static string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        static string gamesLoc = roaming + "\\yuzu\\cache\\game_list"; 
        static string keysLoc = roaming + "\\yuzu\\keys";
        static string shadersLoc = roaming + "\\yuzu\\shader";
        static string configIni = roaming + "\\yuzu\\config\\qt-config.ini";

        static string portableGamesLoc = portableYuzuPath + "\\cache\\game_list";
        static string portableKeysLoc = portableYuzuPath + "\\keys";
        static string portableConfigIni = portableYuzuPath + "\\config\\qt-config.ini";
        static string portableShadersLoc = roaming + "\\yuzu\\shader";

        static string customNandLoc = string.Empty;
        static string firmwareLoc = string.Empty;

        public static void ChangePortablePath(string path)
        {
            portableYuzuPath = path;
            portableGamesLoc = path + "\\cache\\game_list";
            portableKeysLoc = path + "\\keys";
            portableConfigIni = path + "\\config\\qt-config.ini";
            portableShadersLoc = path + "\\shader";
        }

        public static void GetGames()
        {
            string[] subdirs = new string[] { };

            if (!string.IsNullOrWhiteSpace(portableYuzuPath))
            {
                try
                {
                    subdirs = Directory.GetFiles(portableGamesLoc);
                }
                catch
                {
                    ToastHandler.ShowToast("Selected portable path doesn't contain Yuzu related files! " +
                        "Please revert to standard settings or select a true Yuzu folder.",
                        "Yuzu portable folder error!");
                }
            }
            else
            {
                subdirs = Directory.GetFiles(gamesLoc);
            }

            foreach (var subdir in subdirs)
            {
                var stringSplitted = subdir.ToUpper().Split('\\');
                foreach (var file in stringSplitted)
                {
                    if (file.Contains("PV"))
                    {
                        games.Add(file.Split('.')[0]);
                    }
                }
            }
            //To make sure that we can also install the firmware right away
            GetCustomNand();
        }

        public static void GetCustomNand()
        {
            string[] fileContent = new string[] { };

            if (!string.IsNullOrWhiteSpace(PortableYuzuPath))
            {
                fileContent = File.ReadAllLines(portableConfigIni);
            }
            else
            {
                fileContent = File.ReadAllLines(configIni);
            }

            foreach (string line in fileContent)
            {
                if (line.Contains("nand_directory="))
                {
                    customNandLoc = line.Split('=')[1];
                    if (customNandLoc.Contains(@"\\"))
                    {
                        var forwardLoc = customNandLoc.Replace(@"\\", @"/");
                        firmwareLoc = forwardLoc + "/system/Contents/registered";
                        return;
                    }
                    firmwareLoc = customNandLoc + "system/Contents/registered";
                }
            }
        }

    }
}
