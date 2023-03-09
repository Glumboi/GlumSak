using EmuSak_Revive.Emulators;
using System.IO;
using EmuSak_Revive.Network;
using System.Threading.Tasks;
using System.Threading;

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

            var files = di.GetFiles();
            for (var index = 0; index < files.Length; index++)
            {
                var file = files[index];
                file.Delete();
            }

            var dirs = di.GetDirectories();
            for (var index = 0; index < dirs.Length; index++)
            {
                var dir = dirs[index];
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

            Task.Run(() => { RunRyuDownloadAsync(fileName, portable ? portableFirmwareLoc : firmwareLoc, url); });
        }

        private static void RyuFirmwareExtraction(string path)
        {
            var files = Directory.GetFiles(path);

            for (var index = 0; index < files.Length; index++)
            {
                var file = files[index];
                var dirName = file;
                var splitted = file.Split('\\');

                for (var i = 0; i < splitted.Length; i++)
                {
                    var fileName = splitted[i];
                    if (fileName.Contains(".nca"))
                    {
                        File.Move(file, path + "\\" + "\\00");
                        Directory.CreateDirectory(path + "\\" + fileName);
                        File.Move(path + "\\00", path + "\\" + fileName + "\\00");
                    }
                }
            }
        }

        private static async void RunRyuDownloadAsync(string fileName, string destination, string url)
        {
            Networking.DownloadAFileFromServer(url, fileName, destination);
            while (!Networking.DownloadDone)
            {
                await Task.Delay(1500);
            }
            UninstallOldFirmware(destination);
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