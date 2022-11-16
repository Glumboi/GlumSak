using System;
using System.IO;

namespace EmuSak_Revive.EmuFiles
{
    public static class Temporary
    {
        public static string TempPath{ get => Path.GetTempPath(); }

        public static void DeleteTemporaryFiles()
        { 
            var tempLoc = Environment.GetEnvironmentVariable("temp");
            var files = Directory.GetFiles(tempLoc);

            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (file.Contains("Sak"))
                {
                    File.Delete(file);
                }
            }
        }

    }
}
