using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using GlumSak3AV.CustomControls;
using GlumSak3AV.Networking;
using GlumSak3AV.Switch;
using GlumSak3AV.Views;

namespace GlumSak3AV.ViewModels;

public class HomeTabViewModel : ViewModelBase
{
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
            Filtering.Buttons.GetButtonsToHide(ref _gameButtons, value);
        }
    }

    public ICommand EditEmulatorConfigurationCommand { get; internal set; }

    void CreateEditEmulatorConfigurationCommand()
    {
        EditEmulatorConfigurationCommand = new RelayCommand(EditEmulatorConfiguration);
    }

    async void EditEmulatorConfiguration()
    {
        EditEmulatorConfigWindow wnd = new EditEmulatorConfigWindow(Emulators[SelectedEmulator].JsonData);
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

    void RemoveEmulatorConfiguration()
    {
        File.Delete(Emulators[SelectedEmulator].JsonFile);
        LoadEmulators();
    }

    void LoadGamesToGUI()
    {
        if (Emulators.Count < 1) return;
        GameButtons.Clear();

        foreach (var game in Emulators[_selectedEmulator].GetGames())
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
        Emulators.Clear();

        string[] emuJsonPaths = Directory.GetFiles("./EmulatorConfigurations");
        for (int i = 0; i < emuJsonPaths.Length; i++)
        {
            Emulators.Add(new Emulator(emuJsonPaths[i]));
        }

        SelectedEmulator = 0;
    }

    public HomeTabViewModel()
    {
        LoadEmulators();
        CreateClearFilterCommand();
        CreateEditEmulatorConfigurationCommand();
        CreateCreateNewEmulatorConfigurationCommand();
        CreateRemoveEmulatorConfigurationCommand();
        LoadFirmwares();
        LoadGamesToGUI();
    }
}