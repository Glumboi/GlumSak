using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using Avalonia.Controls;
using GlumSak3AV.Networking.CustomControls;

namespace GlumSak3AV.Networking;

public class Downloader : IDisposable
{
    private WebClient _webClient;
    private Stopwatch _stopWatch;

    private string _currentTempFile;
    private bool _isZipped;
    private DownloadSettings _currentSettings;

    private CustomProgressBar _downloadProgressBar;

    public CustomProgressBar DownloadProgressBar
    {
        get => _downloadProgressBar;
        private set => _downloadProgressBar = value;
    }

    public Downloader()
    {
        _webClient = new WebClient();
        _stopWatch = new Stopwatch();

        _webClient.DownloadProgressChanged += UpdateProgress;
        _webClient.DownloadFileCompleted += DownloadDone;

        DownloadProgressBar = new CustomProgressBar(this);

        DownloadProgressBar.StartProgressing();
    }

    public void CancelDownload()
    {
        _webClient.CancelAsync();
    }

    public void
        DownloadFile(DownloadSettings settings) //string addr, string tempPath, string? unzipPath = null)
    {
        _currentSettings = settings;
        _isZipped = _currentSettings.IsZipped;
        _currentTempFile =
            $"{_currentSettings.TempDestination}/GlumSakTemp_{new Random().Next(0, Int32.MaxValue)}.tempSakFile";
        _webClient.DownloadFileTaskAsync(_currentSettings.Url, _currentTempFile);
        _stopWatch.Start();
    }

    private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;

        // Calculate progress values
        double fileSize = totalBytes / 1024.0 / 1024.0;
        double downloadSpeed = e.BytesReceived / 1024.0 / 1024.0 / _stopWatch.Elapsed.TotalSeconds;

        //Calculate ETA
        double remainingBytes = totalBytes - bytesIn;
        double remainingTime = remainingBytes / (downloadSpeed * 1024 * 1024);
        string remainingTimeString = TimeSpan.FromSeconds(remainingTime).ToString(@"hh\:mm\:ss");

        string progressBarText = string.Format("{0} MB/s | {1}: {2} MB ({3}%) | ETA: {4}",
            downloadSpeed.ToString("0.00"),
            "File Size",
            GetFileSize(fileSize),
            percentage.ToString("0.00"),
            remainingTimeString);

        DownloadProgressBar.DownloadProgressText = progressBarText;
        DownloadProgressBar.Progress = percentage;
    }

    private void DownloadDone(object? sender, AsyncCompletedEventArgs e)
    {
        if (!e.Cancelled)
        {
            Console.WriteLine("Done downloading");
            _stopWatch.Reset();
            if (_isZipped)
            {
                Console.WriteLine("Unzipping file...");
                Files.Zip.Unzip(_currentTempFile, _currentSettings.Destination);

                if (_currentSettings.AfterExtractionOperation != null)
                {
                    _currentSettings.AfterExtractionOperation.Invoke();
                }
            }
        }

        File.Delete(_currentTempFile);
        DownloadProgressBar.StopProgressing();
        //Done
        Dispose();
    }

    private string GetFileSize(double totalBytes)
    {
        return string.Format(totalBytes.ToString(".00"));
    }

    ~Downloader()
    {
        Dispose(false);
    }

    private void ReleaseUnmanagedResources()
    {
        _webClient.DownloadProgressChanged -= UpdateProgress;
        _webClient.DownloadFileCompleted -= DownloadDone;
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
            _webClient.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}