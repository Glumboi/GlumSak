using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using GlumSak3AV.CustomBehaviours;
using GlumSak3AV.CustomControls;
using GlumSak3AV.Filtering;
using GlumSak3AV.Networking;
using GlumSak3AV.Networking.CustomControls;
using GlumSak3AV.Switch;
using GlumSak3AV.Views;

namespace GlumSak3AV.ViewModels;

public class HomeTabViewModel : ViewModelBase
{
    public static HomeTabViewModel? CurrentHomeTabInstance { get; private set; }

    private ObservableCollection<Emulator> _emulators = new ObservableCollection<Emulator>();

    public ObservableCollection<Emulator> Emulators
    {
        get => _emulators;
        set => SetProperty(ref _emulators, value);
    }

    private int _selectedEmulator = 0;

    public int SelectedEmulator
    {
        get => _selectedEmulator;
        set
        {
            SetProperty(ref _selectedEmulator, value);
            LoadGamesToGUI();
        }
    }

    private ObservableCollection<SwitchFirmware> _firmwares = new ObservableCollection<SwitchFirmware>();

    public ObservableCollection<SwitchFirmware> Firmwares
    {
        get => _firmwares;
        set => SetProperty(ref _firmwares, value);
    }

    private int _selectedFirmware;

    public int SelectedFirmware
    {
        get => _selectedFirmware;
        set => SetProperty(ref _selectedFirmware, value);
    }

    private ObservableCollection<GameButton> _gameButtons = new ObservableCollection<GameButton>();

    public ObservableCollection<GameButton> GameButtons
    {
        get => _gameButtons;
        set => SetProperty(ref _gameButtons, value);
    }

    public ObservableCollection<CustomProgressBar> _progressBars = new ObservableCollection<CustomProgressBar>();

    public ObservableCollection<CustomProgressBar> ProgressBars
    {
        get => _progressBars;
        set => SetProperty(ref _progressBars, value);
    }

    public ICommand ClearFilterCommand { get; internal set; }

    void CreateClearFilterCommand()
    {
        ClearFilterCommand = new RelayCommand(ClearFilter);
    }

    void ClearFilter()
    {
        Filter = string.Empty;
    }

    private string _filter;

    public string Filter
    {
        get => _filter;
        set
        {
            SetProperty(ref _filter, value);
            Buttons.GetButtonsToHide(ref _gameButtons, value);
        }
    }

    public void AddDownload(DownloadSettings settings)
    {
        Downloader downloader;
        CustomProgressBar progressBar;
        DownloaderFactory.CreateNewDownloader(out downloader, out progressBar);
        progressBar.NotifyAllProgressDone += NotifyAllProgressDone;
        ProgressBars.Add(progressBar);
        downloader.DownloadFile(settings);
    }

    private void NotifyAllProgressDone(CustomProgressBar caller)
    {
        caller.NotifyAllProgressDone -= NotifyAllProgressDone;
        ProgressBars.Remove(caller);
    }

    public ICommand DownloadAndInstallFirmwareCommand { get; internal set; }

    void CreateDownloadAndInstallFirmwareCommand()
    {
        DownloadAndInstallFirmwareCommand = new RelayCommand(DownloadAndInstallFirmware);
    }

    void DownloadAndInstallFirmware()
    {
        AddDownload(Emulators[SelectedEmulator]
            .FirmwareDownload(Firmwares[SelectedFirmware].ZipURL));
    }

    public ICommand DownloadAndInstallKeysCommand { get; internal set; }

    void CreateDownloadAndInstallKeysCommand()
    {
        DownloadAndInstallKeysCommand = new RelayCommand(DownloadAndInstallKeys);
    }

    void DownloadAndInstallKeys()
    {
        AddDownload(Emulators[SelectedEmulator]
            .KeysDownload("https://www.mediafire.com/file/a8dg2wnszlowsfm/prod.zip/file"));
    }

    public ICommand EditEmulatorConfigurationCommand { get; internal set; }

    void CreateEditEmulatorConfigurationCommand()
    {
        EditEmulatorConfigurationCommand = new RelayCommand(EditEmulatorConfiguration);
    }

    async void EditEmulatorConfiguration()
    {
        EditEmulatorConfigWindow wnd = new EditEmulatorConfigWindow(Emulators[SelectedEmulator]);
        await wnd.ShowDialog(MainWindow._currentMainWindow);
        LoadEmulators();
    }

    public ICommand CreateNewEmulatorConfigurationCommand { get; internal set; }

    void CreateCreateNewEmulatorConfigurationCommand()
    {
        CreateNewEmulatorConfigurationCommand = new RelayCommand(CreateNewEmulatorConfiguration);
    }

    async void CreateNewEmulatorConfiguration()
    {
        EditEmulatorConfigWindow wnd = new EditEmulatorConfigWindow();
        await wnd.ShowDialog(MainWindow._currentMainWindow);
        LoadEmulators();
    }

    public ICommand RemoveEmulatorConfigurationCommand { get; internal set; }

    void CreateRemoveEmulatorConfigurationCommand()
    {
        RemoveEmulatorConfigurationCommand = new RelayCommand(RemoveEmulatorConfiguration);
    }

    async void RemoveEmulatorConfiguration()
    {
        GlumSakDialog dlg = new GlumSakDialog("Do you really want to delete this Emulator config?",
            "The deletion is not reversible and will permanently remove this config from GlumSak!",
            "Yes",
            "No");

        var res = await dlg.ShowAsync();

        if (res == ContentDialogResult.Primary)
        {
            File.Delete(Emulators[SelectedEmulator].JsonFile);
            LoadEmulators();
        }
    }

    async void LoadGamesToGUI()
    {
        if (Emulators.Count < 1) return;
        GameButtons.Clear();
        var emuGames = Emulators[_selectedEmulator].GetGames();

        //TODO: Implement a better way of notifying the user that a config is corrupt aka not working!
        if (emuGames == null)
        {
            GlumSakDialog dlg = new GlumSakDialog("One or more Emulator configs is not set up properly",
                "Prevented a crash caused by one or more corrupted config files, please verify the integrity of the EmulatorConfigs!\n" +
                "Do you want to exit the app?",
                "Yes",
                "No");

            if (await dlg.ShowAsync() == ContentDialogResult.Primary)
            {
                CurrentApplication.Close();
            }

            Debug.WriteLine("One emulator config is corrupt!");
            return;
        }

        foreach (var game in emuGames)
        {
            GameButtons.Add(new GameButton(game));
        }
    }

    void LoadFirmwares()
    {
        foreach (var firmware in Networking.Firmwares.GetFirmwareVersions())
        {
            Firmwares.Add(firmware);
        }
    }

    void LoadEmulators()
    {
        var lastSelected = SelectedEmulator;
        Emulators.Clear();

        string[] emuJsonPaths = Directory.GetFiles("./EmulatorConfigurations");
        for (int i = 0; i < emuJsonPaths.Length; i++)
        {
            Emulators.Add(new Emulator(emuJsonPaths[i]));
        }

        SelectedEmulator = lastSelected;
    }

    private void Initialize()
    {
        LoadEmulators();
        LoadFirmwares();
        CreateClearFilterCommand();
        CreateEditEmulatorConfigurationCommand();
        CreateCreateNewEmulatorConfigurationCommand();
        CreateRemoveEmulatorConfigurationCommand();
        CreateDownloadAndInstallFirmwareCommand();
        CreateDownloadAndInstallKeysCommand();
        LoadGamesToGUI();
    }

    public HomeTabViewModel()
    {
        Initialize();
        CurrentHomeTabInstance = this;
    }
}