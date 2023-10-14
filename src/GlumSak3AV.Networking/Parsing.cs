using HtmlAgilityPack;

namespace GlumSak3AV.Networking;

internal class Parsing
{
    private static string GetAbsoluteUrlString(string baseUrl, string url)
    {
        var uri = new Uri(url, UriKind.RelativeOrAbsolute);
        if (!uri.IsAbsoluteUri)
            uri = new Uri(new Uri(baseUrl), uri);
        return uri.ToString();
    }

    /// <summary>
    /// Parses a websites content and gets any links from the site and outputs them (used for archive.org)
    /// </summary>
    /// <param name="urlToCrawl"></param>
    /// <returns></returns>
    ///
    public static List<string> ParseLinks(string urlToCrawl)
    {
        List<string> result = new List<string>();

        foreach (var href in GetHrefs(urlToCrawl))
        {
            result.Add(GetAbsoluteUrlString(urlToCrawl, href));
        }

        return result;
    }

    /// <summary>
    /// Gets all hrefs in a website
    /// </summary>
    /// <param name="url">Source url</param>
    /// <returns></returns>
    public static IEnumerable<string> GetHrefs(string url)
    {
        // declaring & loading dom
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = new HtmlDocument();
        doc = web.Load(url);

        // extracting all links
        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            HtmlAttribute att = link.Attributes["href"];

            if (att.Value.Contains("a"))
            {
                yield return att.Value;
            }
        }

        yield return string.Empty;
    }
}