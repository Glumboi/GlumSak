using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using GlumSak3AV.CustomControls;
using GlumSak3AV.Networking;
using GlumSak3AV.Switch;

namespace GlumSak3AV.ViewModels;

public class HomeTabViewModel : ViewModelBase
{
    private List<Emulator> _emulators = new List<Emulator>();

    public List<Emulator> Emulators
    {
        get => _emulators;
        set => SetProperty(ref _emulators, value);
    }

    private int _selectedEmulator = 0;

    public int SelectedEmulator
    {
        get => _selectedEmulator;
        set => SetProperty(ref _selectedEmulator, value);
    }

    private List<SwitchFirmware> _firmwares = new List<SwitchFirmware>();

    public List<SwitchFirmware> Firmwares
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

    private List<GameButton> _gameButtons = new List<GameButton>();

    public List<GameButton> GameButtons
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

    public HomeTabViewModel()
    {
        CreateClearFilterCommand();

        for (int i = 0; i < 27; i++)
        {
            _gameButtons.Add(new GameButton(new SwitchGame("Game" + i, "ID",
                "https://placehold.co/600x400/png")));
        }

        _firmwares = Networking.Firmwares.GetFirmwareVersions();

        string[] emuJsonPaths = Directory.GetFiles("./EmulatorConfigurations");
        for (int i = 0; i < emuJsonPaths.Length; i++)
        {
            if (emuJsonPaths[i].Contains('Y'))
            {
                var emu = new Emulator(emuJsonPaths[i]);
                Emulators.Add(emu);
            }
        }
    }
}