using EmuSak_Revive.Emulators;
using System.IO;
using EmuSak_Revive.Network;
using System.Threading.Tasks;

namespace EmuSak_Revive.EmuFiles
{
    public static class EmuFirmware
    {
        public static void InstallFirmware(int config, string url)
        {
            if (config == 0)
            {
                InstallYuzuFirmware(url);
            }

            if (config == 1)
            {
                InstallRyujinxFirmware(url);
            }
        }

        private static void UninstallOldFirmware(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private static void InstallRyujinxFirmware(string url)
        {
            var firmwareLoc = Ryujinx.FirmwareLoc;
            var portableFirmwareLoc = Ryujinx.PortableFirmwareLoc;
            var fileName = Temporary.TempPath + $"tempFirmware.Sak";
            bool portable = Ryujinx.PortableRyujinx;

            //Network.GDriveDownloader downloader = new Network.GDriveDownloader();
            //downloader.DownloadFile(url, fileName);

            Task.Run(() =>
            {
                if (portable)
                {
                    RunRyuDownloadAsync(fileName, portableFirmwareLoc, url);
                }
                else
                {
                    RunRyuDownloadAsync(fileName, firmwareLoc, url);
                }
            });
        }

        private static void RyuFirmwareExtraction(string path)
        {
            var files = Directory.GetFiles(path);

            foreach(string file in files)
            {
                var dirName = file;
                var splitted = file.Split('\\');

                foreach(string fileName in splitted)
                {
                    if(fileName.Contains(".nca"))
                    {
                        File.Move(file, path + "\\" + "\\00");
                        Directory.CreateDirectory(path + "\\" + fileName);
                        File.Move(path + "\\00", path + "\\" + fileName + "\\00");
                    }
                }
            }
        }

        private static void RunRyuDownloadAsync(string fileName, string destination, string url)
        {
            UninstallOldFirmware(destination);
            Networking.DownloadAFileFromServer(url, fileName, destination);
            while(!Networking.DownloadDone)
            {
            }
            RyuFirmwareExtraction(destination);
        }

        private static void InstallYuzuFirmware(string url)
        {
            var firmwareLoc = Yuzu.FirmwareLoc;
            var fileName = Temporary.TempPath + $"tempFirmware.Sak";

            //Network.GDriveDownloader downloader = new Network.GDriveDownloader();
            //downloader.DownloadFile(url, fileName);

            Task.Run(() =>
            {
                UninstallOldFirmware(firmwareLoc);
                Networking.DownloadAFileFromServer(url, fileName, firmwareLoc);
            });
        }
    }
}
