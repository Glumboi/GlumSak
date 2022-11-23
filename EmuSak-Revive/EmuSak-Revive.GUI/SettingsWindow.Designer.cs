namespace EmuSak_Revive.GUI
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties25 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties26 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties27 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties28 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties29 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties30 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties31 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties32 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties33 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties34 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties35 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties36 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.Sounds_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.PlaySounds_CheckBox = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.Help_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.SaveAndClose_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.PasteBinUrl_TextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.Ryujinx_Image = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.Yuzu_Image = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.SelectRyuPath_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.SelectYuzuPath_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.RyuPath_TextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.YuzuPath_TextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.MainWindow_AudioSlider = new Bunifu.UI.WinForms.BunifuHSlider();
            this.Action_Label = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Ryujinx_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yuzu_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Sounds_Label
            // 
            this.Sounds_Label.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.Sounds_Label.AllowParentOverrides = false;
            this.Sounds_Label.AutoEllipsis = false;
            this.Sounds_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Sounds_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Sounds_Label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Sounds_Label.ForeColor = System.Drawing.Color.White;
            this.Sounds_Label.Location = new System.Drawing.Point(40, 331);
            this.Sounds_Label.Name = "Sounds_Label";
            this.Sounds_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Sounds_Label.Size = new System.Drawing.Size(153, 15);
            this.Sounds_Label.TabIndex = 42;
            this.Sounds_Label.Text = "Play sounds on actions (WIP)";
            this.Sounds_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Sounds_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // PlaySounds_CheckBox
            // 
            this.PlaySounds_CheckBox.AllowBindingControlAnimation = true;
            this.PlaySounds_CheckBox.AllowBindingControlColorChanges = false;
            this.PlaySounds_CheckBox.AllowBindingControlLocation = true;
            this.PlaySounds_CheckBox.AllowCheckBoxAnimation = false;
            this.PlaySounds_CheckBox.AllowCheckmarkAnimation = true;
            this.PlaySounds_CheckBox.AllowOnHoverStates = true;
            this.PlaySounds_CheckBox.AutoCheck = true;
            this.PlaySounds_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PlaySounds_CheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PlaySounds_CheckBox.BackgroundImage")));
            this.PlaySounds_CheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlaySounds_CheckBox.BindingControl = this.Sounds_Label;
            this.PlaySounds_CheckBox.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.PlaySounds_CheckBox.BorderRadius = 13;
            this.PlaySounds_CheckBox.Checked = true;
            this.PlaySounds_CheckBox.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.PlaySounds_CheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PlaySounds_CheckBox.CustomCheckmarkImage = null;
            this.PlaySounds_CheckBox.Location = new System.Drawing.Point(12, 326);
            this.PlaySounds_CheckBox.MinimumSize = new System.Drawing.Size(17, 17);
            this.PlaySounds_CheckBox.Name = "PlaySounds_CheckBox";
            this.PlaySounds_CheckBox.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PlaySounds_CheckBox.OnCheck.BorderRadius = 13;
            this.PlaySounds_CheckBox.OnCheck.BorderThickness = 2;
            this.PlaySounds_CheckBox.OnCheck.CheckBoxColor = System.Drawing.Color.Gray;
            this.PlaySounds_CheckBox.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.PlaySounds_CheckBox.OnCheck.CheckmarkThickness = 2;
            this.PlaySounds_CheckBox.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.PlaySounds_CheckBox.OnDisable.BorderRadius = 13;
            this.PlaySounds_CheckBox.OnDisable.BorderThickness = 2;
            this.PlaySounds_CheckBox.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.PlaySounds_CheckBox.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.PlaySounds_CheckBox.OnDisable.CheckmarkThickness = 2;
            this.PlaySounds_CheckBox.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.PlaySounds_CheckBox.OnHoverChecked.BorderRadius = 13;
            this.PlaySounds_CheckBox.OnHoverChecked.BorderThickness = 2;
            this.PlaySounds_CheckBox.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.PlaySounds_CheckBox.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.PlaySounds_CheckBox.OnHoverChecked.CheckmarkThickness = 2;
            this.PlaySounds_CheckBox.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.PlaySounds_CheckBox.OnHoverUnchecked.BorderRadius = 13;
            this.PlaySounds_CheckBox.OnHoverUnchecked.BorderThickness = 1;
            this.PlaySounds_CheckBox.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.PlaySounds_CheckBox.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.PlaySounds_CheckBox.OnUncheck.BorderRadius = 13;
            this.PlaySounds_CheckBox.OnUncheck.BorderThickness = 1;
            this.PlaySounds_CheckBox.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.PlaySounds_CheckBox.Size = new System.Drawing.Size(25, 25);
            this.PlaySounds_CheckBox.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.PlaySounds_CheckBox.TabIndex = 41;
            this.PlaySounds_CheckBox.ThreeState = false;
            this.PlaySounds_CheckBox.ToolTipText = null;
            // 
            // Help_Button
            // 
            this.Help_Button.ActiveImage = null;
            this.Help_Button.AllowAnimations = true;
            this.Help_Button.AllowBuffering = false;
            this.Help_Button.AllowToggling = false;
            this.Help_Button.AllowZooming = false;
            this.Help_Button.AllowZoomingOnFocus = false;
            this.Help_Button.BackColor = System.Drawing.Color.Transparent;
            this.Help_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Help_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Help_Button.ErrorImage")));
            this.Help_Button.FadeWhenInactive = true;
            this.Help_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Help_Button.Image = ((System.Drawing.Image)(resources.GetObject("Help_Button.Image")));
            this.Help_Button.ImageActive = null;
            this.Help_Button.ImageLocation = null;
            this.Help_Button.ImageMargin = 40;
            this.Help_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Help_Button.ImageZoomSize = new System.Drawing.Size(64, 64);
            this.Help_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Help_Button.InitialImage")));
            this.Help_Button.Location = new System.Drawing.Point(552, 205);
            this.Help_Button.Name = "Help_Button";
            this.Help_Button.Rotation = 0;
            this.Help_Button.ShowActiveImage = true;
            this.Help_Button.ShowCursorChanges = true;
            this.Help_Button.ShowImageBorders = false;
            this.Help_Button.ShowSizeMarkers = false;
            this.Help_Button.Size = new System.Drawing.Size(64, 64);
            this.Help_Button.TabIndex = 28;
            this.Help_Button.ToolTipText = "";
            this.Help_Button.WaitOnLoad = false;
            this.Help_Button.Zoom = 40;
            this.Help_Button.ZoomSpeed = 10;
            this.Help_Button.Click += new System.EventHandler(this.Help_Button_Click);
            // 
            // SaveAndClose_Button
            // 
            this.SaveAndClose_Button.AllowAnimations = true;
            this.SaveAndClose_Button.AllowMouseEffects = true;
            this.SaveAndClose_Button.AllowToggling = false;
            this.SaveAndClose_Button.AnimationSpeed = 200;
            this.SaveAndClose_Button.AutoGenerateColors = false;
            this.SaveAndClose_Button.AutoRoundBorders = true;
            this.SaveAndClose_Button.AutoSizeLeftIcon = true;
            this.SaveAndClose_Button.AutoSizeRightIcon = true;
            this.SaveAndClose_Button.BackColor = System.Drawing.Color.Transparent;
            this.SaveAndClose_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveAndClose_Button.BackgroundImage")));
            this.SaveAndClose_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveAndClose_Button.ButtonText = "Save and close";
            this.SaveAndClose_Button.ButtonTextMarginLeft = 0;
            this.SaveAndClose_Button.ColorContrastOnClick = 45;
            this.SaveAndClose_Button.ColorContrastOnHover = 45;
            this.SaveAndClose_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.SaveAndClose_Button.CustomizableEdges = borderEdges3;
            this.SaveAndClose_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SaveAndClose_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.DisabledForecolor = System.Drawing.Color.White;
            this.SaveAndClose_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.SaveAndClose_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveAndClose_Button.ForeColor = System.Drawing.Color.White;
            this.SaveAndClose_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveAndClose_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.SaveAndClose_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.SaveAndClose_Button.IconMarginLeft = 11;
            this.SaveAndClose_Button.IconPadding = 10;
            this.SaveAndClose_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveAndClose_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.SaveAndClose_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.SaveAndClose_Button.IconSize = 25;
            this.SaveAndClose_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.IdleBorderRadius = 35;
            this.SaveAndClose_Button.IdleBorderThickness = 1;
            this.SaveAndClose_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("SaveAndClose_Button.IdleIconLeftImage")));
            this.SaveAndClose_Button.IdleIconRightImage = null;
            this.SaveAndClose_Button.IndicateFocus = false;
            this.SaveAndClose_Button.Location = new System.Drawing.Point(374, 219);
            this.SaveAndClose_Button.Name = "SaveAndClose_Button";
            this.SaveAndClose_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.OnDisabledState.BorderRadius = 1;
            this.SaveAndClose_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveAndClose_Button.OnDisabledState.BorderThickness = 1;
            this.SaveAndClose_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.SaveAndClose_Button.OnDisabledState.IconLeftImage = null;
            this.SaveAndClose_Button.OnDisabledState.IconRightImage = null;
            this.SaveAndClose_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.SaveAndClose_Button.onHoverState.BorderRadius = 1;
            this.SaveAndClose_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveAndClose_Button.onHoverState.BorderThickness = 1;
            this.SaveAndClose_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.SaveAndClose_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.SaveAndClose_Button.onHoverState.IconLeftImage = null;
            this.SaveAndClose_Button.onHoverState.IconRightImage = null;
            this.SaveAndClose_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.OnIdleState.BorderRadius = 1;
            this.SaveAndClose_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveAndClose_Button.OnIdleState.BorderThickness = 1;
            this.SaveAndClose_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SaveAndClose_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.SaveAndClose_Button.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("SaveAndClose_Button.OnIdleState.IconLeftImage")));
            this.SaveAndClose_Button.OnIdleState.IconRightImage = null;
            this.SaveAndClose_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.SaveAndClose_Button.OnPressedState.BorderRadius = 1;
            this.SaveAndClose_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveAndClose_Button.OnPressedState.BorderThickness = 1;
            this.SaveAndClose_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.SaveAndClose_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.SaveAndClose_Button.OnPressedState.IconLeftImage = null;
            this.SaveAndClose_Button.OnPressedState.IconRightImage = null;
            this.SaveAndClose_Button.Size = new System.Drawing.Size(172, 37);
            this.SaveAndClose_Button.TabIndex = 27;
            this.SaveAndClose_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveAndClose_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.SaveAndClose_Button.TextMarginLeft = 0;
            this.SaveAndClose_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.SaveAndClose_Button.UseDefaultRadiusAndThickness = true;
            this.SaveAndClose_Button.Click += new System.EventHandler(this.SaveAndClose_Button_Click);
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
            this.bunifuSeparator2.Location = new System.Drawing.Point(12, 197);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(598, 14);
            this.bunifuSeparator2.TabIndex = 26;
            // 
            // PasteBinUrl_TextBox
            // 
            this.PasteBinUrl_TextBox.AcceptsReturn = false;
            this.PasteBinUrl_TextBox.AcceptsTab = false;
            this.PasteBinUrl_TextBox.AllowDrop = true;
            this.PasteBinUrl_TextBox.AnimationSpeed = 200;
            this.PasteBinUrl_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.PasteBinUrl_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.PasteBinUrl_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.PasteBinUrl_TextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PasteBinUrl_TextBox.BackgroundImage")));
            this.PasteBinUrl_TextBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.PasteBinUrl_TextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PasteBinUrl_TextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.PasteBinUrl_TextBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.PasteBinUrl_TextBox.BorderRadius = 1;
            this.PasteBinUrl_TextBox.BorderThickness = 1;
            this.PasteBinUrl_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PasteBinUrl_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasteBinUrl_TextBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.PasteBinUrl_TextBox.DefaultText = "";
            this.PasteBinUrl_TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.PasteBinUrl_TextBox.ForeColor = System.Drawing.Color.White;
            this.PasteBinUrl_TextBox.HideSelection = true;
            this.PasteBinUrl_TextBox.IconLeft = null;
            this.PasteBinUrl_TextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.PasteBinUrl_TextBox.IconPadding = 10;
            this.PasteBinUrl_TextBox.IconRight = null;
            this.PasteBinUrl_TextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.PasteBinUrl_TextBox.Lines = new string[0];
            this.PasteBinUrl_TextBox.Location = new System.Drawing.Point(12, 219);
            this.PasteBinUrl_TextBox.MaxLength = 32767;
            this.PasteBinUrl_TextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.PasteBinUrl_TextBox.Modified = false;
            this.PasteBinUrl_TextBox.Multiline = false;
            this.PasteBinUrl_TextBox.Name = "PasteBinUrl_TextBox";
            stateProperties25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties25.FillColor = System.Drawing.Color.Empty;
            stateProperties25.ForeColor = System.Drawing.Color.Empty;
            stateProperties25.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasteBinUrl_TextBox.OnActiveState = stateProperties25;
            stateProperties26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties26.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties26.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.PasteBinUrl_TextBox.OnDisabledState = stateProperties26;
            stateProperties27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            stateProperties27.FillColor = System.Drawing.Color.Empty;
            stateProperties27.ForeColor = System.Drawing.Color.Empty;
            stateProperties27.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasteBinUrl_TextBox.OnHoverState = stateProperties27;
            stateProperties28.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties28.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties28.ForeColor = System.Drawing.Color.White;
            stateProperties28.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.PasteBinUrl_TextBox.OnIdleState = stateProperties28;
            this.PasteBinUrl_TextBox.Padding = new System.Windows.Forms.Padding(3);
            this.PasteBinUrl_TextBox.PasswordChar = '\0';
            this.PasteBinUrl_TextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.PasteBinUrl_TextBox.PlaceholderText = "Pastebin link";
            this.PasteBinUrl_TextBox.ReadOnly = false;
            this.PasteBinUrl_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasteBinUrl_TextBox.SelectedText = "";
            this.PasteBinUrl_TextBox.SelectionLength = 0;
            this.PasteBinUrl_TextBox.SelectionStart = 0;
            this.PasteBinUrl_TextBox.ShortcutsEnabled = true;
            this.PasteBinUrl_TextBox.Size = new System.Drawing.Size(356, 37);
            this.PasteBinUrl_TextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.PasteBinUrl_TextBox.TabIndex = 25;
            this.PasteBinUrl_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PasteBinUrl_TextBox.TextMarginBottom = 0;
            this.PasteBinUrl_TextBox.TextMarginLeft = 3;
            this.PasteBinUrl_TextBox.TextMarginTop = 0;
            this.PasteBinUrl_TextBox.TextPlaceholder = "Pastebin link";
            this.PasteBinUrl_TextBox.UseSystemPasswordChar = false;
            this.PasteBinUrl_TextBox.WordWrap = true;
            // 
            // Ryujinx_Image
            // 
            this.Ryujinx_Image.AllowFocused = false;
            this.Ryujinx_Image.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Ryujinx_Image.AutoSizeHeight = true;
            this.Ryujinx_Image.BorderRadius = 50;
            this.Ryujinx_Image.Image = ((System.Drawing.Image)(resources.GetObject("Ryujinx_Image.Image")));
            this.Ryujinx_Image.IsCircle = true;
            this.Ryujinx_Image.Location = new System.Drawing.Point(410, 22);
            this.Ryujinx_Image.Name = "Ryujinx_Image";
            this.Ryujinx_Image.Size = new System.Drawing.Size(100, 100);
            this.Ryujinx_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ryujinx_Image.TabIndex = 24;
            this.Ryujinx_Image.TabStop = false;
            this.Ryujinx_Image.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // Yuzu_Image
            // 
            this.Yuzu_Image.AllowFocused = false;
            this.Yuzu_Image.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Yuzu_Image.AutoSizeHeight = true;
            this.Yuzu_Image.BorderRadius = 50;
            this.Yuzu_Image.Image = ((System.Drawing.Image)(resources.GetObject("Yuzu_Image.Image")));
            this.Yuzu_Image.IsCircle = true;
            this.Yuzu_Image.Location = new System.Drawing.Point(84, 22);
            this.Yuzu_Image.Name = "Yuzu_Image";
            this.Yuzu_Image.Size = new System.Drawing.Size(100, 100);
            this.Yuzu_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Yuzu_Image.TabIndex = 23;
            this.Yuzu_Image.TabStop = false;
            this.Yuzu_Image.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // SelectRyuPath_Button
            // 
            this.SelectRyuPath_Button.ActiveImage = null;
            this.SelectRyuPath_Button.AllowAnimations = true;
            this.SelectRyuPath_Button.AllowBuffering = false;
            this.SelectRyuPath_Button.AllowToggling = false;
            this.SelectRyuPath_Button.AllowZooming = false;
            this.SelectRyuPath_Button.AllowZoomingOnFocus = false;
            this.SelectRyuPath_Button.BackColor = System.Drawing.Color.Transparent;
            this.SelectRyuPath_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SelectRyuPath_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("SelectRyuPath_Button.ErrorImage")));
            this.SelectRyuPath_Button.FadeWhenInactive = true;
            this.SelectRyuPath_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.SelectRyuPath_Button.Image = ((System.Drawing.Image)(resources.GetObject("SelectRyuPath_Button.Image")));
            this.SelectRyuPath_Button.ImageActive = null;
            this.SelectRyuPath_Button.ImageLocation = null;
            this.SelectRyuPath_Button.ImageMargin = 40;
            this.SelectRyuPath_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.SelectRyuPath_Button.ImageZoomSize = new System.Drawing.Size(64, 64);
            this.SelectRyuPath_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("SelectRyuPath_Button.InitialImage")));
            this.SelectRyuPath_Button.Location = new System.Drawing.Point(552, 145);
            this.SelectRyuPath_Button.Name = "SelectRyuPath_Button";
            this.SelectRyuPath_Button.Rotation = 0;
            this.SelectRyuPath_Button.ShowActiveImage = true;
            this.SelectRyuPath_Button.ShowCursorChanges = true;
            this.SelectRyuPath_Button.ShowImageBorders = false;
            this.SelectRyuPath_Button.ShowSizeMarkers = false;
            this.SelectRyuPath_Button.Size = new System.Drawing.Size(64, 64);
            this.SelectRyuPath_Button.TabIndex = 22;
            this.SelectRyuPath_Button.ToolTipText = "";
            this.SelectRyuPath_Button.WaitOnLoad = false;
            this.SelectRyuPath_Button.Zoom = 40;
            this.SelectRyuPath_Button.ZoomSpeed = 10;
            this.SelectRyuPath_Button.Click += new System.EventHandler(this.SelectRyuPath_Button_Click);
            // 
            // SelectYuzuPath_Button
            // 
            this.SelectYuzuPath_Button.ActiveImage = null;
            this.SelectYuzuPath_Button.AllowAnimations = true;
            this.SelectYuzuPath_Button.AllowBuffering = false;
            this.SelectYuzuPath_Button.AllowToggling = false;
            this.SelectYuzuPath_Button.AllowZooming = false;
            this.SelectYuzuPath_Button.AllowZoomingOnFocus = false;
            this.SelectYuzuPath_Button.BackColor = System.Drawing.Color.Transparent;
            this.SelectYuzuPath_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SelectYuzuPath_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("SelectYuzuPath_Button.ErrorImage")));
            this.SelectYuzuPath_Button.FadeWhenInactive = true;
            this.SelectYuzuPath_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.SelectYuzuPath_Button.Image = ((System.Drawing.Image)(resources.GetObject("SelectYuzuPath_Button.Image")));
            this.SelectYuzuPath_Button.ImageActive = null;
            this.SelectYuzuPath_Button.ImageLocation = null;
            this.SelectYuzuPath_Button.ImageMargin = 40;
            this.SelectYuzuPath_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.SelectYuzuPath_Button.ImageZoomSize = new System.Drawing.Size(64, 64);
            this.SelectYuzuPath_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("SelectYuzuPath_Button.InitialImage")));
            this.SelectYuzuPath_Button.Location = new System.Drawing.Point(234, 145);
            this.SelectYuzuPath_Button.Name = "SelectYuzuPath_Button";
            this.SelectYuzuPath_Button.Rotation = 0;
            this.SelectYuzuPath_Button.ShowActiveImage = true;
            this.SelectYuzuPath_Button.ShowCursorChanges = true;
            this.SelectYuzuPath_Button.ShowImageBorders = false;
            this.SelectYuzuPath_Button.ShowSizeMarkers = false;
            this.SelectYuzuPath_Button.Size = new System.Drawing.Size(64, 64);
            this.SelectYuzuPath_Button.TabIndex = 21;
            this.SelectYuzuPath_Button.ToolTipText = "";
            this.SelectYuzuPath_Button.WaitOnLoad = false;
            this.SelectYuzuPath_Button.Zoom = 40;
            this.SelectYuzuPath_Button.ZoomSpeed = 10;
            this.SelectYuzuPath_Button.Click += new System.EventHandler(this.SelectYuzuPath_Button_Click);
            // 
            // RyuPath_TextBox
            // 
            this.RyuPath_TextBox.AcceptsReturn = false;
            this.RyuPath_TextBox.AcceptsTab = false;
            this.RyuPath_TextBox.AllowDrop = true;
            this.RyuPath_TextBox.AnimationSpeed = 200;
            this.RyuPath_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.RyuPath_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.RyuPath_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.RyuPath_TextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RyuPath_TextBox.BackgroundImage")));
            this.RyuPath_TextBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.RyuPath_TextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.RyuPath_TextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.RyuPath_TextBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.RyuPath_TextBox.BorderRadius = 1;
            this.RyuPath_TextBox.BorderThickness = 1;
            this.RyuPath_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.RyuPath_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RyuPath_TextBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.RyuPath_TextBox.DefaultText = "";
            this.RyuPath_TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.RyuPath_TextBox.ForeColor = System.Drawing.Color.White;
            this.RyuPath_TextBox.HideSelection = true;
            this.RyuPath_TextBox.IconLeft = null;
            this.RyuPath_TextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.RyuPath_TextBox.IconPadding = 10;
            this.RyuPath_TextBox.IconRight = null;
            this.RyuPath_TextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.RyuPath_TextBox.Lines = new string[0];
            this.RyuPath_TextBox.Location = new System.Drawing.Point(330, 157);
            this.RyuPath_TextBox.MaxLength = 32767;
            this.RyuPath_TextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.RyuPath_TextBox.Modified = false;
            this.RyuPath_TextBox.Multiline = false;
            this.RyuPath_TextBox.Name = "RyuPath_TextBox";
            stateProperties29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties29.FillColor = System.Drawing.Color.Empty;
            stateProperties29.ForeColor = System.Drawing.Color.Empty;
            stateProperties29.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.RyuPath_TextBox.OnActiveState = stateProperties29;
            stateProperties30.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties30.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties30.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.RyuPath_TextBox.OnDisabledState = stateProperties30;
            stateProperties31.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            stateProperties31.FillColor = System.Drawing.Color.Empty;
            stateProperties31.ForeColor = System.Drawing.Color.Empty;
            stateProperties31.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.RyuPath_TextBox.OnHoverState = stateProperties31;
            stateProperties32.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties32.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties32.ForeColor = System.Drawing.Color.White;
            stateProperties32.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.RyuPath_TextBox.OnIdleState = stateProperties32;
            this.RyuPath_TextBox.Padding = new System.Windows.Forms.Padding(3);
            this.RyuPath_TextBox.PasswordChar = '\0';
            this.RyuPath_TextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.RyuPath_TextBox.PlaceholderText = "Ryujinx portable path";
            this.RyuPath_TextBox.ReadOnly = false;
            this.RyuPath_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.RyuPath_TextBox.SelectedText = "";
            this.RyuPath_TextBox.SelectionLength = 0;
            this.RyuPath_TextBox.SelectionStart = 0;
            this.RyuPath_TextBox.ShortcutsEnabled = true;
            this.RyuPath_TextBox.Size = new System.Drawing.Size(216, 37);
            this.RyuPath_TextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.RyuPath_TextBox.TabIndex = 20;
            this.RyuPath_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RyuPath_TextBox.TextMarginBottom = 0;
            this.RyuPath_TextBox.TextMarginLeft = 3;
            this.RyuPath_TextBox.TextMarginTop = 0;
            this.RyuPath_TextBox.TextPlaceholder = "Ryujinx portable path";
            this.RyuPath_TextBox.UseSystemPasswordChar = false;
            this.RyuPath_TextBox.WordWrap = true;
            // 
            // YuzuPath_TextBox
            // 
            this.YuzuPath_TextBox.AcceptsReturn = false;
            this.YuzuPath_TextBox.AcceptsTab = false;
            this.YuzuPath_TextBox.AllowDrop = true;
            this.YuzuPath_TextBox.AnimationSpeed = 200;
            this.YuzuPath_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.YuzuPath_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.YuzuPath_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.YuzuPath_TextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("YuzuPath_TextBox.BackgroundImage")));
            this.YuzuPath_TextBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.YuzuPath_TextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.YuzuPath_TextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.YuzuPath_TextBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.YuzuPath_TextBox.BorderRadius = 1;
            this.YuzuPath_TextBox.BorderThickness = 1;
            this.YuzuPath_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.YuzuPath_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.YuzuPath_TextBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.YuzuPath_TextBox.DefaultText = "";
            this.YuzuPath_TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.YuzuPath_TextBox.ForeColor = System.Drawing.Color.White;
            this.YuzuPath_TextBox.HideSelection = true;
            this.YuzuPath_TextBox.IconLeft = null;
            this.YuzuPath_TextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.YuzuPath_TextBox.IconPadding = 10;
            this.YuzuPath_TextBox.IconRight = null;
            this.YuzuPath_TextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.YuzuPath_TextBox.Lines = new string[0];
            this.YuzuPath_TextBox.Location = new System.Drawing.Point(12, 157);
            this.YuzuPath_TextBox.MaxLength = 32767;
            this.YuzuPath_TextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.YuzuPath_TextBox.Modified = false;
            this.YuzuPath_TextBox.Multiline = false;
            this.YuzuPath_TextBox.Name = "YuzuPath_TextBox";
            stateProperties33.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties33.FillColor = System.Drawing.Color.Empty;
            stateProperties33.ForeColor = System.Drawing.Color.Empty;
            stateProperties33.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.YuzuPath_TextBox.OnActiveState = stateProperties33;
            stateProperties34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties34.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties34.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.YuzuPath_TextBox.OnDisabledState = stateProperties34;
            stateProperties35.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            stateProperties35.FillColor = System.Drawing.Color.Empty;
            stateProperties35.ForeColor = System.Drawing.Color.Empty;
            stateProperties35.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.YuzuPath_TextBox.OnHoverState = stateProperties35;
            stateProperties36.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            stateProperties36.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties36.ForeColor = System.Drawing.Color.White;
            stateProperties36.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.YuzuPath_TextBox.OnIdleState = stateProperties36;
            this.YuzuPath_TextBox.Padding = new System.Windows.Forms.Padding(3);
            this.YuzuPath_TextBox.PasswordChar = '\0';
            this.YuzuPath_TextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.YuzuPath_TextBox.PlaceholderText = "Yuzu portable path";
            this.YuzuPath_TextBox.ReadOnly = false;
            this.YuzuPath_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.YuzuPath_TextBox.SelectedText = "";
            this.YuzuPath_TextBox.SelectionLength = 0;
            this.YuzuPath_TextBox.SelectionStart = 0;
            this.YuzuPath_TextBox.ShortcutsEnabled = true;
            this.YuzuPath_TextBox.Size = new System.Drawing.Size(216, 37);
            this.YuzuPath_TextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.YuzuPath_TextBox.TabIndex = 19;
            this.YuzuPath_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.YuzuPath_TextBox.TextMarginBottom = 0;
            this.YuzuPath_TextBox.TextMarginLeft = 3;
            this.YuzuPath_TextBox.TextMarginTop = 0;
            this.YuzuPath_TextBox.TextPlaceholder = "Yuzu portable path";
            this.YuzuPath_TextBox.UseSystemPasswordChar = false;
            this.YuzuPath_TextBox.WordWrap = true;
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(300, 6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunifuSeparator1.Size = new System.Drawing.Size(14, 188);
            this.bunifuSeparator1.TabIndex = 16;
            // 
            // MainWindow_AudioSlider
            // 
            this.MainWindow_AudioSlider.AllowCursorChanges = true;
            this.MainWindow_AudioSlider.AllowHomeEndKeysDetection = false;
            this.MainWindow_AudioSlider.AllowIncrementalClickMoves = true;
            this.MainWindow_AudioSlider.AllowMouseDownEffects = false;
            this.MainWindow_AudioSlider.AllowMouseHoverEffects = false;
            this.MainWindow_AudioSlider.AllowScrollingAnimations = true;
            this.MainWindow_AudioSlider.AllowScrollKeysDetection = true;
            this.MainWindow_AudioSlider.AllowScrollOptionsMenu = true;
            this.MainWindow_AudioSlider.AllowShrinkingOnFocusLost = false;
            this.MainWindow_AudioSlider.BackColor = System.Drawing.Color.Transparent;
            this.MainWindow_AudioSlider.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainWindow_AudioSlider.BackgroundImage")));
            this.MainWindow_AudioSlider.BindingContainer = null;
            this.MainWindow_AudioSlider.BorderRadius = 2;
            this.MainWindow_AudioSlider.BorderThickness = 1;
            this.MainWindow_AudioSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainWindow_AudioSlider.DrawThickBorder = false;
            this.MainWindow_AudioSlider.DurationBeforeShrink = 2000;
            this.MainWindow_AudioSlider.ElapsedColor = System.Drawing.Color.Silver;
            this.MainWindow_AudioSlider.LargeChange = 10;
            this.MainWindow_AudioSlider.Location = new System.Drawing.Point(12, 289);
            this.MainWindow_AudioSlider.Maximum = 100;
            this.MainWindow_AudioSlider.Minimum = 0;
            this.MainWindow_AudioSlider.MinimumSize = new System.Drawing.Size(0, 31);
            this.MainWindow_AudioSlider.MinimumThumbLength = 18;
            this.MainWindow_AudioSlider.Name = "MainWindow_AudioSlider";
            this.MainWindow_AudioSlider.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.MainWindow_AudioSlider.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.MainWindow_AudioSlider.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.MainWindow_AudioSlider.ScrollBarBorderColor = System.Drawing.Color.White;
            this.MainWindow_AudioSlider.ScrollBarColor = System.Drawing.Color.White;
            this.MainWindow_AudioSlider.ShrinkSizeLimit = 3;
            this.MainWindow_AudioSlider.Size = new System.Drawing.Size(216, 31);
            this.MainWindow_AudioSlider.SliderColor = System.Drawing.Color.White;
            this.MainWindow_AudioSlider.SliderStyle = Bunifu.UI.WinForms.BunifuHSlider.SliderStyles.Thin;
            this.MainWindow_AudioSlider.SliderThumbStyle = Utilities.BunifuSlider.BunifuHScrollBar.SliderThumbStyles.Circular;
            this.MainWindow_AudioSlider.SmallChange = 1;
            this.MainWindow_AudioSlider.TabIndex = 43;
            this.MainWindow_AudioSlider.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MainWindow_AudioSlider.ThumbFillColor = System.Drawing.SystemColors.Control;
            this.MainWindow_AudioSlider.ThumbLength = 21;
            this.MainWindow_AudioSlider.ThumbMargin = 1;
            this.MainWindow_AudioSlider.ThumbSize = Bunifu.UI.WinForms.BunifuHSlider.ThumbSizes.Medium;
            this.MainWindow_AudioSlider.ThumbStyle = Bunifu.UI.WinForms.BunifuHSlider.ThumbStyles.Outline;
            this.MainWindow_AudioSlider.Value = 0;
            this.MainWindow_AudioSlider.Scroll += new System.EventHandler<Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs>(this.MainWindow_AudioSlider_Scroll);
            // 
            // Action_Label
            // 
            this.Action_Label.AllowParentOverrides = false;
            this.Action_Label.AutoEllipsis = false;
            this.Action_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Action_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Action_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.Action_Label.ForeColor = System.Drawing.Color.White;
            this.Action_Label.Location = new System.Drawing.Point(54, 269);
            this.Action_Label.Name = "Action_Label";
            this.Action_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Action_Label.Size = new System.Drawing.Size(127, 14);
            this.Action_Label.TabIndex = 44;
            this.Action_Label.Text = "Main window sound";
            this.Action_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Action_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(622, 363);
            this.Controls.Add(this.Action_Label);
            this.Controls.Add(this.MainWindow_AudioSlider);
            this.Controls.Add(this.Sounds_Label);
            this.Controls.Add(this.PlaySounds_CheckBox);
            this.Controls.Add(this.Help_Button);
            this.Controls.Add(this.SaveAndClose_Button);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.PasteBinUrl_TextBox);
            this.Controls.Add(this.Ryujinx_Image);
            this.Controls.Add(this.Yuzu_Image);
            this.Controls.Add(this.SelectRyuPath_Button);
            this.Controls.Add(this.SelectYuzuPath_Button);
            this.Controls.Add(this.RyuPath_TextBox);
            this.Controls.Add(this.YuzuPath_TextBox);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ryujinx_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Yuzu_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuTextBox YuzuPath_TextBox;
        private Bunifu.UI.WinForms.BunifuTextBox RyuPath_TextBox;
        private Bunifu.UI.WinForms.BunifuImageButton SelectYuzuPath_Button;
        private Bunifu.UI.WinForms.BunifuImageButton SelectRyuPath_Button;
        private Bunifu.UI.WinForms.BunifuPictureBox Yuzu_Image;
        private Bunifu.UI.WinForms.BunifuPictureBox Ryujinx_Image;
        private Bunifu.UI.WinForms.BunifuTextBox PasteBinUrl_TextBox;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton SaveAndClose_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Help_Button;
        private Bunifu.UI.WinForms.BunifuCheckBox PlaySounds_CheckBox;
        private Bunifu.UI.WinForms.BunifuLabel Sounds_Label;
        private Bunifu.UI.WinForms.BunifuHSlider MainWindow_AudioSlider;
        private Bunifu.UI.WinForms.BunifuLabel Action_Label;
    }
}