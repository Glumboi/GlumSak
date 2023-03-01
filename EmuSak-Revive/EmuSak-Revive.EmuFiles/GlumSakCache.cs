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
        public static List<Image> GameImgs { get => _gameImgs; }
        public static List<string> GameNames { get => _gameNames; }
        public static List<string> GameIds { get => _gameIds; }
        public static string EmuConfig { get; private set; }

        private static List<Image> _gameImgs = new List<Image>();
        private static List<string> _gameNames = new List<string>();
        private static List<string> _gameIds = new List<string>();

        private static string tempPath = Temporary.TempPath;
        private static string metaPath = Temporary.TempPath + "glumCacheMeta.glumMeta";

        public static void CreateGlumSakCache(
            List<Image> imgs,
            List<string> imgNames,
            List<string> gameIds,
            int config)
        {
            CreateCacheMetaData();

            for (int i = 0; i < imgs.Count; i++)
            {
                Image img = imgs[i];

                var saveString = tempPath + i + ".glumImg";

                if (File.Exists(saveString)) //Delete image if exists
                    File.Delete(saveString);

                img.Save(saveString);
                WriteToMetaData(saveString + ",", "w");
            }

            WriteToMetaData("", "wl");

            for (int i = 0; i < gameIds.Count; i++)
            {
                WriteToMetaData(gameIds[i] + ",", "w");
            }

            WriteToMetaData("", "wl");

            for (int i = 0; i < imgNames.Count; i++)
            {
                WriteToMetaData(imgNames[i] + ",", "w");
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

        public static void GetCacheContent()
        {
            var content = File.ReadAllLines(metaPath);

            List<string> imgPaths = new List<string>();
            List<string> gameNames = new List<string>();
            List<string> gameIds = new List<string>();

            foreach (string line in content)
            {
                if (line == content[0])
                {
                    var imgs = line.Split(',');
                    for (int i = 0; i < imgs.Length; i++)
                    {
                        imgPaths.Add(imgs[i]);
                    }
                }

                if (line == content[1])
                {
                    var names = line.Split(',');
                    for (int i = 0; i < names.Length; i++)
                    {
                        gameNames.Add(names[i]);
                    }
                }

                if (line == content[2])
                {
                    var ids = line.Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        gameIds.Add(ids[i]);
                    }
                }

                if (line == content[3])
                {
                    EmuConfig = line.Split('=').Last().Split(',').First();
                }
            }

            //Removes empty strings from lists
            imgPaths.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            gameIds.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            gameNames.RemoveAll(s => string.IsNullOrWhiteSpace(s));

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