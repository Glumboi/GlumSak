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
                Networking.ShowNotification("Yuzu is not supported currently!");
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

            for (var index = 0; index < shadersLoc.Count; index++)
            {
                var str = shadersLoc[index];
                if (str.ToUpper().Contains(gameId))
                {
                    Task.Run(() => { Networking.DownloadAFileFromServer(url, fileName, str); });
                }
            }

            //Network.GDriveDownloader downloader = new Network.GDriveDownloader();
            //downloader.DownloadFile(url, fileName);
        }

        //Not developed yet
        private static void InstallYuzuShader(string url)
        {
        }
    }
}