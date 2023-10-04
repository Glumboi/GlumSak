using System.Text.RegularExpressions;

namespace GlumSak3AV.Networking;

public class Firmwares
{
    /// <summary>
    /// Parses the given archive.org link with the firmwares and slpits the returned url and returns the result
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public static string GetFirmwareDownload(List<string> urls, string version)
    {
        return urls[0].Split(new char[] { '#' })[0]
               + "/Firmware%20" + version.Split(new char[] { ' ' })[1]
               + ".zip";
    }

    /// <summary>
    /// This gets all firmwares from a archive.org site
    /// </summary>
    /// <returns></returns>
    public static List<SwitchFirmware> GetFirmwareVersions()
    {
        List<string> linksToVisit =
            Parsing.ParseLinks(@"https://archive.org/download/nintendo-switch-global-firmwares");
        List<SwitchFirmware> rtrnList = new List<SwitchFirmware>();

        foreach (var link in linksToVisit)
        {
            string firmwareVersion = ExtractFirmwareVersion(link);
            if (!string.IsNullOrEmpty(firmwareVersion))
            {
                string downloadUrl = GetFirmwareDownload(linksToVisit, firmwareVersion);
                rtrnList.Add(new SwitchFirmware(firmwareVersion, downloadUrl));
            }
        }

        rtrnList.Sort((x, y) => VersionSorter.OrderVersion(y.Version).CompareTo(VersionSorter.OrderVersion(x.Version)));

        return rtrnList;
    }

    private static string ExtractFirmwareVersion(string link)
    {
        string[] splitted = link.Split(new string[] { ".zip" }, StringSplitOptions.None);
        string[] firmwareVersions = splitted[0].Split('/');

        foreach (var version in firmwareVersions)
        {
            if (version.Contains("Firmware") && !version.Contains("%") && !version.Contains("MD5"))
            {
                string itemToAdd = version.Split(new string[] { "Firmware" }, StringSplitOptions.None)[1];
                return itemToAdd;
            }
        }

        return null;
    }
}

public struct SwitchFirmware
{
    private string _version;

    public string Version
    {
        get => _version;
        set => _version = value;
    }

    private string _zipURL;

    public string ZipURL
    {
        get => _zipURL;
        set => _zipURL = value;
    }

    public SwitchFirmware(string version, string zipUrl)
    {
        _zipURL = zipUrl;
        _version = version;
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