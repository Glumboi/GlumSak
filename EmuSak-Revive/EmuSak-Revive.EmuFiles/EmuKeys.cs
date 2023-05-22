using System.IO;
using System.IO.Compression;
using EmuSak_Revive.Network;
using EmuSak_Revive.Emulators;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using Glumboi.UI.Toast;

namespace EmuSak_Revive.EmuFiles
{
    public class EmuKeys
    {
        private static string keysServerUrl = Networking.GetShaderDownload("titlekeys");

        private static void RunDownLoad(string filePath, string destination)
        {
            Networking.DownloadAFileFromServer(keysServerUrl, filePath, destination, true, false, false);
        }

        private static void DownLoadKeys(string path, string keysLoc)
        {
            if (File.Exists(path))
            {
                Networking.Unzip(path, keysLoc, false);
                Networking.ShowNotification("Installed keys from temp folder successfully to: \n"
                + keysLoc + ".");
                return;
            }

            RunDownLoad(path, keysLoc);
        }

        public static void InstallKeys(int config, bool portable)
        {
            keysServerUrl = Networking.GetShaderDownload("titlekeys");
            var temp = Path.GetTempPath();
            var filePath = temp + "tempKeys.Sak";

            //try
            //{
                switch (config)
                {
                    case 0 when portable:
                        DownLoadKeys(filePath, Yuzu.PortableKeysLoc);
                        break;

                    case 0 when !portable:
                        DownLoadKeys(filePath, Yuzu.KeysLoc);
                        break;

                    case 1 when portable:
                        DownLoadKeys(filePath, Ryujinx.PortableKeysLoc);
                        break;

                    case 1 when !portable:
                        DownLoadKeys(filePath, Ryujinx.KeysLoc);
                        break;
                }
            //}
            /*catch (System.Exception)
            {
                Networking.ShowNotification("Could not install keys, make sure your paste is right!", Wpf.Ui.Common.SymbolRegular.ErrorCircle24);
            }*/
        }
    }
}