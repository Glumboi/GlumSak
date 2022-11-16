using EmuSak_Revive.Discord;
using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI.Generics;
using Glumboi.UI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace EmuSak_Revive.GUI
{
    public partial class LoadingScreen : Form
    {
        MainWindow mainWindow = new MainWindow();

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
            AnimateControls();
            Gif_PictureBox.BorderRadius= 0;
            Task.Run(() => mainWindow.LoadButtons());
        }

        private void AnimateControls()
        {
            Transition transition1 = new Transition(new TransitionType_EaseInEaseOut(1000));

            transition1.add(Gif_PictureBox, "Left", 138);
            transition1.add(bunifuLabel1, "Left", 46);

            transition1.run();

            //Animates the label
            string[] stringsForLabelAnimation = {
                "Getting things ready",
                "Getting things ready.",
                "Getting things ready..",
                "Getting things ready..."
            }; 

            string[] stringsForTitleAnimation = {
                "Loading",
                "Loading.",
                "Loading..",
                "Loading..."
            };

            AnimateText textAnimator = new AnimateText(bunifuLabel1, stringsForLabelAnimation, 300);
            AnimateText textAnimator2 = new AnimateText(this, stringsForTitleAnimation, 300);
            textAnimator.Run();
            textAnimator2.Run();
        }

        private void Update_Timer_Tick(object sender, EventArgs e)
        {
            if (!mainWindow.DoneLoading) return;
            this.Hide();
            mainWindow.Show();
            Gif_PictureBox.Enabled = false;
            Update_Timer.Stop();
        }

        public void LaunchWithYuzuConfig()
        {
            mainWindow.LoadPortableEmus();
            Yuzu.GetGames();
            mainWindow.ChangeEmuConfig(0);
        }

        public void LaunchWithRyujinxConfig()
        {
            mainWindow.LoadPortableEmus();
            Ryujinx.GetGames();
            mainWindow.ChangeEmuConfig(1);
        }

        private void LoadingScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
