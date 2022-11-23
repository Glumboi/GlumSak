namespace EmuSak_Revive.GUI
{
    partial class GameActionsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameActionsWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.Action_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.GameId_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.DownloadShaders_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.Game_PrictureBox = new Bunifu.UI.WinForms.BunifuPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Game_PrictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Action_Label
            // 
            this.Action_Label.AllowParentOverrides = false;
            this.Action_Label.AutoEllipsis = false;
            this.Action_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Action_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Action_Label.Font = new System.Drawing.Font("Russo One", 12F);
            this.Action_Label.ForeColor = System.Drawing.Color.White;
            this.Action_Label.Location = new System.Drawing.Point(98, 12);
            this.Action_Label.Name = "Action_Label";
            this.Action_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Action_Label.Size = new System.Drawing.Size(133, 19);
            this.Action_Label.TabIndex = 1;
            this.Action_Label.Text = "Select an action";
            this.Action_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Action_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // GameId_Label
            // 
            this.GameId_Label.AllowParentOverrides = false;
            this.GameId_Label.AutoEllipsis = false;
            this.GameId_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.GameId_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.GameId_Label.Font = new System.Drawing.Font("Russo One", 8.8F);
            this.GameId_Label.ForeColor = System.Drawing.Color.White;
            this.GameId_Label.Location = new System.Drawing.Point(342, 118);
            this.GameId_Label.Name = "GameId_Label";
            this.GameId_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GameId_Label.Size = new System.Drawing.Size(103, 13);
            this.GameId_Label.TabIndex = 16;
            this.GameId_Label.Text = "0100152000022000";
            this.GameId_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.GameId_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(110, 110);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(113, 15);
            this.bunifuLabel1.TabIndex = 17;
            this.bunifuLabel1.Text = "More to come soon...";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // DownloadShaders_Button
            // 
            this.DownloadShaders_Button.AllowAnimations = true;
            this.DownloadShaders_Button.AllowMouseEffects = true;
            this.DownloadShaders_Button.AllowToggling = false;
            this.DownloadShaders_Button.AnimationSpeed = 200;
            this.DownloadShaders_Button.AutoGenerateColors = false;
            this.DownloadShaders_Button.AutoRoundBorders = true;
            this.DownloadShaders_Button.AutoSizeLeftIcon = true;
            this.DownloadShaders_Button.AutoSizeRightIcon = true;
            this.DownloadShaders_Button.BackColor = System.Drawing.Color.Transparent;
            this.DownloadShaders_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DownloadShaders_Button.BackgroundImage")));
            this.DownloadShaders_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadShaders_Button.ButtonText = "Download and install shaders";
            this.DownloadShaders_Button.ButtonTextMarginLeft = 0;
            this.DownloadShaders_Button.ColorContrastOnClick = 45;
            this.DownloadShaders_Button.ColorContrastOnHover = 45;
            this.DownloadShaders_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.DownloadShaders_Button.CustomizableEdges = borderEdges1;
            this.DownloadShaders_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DownloadShaders_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.DisabledForecolor = System.Drawing.Color.White;
            this.DownloadShaders_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.DownloadShaders_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DownloadShaders_Button.ForeColor = System.Drawing.Color.White;
            this.DownloadShaders_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadShaders_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.DownloadShaders_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.DownloadShaders_Button.IconMarginLeft = 11;
            this.DownloadShaders_Button.IconPadding = 10;
            this.DownloadShaders_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DownloadShaders_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.DownloadShaders_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.DownloadShaders_Button.IconSize = 25;
            this.DownloadShaders_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.IdleBorderRadius = 30;
            this.DownloadShaders_Button.IdleBorderThickness = 1;
            this.DownloadShaders_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("DownloadShaders_Button.IdleIconLeftImage")));
            this.DownloadShaders_Button.IdleIconRightImage = null;
            this.DownloadShaders_Button.IndicateFocus = false;
            this.DownloadShaders_Button.Location = new System.Drawing.Point(12, 53);
            this.DownloadShaders_Button.Name = "DownloadShaders_Button";
            this.DownloadShaders_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.OnDisabledState.BorderRadius = 1;
            this.DownloadShaders_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadShaders_Button.OnDisabledState.BorderThickness = 1;
            this.DownloadShaders_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.DownloadShaders_Button.OnDisabledState.IconLeftImage = null;
            this.DownloadShaders_Button.OnDisabledState.IconRightImage = null;
            this.DownloadShaders_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.DownloadShaders_Button.onHoverState.BorderRadius = 1;
            this.DownloadShaders_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadShaders_Button.onHoverState.BorderThickness = 1;
            this.DownloadShaders_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.DownloadShaders_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.DownloadShaders_Button.onHoverState.IconLeftImage = null;
            this.DownloadShaders_Button.onHoverState.IconRightImage = null;
            this.DownloadShaders_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.OnIdleState.BorderRadius = 1;
            this.DownloadShaders_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadShaders_Button.OnIdleState.BorderThickness = 1;
            this.DownloadShaders_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadShaders_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.DownloadShaders_Button.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("DownloadShaders_Button.OnIdleState.IconLeftImage")));
            this.DownloadShaders_Button.OnIdleState.IconRightImage = null;
            this.DownloadShaders_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DownloadShaders_Button.OnPressedState.BorderRadius = 1;
            this.DownloadShaders_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadShaders_Button.OnPressedState.BorderThickness = 1;
            this.DownloadShaders_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DownloadShaders_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.DownloadShaders_Button.OnPressedState.IconLeftImage = null;
            this.DownloadShaders_Button.OnPressedState.IconRightImage = null;
            this.DownloadShaders_Button.Size = new System.Drawing.Size(306, 32);
            this.DownloadShaders_Button.TabIndex = 15;
            this.DownloadShaders_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DownloadShaders_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.DownloadShaders_Button.TextMarginLeft = 0;
            this.DownloadShaders_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.DownloadShaders_Button.UseDefaultRadiusAndThickness = true;
            this.DownloadShaders_Button.Click += new System.EventHandler(this.DownloadShaders_Button_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(12, 37);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(306, 10);
            this.bunifuSeparator1.TabIndex = 2;
            // 
            // Game_PrictureBox
            // 
            this.Game_PrictureBox.AllowFocused = false;
            this.Game_PrictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Game_PrictureBox.AutoSizeHeight = true;
            this.Game_PrictureBox.BorderRadius = 50;
            this.Game_PrictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Game_PrictureBox.Image")));
            this.Game_PrictureBox.IsCircle = true;
            this.Game_PrictureBox.Location = new System.Drawing.Point(344, 12);
            this.Game_PrictureBox.Name = "Game_PrictureBox";
            this.Game_PrictureBox.Size = new System.Drawing.Size(100, 100);
            this.Game_PrictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Game_PrictureBox.TabIndex = 0;
            this.Game_PrictureBox.TabStop = false;
            this.Game_PrictureBox.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // GameActionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(462, 148);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.GameId_Label);
            this.Controls.Add(this.DownloadShaders_Button);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.Action_Label);
            this.Controls.Add(this.Game_PrictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameActionsWindow";
            this.Text = "{GAMEID}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameActionsWindow_FormClosing);
            this.Load += new System.EventHandler(this.GameActionsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Game_PrictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox Game_PrictureBox;
        private Bunifu.UI.WinForms.BunifuLabel Action_Label;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton DownloadShaders_Button;
        private Bunifu.UI.WinForms.BunifuLabel GameId_Label;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}