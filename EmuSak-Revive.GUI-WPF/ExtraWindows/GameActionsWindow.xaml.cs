using EmuSak_Revive.EmuFiles;
using EmuSak_Revive.Network;
using Glumboi.UI.Toast;
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
        public string GameName { get; private set; }
        public string GameID { get; private set; }
        public ImageSource GameImage { get; private set; }

        private static bool shaderExists = false;
        private static string shaderUrl = string.Empty;

        public GameActionsWindow(string gameName, string gameID, ImageSource image)
        {
            InitializeComponent();
            GameName = gameName;
            GameID = gameID;
            GameImage = image;
        }

        private void LoadContent()
        {
            GameID_TextBlock.Text = GameID;
            Game_Image.Source = GameImage;
            TitleBar.Title = GameName;
            this.Title = GameName;

            SaveManager_Button.Content = "Save manager is coming soon!";

            shaderUrl = Networking.GetShaderDownload(GameName);

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

            System.Windows.MessageBox.Show("Can you read?\nThere is no Shader available for this Game!",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void CheckShader()
        {
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
            ToastHandler.ShowToast($"There is no shader available for {gameName} at the moment.", "Info");
        }

        private void SaveManager_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Can you read?\nThis feature is not developed yet!",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}