using System.Collections.Generic;
using Avalonia.Controls;
using GlumSak3AV.CustomControls;
using GlumSak3AV.Switch;
using ReactiveUI;

namespace GlumSak3AV.ViewModels;

public class HomeTabViewModel : ViewModelBase
{
    public List<GameButton> _gameButtons = new List<GameButton>();

    public List<GameButton> GameButtons
    {
        get => _gameButtons;
        set
        {
            this.RaiseAndSetIfChanged(ref _gameButtons, value);
        }
    }
    
    private int _selectedFirmware;

    public int SelectedFirmware
    {
        get => _selectedFirmware;
        set
        {
            if (value != _selectedFirmware)
            {
                this.RaiseAndSetIfChanged(ref _selectedFirmware, value);
            }
        }
    }

    private List<Networking.SwitchFirmware> _firmwares = Networking.Firmwares.GetFirmwareVersions();

    public List<Networking.SwitchFirmware> Firmwares
    {
        get => _firmwares;
        set
        {
            if (value != _firmwares)
            {
                this.RaiseAndSetIfChanged(ref _firmwares, value);
                SelectedFirmware = 0;
            }
        }
    }

    public HomeTabViewModel()
    {
        for (int i = 0; i < 27; i++)
        {
            GameButtons.Add(new GameButton(new SwitchGame("Game", "ID",
                "https://placehold.co/600x400/png")));
        }
    }
}