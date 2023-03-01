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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.PanelContainer = new Telerik.WinControls.UI.RadScrollablePanelContainer();
            this.Firmware_DropDown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.Main_Panel = new System.Windows.Forms.Panel();
            this.Games_FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Download_ProgressBar = new Telerik.WinControls.UI.RadProgressBar();
            this.crystalDarkTheme1 = new Telerik.WinControls.Themes.CrystalDarkTheme();
            this.RemoveFilter_Button = new ns1.SiticoneCircleButton();
            this.Game_ContextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.Filter_TextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.Games_ScrollBar = new Bunifu.UI.WinForms.BunifuVScrollBar();
            this.Keys_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DownloadFirmware_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.About_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Update_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Configure_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Discord_Button = new Bunifu.UI.WinForms.BunifuImageButton();
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
            this.Firmware_DropDown.Size = new System.Drawing.Size(345, 32);
            this.Firmware_DropDown.TabIndex = 13;
            this.Firmware_DropDown.Text = null;
            this.Firmware_DropDown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.Firmware_DropDown.TextLeftMargin = 5;
            this.Firmware_DropDown.SelectedIndexChanged += new System.EventHandler(this.Firmware_DropDown_SelectedIndexChanged);
            // 
            // Main_Panel
            // 
            this.Main_Panel.Controls.Add(this.Games_FlowPanel);
            this.Main_Panel.Location = new System.Drawing.Point(128, 78);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.Size = new System.Drawing.Size(658, 347);
            this.Main_Panel.TabIndex = 16;
            // 
            // Games_FlowPanel
            // 
            this.Games_FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Games_FlowPanel.Location = new System.Drawing.Point(0, 0);
            this.Games_FlowPanel.Name = "Games_FlowPanel";
            this.Games_FlowPanel.Size = new System.Drawing.Size(658, 347);
            this.Games_FlowPanel.TabIndex = 18;
            this.Games_FlowPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Games_FlowPanel_Scroll);
            // 
            // Download_ProgressBar
            // 
            this.Download_ProgressBar.Location = new System.Drawing.Point(128, 431);
            this.Download_ProgressBar.Name = "Download_ProgressBar";
            this.Download_ProgressBar.Size = new System.Drawing.Size(684, 19);
            this.Download_ProgressBar.TabIndex = 18;
            this.Download_ProgressBar.ThemeName = "CrystalDark";
            // 
            // RemoveFilter_Button
            // 
            this.RemoveFilter_Button.BackColor = System.Drawing.Color.Transparent;
            this.RemoveFilter_Button.BorderColor = System.Drawing.Color.Transparent;
            this.RemoveFilter_Button.CheckedState.Parent = this.RemoveFilter_Button;
            this.RemoveFilter_Button.CustomImages.Parent = this.RemoveFilter_Button;
            this.RemoveFilter_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.RemoveFilter_Button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RemoveFilter_Button.ForeColor = System.Drawing.Color.White;
            this.RemoveFilter_Button.HoveredState.Parent = this.RemoveFilter_Button;
            this.RemoveFilter_Button.Location = new System.Drawing.Point(475, 51);
            this.RemoveFilter_Button.Name = "RemoveFilter_Button";
            this.RemoveFilter_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.RemoveFilter_Button.ShadowDecoration.Mode = ns5.ShadowMode.Circle;
            this.RemoveFilter_Button.ShadowDecoration.Parent = this.RemoveFilter_Button;
            this.RemoveFilter_Button.Size = new System.Drawing.Size(19, 19);
            this.RemoveFilter_Button.TabIndex = 24;
            this.RemoveFilter_Button.Text = "X";
            this.RemoveFilter_Button.Click += new System.EventHandler(this.RemoveFilter_Button_Click);
            // 
            // Game_ContextMenu
            // 
            this.Game_ContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Install shader for {game}";
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(106, -34);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunifuSeparator1.Size = new System.Drawing.Size(14, 542);
            this.bunifuSeparator1.TabIndex = 25;
            // 
            // Filter_TextBox
            // 
            this.Filter_TextBox.AcceptsReturn = false;
            this.Filter_TextBox.AcceptsTab = false;
            this.Filter_TextBox.AnimationSpeed = 200;
            this.Filter_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Filter_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Filter_TextBox.BackColor = System.Drawing.Color.Transparent;
            this.Filter_TextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Filter_TextBox.BackgroundImage")));
            this.Filter_TextBox.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Filter_TextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Filter_TextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Filter_TextBox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Filter_TextBox.BorderRadius = 10;
            this.Filter_TextBox.BorderThickness = 1;
            this.Filter_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Filter_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Filter_TextBox.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_TextBox.DefaultText = "";
            this.Filter_TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Filter_TextBox.ForeColor = System.Drawing.Color.White;
            this.Filter_TextBox.HideSelection = true;
            this.Filter_TextBox.IconLeft = null;
            this.Filter_TextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.Filter_TextBox.IconPadding = 10;
            this.Filter_TextBox.IconRight = null;
            this.Filter_TextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.Filter_TextBox.Lines = new string[0];
            this.Filter_TextBox.Location = new System.Drawing.Point(128, 50);
            this.Filter_TextBox.MaxLength = 32767;
            this.Filter_TextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.Filter_TextBox.Modified = false;
            this.Filter_TextBox.Multiline = false;
            this.Filter_TextBox.Name = "Filter_TextBox";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Filter_TextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.Filter_TextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Filter_TextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Filter_TextBox.OnIdleState = stateProperties4;
            this.Filter_TextBox.Padding = new System.Windows.Forms.Padding(3);
            this.Filter_TextBox.PasswordChar = '\0';
            this.Filter_TextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.Filter_TextBox.PlaceholderText = "Filter games";
            this.Filter_TextBox.ReadOnly = false;
            this.Filter_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Filter_TextBox.SelectedText = "";
            this.Filter_TextBox.SelectionLength = 0;
            this.Filter_TextBox.SelectionStart = 0;
            this.Filter_TextBox.ShortcutsEnabled = true;
            this.Filter_TextBox.Size = new System.Drawing.Size(345, 20);
            this.Filter_TextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.Filter_TextBox.TabIndex = 23;
            this.Filter_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Filter_TextBox.TextMarginBottom = 0;
            this.Filter_TextBox.TextMarginLeft = 3;
            this.Filter_TextBox.TextMarginTop = 0;
            this.Filter_TextBox.TextPlaceholder = "Filter games";
            this.Filter_TextBox.UseSystemPasswordChar = false;
            this.Filter_TextBox.WordWrap = true;
            this.Filter_TextBox.TextChange += new System.EventHandler(this.Filter_TextBox_TextChanged);
            // 
            // Games_ScrollBar
            // 
            this.Games_ScrollBar.AllowCursorChanges = true;
            this.Games_ScrollBar.AllowHomeEndKeysDetection = false;
            this.Games_ScrollBar.AllowIncrementalClickMoves = true;
            this.Games_ScrollBar.AllowMouseDownEffects = true;
            this.Games_ScrollBar.AllowMouseHoverEffects = true;
            this.Games_ScrollBar.AllowScrollingAnimations = true;
            this.Games_ScrollBar.AllowScrollKeysDetection = true;
            this.Games_ScrollBar.AllowScrollOptionsMenu = true;
            this.Games_ScrollBar.AllowShrinkingOnFocusLost = false;
            this.Games_ScrollBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Games_ScrollBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Games_ScrollBar.BackgroundImage")));
            this.Games_ScrollBar.BindingContainer = this.Games_FlowPanel;
            this.Games_ScrollBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Games_ScrollBar.BorderRadius = 14;
            this.Games_ScrollBar.BorderThickness = 1;
            this.Games_ScrollBar.DurationBeforeShrink = 2000;
            this.Games_ScrollBar.LargeChange = 10;
            this.Games_ScrollBar.Location = new System.Drawing.Point(792, 78);
            this.Games_ScrollBar.Maximum = 100;
            this.Games_ScrollBar.Minimum = 0;
            this.Games_ScrollBar.MinimumThumbLength = 18;
            this.Games_ScrollBar.Name = "Games_ScrollBar";
            this.Games_ScrollBar.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.Games_ScrollBar.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.Games_ScrollBar.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.Games_ScrollBar.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Games_ScrollBar.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Games_ScrollBar.ShrinkSizeLimit = 3;
            this.Games_ScrollBar.Size = new System.Drawing.Size(20, 347);
            this.Games_ScrollBar.SmallChange = 1;
            this.Games_ScrollBar.TabIndex = 22;
            this.Games_ScrollBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Games_ScrollBar.ThumbLength = 34;
            this.Games_ScrollBar.ThumbMargin = 1;
            this.Games_ScrollBar.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.Games_ScrollBar.Value = 0;
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
            this.Keys_Button.Location = new System.Drawing.Point(664, 12);
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
            this.Keys_Button.Size = new System.Drawing.Size(148, 32);
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
            this.DownloadFirmware_Button.Location = new System.Drawing.Point(481, 12);
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
            this.DownloadFirmware_Button.Size = new System.Drawing.Size(177, 32);
            this.DownloadFirmware_Button.TabIndex = 14;
            this.DownloadFirmware_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DownloadFirmware_Button.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.DownloadFirmware_Button.TextMarginLeft = 0;
            this.DownloadFirmware_Button.TextPadding = new System.Windows.Forms.Padding(0);
            this.DownloadFirmware_Button.UseDefaultRadiusAndThickness = true;
            this.DownloadFirmware_Button.Click += new System.EventHandler(this.DownloadFirmware_Button_Click);
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
            this.About_Button.ImageSize = new System.Drawing.Size(60, 60);
            this.About_Button.ImageZoomSize = new System.Drawing.Size(100, 100);
            this.About_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("About_Button.InitialImage")));
            this.About_Button.Location = new System.Drawing.Point(8, 340);
            this.About_Button.Name = "About_Button";
            this.About_Button.Rotation = 0;
            this.About_Button.ShowActiveImage = true;
            this.About_Button.ShowCursorChanges = true;
            this.About_Button.ShowImageBorders = false;
            this.About_Button.ShowSizeMarkers = false;
            this.About_Button.Size = new System.Drawing.Size(100, 100);
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
            this.Update_Button.ImageSize = new System.Drawing.Size(60, 60);
            this.Update_Button.ImageZoomSize = new System.Drawing.Size(100, 100);
            this.Update_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Update_Button.InitialImage")));
            this.Update_Button.Location = new System.Drawing.Point(8, 234);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Rotation = 0;
            this.Update_Button.ShowActiveImage = true;
            this.Update_Button.ShowCursorChanges = true;
            this.Update_Button.ShowImageBorders = false;
            this.Update_Button.ShowSizeMarkers = false;
            this.Update_Button.Size = new System.Drawing.Size(100, 100);
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
            this.Configure_Button.ImageSize = new System.Drawing.Size(60, 60);
            this.Configure_Button.ImageZoomSize = new System.Drawing.Size(100, 100);
            this.Configure_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Configure_Button.InitialImage")));
            this.Configure_Button.Location = new System.Drawing.Point(8, 128);
            this.Configure_Button.Name = "Configure_Button";
            this.Configure_Button.Rotation = 0;
            this.Configure_Button.ShowActiveImage = true;
            this.Configure_Button.ShowCursorChanges = true;
            this.Configure_Button.ShowImageBorders = false;
            this.Configure_Button.ShowSizeMarkers = false;
            this.Configure_Button.Size = new System.Drawing.Size(100, 100);
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
            this.Discord_Button.ImageSize = new System.Drawing.Size(60, 60);
            this.Discord_Button.ImageZoomSize = new System.Drawing.Size(100, 100);
            this.Discord_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Discord_Button.InitialImage")));
            this.Discord_Button.Location = new System.Drawing.Point(8, 22);
            this.Discord_Button.Name = "Discord_Button";
            this.Discord_Button.Rotation = 0;
            this.Discord_Button.ShowActiveImage = true;
            this.Discord_Button.ShowCursorChanges = true;
            this.Discord_Button.ShowImageBorders = false;
            this.Discord_Button.ShowSizeMarkers = false;
            this.Discord_Button.Size = new System.Drawing.Size(100, 100);
            this.Discord_Button.TabIndex = 6;
            this.Discord_Button.ToolTipText = "";
            this.Discord_Button.WaitOnLoad = false;
            this.Discord_Button.Zoom = 40;
            this.Discord_Button.ZoomSpeed = 10;
            this.Discord_Button.Click += new System.EventHandler(this.Discord_Button_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(824, 462);
            this.Controls.Add(this.Filter_TextBox);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.RemoveFilter_Button);
            this.Controls.Add(this.Games_ScrollBar);
            this.Controls.Add(this.Download_ProgressBar);
            this.Controls.Add(this.Main_Panel);
            this.Controls.Add(this.Keys_Button);
            this.Controls.Add(this.DownloadFirmware_Button);
            this.Controls.Add(this.Firmware_DropDown);
            this.Controls.Add(this.About_Button);
            this.Controls.Add(this.Update_Button);
            this.Controls.Add(this.Configure_Button);
            this.Controls.Add(this.Discord_Button);
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
        private Telerik.WinControls.UI.RadScrollablePanelContainer PanelContainer;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Keys_Button;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton DownloadFirmware_Button;
        private Bunifu.UI.WinForms.BunifuDropdown Firmware_DropDown;
        private System.Windows.Forms.Panel Main_Panel;
        private System.Windows.Forms.FlowLayoutPanel Games_FlowPanel;
        private Telerik.WinControls.UI.RadProgressBar Download_ProgressBar;
        private Telerik.WinControls.Themes.CrystalDarkTheme crystalDarkTheme1;
        private Bunifu.UI.WinForms.BunifuVScrollBar Games_ScrollBar;
        private Bunifu.UI.WinForms.BunifuTextBox Filter_TextBox;
        private ns1.SiticoneCircleButton RemoveFilter_Button;
        private System.Windows.Forms.ContextMenu Game_ContextMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
    }
}