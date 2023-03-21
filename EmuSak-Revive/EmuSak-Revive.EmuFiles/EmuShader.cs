using EmuSak_Revive.Emulators;
using EmuSak_Revive.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuSak_Revive.EmuFiles
{
    public static class EmuShader
    {
        public static List<string> RyuGameShaderLocations { get => Ryujinx.GamesShader; }
        private static string lastCheckedGame = string.Empty;

        public static void InstallShader(int config, string url, string gameId)
        {
            if (config == 0)
            {
                Networking.ShowNotification("Yuzu is not supported currently!");
                //InstallYuzuShader(url);
            }

            if (config == 1)
            {
                InstallRyujinxShader(url, gameId);
            }
        }

        private static bool IsGameIDEqualToShader(string gameID)
        {
            for (var index = 0; index < RyuGameShaderLocations.Count; index++)
            {
                var str = RyuGameShaderLocations[index];
                if (str.ToUpper().Contains(gameID))
                {
                    lastCheckedGame = str;
                    return true;
                }
            }
            return false;
        }

        private static void InstallRyujinxShader(string url, string gameID)
        {
            string fileName = Temporary.TempPath + $"tempShader_{gameID}.Sak";

            if (IsGameIDEqualToShader(gameID))
            {
                Task.Run(() => { Networking.DownloadAFileFromServer(url, fileName, lastCheckedGame); });
            }
        }

        /// <summary>
        /// This only supports Ryujinx, same as the shader installation
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns></returns>
        public static string GetShaderCount(string gameID)
        {
            bool match = IsGameIDEqualToShader(gameID);
            string tocPath = $"{lastCheckedGame}\\shared.toc";

            if (match && File.Exists(tocPath))
            {
                FileInfo rileInfo = new FileInfo(tocPath);
                long fileSize = rileInfo.Length;
                long shaderCount = Math.Max(+((fileSize - 32) / 8), 0);

                return shaderCount.ToString();
            }

            return "0";
        }

        //Not developed yet and maybe not going to be developed at all
        private static void InstallYuzuShader(string url)
        {
        }
    }
}