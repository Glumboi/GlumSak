using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.Network;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.ExtraWindows
{
    /// <summary>
    /// Interaktionslogik für GameActionsWindow.xaml
    /// </summary>
    public partial class GameActionsWindow : UiWindow
    {
        public string GameName
        {
            get
            {
                return _gameName;
            }
            private set
            {
                _gameName = value;

                TitleBar.Title = _gameName;
                this.Title = _gameName;
                shaderUrl = Networking.GetShaderDownload(_gameName);
            }
        }

        public string GameID
        {
            get
            {
                return _gameId;
            }
            private set
            {
                _gameId = value;
                GameID_TextBlock.Text = _gameId;
            }
        }

        public ImageSource GameImage
        {
            get
            {
                return _gameImg;
            }

            private set
            {
                _gameImg = value;
                Game_Image.Source = _gameImg;
            }
        }

        public string ShaderCount
        {
            get
            {
                return _shaderCount;
            }
            set
            {
                _shaderCount = value;
                ShaderCount_TextBlock.Text = "Your Shadercount is: " +
                    value +
                    " | Pastecount: " +
                    Networking.GetPasteGameShaderCount(GameName);
            }
        }

        private static bool shaderExists = false;
        private string shaderUrl = string.Empty;

        private static SwitchGame switchGame;

        private string _gameName;
        private string _gameId;
        private string _shaderCount;
        private ImageSource _gameImg;

        public GameActionsWindow(SwitchGame game)
        {
            InitializeComponent();

            switchGame = game;
            GameName = switchGame.GameName;
            GameID = switchGame.GameID;
            GameImage = switchGame.GameImageSource;
        }

        private void LoadContent()
        {
            SaveManager_Button.Content = "Save manager is coming soon!";
            CheckShader();
        }

        private void UiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }

        private void DownloadShaders_Button_Click(object sender, RoutedEventArgs e)
        {
            if (shaderExists)
            {
                DownloadShader(GameName, GameID);
                return;
            }

            Networking.ShowNotification("Can you read?\nThere is no Shader available for this Game!");
        }

        private void CheckShader()
        {
            ShaderCount = EmuShader.GetShaderCount(GameID);

            shaderExists = !string.IsNullOrWhiteSpace(shaderUrl);

            if (!shaderExists)
            {
                DownloadShaders_Button.Content = "Shader is not available for this game!";
            }
        }

        public static void DownloadShader(string gameName, string gameId)
        {
            if (shaderExists)
            {
                EmuShader.InstallShader(MainWindow.EmuConfig, Networking.GetShaderDownload(gameName), gameId);
                return;
            }
            Networking.ShowNotification($"There is no shader available for {gameName} at the moment.");
            //  ^
            //  |
            //Sends message if game exists in paste but the url is not valid
        }

        private void SaveManager_Button_Click(object sender, RoutedEventArgs e)
        {
            Networking.ShowNotification("Can you read?\nThis feature is not done yet!");

            /*SaveManagerWindow saveManagerWindow = new SaveManagerWindow(switchGame);

            saveManagerWindow.Show();*/
        }
    }
}