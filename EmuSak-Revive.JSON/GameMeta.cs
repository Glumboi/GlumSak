using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmuSak_Revive.JSON
{
    public static class GameMeta
    {
        private static string url = "https://raw.githubusercontent.com/blawar/titledb/master/US.en.json";
        private static string nsuIdFile = "./Json/nsuIds.txt";
        private static string[] nsuIds = new string[] { };
        private static string response = string.Empty;

        public static void DownloadGameMeta()
        {
            using (HttpClient client = new HttpClient())
            {
                nsuIds = File.ReadLines(nsuIdFile).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                response = client.GetStringAsync(url).Result;
                Dictionary<string, GameData> data = JsonConvert.DeserializeObject<Dictionary<string, GameData>>(response);
                GetAll(data);
            }
        }

        private static void GetAll(Dictionary<string, GameData> data)
        {
            ConcurrentQueue<string> lines = new ConcurrentQueue<string>();

            Parallel.ForEach(nsuIds, fileLine =>
            {
                if (data.ContainsKey(fileLine))
                {
                    GameData gameData = data[fileLine];
                    string line = JsonConvert.SerializeObject(gameData.iconUrl, Newtonsoft.Json.Formatting.Indented) + " | " +
                                   JsonConvert.SerializeObject(gameData.id, Newtonsoft.Json.Formatting.Indented) + " | " +
                                   JsonConvert.SerializeObject(gameData.name, Newtonsoft.Json.Formatting.Indented);
                    lines.Enqueue(line);
                }
            });

            File.WriteAllText("./Json/gameIcons_Ids.txt", string.Join(Environment.NewLine, lines));
        }

        private class GameData
        {
            public string iconUrl { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }
    }
}