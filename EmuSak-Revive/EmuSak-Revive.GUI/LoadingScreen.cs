using EmuSak_Revive.Emulators;
using EmuSak_Revive.GUI.Generics;
using EmuSak_Revive.GUI.Properties;
using Glumboi.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace EmuSak_Revive.GUI
{
    public partial class LoadingScreen : Form
    {
        private readonly New.MainWindow mainWindow = new New.MainWindow();
        public bool ignoreCache = true;

        private List<Image> images = new List<Image>()
        {
            Resources.Pepe_Asset,
            Resources.HappyCat_Asset,
            Resources.PeepoHappy_Asset,
            Resources.HappyBird_Asset,
            Resources.RabbitVibe_Asset,
            Resources.CatDance_Asset
        };

        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadRandomGif()
        {
            Random rnd = new Random();
            TransparencyKey = BackColor;
            int num = rnd.Next(0, images.Count);
            Gif_PictureBox.Image = images[num];
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            UI.ChangeToDarkMode(this);
            LoadRandomGif();
            EffectBlur effectBlur = new EffectBlur(this);
            effectBlur.EnableBlur();
            AnimateControls();
            Gif_PictureBox.BorderRadius = 0; //Cant be set with the properties in designer
            if (ignoreCache)
            {
                Task.Run(() => mainWindow.LoadButtons());
            }
            mainWindow.Size = new Size(Settings.Default.LastWidth, Settings.Default.LastHeight);
        }

        private void AnimateControls()
        {
            // Get the current screen resolution
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            // Calculate the center of the screen
            int x = screen.Width / 2 - this.Width / 2;
            int y = screen.Height / 2 - this.Height / 2;

            // Set the position of the form to the center of the screen
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);

            // Center the controls on the form
            int gifX = this.Width / 2 - Gif_PictureBox.Width / 2;
            int gifY = this.Height / 4 - Gif_PictureBox.Height / 2; // Decrease the value of gifY to position the control further up

            // Position the label below the picture box
            int labelX = this.Width / 2 - bunifuLabel1.Width / 2;
            int labelY = gifY + Gif_PictureBox.Height; // Decrease the value of labelY to position the control further up

            // Animate the controls using the Transition library
            Transition transition1 = new Transition(new TransitionType_EaseInEaseOut(1000));
            transition1.add(Gif_PictureBox, "Left", gifX);
            transition1.add(bunifuLabel1, "Left", labelX);
            transition1.run();

            // Animate the label
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

        public void LaunchWithLastSesionCache()
        {
            mainWindow.LoadWithCache();
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