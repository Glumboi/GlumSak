using EmuSak_Revive.ConfigIni.Core;
using EmuSak_Revive.Network;
using Glumboi.UI.Toast;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmuSak_Revive.Emulators
{
    public static class Yuzu
    {
        #region Public properties

        private static List<string> games = new List<string>();

        public static List<string> YuzuEAVersions { get => versionsList; }
        public static List<string> YuzuEAVersionsLinks { get => versionLinks; }

        public static List<string> Games
        {
            get { return games; }
            set { games = value; }
        }

        public static string SaveRoot
        {
            get
            {
                return PortableYuzu ? portableSavesLoc : savesLoc;
            }
        }

        public static string DefaultBaseLoc { get => defaultBaseLoc; }
        public static string KeysLoc { get => keysLoc; }
        public static string PortableKeysLoc { get => portableKeysLoc; }
        public static string CustomNandLoc { get => customNandLoc; }
        public static string FirmwareLoc { get => firmwareLoc; }
        public static string PortableYuzuPath { get => portableYuzuPath; }
        public static bool PortableYuzu { get => !string.IsNullOrWhiteSpace(portableYuzuPath); }

        #endregion Public properties

        #region Private variables

        private static string portableYuzuPath = string.Empty;
        private static string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private static string defaultBaseLoc = roaming + "\\yuzu";
        private static string gamesLoc = roaming + "\\yuzu\\cache\\game_list";
        private static string keysLoc = roaming + "\\yuzu\\keys";
        private static string shadersLoc = roaming + "\\yuzu\\shader";
        private static string configIni = roaming + "\\yuzu\\config\\qt-config.ini";
        private static string savesLoc = roaming + "\\yuzu\\nand\\user\\save\\0000000000000000";

        private static string portableGamesLoc;//portableYuzuPath + "\\cache\\game_list";
        private static string portableKeysLoc;// portableYuzuPath + "\\keys";
        private static string portableConfigIni;// portableYuzuPath + "\\config\\qt-config.ini";
        private static string portableShadersLoc;// portableYuzuPath + "\\yuzu\\shader";
        private static string portableSavesLoc;// portableYuzuPath + "\\nand\\user\\save";

        private static string customNandLoc = string.Empty;
        private static string firmwareLoc = string.Empty;

        private static List<string> versionsList = new List<string>();
        private static List<string> versionLinks = new List<string>();
        private static List<string> saveGameDirectories = new List<string>();

        #endregion Private variables

        public static void ChangePortablePath(string path)
        {
            portableYuzuPath = path;
            portableGamesLoc = path + "\\cache\\game_list";
            portableKeysLoc = path + "\\keys";
            portableConfigIni = path + "\\config\\qt-config.ini";
            portableShadersLoc = path + "\\shader";
            portableSavesLoc = path + "\\nand\\user\\save\\0000000000000000";
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
                if (!Directory.Exists(gamesLoc))
                {
                    ToastHandler.ShowToast("Could not load Yuzu, " +
                        "please make sure that you ran Yuzu before or if you have a portable Version, " +
                        "set the Path of it in the Setting.",
                        "Info");

                    return;
                }

                subdirs = Directory.GetDirectories(gamesLoc);
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
            string configIniPath = string.IsNullOrWhiteSpace(PortableYuzuPath) ? configIni : portableConfigIni;

            IniParser iniParser = new IniParser(configIniPath);

            customNandLoc = iniParser.GetSetting("Data%20Storage", "nand_directory");

            if (customNandLoc == null) return;

            if (customNandLoc.Contains(@"\\"))
            {
                var forwardLoc = customNandLoc.Replace(@"\\", @"/");
                firmwareLoc = forwardLoc + "/system/Contents/registered";
                return;
            }

            firmwareLoc = customNandLoc + "system/Contents/registered";
        }

        #region Yuzu updater

        public static void GetYuzuEABuilds()
        {
            List<string> linksToVisit = Networking.ParseLinks(@"https://pineappleea.github.io/");

            foreach (var item in linksToVisit)
            {
                if (item.Contains("EA-") && versionsList.Count < 30) //Limit to 30 since more than that is
                                                                     //useless and not shown by default with
                                                                     //the Github API
                {
                    versionsList.Add(item.Split('/').Last());
                    versionLinks.Add(item);
                }
            }
        }

        public static string GetYuzuEADDL(string version)
        {
            var links = Networking.GetAllLinksFromGithubReleases(version);

            foreach (var link in links)
            {
                if (link.Contains(".zip") || link.Contains(".7z"))
                {
                    return link;
                }
            }

            return string.Empty;
        }

        public static string GetYuzuBinaryVersion(string path)
        {
            try
            {
                string exe = "yuzu.exe";
                string fullExePath = Path.Combine(path, exe);

                Process exeProcess = Process.Start(fullExePath);

                while (string.IsNullOrEmpty(exeProcess.MainWindowTitle))
                {
                    Thread.Sleep(100);
                    exeProcess.Refresh();
                }

                exeProcess.Kill();

                return "EA-" + exeProcess.MainWindowTitle.Split(' ').Last();
            }
            catch (Exception)
            {
                Networking.ShowNotification("Could not check for yuzu updates, did you select a valid yuzu folder?", Wpf.Ui.Common.SymbolRegular.ErrorCircle24);

                return string.Empty;
            }
        }

        public static bool IsLocalYuzuOutdated(string localVer, string newestWeb)
        {
            int localVerNum = Int32.Parse(localVer.Split('-').Last());
            int webVerNum = Int32.Parse(newestWeb.Split('-').Last());

            return localVerNum < webVerNum ? true : false;
        }

        #endregion Yuzu updater

        #region Save manager related

        public static int GetUserCount()
        {
            List<string> dirs = new List<string>();

            if (PortableYuzu)
            {
                dirs = Directory.GetDirectories(portableSavesLoc).ToList();
            }
            else
            {
                dirs = Directory.GetDirectories(savesLoc).ToList();
            }

            dirs.Remove(dirs[0]);

            saveGameDirectories = dirs;

            return dirs.Count;
        }

        public static List<string> GetGameSavePaths(string gameID)
        {
            List<string> res = new List<string>();

            foreach (string item in saveGameDirectories)
            {
                var dir = item + "\\" + gameID;

                if (Directory.Exists(dir))
                {
                    res.Add(dir);
                }
            }

            return res;
        }

        #endregion Save manager related
    }
}