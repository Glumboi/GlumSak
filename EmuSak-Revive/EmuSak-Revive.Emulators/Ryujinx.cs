using Glumboi.UI.Toast;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.Emulators
{
    public static class Ryujinx
    {
        private static List<string> games = new List<string>();
        public static List<string> Games
        {
            get { return games; }
            set { games = value; }
        }

        private static List<string> gamesShader = new List<string>();
        public static List<string> GamesShader
        {
            get { return gamesShader; }
            set { gamesShader = value; }
        }

        public static string KeysLoc { get => keysLoc; }
        public static string FirmwareLoc { get => firmwareLoc; }

        //Properties for portable install of ryu
        public static string PortableRyujinxPath { get => portableRyuFolder; }
        public static bool PortableRyujinx { get => !string.IsNullOrWhiteSpace(portableRyuFolder); }
        public static string PortableKeysLoc { get => portableKeysLoc; }
        public static string PortableFirmwareLoc { get => portablefirmwareLoc; }

        private static string ryuFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ryujinx";
        private static string ryuGamesLoc = ryuFolder + "\\games";
        private static string keysLoc = ryuFolder + "\\system";
        static string firmwareLoc = ryuFolder + "\\bis\\system\\contents\\registered";

        //Variables for portable install of ryu
        private static string portableRyuFolder = string.Empty;
        private static string portableGamesLoc = string.Empty;
        private static string portableKeysLoc = string.Empty;
        private static string portablefirmwareLoc = string.Empty;

        public static void ChangePortablePath(string path)
        {
            portableRyuFolder = path;
            portableGamesLoc = path + "\\games";
            portableKeysLoc = path + "\\system";
            portablefirmwareLoc = path + "\\bis\\system\\contents\\registered";
        }

        public static void GetGames()
        {
            string[] subdirs = new string[] { };

            if (PortableRyujinx)
            {
                try
                {
                    subdirs = Directory.GetDirectories(portableGamesLoc);
                }
                catch
                {
                    ToastHandler.ShowToast("Selected portable path doesn't contain Ryujinx related files! " +
                        "Please revert to standard settings or select a true Ryujinx folder.",
                        "Ryujinx portable folder error!");
                }
            }
            else
            {
                subdirs = Directory.GetDirectories(ryuGamesLoc);
            }

            foreach (var subdir in subdirs)
            {
                gamesShader.Add(subdir + "\\cache\\shader");
                var stringSplitted = subdir.ToUpper().Split('\\');
                foreach (var folder in stringSplitted)
                {
                    if (folder.Contains("01"))
                    {
                        games.Add(folder.ToUpper());
                    }
                }
            }
        }
    }
}
