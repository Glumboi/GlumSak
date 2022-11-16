using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmuSak_Revive.ConfigIni
{
    class ConfigIni
    {
        static WebClient client = new WebClient();

        private static void DownloadIni()
        {
            /*if (await Connection.IsConnectedToInternetAsync())
            {
                Program.DebugConsole.Info(
                    $"Downloading newest config.ini from the webserver [{Properties.Settings.Default.ConfigFile}]");
                client.DownloadFileAsync(new Uri(Properties.Settings.Default.ConfigFile), "config.ini");
                return;
            }*/

            //Program.DebugConsole.Warn(
                //$"No internet connection, this could lead into some issues like the version checking throwing an error!");
        }

        private static IPAddress GetIpFromUrl(string URL)
        {
            Uri myUri = new Uri(URL);
            return Dns.GetHostAddresses(myUri.Host)[0];
        }

        //Get Config
        public static string GetConfig(string key, string config)
        {
            string value = "";
            string path = Assembly.GetExecutingAssembly().GetName().Name + "\\config.ini";
            if (File.Exists(path))
            {
                IniFile ini = new IniFile(path);
                value = ini.ReadString(config, key);
            }

            return value;
        }

        //Set Config
        public static void SetConfig(string key, string value, string config)
        {
            string path = Assembly.GetExecutingAssembly().GetName().Name + "\\config.ini";

            if(!File.Exists(path))
            {
                //Program.DebugConsole.Info("Couldn't find a config.ini, creating local ini...");

                IniFile ini = new IniFile(path);

                ini.WriteString("config", "WebConfig", "True");
            }

            if (File.Exists(path))
            {
                IniFile ini = new IniFile(path);
                ini.WriteString(config, key, value);
            }
        }

        //Create Config
        public void CreateConfig()
        {
            string _path = Assembly.GetExecutingAssembly().GetName().Name + "\\config.ini";
            if (!File.Exists(_path))
            {
                //Program.DebugConsole.Info("Couldn't find a config.ini, creating local ini...");

                IniFile ini = new IniFile(_path);

            }

            if (Core.ConfigVars.GetWebConfig())
            {
                Thread _t = new Thread(DownloadIni);

                _t.Start();

                while (_t.IsAlive) { }
            }
        }

        //Resets Config
        public void ResetConfig()
        {
            string _path = Assembly.GetExecutingAssembly().GetName().Name + "\\config.ini";
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            CreateConfig();
        }
    }
}
