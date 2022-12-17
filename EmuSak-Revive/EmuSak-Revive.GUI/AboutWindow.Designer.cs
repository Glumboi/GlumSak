namespace EmuSak_Revive.GUI
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.Text_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.About_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.Github_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.EmuSakUI_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.SuspendLayout();
            // 
            // Text_Label
            // 
            this.Text_Label.AllowParentOverrides = false;
            this.Text_Label.AutoEllipsis = false;
            this.Text_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Text_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Text_Label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Text_Label.ForeColor = System.Drawing.Color.White;
            this.Text_Label.Location = new System.Drawing.Point(13, 84);
            this.Text_Label.Name = "Text_Label";
            this.Text_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text_Label.Size = new System.Drawing.Size(468, 148);
            this.Text_Label.TabIndex = 0;
            this.Text_Label.Text = resources.GetString("Text_Label.Text");
            this.Text_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Text_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.Text_Label.Click += new System.EventHandler(this.Text_Label_Click);
            // 
            // About_Label
            // 
            this.About_Label.AllowParentOverrides = false;
            this.About_Label.AutoEllipsis = false;
            this.About_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.About_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.About_Label.Font = new System.Drawing.Font("Russo One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Label.ForeColor = System.Drawing.Color.White;
            this.About_Label.Location = new System.Drawing.Point(197, 12);
            this.About_Label.Name = "About_Label";
            this.About_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.About_Label.Size = new System.Drawing.Size(100, 40);
            this.About_Label.TabIndex = 1;
            this.About_Label.Text = "About";
            this.About_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.About_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.About_Label.Click += new System.EventHandler(this.About_Label_Click);
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(13, 65);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(477, 14);
            this.bunifuSeparator1.TabIndex = 2;
            this.bunifuSeparator1.Click += new System.EventHandler(this.bunifuSeparator1_Click);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator2.BackgroundImage")));
            this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(13, 239);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(477, 8);
            this.bunifuSeparator2.TabIndex = 3;
            this.bunifuSeparator2.Click += new System.EventHandler(this.bunifuSeparator2_Click);
            // 
            // Github_Button
            // 
            this.Github_Button.AllowAnimations = true;
            this.Github_Button.AllowMouseEffects = true;
            this.Github_Button.AllowToggling = false;
            this.Github_Button.AnimationSpeed = 200;
            this.Github_Button.AutoGenerateColors = false;
            this.Github_Button.AutoRoundBorders = true;
            this.Github_Button.AutoSizeLeftIcon = true;
            this.Github_Button.AutoSizeRightIcon = true;
            this.Github_Button.BackColor = System.Drawing.Color.Transparent;
            this.Github_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Github_Button.BackgroundImage")));
            this.Github_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Github_Button.ButtonText = "My Github";
            this.Github_Button.ButtonTextMarginLeft = 0;
            this.Github_Button.ColorContrastOnClick = 45;
            this.Github_Button.ColorContrastOnHover = 45;
            this.Github_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.Github_Button.CustomizableEdges = borderEdges1;
            this.Github_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Github_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.DisabledForecolor = System.Drawing.Color.White;
            this.Github_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Github_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Github_Button.ForeColor = System.Drawing.Color.White;
            this.Github_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Github_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Github_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Github_Button.IconMarginLeft = 11;
            this.Github_Button.IconPadding = 10;
            this.Github_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Github_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Github_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Github_Button.IconSize = 25;
            this.Github_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.IdleBorderRadius = 30;
            this.Github_Button.IdleBorderThickness = 1;
            this.Github_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("Github_Button.IdleIconLeftImage")));
            this.Github_Button.IdleIconRightImage = null;
            this.Github_Button.IndicateFocus = false;
            this.Github_Button.Location = new System.Drawing.Point(12, 253);
            this.Github_Button.Name = "Github_Button";
            this.Github_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.OnDisabledState.BorderRadius = 1;
            this.Github_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Github_Button.OnDisabledState.BorderThickness = 1;
            this.Github_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.Github_Button.OnDisabledState.IconLeftImage = null;
            this.Github_Button.OnDisabledState.IconRightImage = null;
            this.Github_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Github_Button.onHoverState.BorderRadius = 1;
            this.Github_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Github_Button.onHoverState.BorderThickness = 1;
            this.Github_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Github_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Github_Button.onHoverState.IconLeftImage = null;
            this.Github_Button.onHoverState.IconRightImage = null;
            this.Github_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.OnIdleState.BorderRadius = 1;
            this.Github_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Github_Button.OnIdleState.BorderThickness = 1;
            this.Github_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Github_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Github_Button.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("Github_Button.OnIdleState.IconLeftImage")));
            this.Github_Button.OnIdleState.IconRightImage = null;
            this.Github_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Github_Button.OnPressedState.BorderRadius = 1;
            this.Github_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Github_Button.OnPressedState.BorderThickness = 1;
            this.Github_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Github_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Github_Button.OnPressedState.IconLeftImage = null;
            this.Github_Button.OnPressedState.IconRightImage = null;
            this.Github_Button.Size = new System.Drawing.Size(175, 32);
            this.Github_Button.TabIndex = 15;
            this.Github_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Github_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Github_Button.TextMarginLeft = 0;
            this.Github_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.Github_Button.UseDefaultRadiusAndThickness = true;
            this.Github_Button.Click += new System.EventHandler(this.Github_Button_Click);
            // 
            // EmuSakUI_Button
            // 
            this.EmuSakUI_Button.AllowAnimations = true;
            this.EmuSakUI_Button.AllowMouseEffects = true;
            this.EmuSakUI_Button.AllowToggling = false;
            this.EmuSakUI_Button.AnimationSpeed = 200;
            this.EmuSakUI_Button.AutoGenerateColors = false;
            this.EmuSakUI_Button.AutoRoundBorders = true;
            this.EmuSakUI_Button.AutoSizeLeftIcon = true;
            this.EmuSakUI_Button.AutoSizeRightIcon = true;
            this.EmuSakUI_Button.BackColor = System.Drawing.Color.Transparent;
            this.EmuSakUI_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EmuSakUI_Button.BackgroundImage")));
            this.EmuSakUI_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.EmuSakUI_Button.ButtonText = "Emusak-UI project";
            this.EmuSakUI_Button.ButtonTextMarginLeft = 0;
            this.EmuSakUI_Button.ColorContrastOnClick = 45;
            this.EmuSakUI_Button.ColorContrastOnHover = 45;
            this.EmuSakUI_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.EmuSakUI_Button.CustomizableEdges = borderEdges2;
            this.EmuSakUI_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.EmuSakUI_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.DisabledForecolor = System.Drawing.Color.White;
            this.EmuSakUI_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.EmuSakUI_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EmuSakUI_Button.ForeColor = System.Drawing.Color.White;
            this.EmuSakUI_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EmuSakUI_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.EmuSakUI_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.EmuSakUI_Button.IconMarginLeft = 11;
            this.EmuSakUI_Button.IconPadding = 10;
            this.EmuSakUI_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EmuSakUI_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.EmuSakUI_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.EmuSakUI_Button.IconSize = 25;
            this.EmuSakUI_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.IdleBorderRadius = 30;
            this.EmuSakUI_Button.IdleBorderThickness = 1;
            this.EmuSakUI_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.IdleIconLeftImage = null;
            this.EmuSakUI_Button.IdleIconRightImage = ((System.Drawing.Image)(resources.GetObject("EmuSakUI_Button.IdleIconRightImage")));
            this.EmuSakUI_Button.IndicateFocus = false;
            this.EmuSakUI_Button.Location = new System.Drawing.Point(315, 253);
            this.EmuSakUI_Button.Name = "EmuSakUI_Button";
            this.EmuSakUI_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.OnDisabledState.BorderRadius = 1;
            this.EmuSakUI_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.EmuSakUI_Button.OnDisabledState.BorderThickness = 1;
            this.EmuSakUI_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.EmuSakUI_Button.OnDisabledState.IconLeftImage = null;
            this.EmuSakUI_Button.OnDisabledState.IconRightImage = null;
            this.EmuSakUI_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.EmuSakUI_Button.onHoverState.BorderRadius = 1;
            this.EmuSakUI_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.EmuSakUI_Button.onHoverState.BorderThickness = 1;
            this.EmuSakUI_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.EmuSakUI_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.EmuSakUI_Button.onHoverState.IconLeftImage = null;
            this.EmuSakUI_Button.onHoverState.IconRightImage = null;
            this.EmuSakUI_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.OnIdleState.BorderRadius = 1;
            this.EmuSakUI_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.EmuSakUI_Button.OnIdleState.BorderThickness = 1;
            this.EmuSakUI_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.EmuSakUI_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.EmuSakUI_Button.OnIdleState.IconLeftImage = null;
            this.EmuSakUI_Button.OnIdleState.IconRightImage = ((System.Drawing.Image)(resources.GetObject("EmuSakUI_Button.OnIdleState.IconRightImage")));
            this.EmuSakUI_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.EmuSakUI_Button.OnPressedState.BorderRadius = 1;
            this.EmuSakUI_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.EmuSakUI_Button.OnPressedState.BorderThickness = 1;
            this.EmuSakUI_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.EmuSakUI_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.EmuSakUI_Button.OnPressedState.IconLeftImage = null;
            this.EmuSakUI_Button.OnPressedState.IconRightImage = null;
            this.EmuSakUI_Button.Size = new System.Drawing.Size(175, 32);
            this.EmuSakUI_Button.TabIndex = 16;
            this.EmuSakUI_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EmuSakUI_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.EmuSakUI_Button.TextMarginLeft = 0;
            this.EmuSakUI_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.EmuSakUI_Button.UseDefaultRadiusAndThickness = true;
            this.EmuSakUI_Button.Click += new System.EventHandler(this.EmuSakUI_Button_Click);
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(501, 293);
            this.Controls.Add(this.EmuSakUI_Button);
            this.Controls.Add(this.Github_Button);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.About_Label);
            this.Controls.Add(this.Text_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutWindow";
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutWindow_FormClosing);
            this.Load += new System.EventHandler(this.AboutWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel Text_Label;
        private Bunifu.UI.WinForms.BunifuLabel About_Label;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Github_Button;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton EmuSakUI_Button;
    }
}