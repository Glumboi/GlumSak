using System;
using System.IO;
using System.Net;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using GlumSak3AV.Switch;
using GlumSak3AV.ViewModels;
using GlumSak3AV.Views;

namespace GlumSak3AV.CustomControls;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;

public partial class GameButton : UserControl
{
    public SwitchGame Game { get; private set; }

    public string GameID
    {
        get => (string)GetValue(GameIDProperty);
        set => SetValue(GameIDProperty, value);
    }

    public static readonly AvaloniaProperty<string> GameIDProperty =
        AvaloniaProperty.Register<GameButton, string>(nameof(GameID));

    public string GameName
    {
        get => (string)GetValue(GameNameProperty);
        set => SetValue(GameNameProperty, value);
    }

    public static readonly AvaloniaProperty<string> GameNameProperty =
        AvaloniaProperty.Register<GameButton, string>(nameof(GameName));

    public string GameImage
    {
        get => (string)GetValue(GameImageProperty);
        set
        {
            GameBitmap = DownloadImage(value);
            SetValue(GameImageProperty, value);
        }
    }

    public static readonly AvaloniaProperty<string> GameImageProperty =
        AvaloniaProperty.Register<GameButton, string>(nameof(GameImage));

    public Bitmap GameBitmap
    {
        get => (Bitmap)GetValue(GameBitmapProperty);
        set => SetValue(GameBitmapProperty, value);
    }

    public static readonly AvaloniaProperty<Bitmap> GameBitmapProperty =
        AvaloniaProperty.Register<GameButton, Bitmap>(nameof(GameBitmap));

    public int GlobalMargin
    {
        get => (int)GetValue(GlobalMarginProperty);
        set => SetValue(GlobalMarginProperty, value);
    }

    public static readonly AvaloniaProperty<int> GlobalMarginProperty =
        AvaloniaProperty.Register<GameButton, int>(nameof(GlobalMargin), defaultValue: 5);

    public int DesiredImageSize
    {
        get => (int)GetValue(DesiredImageSizeProperty);
        set => SetValue(DesiredImageSizeProperty, value);
    }

    public static readonly AvaloniaProperty<int> DesiredImageSizeProperty =
        AvaloniaProperty.Register<GameButton, int>(nameof(DesiredImageSize), defaultValue: 130);

    public int DesiredButtonSize
    {
        get => (int)GetValue(DesiredButtonSizeProperty);
        set => SetValue(DesiredButtonSizeProperty, value);
    }

    public static readonly AvaloniaProperty<int> DesiredButtonSizeProperty =
        AvaloniaProperty.Register<GameButton, int>(nameof(DesiredButtonSize), defaultValue: 155);
    
    public ICommand InstallShaderCommand
    {
        get => (ICommand)GetValue(InstallShaderCommandProperty);
        set => SetValue(InstallShaderCommandProperty, value);
    }

    public static readonly AvaloniaProperty<ICommand> InstallShaderCommandProperty =
        AvaloniaProperty.Register<GameButton, ICommand>(nameof(DesiredButtonSize));

    void CreateInstallShaderCommand()
    {
        InstallShaderCommand = new RelayCommand(InstallShader, SupportsShaderInstallation);
    }

    void InstallShader()
    {
        //TODO: implement   
        Console.WriteLine("Test");
    }
    
    private bool SupportsShaderInstallation()
    {
        return Game.SupportsShaderDownload;
    }

    #region ctors

    public GameButton()
    {
        this.DataContext = this;
        InitializeComponent();
        CreateInstallShaderCommand();
    }

    public GameButton(SwitchGame switchGame)
    {
        this.DataContext = new GameButtonViewModel(switchGame);
        InitializeComponent();

        Game = switchGame;
        GameID = switchGame.GameID;
        GameName = switchGame.GameName;
        GameImage = switchGame.ImageURL;
    }

    #endregion

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public Bitmap DownloadImage(string url)
    {
        using (WebClient client = new WebClient())
        {
            var imageBytes = client.DownloadData(new Uri(url));

            Stream stream = new MemoryStream(imageBytes);

            return new Bitmap(stream);
        }
    }
}