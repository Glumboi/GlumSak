using EmuSak_Revive.Network;
using Glumboi.UI.Toast;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EmuSak_Revive.Emulators
{
    public static class Ryujinx
    {
        #region Public properties

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

        public static string SaveRoot
        {
            get
            {
                return PortableRyujinx ? portableSaveGameLoc : saveGameLoc;
            }
        }

        public static string DefaultBaseLoc { get => ryuFolder; }
        public static string KeysLoc { get => keysLoc; }
        public static string FirmwareLoc { get => firmwareLoc; }

        //Properties for portable install of ryu
        public static string PortableRyujinxPath { get => portableRyuFolder; }

        public static bool PortableRyujinx { get => !string.IsNullOrWhiteSpace(portableRyuFolder); }
        public static string PortableKeysLoc { get => portableKeysLoc; }
        public static string PortableFirmwareLoc { get => portablefirmwareLoc; }

        #endregion Public properties

        #region Private variables

        private static string ryuFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ryujinx";
        private static string ryuGamesLoc = ryuFolder + "\\games";
        private static string keysLoc = ryuFolder + "\\system";
        private static string firmwareLoc = ryuFolder + "\\bis\\system\\contents\\registered";
        private static string saveGameLoc = ryuFolder + "\\bis\\user\\save";

        //Variables for portable install of ryu
        private static string portableRyuFolder = string.Empty;

        private static string portableGamesLoc = string.Empty;
        private static string portableKeysLoc = string.Empty;
        private static string portablefirmwareLoc = string.Empty;
        private static string portableSaveGameLoc = string.Empty;

        #endregion Private variables

        public static void ChangePortablePath(string path)
        {
            portableRyuFolder = path;
            portableGamesLoc = path + "\\games";
            portableKeysLoc = path + "\\system";
            portablefirmwareLoc = path + "\\bis\\system\\contents\\registered";
            portableSaveGameLoc = path + "\\bis\\user\\save";
        }

        #region Games related

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
                    MessageBox.Show("Selected portable path doesn't contain Ryujinx related files!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!Directory.Exists(ryuGamesLoc))
                {
                    MessageBox.Show("Could not load Ryujinx, " +
                        "please make sure that you ran Ryujinx before or if you have a portable Version, " +
                        "set the Path of it in the Setting.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

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

        public static string GetSavePath(string gameID)
        {
            string dir = string.Empty;

            if (PortableRyujinx)
            {
                dir = portableSaveGameLoc;
            }
            else
            {
                dir = saveGameLoc;
            }

            string[] files = new string[] { };
            try
            {
                files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception)
            {
                Networking.ShowNotification("Could not get the saves, make sure that you played the game before!", Wpf.Ui.Common.SymbolRegular.ErrorCircle24);
            }

            List<string> gameIds = new List<string>();
            List<string> gameSavePaths = new List<string>();
            foreach (var file in files)
            {
                if (file.Contains("ExtraData0"))
                {
                    gameIds.Add(ReadSaveGameID(file));
                    gameSavePaths.Add(file);
                }
            }

            for (int i = 0; i < gameIds.Count; i++)
            {
                string gameid = gameIds[i];
                if (gameid == gameID)
                {
                    return gameSavePaths[i].Replace("\\ExtraData0", "");
                }
            }

            return null;
        }

        private static string ReadSaveGameID(string path)
        {
            byte[] readText = System.IO.File.ReadAllBytes(path).Take(8).ToArray();

            string hex = BitConverter.ToString(readText);
            string result = string.Empty;

            string[] numbers = Reverse(hex).Split('-');
            foreach (var item in numbers)
            {
                item.Remove(0, 1);
                result += Reverse(item);
            }

            return result;
        }

        #endregion Games related

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}