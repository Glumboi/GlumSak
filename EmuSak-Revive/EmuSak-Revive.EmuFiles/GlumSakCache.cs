using EmuSak_Revive.Emulators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.EmuFiles
{
    public static class GlumSakCache
    {
        #region Properties

        public static List<Image> GameImgs { get => _gameImgs; }
        public static List<string> GameNames { get => _gameNames; }
        public static List<string> GameIds { get => _gameIds; }
        public static string EmuConfig { get; private set; }

        #endregion Properties

        #region Variables

        private static List<Image> _gameImgs = new List<Image>();
        private static List<string> _gameNames = new List<string>();
        private static List<string> _gameIds = new List<string>();

        private static string tempPath = Temporary.TempPath;
        private static string metaPath = Temporary.TempPath + "glumCacheMeta.glumMeta";

        #endregion Variables

        public static void CreateGlumSakCache(List<SwitchGame> switchGames, int config)
        {
            CreateCacheMetaData();

            for (int i = 0; i < switchGames.Count; i++)
            {
                Image img = switchGames[i].GameImage;

                var saveString = tempPath + i + ".glumImg";

                if (File.Exists(saveString)) //Delete image if exists
                    File.Delete(saveString);

                img.Save(saveString);
                WriteToMetaData(saveString + ",", "w");
            }

            WriteToMetaData("", "wl");

            for (int i = 0; i < switchGames.Count; i++)
            {
                WriteToMetaData(switchGames[i].GameID + ",", "w");
            }

            WriteToMetaData("", "wl");

            for (int i = 0; i < switchGames.Count; i++)
            {
                WriteToMetaData(switchGames[i].GameName + ",", "w");
            }

            WriteToMetaData("", "wl");

            if (config == 0)
            {
                WriteToMetaData("EmuConfig=Yuzu,", "w");
            }

            if (config == 1)
            {
                WriteToMetaData("EmuConfig=Ryujinx,", "w");
            }

            WriteToMetaData("", "wl");
        }

        public static bool CacheExists()
        {
            return File.Exists(metaPath);
        }

        private static void ReadContent(List<string> target, string line, string fileContent)
        {
            if (line == fileContent)
            {
                string[] tempLines = line.Split(',');
                for (int i = 0; i < tempLines.Length; i++)
                {
                    if (tempLines[i] != string.Empty)
                    {
                        target.Add(tempLines[i]);
                    }
                }
            }
        }

        public static void GetCacheContent()
        {
            string[] content = File.ReadAllLines(metaPath);

            List<string> imgPaths = new List<string>();
            List<string> gameNames = new List<string>();
            List<string> gameIds = new List<string>();

            foreach (string line in content)
            {
                ReadContent(imgPaths, line, content[0]);
                ReadContent(gameIds, line, content[1]);
                ReadContent(gameNames, line, content[2]);

                if (line == content[3])
                {
                    EmuConfig = line.Split('=').Last().Split(',').First();
                }
            }

            foreach (var imgPath in imgPaths) //gets the images from the meta file and converts them to Image
            {
                using (Stream bmpStrm = File.Open(imgPath, FileMode.Open)) //To make sure that the imgs can be deleted
                                                                           //at runtime
                {
                    Image img = Image.FromStream(bmpStrm);
                    var bmp = new Bitmap(img);
                    _gameImgs.Add(bmp);
                }
            }

            _gameNames = gameNames;
            _gameIds = gameIds;
        }

        private static void WriteToMetaData(string str, string writeMode)
        {
            using (StreamWriter sw = File.AppendText(metaPath))
            {
                if (writeMode == "w")
                {
                    sw.Write(str);
                }
                else if (writeMode == "wl")
                {
                    sw.WriteLine(str);
                }
                else
                {
                    throw new Exception($"\"{writeMode}\" is not a supported write mode!");
                }
            }
        }

        private static void CreateCacheMetaData()
        {
            if (!File.Exists(tempPath))
            {
                File.CreateText(metaPath).Close();
            }
            else if (File.Exists(metaPath) && string.IsNullOrWhiteSpace(File.ReadAllText(metaPath)))
            {
                File.CreateText(metaPath).Close();
            }
        }
    }
}