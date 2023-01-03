using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace EmuSak_Revive.JSON
{
    public class Json
    {
        private static List<string> CreateNsuIdsFile(string URL)
        {
            Regex nsuIdRegex = new Regex(@"""nsuId"": (\d+)");

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(URL))
            using (StreamReader reader = new StreamReader(stream))
            {
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var match = nsuIdRegex.Match(line);
                    if (match.Success)
                    {
                        sb.AppendLine(match.Groups[1].Value);
                    }
                }

                File.WriteAllLines("./Python/nsuIds.txt", sb.ToString().Split('\n'));

                return sb.ToString().Split('\n').Select(x => x.TrimEnd('\r')).ToList();
            }
        }

        public static async void Run(string URL)
        {
            CreateNsuIdsFile(URL);

            RunJsonPython();
        }

        private static void RunJsonPython() //Starts our Json.exe which gathers json info from a titledb
        {
            RunBat();
        }

        private static void RunBat() //Used to run the launch.bat file
                                     //(normal process on the py exe will cause an exception)
        {
            Process p = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "Python/launch.bat";
            p.StartInfo = processStartInfo;
            p.Start();
            p.WaitForExit();
        }
    }
}