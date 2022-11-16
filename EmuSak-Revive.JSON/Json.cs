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
using Python.Runtime;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace EmuSak_Revive.JSON
{
    public class Json
    {
        /// <summary>
        /// Creates a file with all nsuids of the games in the titledb in this format:
        ///         000000000
        ///         000000001
        ///         000000002
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private static List<string> CreateNsuIdsFile(string URL)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(URL);
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            List<string> result = new List<string>();

            foreach (string line in content.Split(new[] { '\n' }))
            {
                if (line.Contains("\"nsuId\": 700"))
                {
                    //nsuId
                    var str = string.Join("", line.Split(',', ':', '\"', 'n', 's', 'u', 'I', 'd')); //Splits the nsuid by chars that we dont want
                    result.Add(str);

                }
            }
            if (!File.Exists("./Python/nsuIds.txt"))
            {
                File.Create("./Python/nsuIds.txt").Close();
            }
            File.WriteAllLines("./Python/nsuIds.txt", result);

            return result;
        }

        public static void Run(string URL)
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
