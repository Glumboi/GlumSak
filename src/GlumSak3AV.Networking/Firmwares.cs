using System.Text.RegularExpressions;

namespace GlumSak3AV.Networking;

public class Firmwares
{
    /// <summary>
    /// Parses the given archive.org link with the firmwares and slpits the returned url and returns the result
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public static string GetFirmwareDownload(string version)
    {
        return Parsing.ParseLinks("https://archive.org/download/nintendo-switch-global-firmwares")
                   [0].Split(new char[] { '#' })[0]
               + "/Firmware%20" + version.Split(new char[] { ' ' })[1]
               + ".zip";
    }

    /// <summary>
    /// This gets all firmwares from a archive.org site
    /// </summary>
    /// <returns></returns>
    public static List<string> GetFirmwareVersions()
    {
        List<string> linksToVisit =
            Parsing.ParseLinks(@"https://archive.org/download/nintendo-switch-global-firmwares");
        List<string> rtrnList = new List<string>();

        foreach (var item in linksToVisit)
        {
            var splitted = item.Split(new string[] { ".zip" }, StringSplitOptions.None);
            var firmwareVersions = splitted[0].Split('/');
            //var sorted = NaturalSort(firmwareVersions).ToArray(); => Disabled for testing purposes
            foreach (var version in firmwareVersions)
            {
                if (version.Contains("Firmware") && !version.Contains("%") && !version.Contains("MD5"))
                {
                    var itemToAdd = version.Split(new string[] { "Firmware" }, StringSplitOptions.None)[1];
                    rtrnList.Add(itemToAdd);
                }
            }
        }

        return rtrnList.Distinct().OrderByDescending(VersionSorter.OrderVersion).ToList();
    }

    public static IEnumerable<string> NaturalSort(IEnumerable<string> list)
    {
        int maxLen = list.Select(s => s.Length).Max();
        Func<string, char> PaddingChar = s => char.IsDigit(s[0]) ? ' ' : char.MaxValue;

        return list
            .Select(s =>
                new
                {
                    OrgStr = s,
                    SortStr = Regex.Replace(s, @"(\d+)|(\D+)", m => m.Value.PadLeft(maxLen, PaddingChar(m.Value)))
                })
            .OrderBy(x => x.SortStr)
            .Select(x => x.OrgStr);
    }
}

internal class VersionSorter
{
    public static IComparable OrderVersion(string arg)
    {
        //Treat N/A as highest version
        return arg == "N/A" ? new Version(Int32.MaxValue, Int32.MaxValue) : Version.Parse(arg);
    }
}