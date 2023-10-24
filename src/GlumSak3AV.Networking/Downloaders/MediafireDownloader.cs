using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using HtmlAgilityPack;

namespace GlumSak3AV.Networking;

public static class MediafireDownloader
{
    /// <summary>
    /// Small portion of my MediafireDownloader nuget package
    /// </summary>
    /// <param name="sourceURL"></param>
    /// <param name="startOfDownloadHref"></param>
    /// <returns></returns>
    public static string GetMediafireDDL(string sourceURL, string startOfDownloadHref = "https://download")
    {
        foreach (string item in Parsing.GetHrefs(sourceURL))
        {
            if (item.Contains(startOfDownloadHref))
            {
                return item;
            }
        }

        return null;
    }
}