using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Security.Policy;

namespace EmuSak_Revive.JSON
{
    public class Json
    {
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

        private static IEnumerable<string> GetNsuIDs(string URL)
        {
            Regex nsuIdRegex = new Regex(@"""nsuId"": (\d+)");

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(URL))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        yield break;
                    }

                    var match = nsuIdRegex.Match(line);
                    if (match.Success)
                    {
                        yield return match.Groups[1].Value;
                    }
                }
            }
        }

        private static void CreateNSUIDsFile(string URL)
        {
            using (FileStream fs = new FileStream("./Json/nsuIds.txt", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                foreach (var item in GetNsuIDs(URL))
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static void Run(string URL)
        {
            CreateNSUIDsFile(URL);
            GameMeta.DownloadGameMeta();
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