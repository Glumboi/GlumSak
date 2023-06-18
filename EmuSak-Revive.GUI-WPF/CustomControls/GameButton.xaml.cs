using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI_WPF.ExtraWindows;
using EmuSak_Revive.Network;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.CustomControls
{
    /// <summary>
    /// Interaction logic for GameButton.xaml
    /// </summary>
    public partial class GameButton : CardExpander
    {
        private string _shaderUrl;

        public SwitchGame Game { get; private set; }

        public string GameID
        {
            get => (string)GetValue(GameIDProperty);
            set => SetValue(GameIDProperty, value);
        }

        // Using a DependencyProperty as the backing store for GameID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameIDProperty =
            DependencyProperty.Register("GameID", typeof(string), typeof(GameButton), new PropertyMetadata(null));

        public string LocalShaderCount
        {
            get => (string)GetValue(LocalShaderCountProperty);
            set => SetValue(LocalShaderCountProperty, value);
        }

        // Using a DependencyProperty as the backing store for GameID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LocalShaderCountProperty =
            DependencyProperty.Register("LocalShaderCount", typeof(string), typeof(GameButton), new PropertyMetadata(null));

        public string WebShaderCount
        {
            get => (string)GetValue(WebShaderCountProperty);
            set => SetValue(WebShaderCountProperty, value);
        }

        // Using a DependencyProperty as the backing store for GameID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WebShaderCountProperty =
            DependencyProperty.Register("WebShaderCount", typeof(string), typeof(GameButton), new PropertyMetadata(null));

        public string GameName
        {
            get => (string)GetValue(GameNameProperty);
            set => SetValue(GameNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for GameName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameNameProperty =
            DependencyProperty.Register("GameName", typeof(string), typeof(GameButton), new PropertyMetadata(null));

        public ImageSource GameImageSource
        {
            get => (ImageSource)GetValue(GameImageSourceProperty);
            set => SetValue(GameImageSourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for GameImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameImageSourceProperty =
            DependencyProperty.Register("GameImageSource", typeof(ImageSource), typeof(GameButton), new PropertyMetadata(null));

        public int GlobalMargin
        {
            get => (int)GetValue(GlobalMarginProperty);
            set => SetValue(GlobalMarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for GlobalMargin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlobalMarginProperty =
            DependencyProperty.Register("GlobalMargin", typeof(int), typeof(GameButton), new PropertyMetadata(5));

        public int DesiredImageSize
        {
            get { return (int)GetValue(DesiredImageSizeProperty); }
            set { SetValue(DesiredImageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesiredImageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesiredImageSizeProperty =
            DependencyProperty.Register("DesiredImageSize", typeof(int), typeof(GameButton), new PropertyMetadata(130));

        public int DesiredButtonSize
        {
            get => (int)GetValue(DesiredButtonSizeProperty);
            set => SetValue(DesiredButtonSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for DesiredButtonSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesiredButtonSizeProperty =
            DependencyProperty.Register("ImageSize", typeof(int), typeof(GameButton), new PropertyMetadata(155));

        public static readonly DependencyProperty DownloadShaderCommandProperty =
            DependencyProperty.Register("DownloadShaderCommand", typeof(ICommand), typeof(GameButton));

        public ICommand DownloadShaderCommand
        {
            get { return (ICommand)GetValue(DownloadShaderCommandProperty); }
            set { SetValue(DownloadShaderCommandProperty, value); }
        }

        public void CreateDownloadShaderCommand()
        {
            DownloadShaderCommand = new RelayCommand(DownloadShader, IsShaderAvailable);
        }

        public GameButton(
            SwitchGame switchGame = null,
            int desiredImageSize = 155,
            int desiredButtonSize = 220)
        {
            InitializeComponent();
            CreateDownloadShaderCommand();

            Style = (Style)Application.Current.Resources[typeof(CardExpander)];

            if (switchGame != null)
            {
                Game = switchGame;
                GameID = switchGame.GameID;
                GameName = switchGame.GameName;
                GameImageSource = ConvertToImageSource(switchGame.GameImage);
            }

            DesiredImageSize = desiredImageSize;
        }

        /*protected override void OnClick()
        {
            new GameActionsWindow(Game).Show();
        }*/

        private static ImageSource ConvertToImageSource(System.Drawing.Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            IntPtr hBitmap = bitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );
            }
            finally
            {
                // Release the HBitmap created by GetHbitmap
                NativeMethods.DeleteObject(hBitmap);
            }
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
        }

        private void CardExpander_Expanded(object sender, RoutedEventArgs e)
        {
            LoadShaderInfo();
        }

        private bool IsShaderAvailable()
        {
            return !string.IsNullOrEmpty(_shaderUrl);
        }

        private void LoadShaderInfo()
        {
            LocalShaderCount = EmuShader.GetShaderCount(GameID);
            WebShaderCount = Network.Networking.GetPasteGameShaderCount(GameName);
            _shaderUrl = Network.Networking.GetShaderDownload(GameName);
        }

        private void DownloadShader()
        {
            var downloadUrl = Networking.GetShaderDownload(GameName);
            EmuShader.InstallShader(MainWindow.EmuConfig, downloadUrl,
                GameID);
        }
    }
}