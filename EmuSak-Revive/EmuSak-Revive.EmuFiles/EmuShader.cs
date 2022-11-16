using EmuSak_Revive.Emulators;
using EmuSak_Revive.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.EmuFiles
{
    public static class EmuShader
    {
        public static void InstallShader(int config, string url, string gameId)
        {
            if (config == 0)
            {
                MessageBox.Show("Yuzu is not supported currently!", 
                    "Info", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                //InstallYuzuShader(url);
            }

            if (config == 1)
            {
                InstallRyujinxShader(url, gameId);
            }
        }

        private static void InstallRyujinxShader(string url, string gameId)
        {
            var shadersLoc = Ryujinx.GamesShader;
            var fileName = Temporary.TempPath + $"tempShader_{gameId}.Sak";

            foreach (string str in shadersLoc)
            {
                if (str.ToUpper().Contains(gameId))
                {
                    Task.Run(() =>
                    {
                        Networking.DownloadAFileFromServer(url, fileName, str);
                    });
                }
            }

            //Network.GDriveDownloader downloader = new Network.GDriveDownloader();
            //downloader.DownloadFile(url, fileName);

        }

        private static void InstallYuzuShader(string url)
        {
            var shadersLoc = Yuzu.FirmwareLoc;
            var fileName = Temporary.TempPath + $"tempFirmware.Sak";

            //Network.GDriveDownloader downloader = new Network.GDriveDownloader();
            //downloader.DownloadFile(url, fileName);

            Task.Run(() =>
            {
                Networking.DownloadAFileFromServer(url, fileName, shadersLoc);
            });
        }
    }
}
