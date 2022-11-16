namespace EmuSak_Revive.GUI
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.PanelContainer = new Telerik.WinControls.UI.RadScrollablePanelContainer();
            this.Firmware_DropDown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.Games_FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Download_ProgressBar = new Telerik.WinControls.UI.RadProgressBar();
            this.crystalDarkTheme1 = new Telerik.WinControls.Themes.CrystalDarkTheme();
            this.Keys_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DownloadFirmware_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuVScrollBar1 = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.About_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Update_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Configure_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Discord_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.Main_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Download_ProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelContainer
            // 
            this.PanelContainer.AutoScroll = false;
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Size = new System.Drawing.Size(198, 98);
            // 
            // Firmware_DropDown
            // 
            this.Firmware_DropDown.BackColor = System.Drawing.Color.Transparent;
            this.Firmware_DropDown.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.BorderRadius = 10;
            this.Firmware_DropDown.Color = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.Firmware_DropDown.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.DisabledForeColor = System.Drawing.Color.White;
            this.Firmware_DropDown.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.Firmware_DropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Firmware_DropDown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.Firmware_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Firmware_DropDown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Firmware_DropDown.FillDropDown = true;
            this.Firmware_DropDown.FillIndicator = false;
            this.Firmware_DropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Firmware_DropDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Firmware_DropDown.ForeColor = System.Drawing.Color.White;
            this.Firmware_DropDown.FormattingEnabled = true;
            this.Firmware_DropDown.Icon = null;
            this.Firmware_DropDown.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Firmware_DropDown.IndicatorColor = System.Drawing.Color.Gray;
            this.Firmware_DropDown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.Firmware_DropDown.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Firmware_DropDown.ItemForeColor = System.Drawing.Color.White;
            this.Firmware_DropDown.ItemHeight = 26;
            this.Firmware_DropDown.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Firmware_DropDown.ItemHighLightForeColor = System.Drawing.Color.White;
            this.Firmware_DropDown.ItemTopMargin = 3;
            this.Firmware_DropDown.Location = new System.Drawing.Point(128, 12);
            this.Firmware_DropDown.Name = "Firmware_DropDown";
            this.Firmware_DropDown.Size = new System.Drawing.Size(294, 32);
            this.Firmware_DropDown.TabIndex = 13;
            this.Firmware_DropDown.Text = null;
            this.Firmware_DropDown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Firmware_DropDown.TextLeftMargin = 5;
            this.Firmware_DropDown.SelectedIndexChanged += new System.EventHandler(this.Firmware_DropDown_SelectedIndexChanged);
            // 
            // Main_Panel
            // 
            this.Main_Panel.Controls.Add(this.Games_FlowPanel);
            this.Main_Panel.Location = new System.Drawing.Point(128, 50);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(611, 323);
            this.Main_Panel.TabIndex = 16;
            // 
            // Games_FlowPanel
            // 
            this.Games_FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Games_FlowPanel.Location = new System.Drawing.Point(0, 0);
            this.Games_FlowPanel.Name = "Games_FlowPanel";
            this.Games_FlowPanel.Size = new System.Drawing.Size(611, 323);
            this.Games_FlowPanel.TabIndex = 18;
            this.Games_FlowPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Games_FlowPanel_Scroll);
            // 
            // Download_ProgressBar
            // 
            this.Download_ProgressBar.Location = new System.Drawing.Point(128, 379);
            this.Download_ProgressBar.Name = "Download_ProgressBar";
            this.Download_ProgressBar.Size = new System.Drawing.Size(611, 19);
            this.Download_ProgressBar.TabIndex = 18;
            this.Download_ProgressBar.ThemeName = "CrystalDark";
            // 
            // Keys_Button
            // 
            this.Keys_Button.AllowAnimations = true;
            this.Keys_Button.AllowMouseEffects = true;
            this.Keys_Button.AllowToggling = false;
            this.Keys_Button.AnimationSpeed = 200;
            this.Keys_Button.AutoGenerateColors = false;
            this.Keys_Button.AutoRoundBorders = true;
            this.Keys_Button.AutoSizeLeftIcon = true;
            this.Keys_Button.AutoSizeRightIcon = true;
            this.Keys_Button.BackColor = System.Drawing.Color.Transparent;
            this.Keys_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Keys_Button.BackgroundImage")));
            this.Keys_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Keys_Button.ButtonText = "Download Keys";
            this.Keys_Button.ButtonTextMarginLeft = 0;
            this.Keys_Button.ColorContrastOnClick = 45;
            this.Keys_Button.ColorContrastOnHover = 45;
            this.Keys_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.Keys_Button.CustomizableEdges = borderEdges1;
            this.Keys_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Keys_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.DisabledForecolor = System.Drawing.Color.White;
            this.Keys_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Keys_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Keys_Button.ForeColor = System.Drawing.Color.White;
            this.Keys_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Keys_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.Keys_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.Keys_Button.IconMarginLeft = 11;
            this.Keys_Button.IconPadding = 10;
            this.Keys_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Keys_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.Keys_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.Keys_Button.IconSize = 25;
            this.Keys_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.IdleBorderRadius = 30;
            this.Keys_Button.IdleBorderThickness = 1;
            this.Keys_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("Keys_Button.IdleIconLeftImage")));
            this.Keys_Button.IdleIconRightImage = null;
            this.Keys_Button.IndicateFocus = false;
            this.Keys_Button.Location = new System.Drawing.Point(609, 12);
            this.Keys_Button.Name = "Keys_Button";
            this.Keys_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.OnDisabledState.BorderRadius = 1;
            this.Keys_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Keys_Button.OnDisabledState.BorderThickness = 1;
            this.Keys_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.Keys_Button.OnDisabledState.IconLeftImage = null;
            this.Keys_Button.OnDisabledState.IconRightImage = null;
            this.Keys_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Keys_Button.onHoverState.BorderRadius = 1;
            this.Keys_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Keys_Button.onHoverState.BorderThickness = 1;
            this.Keys_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Keys_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Keys_Button.onHoverState.IconLeftImage = null;
            this.Keys_Button.onHoverState.IconRightImage = null;
            this.Keys_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.OnIdleState.BorderRadius = 1;
            this.Keys_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Keys_Button.OnIdleState.BorderThickness = 1;
            this.Keys_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Keys_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Keys_Button.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("Keys_Button.OnIdleState.IconLeftImage")));
            this.Keys_Button.OnIdleState.IconRightImage = null;
            this.Keys_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Keys_Button.OnPressedState.BorderRadius = 1;
            this.Keys_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Keys_Button.OnPressedState.BorderThickness = 1;
            this.Keys_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Keys_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Keys_Button.OnPressedState.IconLeftImage = null;
            this.Keys_Button.OnPressedState.IconRightImage = null;
            this.Keys_Button.Size = new System.Drawing.Size(152, 32);
            this.Keys_Button.TabIndex = 15;
            this.Keys_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Keys_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Keys_Button.TextMarginLeft = 0;
            this.Keys_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.Keys_Button.UseDefaultRadiusAndThickness = true;
            this.Keys_Button.Click += new System.EventHandler(this.Keys_Button_Click);
            // 
            // DownloadFirmware_Button
            // 
            this.DownloadFirmware_Button.AllowAnimations = true;
            this.DownloadFirmware_Button.AllowMouseEffects = true;
            this.DownloadFirmware_Button.AllowToggling = false;
            this.DownloadFirmware_Button.AnimationSpeed = 200;
            this.DownloadFirmware_Button.AutoGenerateColors = false;
            this.DownloadFirmware_Button.AutoRoundBorders = true;
            this.DownloadFirmware_Button.AutoSizeLeftIcon = true;
            this.DownloadFirmware_Button.AutoSizeRightIcon = true;
            this.DownloadFirmware_Button.BackColor = System.Drawing.Color.Transparent;
            this.DownloadFirmware_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DownloadFirmware_Button.BackgroundImage")));
            this.DownloadFirmware_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadFirmware_Button.ButtonText = "Download Firmware";
            this.DownloadFirmware_Button.ButtonTextMarginLeft = 0;
            this.DownloadFirmware_Button.ColorContrastOnClick = 45;
            this.DownloadFirmware_Button.ColorContrastOnHover = 45;
            this.DownloadFirmware_Button.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.DownloadFirmware_Button.CustomizableEdges = borderEdges2;
            this.DownloadFirmware_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DownloadFirmware_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.DisabledForecolor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.DownloadFirmware_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DownloadFirmware_Button.ForeColor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadFirmware_Button.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.DownloadFirmware_Button.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.DownloadFirmware_Button.IconMarginLeft = 11;
            this.DownloadFirmware_Button.IconPadding = 10;
            this.DownloadFirmware_Button.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DownloadFirmware_Button.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.DownloadFirmware_Button.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.DownloadFirmware_Button.IconSize = 25;
            this.DownloadFirmware_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.IdleBorderRadius = 30;
            this.DownloadFirmware_Button.IdleBorderThickness = 1;
            this.DownloadFirmware_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("DownloadFirmware_Button.IdleIconLeftImage")));
            this.DownloadFirmware_Button.IdleIconRightImage = null;
            this.DownloadFirmware_Button.IndicateFocus = false;
            this.DownloadFirmware_Button.Location = new System.Drawing.Point(428, 12);
            this.DownloadFirmware_Button.Name = "DownloadFirmware_Button";
            this.DownloadFirmware_Button.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.OnDisabledState.BorderRadius = 1;
            this.DownloadFirmware_Button.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadFirmware_Button.OnDisabledState.BorderThickness = 1;
            this.DownloadFirmware_Button.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.OnDisabledState.ForeColor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.OnDisabledState.IconLeftImage = null;
            this.DownloadFirmware_Button.OnDisabledState.IconRightImage = null;
            this.DownloadFirmware_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.DownloadFirmware_Button.onHoverState.BorderRadius = 1;
            this.DownloadFirmware_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadFirmware_Button.onHoverState.BorderThickness = 1;
            this.DownloadFirmware_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.DownloadFirmware_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.onHoverState.IconLeftImage = null;
            this.DownloadFirmware_Button.onHoverState.IconRightImage = null;
            this.DownloadFirmware_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.OnIdleState.BorderRadius = 1;
            this.DownloadFirmware_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadFirmware_Button.OnIdleState.BorderThickness = 1;
            this.DownloadFirmware_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.DownloadFirmware_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("DownloadFirmware_Button.OnIdleState.IconLeftImage")));
            this.DownloadFirmware_Button.OnIdleState.IconRightImage = null;
            this.DownloadFirmware_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DownloadFirmware_Button.OnPressedState.BorderRadius = 1;
            this.DownloadFirmware_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.DownloadFirmware_Button.OnPressedState.BorderThickness = 1;
            this.DownloadFirmware_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DownloadFirmware_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.DownloadFirmware_Button.OnPressedState.IconLeftImage = null;
            this.DownloadFirmware_Button.OnPressedState.IconRightImage = null;
            this.DownloadFirmware_Button.Size = new System.Drawing.Size(175, 32);
            this.DownloadFirmware_Button.TabIndex = 14;
            this.DownloadFirmware_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DownloadFirmware_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.DownloadFirmware_Button.TextMarginLeft = 0;
            this.DownloadFirmware_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.DownloadFirmware_Button.UseDefaultRadiusAndThickness = true;
            this.DownloadFirmware_Button.Click += new System.EventHandler(this.DownloadFirmware_Button_Click);
            // 
            // bunifuVScrollBar1
            // 
            this.bunifuVScrollBar1.AllowCursorChanges = true;
            this.bunifuVScrollBar1.AllowHomeEndKeysDetection = false;
            this.bunifuVScrollBar1.AllowIncrementalClickMoves = true;
            this.bunifuVScrollBar1.AllowMouseDownEffects = true;
            this.bunifuVScrollBar1.AllowMouseHoverEffects = true;
            this.bunifuVScrollBar1.AllowScrollingAnimations = true;
            this.bunifuVScrollBar1.AllowScrollKeysDetection = true;
            this.bunifuVScrollBar1.AllowScrollOptionsMenu = true;
            this.bunifuVScrollBar1.AllowShrinkingOnFocusLost = false;
            this.bunifuVScrollBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bunifuVScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuVScrollBar1.BackgroundImage")));
            this.bunifuVScrollBar1.BindingContainer = this.Games_FlowPanel;
            this.bunifuVScrollBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bunifuVScrollBar1.BorderRadius = 14;
            this.bunifuVScrollBar1.BorderThickness = 1;
            this.bunifuVScrollBar1.DurationBeforeShrink = 2000;
            this.bunifuVScrollBar1.LargeChange = 10;
            this.bunifuVScrollBar1.Location = new System.Drawing.Point(745, 50);
            this.bunifuVScrollBar1.Maximum = 100;
            this.bunifuVScrollBar1.Minimum = 0;
            this.bunifuVScrollBar1.MinimumThumbLength = 18;
            this.bunifuVScrollBar1.Name = "bunifuVScrollBar1";
            this.bunifuVScrollBar1.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuVScrollBar1.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bunifuVScrollBar1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bunifuVScrollBar1.ShrinkSizeLimit = 3;
            this.bunifuVScrollBar1.Size = new System.Drawing.Size(17, 323);
            this.bunifuVScrollBar1.SmallChange = 1;
            this.bunifuVScrollBar1.TabIndex = 17;
            this.bunifuVScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.bunifuVScrollBar1.ThumbLength = 31;
            this.bunifuVScrollBar1.ThumbMargin = 1;
            this.bunifuVScrollBar1.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar1.Value = 0;
            // 
            // About_Button
            // 
            this.About_Button.ActiveImage = null;
            this.About_Button.AllowAnimations = true;
            this.About_Button.AllowBuffering = false;
            this.About_Button.AllowToggling = false;
            this.About_Button.AllowZooming = false;
            this.About_Button.AllowZoomingOnFocus = false;
            this.About_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.About_Button.BackColor = System.Drawing.Color.Transparent;
            this.About_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.About_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("About_Button.ErrorImage")));
            this.About_Button.FadeWhenInactive = true;
            this.About_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.About_Button.Image = ((System.Drawing.Image)(resources.GetObject("About_Button.Image")));
            this.About_Button.ImageActive = null;
            this.About_Button.ImageLocation = null;
            this.About_Button.ImageMargin = 40;
            this.About_Button.ImageSize = new System.Drawing.Size(50, 50);
            this.About_Button.ImageZoomSize = new System.Drawing.Size(90, 90);
            this.About_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("About_Button.InitialImage")));
            this.About_Button.Location = new System.Drawing.Point(12, 308);
            this.About_Button.Name = "About_Button";
            this.About_Button.Rotation = 0;
            this.About_Button.ShowActiveImage = true;
            this.About_Button.ShowCursorChanges = true;
            this.About_Button.ShowImageBorders = false;
            this.About_Button.ShowSizeMarkers = false;
            this.About_Button.Size = new System.Drawing.Size(90, 90);
            this.About_Button.TabIndex = 9;
            this.About_Button.ToolTipText = "";
            this.About_Button.WaitOnLoad = false;
            this.About_Button.Zoom = 40;
            this.About_Button.ZoomSpeed = 10;
            this.About_Button.Click += new System.EventHandler(this.About_Button_Click);
            // 
            // Update_Button
            // 
            this.Update_Button.ActiveImage = null;
            this.Update_Button.AllowAnimations = true;
            this.Update_Button.AllowBuffering = false;
            this.Update_Button.AllowToggling = false;
            this.Update_Button.AllowZooming = false;
            this.Update_Button.AllowZoomingOnFocus = false;
            this.Update_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Update_Button.BackColor = System.Drawing.Color.Transparent;
            this.Update_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Update_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Update_Button.ErrorImage")));
            this.Update_Button.FadeWhenInactive = true;
            this.Update_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Update_Button.Image = ((System.Drawing.Image)(resources.GetObject("Update_Button.Image")));
            this.Update_Button.ImageActive = null;
            this.Update_Button.ImageLocation = null;
            this.Update_Button.ImageMargin = 40;
            this.Update_Button.ImageSize = new System.Drawing.Size(50, 50);
            this.Update_Button.ImageZoomSize = new System.Drawing.Size(90, 90);
            this.Update_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Update_Button.InitialImage")));
            this.Update_Button.Location = new System.Drawing.Point(12, 212);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Rotation = 0;
            this.Update_Button.ShowActiveImage = true;
            this.Update_Button.ShowCursorChanges = true;
            this.Update_Button.ShowImageBorders = false;
            this.Update_Button.ShowSizeMarkers = false;
            this.Update_Button.Size = new System.Drawing.Size(90, 90);
            this.Update_Button.TabIndex = 8;
            this.Update_Button.ToolTipText = "";
            this.Update_Button.WaitOnLoad = false;
            this.Update_Button.Zoom = 40;
            this.Update_Button.ZoomSpeed = 10;
            this.Update_Button.Click += new System.EventHandler(this.Update_Button_Click);
            // 
            // Configure_Button
            // 
            this.Configure_Button.ActiveImage = null;
            this.Configure_Button.AllowAnimations = true;
            this.Configure_Button.AllowBuffering = false;
            this.Configure_Button.AllowToggling = false;
            this.Configure_Button.AllowZooming = false;
            this.Configure_Button.AllowZoomingOnFocus = false;
            this.Configure_Button.BackColor = System.Drawing.Color.Transparent;
            this.Configure_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Configure_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Configure_Button.ErrorImage")));
            this.Configure_Button.FadeWhenInactive = true;
            this.Configure_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Configure_Button.Image = ((System.Drawing.Image)(resources.GetObject("Configure_Button.Image")));
            this.Configure_Button.ImageActive = null;
            this.Configure_Button.ImageLocation = null;
            this.Configure_Button.ImageMargin = 40;
            this.Configure_Button.ImageSize = new System.Drawing.Size(50, 50);
            this.Configure_Button.ImageZoomSize = new System.Drawing.Size(90, 90);
            this.Configure_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Configure_Button.InitialImage")));
            this.Configure_Button.Location = new System.Drawing.Point(12, 116);
            this.Configure_Button.Name = "Configure_Button";
            this.Configure_Button.Rotation = 0;
            this.Configure_Button.ShowActiveImage = true;
            this.Configure_Button.ShowCursorChanges = true;
            this.Configure_Button.ShowImageBorders = false;
            this.Configure_Button.ShowSizeMarkers = false;
            this.Configure_Button.Size = new System.Drawing.Size(90, 90);
            this.Configure_Button.TabIndex = 7;
            this.Configure_Button.ToolTipText = "";
            this.Configure_Button.WaitOnLoad = false;
            this.Configure_Button.Zoom = 40;
            this.Configure_Button.ZoomSpeed = 10;
            this.Configure_Button.Click += new System.EventHandler(this.Configure_Button_Click);
            // 
            // Discord_Button
            // 
            this.Discord_Button.ActiveImage = null;
            this.Discord_Button.AllowAnimations = true;
            this.Discord_Button.AllowBuffering = false;
            this.Discord_Button.AllowToggling = false;
            this.Discord_Button.AllowZooming = false;
            this.Discord_Button.AllowZoomingOnFocus = false;
            this.Discord_Button.BackColor = System.Drawing.Color.Transparent;
            this.Discord_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Discord_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Discord_Button.ErrorImage")));
            this.Discord_Button.FadeWhenInactive = true;
            this.Discord_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Discord_Button.Image = ((System.Drawing.Image)(resources.GetObject("Discord_Button.Image")));
            this.Discord_Button.ImageActive = null;
            this.Discord_Button.ImageLocation = null;
            this.Discord_Button.ImageMargin = 40;
            this.Discord_Button.ImageSize = new System.Drawing.Size(50, 50);
            this.Discord_Button.ImageZoomSize = new System.Drawing.Size(90, 90);
            this.Discord_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Discord_Button.InitialImage")));
            this.Discord_Button.Location = new System.Drawing.Point(12, 20);
            this.Discord_Button.Name = "Discord_Button";
            this.Discord_Button.Rotation = 0;
            this.Discord_Button.ShowActiveImage = true;
            this.Discord_Button.ShowCursorChanges = true;
            this.Discord_Button.ShowImageBorders = false;
            this.Discord_Button.ShowSizeMarkers = false;
            this.Discord_Button.Size = new System.Drawing.Size(90, 90);
            this.Discord_Button.TabIndex = 6;
            this.Discord_Button.ToolTipText = "";
            this.Discord_Button.WaitOnLoad = false;
            this.Discord_Button.Zoom = 40;
            this.Discord_Button.ZoomSpeed = 10;
            this.Discord_Button.Click += new System.EventHandler(this.Discord_Button_Click);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(108, 0);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunifuSeparator1.Size = new System.Drawing.Size(14, 423);
            this.bunifuSeparator1.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(773, 410);
            this.Controls.Add(this.Download_ProgressBar);
            this.Controls.Add(this.Main_Panel);
            this.Controls.Add(this.Keys_Button);
            this.Controls.Add(this.DownloadFirmware_Button);
            this.Controls.Add(this.Firmware_DropDown);
            this.Controls.Add(this.bunifuVScrollBar1);
            this.Controls.Add(this.About_Button);
            this.Controls.Add(this.Update_Button);
            this.Controls.Add(this.Configure_Button);
            this.Controls.Add(this.Discord_Button);
            this.Controls.Add(this.bunifuSeparator1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "GlumSak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Main_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Download_ProgressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton About_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Update_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Configure_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Discord_Button;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Telerik.WinControls.UI.RadScrollablePanelContainer PanelContainer;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Keys_Button;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton DownloadFirmware_Button;
        private Bunifu.UI.WinForms.BunifuDropdown Firmware_DropDown;
        private System.Windows.Forms.Panel Main_Panel;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar1;
        private System.Windows.Forms.FlowLayoutPanel Games_FlowPanel;
        private Telerik.WinControls.UI.RadProgressBar Download_ProgressBar;
        private Telerik.WinControls.Themes.CrystalDarkTheme crystalDarkTheme1;
    }
}