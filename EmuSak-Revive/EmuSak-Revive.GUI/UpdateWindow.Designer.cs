namespace EmuSak_Revive.GUI
{
    partial class UpdateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.Main_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.CurrentVersion_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.NewVersion_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.Button_Yes = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.Button_No = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.CheckOnStartup_CheckBox = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.CheckOnStartUp_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.Progress_CircleBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.PleaseWait_label = new Bunifu.UI.WinForms.BunifuLabel();
            this.Changelog_Textbox = new System.Windows.Forms.RichTextBox();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Main_Label
            // 
            this.Main_Label.AllowParentOverrides = false;
            this.Main_Label.AutoEllipsis = false;
            this.Main_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Main_Label.Font = new System.Drawing.Font("Russo One", 11F);
            this.Main_Label.ForeColor = System.Drawing.Color.White;
            this.Main_Label.Location = new System.Drawing.Point(12, 12);
            this.Main_Label.Name = "Main_Label";
            this.Main_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Main_Label.Size = new System.Drawing.Size(315, 123);
            this.Main_Label.TabIndex = 79;
            this.Main_Label.Text = "There is an update available for GlumSak!\r\n\r\nCurrent installed version:\r\n\r\nAvaila" +
    "ble version:\r\n\r\nDo you want to update?";
            this.Main_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Main_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // CurrentVersion_Label
            // 
            this.CurrentVersion_Label.AllowParentOverrides = false;
            this.CurrentVersion_Label.AutoEllipsis = false;
            this.CurrentVersion_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.CurrentVersion_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.CurrentVersion_Label.Font = new System.Drawing.Font("Russo One", 11F);
            this.CurrentVersion_Label.ForeColor = System.Drawing.Color.White;
            this.CurrentVersion_Label.Location = new System.Drawing.Point(212, 48);
            this.CurrentVersion_Label.Name = "CurrentVersion_Label";
            this.CurrentVersion_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CurrentVersion_Label.Size = new System.Drawing.Size(20, 18);
            this.CurrentVersion_Label.TabIndex = 80;
            this.CurrentVersion_Label.Text = "1.0";
            this.CurrentVersion_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CurrentVersion_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // NewVersion_Label
            // 
            this.NewVersion_Label.AllowParentOverrides = false;
            this.NewVersion_Label.AutoEllipsis = false;
            this.NewVersion_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.NewVersion_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.NewVersion_Label.Font = new System.Drawing.Font("Russo One", 11F);
            this.NewVersion_Label.ForeColor = System.Drawing.Color.White;
            this.NewVersion_Label.Location = new System.Drawing.Point(153, 83);
            this.NewVersion_Label.Name = "NewVersion_Label";
            this.NewVersion_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NewVersion_Label.Size = new System.Drawing.Size(20, 18);
            this.NewVersion_Label.TabIndex = 81;
            this.NewVersion_Label.Text = "1.0";
            this.NewVersion_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.NewVersion_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Button_Yes
            // 
            this.Button_Yes.AllowAnimations = true;
            this.Button_Yes.AllowMouseEffects = true;
            this.Button_Yes.AllowToggling = false;
            this.Button_Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Yes.AnimationSpeed = 200;
            this.Button_Yes.AutoGenerateColors = false;
            this.Button_Yes.AutoRoundBorders = true;
            this.Button_Yes.AutoSizeLeftIcon = true;
            this.Button_Yes.AutoSizeRightIcon = true;
            this.Button_Yes.BackColor = System.Drawing.Color.Transparent;
            this.Button_Yes.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Yes.BackgroundImage")));
            this.Button_Yes.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_Yes.ButtonText = "Yes";
            this.Button_Yes.ButtonTextMarginLeft = 0;
            this.Button_Yes.ColorContrastOnClick = 45;
            this.Button_Yes.ColorContrastOnHover = 45;
            this.Button_Yes.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.Button_Yes.CustomizableEdges = borderEdges7;
            this.Button_Yes.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_Yes.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.DisabledForecolor = System.Drawing.Color.White;
            this.Button_Yes.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Button_Yes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Button_Yes.ForeColor = System.Drawing.Color.White;
            this.Button_Yes.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Yes.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Button_Yes.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Button_Yes.IconMarginLeft = 11;
            this.Button_Yes.IconPadding = 10;
            this.Button_Yes.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Yes.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Button_Yes.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Button_Yes.IconSize = 25;
            this.Button_Yes.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.IdleBorderRadius = 35;
            this.Button_Yes.IdleBorderThickness = 1;
            this.Button_Yes.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("Button_Yes.IdleIconLeftImage")));
            this.Button_Yes.IdleIconRightImage = null;
            this.Button_Yes.IndicateFocus = false;
            this.Button_Yes.Location = new System.Drawing.Point(12, 442);
            this.Button_Yes.Name = "Button_Yes";
            this.Button_Yes.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.OnDisabledState.BorderRadius = 1;
            this.Button_Yes.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_Yes.OnDisabledState.BorderThickness = 1;
            this.Button_Yes.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.Button_Yes.OnDisabledState.IconLeftImage = null;
            this.Button_Yes.OnDisabledState.IconRightImage = null;
            this.Button_Yes.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Button_Yes.onHoverState.BorderRadius = 1;
            this.Button_Yes.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_Yes.onHoverState.BorderThickness = 1;
            this.Button_Yes.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Button_Yes.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Button_Yes.onHoverState.IconLeftImage = null;
            this.Button_Yes.onHoverState.IconRightImage = null;
            this.Button_Yes.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.OnIdleState.BorderRadius = 1;
            this.Button_Yes.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_Yes.OnIdleState.BorderThickness = 1;
            this.Button_Yes.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_Yes.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Button_Yes.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("Button_Yes.OnIdleState.IconLeftImage")));
            this.Button_Yes.OnIdleState.IconRightImage = null;
            this.Button_Yes.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Button_Yes.OnPressedState.BorderRadius = 1;
            this.Button_Yes.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_Yes.OnPressedState.BorderThickness = 1;
            this.Button_Yes.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Button_Yes.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Button_Yes.OnPressedState.IconLeftImage = null;
            this.Button_Yes.OnPressedState.IconRightImage = null;
            this.Button_Yes.Size = new System.Drawing.Size(180, 37);
            this.Button_Yes.TabIndex = 83;
            this.Button_Yes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button_Yes.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_Yes.TextMarginLeft = 0;
            this.Button_Yes.TextPadding = new System.Windows.Forms.Padding(0);
            this.Button_Yes.UseDefaultRadiusAndThickness = true;
            this.Button_Yes.Click += new System.EventHandler(this.Button_Yes_Click);
            // 
            // Button_No
            // 
            this.Button_No.AllowAnimations = true;
            this.Button_No.AllowMouseEffects = true;
            this.Button_No.AllowToggling = false;
            this.Button_No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_No.AnimationSpeed = 200;
            this.Button_No.AutoGenerateColors = false;
            this.Button_No.AutoRoundBorders = true;
            this.Button_No.AutoSizeLeftIcon = true;
            this.Button_No.AutoSizeRightIcon = true;
            this.Button_No.BackColor = System.Drawing.Color.Transparent;
            this.Button_No.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_No.BackgroundImage")));
            this.Button_No.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_No.ButtonText = "No";
            this.Button_No.ButtonTextMarginLeft = 0;
            this.Button_No.ColorContrastOnClick = 45;
            this.Button_No.ColorContrastOnHover = 45;
            this.Button_No.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges8.BottomLeft = true;
            borderEdges8.BottomRight = true;
            borderEdges8.TopLeft = true;
            borderEdges8.TopRight = true;
            this.Button_No.CustomizableEdges = borderEdges8;
            this.Button_No.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_No.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.DisabledForecolor = System.Drawing.Color.White;
            this.Button_No.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Button_No.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Button_No.ForeColor = System.Drawing.Color.White;
            this.Button_No.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_No.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Button_No.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Button_No.IconMarginLeft = 11;
            this.Button_No.IconPadding = 10;
            this.Button_No.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_No.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Button_No.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Button_No.IconSize = 25;
            this.Button_No.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.IdleBorderRadius = 35;
            this.Button_No.IdleBorderThickness = 1;
            this.Button_No.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("Button_No.IdleIconLeftImage")));
            this.Button_No.IdleIconRightImage = null;
            this.Button_No.IndicateFocus = false;
            this.Button_No.Location = new System.Drawing.Point(423, 442);
            this.Button_No.Name = "Button_No";
            this.Button_No.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.OnDisabledState.BorderRadius = 1;
            this.Button_No.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_No.OnDisabledState.BorderThickness = 1;
            this.Button_No.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.Button_No.OnDisabledState.IconLeftImage = null;
            this.Button_No.OnDisabledState.IconRightImage = null;
            this.Button_No.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Button_No.onHoverState.BorderRadius = 1;
            this.Button_No.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_No.onHoverState.BorderThickness = 1;
            this.Button_No.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Button_No.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Button_No.onHoverState.IconLeftImage = null;
            this.Button_No.onHoverState.IconRightImage = null;
            this.Button_No.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.OnIdleState.BorderRadius = 1;
            this.Button_No.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_No.OnIdleState.BorderThickness = 1;
            this.Button_No.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Button_No.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Button_No.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("Button_No.OnIdleState.IconLeftImage")));
            this.Button_No.OnIdleState.IconRightImage = null;
            this.Button_No.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Button_No.OnPressedState.BorderRadius = 1;
            this.Button_No.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Button_No.OnPressedState.BorderThickness = 1;
            this.Button_No.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Button_No.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Button_No.OnPressedState.IconLeftImage = null;
            this.Button_No.OnPressedState.IconRightImage = null;
            this.Button_No.Size = new System.Drawing.Size(173, 37);
            this.Button_No.TabIndex = 82;
            this.Button_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button_No.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_No.TextMarginLeft = 0;
            this.Button_No.TextPadding = new System.Windows.Forms.Padding(0);
            this.Button_No.UseDefaultRadiusAndThickness = true;
            this.Button_No.Click += new System.EventHandler(this.Button_No_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-14, 422);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(649, 14);
            this.bunifuSeparator1.TabIndex = 84;
            // 
            // CheckOnStartup_CheckBox
            // 
            this.CheckOnStartup_CheckBox.AllowBindingControlAnimation = true;
            this.CheckOnStartup_CheckBox.AllowBindingControlColorChanges = false;
            this.CheckOnStartup_CheckBox.AllowBindingControlLocation = true;
            this.CheckOnStartup_CheckBox.AllowCheckBoxAnimation = false;
            this.CheckOnStartup_CheckBox.AllowCheckmarkAnimation = true;
            this.CheckOnStartup_CheckBox.AllowOnHoverStates = true;
            this.CheckOnStartup_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckOnStartup_CheckBox.AutoCheck = true;
            this.CheckOnStartup_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CheckOnStartup_CheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckOnStartup_CheckBox.BackgroundImage")));
            this.CheckOnStartup_CheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CheckOnStartup_CheckBox.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.CheckOnStartup_CheckBox.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.Checked = true;
            this.CheckOnStartup_CheckBox.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.CheckOnStartup_CheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckOnStartup_CheckBox.CustomCheckmarkImage = null;
            this.CheckOnStartup_CheckBox.Location = new System.Drawing.Point(12, 394);
            this.CheckOnStartup_CheckBox.MinimumSize = new System.Drawing.Size(17, 17);
            this.CheckOnStartup_CheckBox.Name = "CheckOnStartup_CheckBox";
            this.CheckOnStartup_CheckBox.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckOnStartup_CheckBox.OnCheck.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.OnCheck.BorderThickness = 2;
            this.CheckOnStartup_CheckBox.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CheckOnStartup_CheckBox.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.CheckOnStartup_CheckBox.OnCheck.CheckmarkThickness = 2;
            this.CheckOnStartup_CheckBox.OnDisable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckOnStartup_CheckBox.OnDisable.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.OnDisable.BorderThickness = 2;
            this.CheckOnStartup_CheckBox.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckOnStartup_CheckBox.OnDisable.CheckmarkColor = System.Drawing.Color.White;
            this.CheckOnStartup_CheckBox.OnDisable.CheckmarkThickness = 2;
            this.CheckOnStartup_CheckBox.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckOnStartup_CheckBox.OnHoverChecked.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.OnHoverChecked.BorderThickness = 2;
            this.CheckOnStartup_CheckBox.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CheckOnStartup_CheckBox.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.CheckOnStartup_CheckBox.OnHoverChecked.CheckmarkThickness = 2;
            this.CheckOnStartup_CheckBox.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckOnStartup_CheckBox.OnHoverUnchecked.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.OnHoverUnchecked.BorderThickness = 1;
            this.CheckOnStartup_CheckBox.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckOnStartup_CheckBox.OnUncheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CheckOnStartup_CheckBox.OnUncheck.BorderRadius = 12;
            this.CheckOnStartup_CheckBox.OnUncheck.BorderThickness = 1;
            this.CheckOnStartup_CheckBox.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.CheckOnStartup_CheckBox.Size = new System.Drawing.Size(22, 22);
            this.CheckOnStartup_CheckBox.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.CheckOnStartup_CheckBox.TabIndex = 85;
            this.CheckOnStartup_CheckBox.ThreeState = false;
            this.CheckOnStartup_CheckBox.ToolTipText = resources.GetString("CheckOnStartup_CheckBox.ToolTipText");
            // 
            // CheckOnStartUp_Label
            // 
            this.CheckOnStartUp_Label.AllowParentOverrides = false;
            this.CheckOnStartUp_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckOnStartUp_Label.AutoEllipsis = false;
            this.CheckOnStartUp_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.CheckOnStartUp_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.CheckOnStartUp_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.CheckOnStartUp_Label.ForeColor = System.Drawing.Color.White;
            this.CheckOnStartUp_Label.Location = new System.Drawing.Point(40, 398);
            this.CheckOnStartUp_Label.Name = "CheckOnStartUp_Label";
            this.CheckOnStartUp_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckOnStartUp_Label.Size = new System.Drawing.Size(257, 14);
            this.CheckOnStartUp_Label.TabIndex = 86;
            this.CheckOnStartUp_Label.Text = "Check for updates on application startup";
            this.CheckOnStartUp_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.CheckOnStartUp_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Progress_CircleBar
            // 
            this.Progress_CircleBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress_CircleBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.Progress_CircleBar.FillThickness = 10;
            this.Progress_CircleBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Progress_CircleBar.ForeColor = System.Drawing.Color.White;
            this.Progress_CircleBar.Location = new System.Drawing.Point(494, 7);
            this.Progress_CircleBar.Minimum = 0;
            this.Progress_CircleBar.Name = "Progress_CircleBar";
            this.Progress_CircleBar.ProgressColor = System.Drawing.Color.Red;
            this.Progress_CircleBar.ProgressColor2 = System.Drawing.Color.Aqua;
            this.Progress_CircleBar.ProgressThickness = 10;
            this.Progress_CircleBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Progress_CircleBar.Size = new System.Drawing.Size(94, 94);
            this.Progress_CircleBar.TabIndex = 87;
            this.Progress_CircleBar.Text = "guna2CircleProgressBar1";
            this.Progress_CircleBar.Visible = false;
            // 
            // PleaseWait_label
            // 
            this.PleaseWait_label.AllowParentOverrides = false;
            this.PleaseWait_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PleaseWait_label.AutoEllipsis = false;
            this.PleaseWait_label.Cursor = System.Windows.Forms.Cursors.Default;
            this.PleaseWait_label.CursorType = System.Windows.Forms.Cursors.Default;
            this.PleaseWait_label.Font = new System.Drawing.Font("Russo One", 11F);
            this.PleaseWait_label.ForeColor = System.Drawing.Color.White;
            this.PleaseWait_label.Location = new System.Drawing.Point(494, 107);
            this.PleaseWait_label.Name = "PleaseWait_label";
            this.PleaseWait_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PleaseWait_label.Size = new System.Drawing.Size(102, 18);
            this.PleaseWait_label.TabIndex = 88;
            this.PleaseWait_label.Text = "Please wait...";
            this.PleaseWait_label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.PleaseWait_label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.PleaseWait_label.Visible = false;
            // 
            // Changelog_Textbox
            // 
            this.Changelog_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Changelog_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Changelog_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Changelog_Textbox.Font = new System.Drawing.Font("Russo One", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Changelog_Textbox.ForeColor = System.Drawing.Color.White;
            this.Changelog_Textbox.Location = new System.Drawing.Point(12, 211);
            this.Changelog_Textbox.Name = "Changelog_Textbox";
            this.Changelog_Textbox.Size = new System.Drawing.Size(584, 175);
            this.Changelog_Textbox.TabIndex = 89;
            this.Changelog_Textbox.Text = "";
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Russo One", 11F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(263, 167);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(77, 18);
            this.bunifuLabel1.TabIndex = 90;
            this.bunifuLabel1.Text = "Changelog";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator2.BackgroundImage")));
            this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(12, 191);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(584, 14);
            this.bunifuSeparator2.TabIndex = 91;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 205);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(584, 181);
            this.webBrowser1.TabIndex = 92;
            // 
            // UpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(608, 491);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.Changelog_Textbox);
            this.Controls.Add(this.PleaseWait_label);
            this.Controls.Add(this.Progress_CircleBar);
            this.Controls.Add(this.CheckOnStartUp_Label);
            this.Controls.Add(this.CheckOnStartup_CheckBox);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.Button_Yes);
            this.Controls.Add(this.Button_No);
            this.Controls.Add(this.NewVersion_Label);
            this.Controls.Add(this.CurrentVersion_Label);
            this.Controls.Add(this.Main_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateWindow";
            this.Text = "Update available!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateWindow_FormClosing);
            this.Load += new System.EventHandler(this.UpdateWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel Main_Label;
        public Bunifu.UI.WinForms.BunifuLabel CurrentVersion_Label;
        public Bunifu.UI.WinForms.BunifuLabel NewVersion_Label;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton Button_Yes;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton Button_No;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuCheckBox CheckOnStartup_CheckBox;
        private Bunifu.UI.WinForms.BunifuLabel CheckOnStartUp_Label;
        private Guna.UI2.WinForms.Guna2CircleProgressBar Progress_CircleBar;
        public Bunifu.UI.WinForms.BunifuLabel PleaseWait_label;
        private System.Windows.Forms.RichTextBox Changelog_Textbox;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}