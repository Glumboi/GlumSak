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

    public HomeTabViewModel()
    {
        for (int i = 0; i < 27; i++)
        {
            GameButtons.Add(new GameButton(new SwitchGame("Game", "ID",
                "https://placehold.co/600x400/png")));
        }
    }
}