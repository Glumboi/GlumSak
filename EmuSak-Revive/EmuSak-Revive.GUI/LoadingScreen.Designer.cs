namespace EmuSak_Revive.GUI
{
    partial class LoadingScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            this.Gif_PictureBox = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Update_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Gif_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Gif_PictureBox
            // 
            this.Gif_PictureBox.AllowFocused = false;
            this.Gif_PictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Gif_PictureBox.AutoSizeHeight = true;
            this.Gif_PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.Gif_PictureBox.BorderRadius = 89;
            this.Gif_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Gif_PictureBox.Image")));
            this.Gif_PictureBox.IsCircle = true;
            this.Gif_PictureBox.Location = new System.Drawing.Point(474, 12);
            this.Gif_PictureBox.Name = "Gif_PictureBox";
            this.Gif_PictureBox.Size = new System.Drawing.Size(179, 179);
            this.Gif_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Gif_PictureBox.TabIndex = 0;
            this.Gif_PictureBox.TabStop = false;
            this.Gif_PictureBox.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Russo One", 20.25F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(473, 215);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(371, 78);
            this.bunifuLabel1.TabIndex = 1;
            this.bunifuLabel1.Text = "Getting things ready...\r\n\r\n";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Update_Timer
            // 
            this.Update_Timer.Enabled = true;
            this.Update_Timer.Interval = 1000;
            this.Update_Timer.Tick += new System.EventHandler(this.Update_Timer_Tick);
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(466, 305);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.Gif_PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadingScreen";
            this.Text = "Loading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingScreen_FormClosing);
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gif_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox Gif_PictureBox;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.Timer Update_Timer;
    }
}