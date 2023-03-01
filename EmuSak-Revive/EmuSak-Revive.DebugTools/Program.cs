using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.JSON;

namespace EmuSak_Revive.DebugTools
{
    internal class Program
    {
        private static List<string> LoadGames(int config)
        {
            List<string> result = new List<string>();
            List<string> fileLines =
                File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Python/gameIcons_Ids.txt").ToList();

            for (int i = 0; i < fileLines.Count; i++)
            {
                string line = fileLines[i];
                if (!line.Contains("null"))
                {
                    string fileGameID = line.Split('\"')[3];
                    string icon = line.Split('\"')[1];
                    string gameId = fileGameID.Split('|')[0];
                    string gameNameRaw = line.Split('\"')[5];
                    string[] gameNameSplitted = new string[] { };
                    string gameName = string.Empty;

                    if (gameNameRaw.Contains(@"\u2122"))
                    {
                        gameNameSplitted = gameNameRaw.Split(new string[] { @"\u2122" }, StringSplitOptions.None);
                    }

                    //This whole branch is intended to clean up pokemon game titles
                    if (gameNameRaw.Contains(@"Pok\u00e9mon"))
                    {
                        string[] pokemon = gameNameRaw.Split(new string[] { @"Pok\u00e9mon\u2122" },
                            StringSplitOptions.None);
                        string pokemonNew = "Pokémon";

                        if (gameNameRaw.Contains(@"Let\u2019s"))
                        {
                            string[] lets = gameNameRaw.Split(new string[] { @"Let\u2019s" }, StringSplitOptions.None);
                            string letsNew = "Let's";
                            gameName = pokemonNew + letsNew + lets[1];
                        }
                        else if (gameNameRaw.Contains(@"\u2122"))
                        {
                            var pokeSplitted = gameNameRaw.Split(new string[] { @"\u2122" }, StringSplitOptions.None);
                            gameName = pokemonNew + pokeSplitted[1];
                        }
                        else
                        {
                            gameName = pokemonNew + pokemon.Last();
                        }
                    }

                    if (gameNameSplitted.Length > 0 && !gameNameSplitted.Contains("Pok\\u00e9mon"))
                    {
                        gameName = gameNameSplitted[0] + gameNameSplitted[1];
                    }
                    else
                    {
                        if (!gameName.Contains("Pokémon"))
                            gameName = gameNameRaw;
                    }

                    bool condition = false;
                    if (config == 0)
                    {
                        condition = Yuzu.Games.Contains(gameId);
                    }

                    if (config == 1)
                    {
                        condition = Ryujinx.Games.Contains(gameId);
                    }

                    if (condition)
                    {
                        result.Add(gameName);
                    }
                }
            }

            return result;
        }

        private static void PrintGames(string arg)
        {
            if (arg == "--getGames_0")
            {
                Console.WriteLine("Games: ");
                Yuzu.GetGames();
                Json.Run(@"https://raw.githubusercontent.com/blawar/titledb/master/US.en.json");
                var games = LoadGames(0);

                foreach (var str in games)
                {
                    Console.WriteLine(str);
                }
            }

            if (arg == "--getGames_1")
            {
                Console.WriteLine("Games: ");
                Ryujinx.GetGames();
                Json.Run(@"https://raw.githubusercontent.com/blawar/titledb/master/US.en.json");
                var games = LoadGames(1);

                foreach (var str in games)
                {
                    Console.WriteLine(str);
                }
            }
        }

        public static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (arg.Contains("--getGames"))
                {
                    PrintGames(arg);
                }
            }

            Console.ReadKey();
        }
    }
}