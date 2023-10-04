using MediaFireDownloaderNew;

namespace GlumSak3AV.Networking;

public struct DownloadSettings
{
    public bool IsZipped { get; set; }
    public bool ChildrenInFolder { get; set; }
    public bool KeepTemp { get; set; }
    public string Url { get; set; }
    public string TempDestination { get; set; }
    public string Destination { get; set; }
    public Action? AfterExtractionOperation { get; set; }

    public DownloadSettings(bool childrenInFolder, bool isZipped, bool keepTemp, string url, string tempDestination,
        string destination, Action? AfterExtraction = null)
    {
        AfterExtractionOperation = AfterExtraction;
        if (url.Contains("mediafire"))
        {
            using (MediaFireDownloader downloaderNew = new MediaFireDownloader())
            {
                Url = downloaderNew.ConvertMediaFireToDirectDownload(url);
            }
        }
        else
        {
            Url = url;
        }

        ChildrenInFolder = childrenInFolder;
        IsZipped = isZipped;
        KeepTemp = keepTemp;
        TempDestination = tempDestination;
        Destination = destination;
    }
}