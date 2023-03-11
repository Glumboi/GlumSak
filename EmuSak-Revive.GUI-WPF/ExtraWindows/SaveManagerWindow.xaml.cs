using EmuSak_Revive.Emulators;
using Wpf.Ui.Controls;

namespace EmuSak_Revive.GUI_WPF.ExtraWindows
{
    /// <summary>
    /// Interaktionslogik für SaveManagerWindow.xaml
    /// </summary>
    public partial class SaveManagerWindow : UiWindow
    {
        public string GameName
        {
            get
            {
                return _gameName;
            }
            set
            {
                _gameName = value;
                TitleBar.Title = $"Save Manager for {_gameName}";
            }
        }

        public string GameID
        {
            get
            {
                return _gameId;
            }
            set
            {
                _gameId = value;
            }
        }

        private string _gameName;
        private string _gameId;

        public SaveManagerWindow(SwitchGame switchGame)
        {
            InitializeComponent();

            GameName = switchGame.GameName;
            GameID = switchGame.GameID;
        }
    }
}