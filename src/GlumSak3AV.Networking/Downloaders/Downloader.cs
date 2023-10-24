using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net;
using Avalonia.Controls;
using GlumSak3AV.Networking.CustomControls;

namespace GlumSak3AV.Networking;

public class Downloader
{
    private HttpClientWrapper _webClient;
    private CancellationTokenSource _cts;
    private Stopwatch _stopWatch;

    private string _currentTempFile;
    private string _currentTempFileDir;
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
        _webClient = new HttpClientWrapper();
        _cts = new CancellationTokenSource();
        _stopWatch = new Stopwatch();

        _webClient.ProgressChanged += UpdateProgress;
        _webClient.DownloadCompleted += DownloadDone;

        DownloadProgressBar = new CustomProgressBar(this);
        DownloadProgressBar.StartProgressing();
    }

    public void CancelDownload()
    {
        _cts.Cancel();
        FinalizeDownload(true);
    }

    public void
        DownloadFile(DownloadSettings settings) //string addr, string tempPath, string? unzipPath = null)
    {
        _currentSettings = settings;
        _isZipped = _currentSettings.IsZipped;

        string fileName = $"GlumSakTemp_{new Random().Next(0, Int32.MaxValue)}";
        string fileDir = $"{_currentSettings.TempDestination}{fileName}";
        Directory.CreateDirectory(fileDir);
        _currentTempFile = $"{fileDir}{fileName}";
        _currentTempFileDir = fileDir;
        _webClient.DownloadFileAsync(_currentSettings.Url, _currentTempFile, _cts.Token);
        _stopWatch.Start();
    }

    private void UpdateProgress(long totalBytes, long bytesReceived)
    {
        double percentage = (double)bytesReceived / (double)totalBytes * 100;

        // Calculate progress values
        double fileSize = totalBytes / 1024.0 / 1024.0;
        double downloadSpeed = bytesReceived / 1024.0 / 1024.0 / _stopWatch.Elapsed.TotalSeconds;

        //Calculate ETA
        double remainingBytes = totalBytes - bytesReceived;
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

    private void DownloadDone()
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

        FinalizeDownload(false);
    }

    private void FinalizeDownload(bool cancelled)
    {
        //Done
        if (!cancelled) Directory.Delete(_currentTempFileDir);
        DownloadProgressBar.StopProgressing();
    }

    private string GetFileSize(double totalBytes)
    {
        return string.Format(totalBytes.ToString(".00"));
    }
}