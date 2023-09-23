using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace GlumSak3AV.Switch;

public class EshopAPI
{
    const string jsonUrl = "https://raw.githubusercontent.com/blawar/titledb/master/US.en.json";
    private const string nsuIdFile = "./Json/nsuIds.txt";
    private static string[] nsuIds = new string[] { };
    private static string response = string.Empty;

    public static void SetupGameMeta()
    {
        CreateNSUIDsFile(jsonUrl);
        DonwloadGameMeta();
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
    
    private static void DonwloadGameMeta()
    {
        using (HttpClient client = new HttpClient())
        {
            nsuIds = File.ReadLines(nsuIdFile).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            response = client.GetStringAsync(jsonUrl).Result;
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
                string line = JsonConvert.SerializeObject(gameData.iconUrl, Newtonsoft.Json.Formatting.Indented) +
                              " | " +
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