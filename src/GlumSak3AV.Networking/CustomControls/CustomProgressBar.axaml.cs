﻿using System.ComponentModel;
using System.Text;
using Avalonia;
using Avalonia.VisualTree;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace GlumSak3AV.Networking.CustomControls;

public partial class CustomProgressBar : UserControl
{
    private Downloader _downloader;
    private TextBlock _downloadProgressTextBlock;

    public bool DownloadDone { get; private set; } = false;

    public string DownloadProgressText
    {
        get => _downloadProgressTextBlock.Text;
        set => _downloadProgressTextBlock.Text = value;
    }

    private ProgressBar _progressBar;

    public double Progress
    {
        get => _progressBar.Value;
        set => _progressBar.Value = value;
    }

    public Action<CustomProgressBar> NotifyAllProgressDone { get; set; }


    public CustomProgressBar(Downloader downloader)
    {
        AvaloniaXamlLoader.Load(this);

        _downloadProgressTextBlock = this.FindControl<TextBlock>("DownloadProgress_TextBlock");
        _progressBar = this.FindControl<ProgressBar>("Download_ProgressBar");
        _downloader = downloader;

        this.IsVisible = false; //Auto hide progressbar on creation
    }

    public void StartProgressing()
    {
        this.IsVisible = true;
        Progress = 0;
    }

    public void StopProgressing()
    {
        this.IsVisible = false;
        DownloadDone = true;
        NotifyAllProgressDone?.Invoke(this);
    }

    private void CancelDownload_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        StopProgressing();
        _downloader.CancelDownload();
    }
}