using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Avalonia.Platform;
using GlumSak3AV.Settings;
using Newtonsoft.Json;

namespace GlumSak3AV.Switch;

public class EshopAPI
{
    //TODO: Implement better way of updating at runtime
    private static string jsonUrl = "https://raw.githubusercontent.com/blawar/titledb/master/US.en.json";

    private const string nsuIdFile = "./Json/nsuIds.txt";
    private const string databseFile = "./Json/gameIcons_Ids.txt";
    private static string[] nsuIds = new string[] { };
    private static string response = string.Empty;

    public static void SetupGameMeta()
    {
        //TODO: Improve how settings are loaded, as a whole in general as well

        if (!Directory.Exists("./Json"))
        {
            Directory.CreateDirectory("./Json");
        }

        jsonUrl = SettingsFactory.Settings.Value.switchGameDatabaseCrawl;
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

    public static GameData? GetGameFromDatabaseByID(string gameId)
    {
        if (!File.Exists(databseFile))
        {
            SetupGameMeta();
        }

        var lines = File.ReadLines(databseFile);

        foreach (string line in lines)
        {
            if (line.Contains(gameId))
            {
                var span = line.AsSpan();
                int start = 0;
                string[] parts = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    int end = span.Slice(start).IndexOf('|');
                    if (end == -1) end = span.Length - start; // For the last part
                    ReadOnlySpan<char> part = span.Slice(start, end).Trim().Trim('\"'); // Remove spaces and quotes
                    start += end + 1; // Move to the next part
                    parts[i] = part.ToString(); // Store the string value
                }

                string url = parts[0];
                string id = parts[1];
                string title = parts[2];

                return new GameData
                {
                    iconUrl = url,
                    id = id,
                    name = title
                };
            }
        }

        return null;
    }
}

public class GameData
{
    public string iconUrl { get; set; }
    public string id { get; set; }
    public string name { get; set; }
}