using System.IO;
using System.IO.Compression;
using EmuSak_Revive.Network;
using EmuSak_Revive.Emulators;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace EmuSak_Revive.EmuFiles
{
    public class EmuKeys
    {
        public Form DownloadFinishedForm{ get; private set; }

        private static string keysUrl = @"https://drive.google.com/file/d/1bN9tg5HbfTCKPXAJaJmDdwP-XJsoMxjX/view?usp=sharing";
        private static string keysServerUrl = @"https://phoebe.feralhosting.com/carltschober/links/GlussySac/Keys_Switch/SwitchKeys.zip";
        public static void InstallYuzuKeys()
        {
            var temp = Path.GetTempPath();
            var filePath = temp + "tempKeys.Sak";

            if (File.Exists(filePath))
            {
                if(Yuzu.PortableYuzu)
                {
                    Networking.Unzip(filePath, Yuzu.PortableKeysLoc, false);
                    Networking.ShowDownloadDone("Installed keys from temp folder successfully to: \n" 
                        + Yuzu.PortableKeysLoc + ".", "Info");
                }
                else
                {
                    Networking.Unzip(filePath, Yuzu.KeysLoc, false);
                    Networking.ShowDownloadDone("Installed keys from temp folder successfully to: \n"
                        + Yuzu.KeysLoc + ".", "Info");
                }
            }
            else if(Yuzu.PortableYuzu)
            {
                Thread thread = new Thread(() => DownloadAndUnzipKeys(filePath, Yuzu.PortableKeysLoc));
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(() => DownloadAndUnzipKeys(filePath, Yuzu.KeysLoc));
                thread.Start();
            }
        }

        private static void DownloadAndUnzipKeys(string filePath, string destination)
        {
            Networking.DownloadAFileFromServer(keysServerUrl, filePath, destination, true, false, false);
        }
        
        public static void InstallRyuKeys()
        {
            var temp = Path.GetTempPath();
            var filePath = temp + "tempKeys.Sak";

            if (File.Exists(filePath))
            {
                if (Ryujinx.PortableRyujinx)
                {
                    Networking.Unzip(filePath, Ryujinx.PortableKeysLoc, false);
                    Networking.ShowDownloadDone("Installed keys from temp folder successfully to: \n"
                        + Ryujinx.PortableKeysLoc + ".", "Info");
                }
                else
                {
                    Networking.Unzip(filePath, Ryujinx.KeysLoc, false);
                    Networking.ShowDownloadDone("Installed keys from temp folder successfully to: \n"
                        + Ryujinx.KeysLoc + ".", "Info");
                }
            }
            else if (Ryujinx.PortableRyujinx)
            {
                Thread thread = new Thread(() => DownloadAndUnzipKeys(filePath, Ryujinx.PortableKeysLoc));
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(() => DownloadAndUnzipKeys(filePath, Ryujinx.KeysLoc));
                thread.Start();
            }
        }
    }
}
