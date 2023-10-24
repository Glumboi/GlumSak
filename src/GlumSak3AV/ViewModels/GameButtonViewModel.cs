using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.UI.Controls;
using GlumSak3AV.CustomBehaviours;
using GlumSak3AV.Networking;
using GlumSak3AV.Switch;
using GlumSak3AV.Views;

namespace GlumSak3AV.ViewModels;

public class GameButtonViewModel : ViewModelBase
{
    private SwitchGame _game;

    public SwitchGame Game
    {
        get => _game;
        set => SetProperty(ref _game, value);
    }

    private string _gameImageUrl;

    public string GameImageUrl
    {
        get => _gameImageUrl;
        set { GameBitmap = WebImage.DownloadImage(value); }
    }

    private Bitmap _gameBitmap;

    public Bitmap GameBitmap
    {
        get => _gameBitmap;
        set => SetProperty(ref _gameBitmap, value);
    }

    public ICommand InstallShadersCommand { get; internal set; }

    void CreateInstallShadersCommand()
    {
        InstallShadersCommand = new RelayCommand(InstallShaders, SupportsShaderInstallation);
    }

    bool SupportsShaderInstallation()
    {
        if (Game.SupportsShaderDownload && !string.IsNullOrWhiteSpace(Game.ShaderDownloadURL))
        {
            return true;
        }

        return false;
    }

    void InstallShaders()
    {
        HomeTabViewModel.CurrentHomeTabInstance?.AddDownload(new DownloadSettings(
            false,
            true,
            false,
            Game.ShaderDownloadURL, Constants.TempPath,
            Game.GameShaderPath, async () =>
            {
                GlumSakDialog dlg = new GlumSakDialog("Happy Gamin!", 
                    $"Shader of game {_game.GameName} got installed!\n" +
                    $"You upgraded from {_game.LocalShaderCount} local shaders to {_game.WebShaderCount} shaders!", 
                    "Take me to the Shader location", 
                    "Dismiss");

                if (await dlg.ShowAsync() == ContentDialogResult.Primary)
                {
                    CustomBehaviours.FileDialog.OpenFileLocation(_game.GameShaderPath);
                }

            }));

        Console.WriteLine("Test shader download");
    }

    public void Init()
    {
        CreateInstallShadersCommand();
    }

    public GameButtonViewModel(SwitchGame game)
    {
        Game = game;
        GameImageUrl = Game.ImageURL;
        Task.Run(() => Init());
    }
}