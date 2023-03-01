namespace EmuSak_Revive.GUI
{
    partial class SaveManagerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveManagerWindow));
            this.MoveFrom_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.MoveTo_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.From_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.To_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.ExpandShrink_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.OpenSaveLocTo_Button = new Guna.UI2.WinForms.Guna2Button();
            this.MoveSaves_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.OpenSaveLoc_Button = new Guna.UI2.WinForms.Guna2Button();
            this.FromUserName_DropDown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ToUserName_DropDown = new Guna.UI2.WinForms.Guna2ComboBox();
            this.RyuSavesPath_ListBox = new Telerik.WinControls.UI.RadListControl();
            this.YuzuSavesPath_ListBox = new Telerik.WinControls.UI.RadListControl();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.YuzuSaves_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.RyujinxSaves_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuSeparator5 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.About_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator3 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator4 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuSeparator6 = new Bunifu.UI.WinForms.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.RyuSavesPath_ListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YuzuSavesPath_ListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveFrom_ComboBox
            // 
            this.MoveFrom_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.MoveFrom_ComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MoveFrom_ComboBox.BorderRadius = 10;
            this.MoveFrom_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MoveFrom_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MoveFrom_ComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.MoveFrom_ComboBox.FocusedColor = System.Drawing.Color.Silver;
            this.MoveFrom_ComboBox.FocusedState.BorderColor = System.Drawing.Color.Silver;
            this.MoveFrom_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MoveFrom_ComboBox.ForeColor = System.Drawing.Color.White;
            this.MoveFrom_ComboBox.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.MoveFrom_ComboBox.ItemHeight = 30;
            this.MoveFrom_ComboBox.Items.AddRange(new object[] {
            "Ryujinx",
            "Yuzu"});
            this.MoveFrom_ComboBox.Location = new System.Drawing.Point(19, 67);
            this.MoveFrom_ComboBox.Name = "MoveFrom_ComboBox";
            this.MoveFrom_ComboBox.Size = new System.Drawing.Size(193, 36);
            this.MoveFrom_ComboBox.TabIndex = 45;
            this.MoveFrom_ComboBox.SelectedIndexChanged += new System.EventHandler(this.MoveFrom_ComboBox_SelectedIndexChanged);
            // 
            // MoveTo_ComboBox
            // 
            this.MoveTo_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.MoveTo_ComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MoveTo_ComboBox.BorderRadius = 10;
            this.MoveTo_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MoveTo_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MoveTo_ComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.MoveTo_ComboBox.FocusedColor = System.Drawing.Color.Silver;
            this.MoveTo_ComboBox.FocusedState.BorderColor = System.Drawing.Color.Silver;
            this.MoveTo_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MoveTo_ComboBox.ForeColor = System.Drawing.Color.White;
            this.MoveTo_ComboBox.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.MoveTo_ComboBox.ItemHeight = 30;
            this.MoveTo_ComboBox.Items.AddRange(new object[] {
            "Ryujinx",
            "Yuzu"});
            this.MoveTo_ComboBox.Location = new System.Drawing.Point(275, 67);
            this.MoveTo_ComboBox.Name = "MoveTo_ComboBox";
            this.MoveTo_ComboBox.Size = new System.Drawing.Size(190, 36);
            this.MoveTo_ComboBox.TabIndex = 47;
            this.MoveTo_ComboBox.SelectedIndexChanged += new System.EventHandler(this.MoveTo_ComboBox_SelectedIndexChanged);
            // 
            // From_Label
            // 
            this.From_Label.AllowParentOverrides = false;
            this.From_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.From_Label.AutoEllipsis = false;
            this.From_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.From_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.From_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.From_Label.ForeColor = System.Drawing.Color.White;
            this.From_Label.Location = new System.Drawing.Point(21, 46);
            this.From_Label.Name = "From_Label";
            this.From_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.From_Label.Size = new System.Drawing.Size(32, 14);
            this.From_Label.TabIndex = 78;
            this.From_Label.Text = "From";
            this.From_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.From_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // To_Label
            // 
            this.To_Label.AllowParentOverrides = false;
            this.To_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.To_Label.AutoEllipsis = false;
            this.To_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.To_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.To_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.To_Label.ForeColor = System.Drawing.Color.White;
            this.To_Label.Location = new System.Drawing.Point(278, 46);
            this.To_Label.Name = "To_Label";
            this.To_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.To_Label.Size = new System.Drawing.Size(15, 14);
            this.To_Label.TabIndex = 79;
            this.To_Label.Text = "To";
            this.To_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.To_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ExpandShrink_Button
            // 
            this.ExpandShrink_Button.ActiveImage = null;
            this.ExpandShrink_Button.AllowAnimations = true;
            this.ExpandShrink_Button.AllowBuffering = false;
            this.ExpandShrink_Button.AllowToggling = false;
            this.ExpandShrink_Button.AllowZooming = false;
            this.ExpandShrink_Button.AllowZoomingOnFocus = false;
            this.ExpandShrink_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpandShrink_Button.BackColor = System.Drawing.Color.Transparent;
            this.ExpandShrink_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ExpandShrink_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("ExpandShrink_Button.ErrorImage")));
            this.ExpandShrink_Button.FadeWhenInactive = true;
            this.ExpandShrink_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.ExpandShrink_Button.Image = global::EmuSak_Revive.GUI.Properties.Resources.Arrow_Right_Asset;
            this.ExpandShrink_Button.ImageActive = null;
            this.ExpandShrink_Button.ImageLocation = null;
            this.ExpandShrink_Button.ImageMargin = 0;
            this.ExpandShrink_Button.ImageSize = new System.Drawing.Size(35, 35);
            this.ExpandShrink_Button.ImageZoomSize = new System.Drawing.Size(35, 35);
            this.ExpandShrink_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("ExpandShrink_Button.InitialImage")));
            this.ExpandShrink_Button.Location = new System.Drawing.Point(445, 10);
            this.ExpandShrink_Button.Name = "ExpandShrink_Button";
            this.ExpandShrink_Button.Rotation = 0;
            this.ExpandShrink_Button.ShowActiveImage = true;
            this.ExpandShrink_Button.ShowCursorChanges = true;
            this.ExpandShrink_Button.ShowImageBorders = false;
            this.ExpandShrink_Button.ShowSizeMarkers = false;
            this.ExpandShrink_Button.Size = new System.Drawing.Size(35, 35);
            this.ExpandShrink_Button.TabIndex = 85;
            this.ExpandShrink_Button.ToolTipText = "";
            this.ExpandShrink_Button.WaitOnLoad = false;
            this.ExpandShrink_Button.Zoom = 0;
            this.ExpandShrink_Button.ZoomSpeed = 10;
            this.ExpandShrink_Button.Click += new System.EventHandler(this.ExpandShrink_Button_Click);
            // 
            // OpenSaveLocTo_Button
            // 
            this.OpenSaveLocTo_Button.Animated = true;
            this.OpenSaveLocTo_Button.BorderColor = System.Drawing.Color.Transparent;
            this.OpenSaveLocTo_Button.BorderRadius = 15;
            this.OpenSaveLocTo_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OpenSaveLocTo_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OpenSaveLocTo_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OpenSaveLocTo_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OpenSaveLocTo_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.OpenSaveLocTo_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.OpenSaveLocTo_Button.ForeColor = System.Drawing.Color.White;
            this.OpenSaveLocTo_Button.Image = ((System.Drawing.Image)(resources.GetObject("OpenSaveLocTo_Button.Image")));
            this.OpenSaveLocTo_Button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OpenSaveLocTo_Button.Location = new System.Drawing.Point(278, 109);
            this.OpenSaveLocTo_Button.Name = "OpenSaveLocTo_Button";
            this.OpenSaveLocTo_Button.Size = new System.Drawing.Size(187, 38);
            this.OpenSaveLocTo_Button.TabIndex = 80;
            this.OpenSaveLocTo_Button.Text = "Open save location";
            this.OpenSaveLocTo_Button.Click += new System.EventHandler(this.OpenSaveLocTo_Button_Click);
            // 
            // MoveSaves_Button
            // 
            this.MoveSaves_Button.ActiveImage = null;
            this.MoveSaves_Button.AllowAnimations = true;
            this.MoveSaves_Button.AllowBuffering = false;
            this.MoveSaves_Button.AllowToggling = false;
            this.MoveSaves_Button.AllowZooming = false;
            this.MoveSaves_Button.AllowZoomingOnFocus = false;
            this.MoveSaves_Button.BackColor = System.Drawing.Color.Transparent;
            this.MoveSaves_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.MoveSaves_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("MoveSaves_Button.ErrorImage")));
            this.MoveSaves_Button.FadeWhenInactive = true;
            this.MoveSaves_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.MoveSaves_Button.Image = ((System.Drawing.Image)(resources.GetObject("MoveSaves_Button.Image")));
            this.MoveSaves_Button.ImageActive = null;
            this.MoveSaves_Button.ImageLocation = null;
            this.MoveSaves_Button.ImageMargin = 0;
            this.MoveSaves_Button.ImageSize = new System.Drawing.Size(35, 35);
            this.MoveSaves_Button.ImageZoomSize = new System.Drawing.Size(35, 35);
            this.MoveSaves_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("MoveSaves_Button.InitialImage")));
            this.MoveSaves_Button.Location = new System.Drawing.Point(229, 66);
            this.MoveSaves_Button.Name = "MoveSaves_Button";
            this.MoveSaves_Button.Rotation = 0;
            this.MoveSaves_Button.ShowActiveImage = true;
            this.MoveSaves_Button.ShowCursorChanges = true;
            this.MoveSaves_Button.ShowImageBorders = false;
            this.MoveSaves_Button.ShowSizeMarkers = false;
            this.MoveSaves_Button.Size = new System.Drawing.Size(35, 35);
            this.MoveSaves_Button.TabIndex = 61;
            this.MoveSaves_Button.ToolTipText = "";
            this.MoveSaves_Button.WaitOnLoad = false;
            this.MoveSaves_Button.Zoom = 0;
            this.MoveSaves_Button.ZoomSpeed = 10;
            this.MoveSaves_Button.Click += new System.EventHandler(this.MoveSaves_Button_Click);
            // 
            // OpenSaveLoc_Button
            // 
            this.OpenSaveLoc_Button.Animated = true;
            this.OpenSaveLoc_Button.BorderColor = System.Drawing.Color.Transparent;
            this.OpenSaveLoc_Button.BorderRadius = 15;
            this.OpenSaveLoc_Button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OpenSaveLoc_Button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OpenSaveLoc_Button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OpenSaveLoc_Button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OpenSaveLoc_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.OpenSaveLoc_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.OpenSaveLoc_Button.ForeColor = System.Drawing.Color.White;
            this.OpenSaveLoc_Button.Image = ((System.Drawing.Image)(resources.GetObject("OpenSaveLoc_Button.Image")));
            this.OpenSaveLoc_Button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OpenSaveLoc_Button.Location = new System.Drawing.Point(19, 109);
            this.OpenSaveLoc_Button.Name = "OpenSaveLoc_Button";
            this.OpenSaveLoc_Button.Size = new System.Drawing.Size(193, 38);
            this.OpenSaveLoc_Button.TabIndex = 42;
            this.OpenSaveLoc_Button.Text = "Open save location";
            this.OpenSaveLoc_Button.Click += new System.EventHandler(this.OpenSaveLoc_Button_Click);
            // 
            // FromUserName_DropDown
            // 
            this.FromUserName_DropDown.BackColor = System.Drawing.Color.Transparent;
            this.FromUserName_DropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FromUserName_DropDown.BorderRadius = 10;
            this.FromUserName_DropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FromUserName_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FromUserName_DropDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.FromUserName_DropDown.FocusedColor = System.Drawing.Color.Silver;
            this.FromUserName_DropDown.FocusedState.BorderColor = System.Drawing.Color.Silver;
            this.FromUserName_DropDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FromUserName_DropDown.ForeColor = System.Drawing.Color.White;
            this.FromUserName_DropDown.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.FromUserName_DropDown.ItemHeight = 30;
            this.FromUserName_DropDown.Items.AddRange(new object[] {
            "All"});
            this.FromUserName_DropDown.Location = new System.Drawing.Point(19, 153);
            this.FromUserName_DropDown.Name = "FromUserName_DropDown";
            this.FromUserName_DropDown.Size = new System.Drawing.Size(193, 36);
            this.FromUserName_DropDown.StartIndex = 0;
            this.FromUserName_DropDown.TabIndex = 86;
            // 
            // ToUserName_DropDown
            // 
            this.ToUserName_DropDown.BackColor = System.Drawing.Color.Transparent;
            this.ToUserName_DropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ToUserName_DropDown.BorderRadius = 10;
            this.ToUserName_DropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ToUserName_DropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ToUserName_DropDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ToUserName_DropDown.FocusedColor = System.Drawing.Color.Silver;
            this.ToUserName_DropDown.FocusedState.BorderColor = System.Drawing.Color.Silver;
            this.ToUserName_DropDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ToUserName_DropDown.ForeColor = System.Drawing.Color.White;
            this.ToUserName_DropDown.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.ToUserName_DropDown.ItemHeight = 30;
            this.ToUserName_DropDown.Items.AddRange(new object[] {
            "All"});
            this.ToUserName_DropDown.Location = new System.Drawing.Point(278, 153);
            this.ToUserName_DropDown.Name = "ToUserName_DropDown";
            this.ToUserName_DropDown.Size = new System.Drawing.Size(187, 36);
            this.ToUserName_DropDown.StartIndex = 0;
            this.ToUserName_DropDown.TabIndex = 87;
            // 
            // RyuSavesPath_ListBox
            // 
            this.RyuSavesPath_ListBox.Font = new System.Drawing.Font("Roboto", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RyuSavesPath_ListBox.ItemHeight = 28;
            this.RyuSavesPath_ListBox.Location = new System.Drawing.Point(519, 274);
            this.RyuSavesPath_ListBox.Name = "RyuSavesPath_ListBox";
            this.RyuSavesPath_ListBox.Size = new System.Drawing.Size(493, 137);
            this.RyuSavesPath_ListBox.TabIndex = 88;
            this.RyuSavesPath_ListBox.ThemeName = "CrystalDark";
            this.RyuSavesPath_ListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RyuSavesPath_ListBox_MouseDoubleClick);
            // 
            // YuzuSavesPath_ListBox
            // 
            this.YuzuSavesPath_ListBox.Font = new System.Drawing.Font("Roboto", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YuzuSavesPath_ListBox.ItemHeight = 28;
            this.YuzuSavesPath_ListBox.Location = new System.Drawing.Point(519, 97);
            this.YuzuSavesPath_ListBox.Name = "YuzuSavesPath_ListBox";
            this.YuzuSavesPath_ListBox.Size = new System.Drawing.Size(492, 137);
            this.YuzuSavesPath_ListBox.TabIndex = 89;
            this.YuzuSavesPath_ListBox.ThemeName = "CrystalDark";
            this.YuzuSavesPath_ListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.YuzuSavesPath_ListBox_MouseDoubleClick);
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(519, 77);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(149, 14);
            this.bunifuSeparator1.TabIndex = 90;
            // 
            // YuzuSaves_Label
            // 
            this.YuzuSaves_Label.AllowParentOverrides = false;
            this.YuzuSaves_Label.AutoEllipsis = false;
            this.YuzuSaves_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.YuzuSaves_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.YuzuSaves_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.YuzuSaves_Label.ForeColor = System.Drawing.Color.White;
            this.YuzuSaves_Label.Location = new System.Drawing.Point(519, 63);
            this.YuzuSaves_Label.Name = "YuzuSaves_Label";
            this.YuzuSaves_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.YuzuSaves_Label.Size = new System.Drawing.Size(69, 14);
            this.YuzuSaves_Label.TabIndex = 91;
            this.YuzuSaves_Label.Text = "Yuzu saves";
            this.YuzuSaves_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.YuzuSaves_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // RyujinxSaves_Label
            // 
            this.RyujinxSaves_Label.AllowParentOverrides = false;
            this.RyujinxSaves_Label.AutoEllipsis = false;
            this.RyujinxSaves_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.RyujinxSaves_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.RyujinxSaves_Label.Font = new System.Drawing.Font("Russo One", 9F);
            this.RyujinxSaves_Label.ForeColor = System.Drawing.Color.White;
            this.RyujinxSaves_Label.Location = new System.Drawing.Point(519, 240);
            this.RyujinxSaves_Label.Name = "RyujinxSaves_Label";
            this.RyujinxSaves_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RyujinxSaves_Label.Size = new System.Drawing.Size(86, 14);
            this.RyujinxSaves_Label.TabIndex = 93;
            this.RyujinxSaves_Label.Text = "Ryujinx saves";
            this.RyujinxSaves_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.RyujinxSaves_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            this.bunifuSeparator2.Location = new System.Drawing.Point(519, 254);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(149, 14);
            this.bunifuSeparator2.TabIndex = 92;
            // 
            // bunifuSeparator5
            // 
            this.bunifuSeparator5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator5.BackgroundImage")));
            this.bunifuSeparator5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator5.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator5.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator5.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator5.LineThickness = 1;
            this.bunifuSeparator5.Location = new System.Drawing.Point(21, 195);
            this.bunifuSeparator5.Name = "bunifuSeparator5";
            this.bunifuSeparator5.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator5.Size = new System.Drawing.Size(447, 14);
            this.bunifuSeparator5.TabIndex = 95;
            // 
            // About_Label
            // 
            this.About_Label.AllowParentOverrides = false;
            this.About_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.About_Label.AutoEllipsis = false;
            this.About_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.About_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.About_Label.Font = new System.Drawing.Font("Russo One", 12F);
            this.About_Label.ForeColor = System.Drawing.Color.White;
            this.About_Label.Location = new System.Drawing.Point(35, 420);
            this.About_Label.Name = "About_Label";
            this.About_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.About_Label.Size = new System.Drawing.Size(412, 19);
            this.About_Label.TabIndex = 94;
            this.About_Label.Text = "This is still in early development, things can break";
            this.About_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.About_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator3.BackgroundImage")));
            this.bunifuSeparator3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator3.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator3.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator3.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator3.LineThickness = 1;
            this.bunifuSeparator3.Location = new System.Drawing.Point(19, 400);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator3.Size = new System.Drawing.Size(449, 14);
            this.bunifuSeparator3.TabIndex = 96;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Russo One", 12F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(84, 215);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(317, 19);
            this.bunifuLabel1.TabIndex = 97;
            this.bunifuLabel1.Text = "New features will be introduced here...";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuSeparator4
            // 
            this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator4.BackgroundImage")));
            this.bunifuSeparator4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator4.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator4.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator4.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator4.LineThickness = 1;
            this.bunifuSeparator4.Location = new System.Drawing.Point(492, -9);
            this.bunifuSeparator4.Name = "bunifuSeparator4";
            this.bunifuSeparator4.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunifuSeparator4.Size = new System.Drawing.Size(14, 477);
            this.bunifuSeparator4.TabIndex = 98;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.Font = new System.Drawing.Font("Russo One", 12F);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel2.Location = new System.Drawing.Point(557, 10);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(394, 19);
            this.bunifuLabel2.TabIndex = 99;
            this.bunifuLabel2.Text = "Extras (double click a list item to open the path)";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuSeparator6
            // 
            this.bunifuSeparator6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator6.BackgroundImage")));
            this.bunifuSeparator6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator6.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator6.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator6.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator6.LineThickness = 1;
            this.bunifuSeparator6.Location = new System.Drawing.Point(557, 31);
            this.bunifuSeparator6.Name = "bunifuSeparator6";
            this.bunifuSeparator6.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator6.Size = new System.Drawing.Size(394, 14);
            this.bunifuSeparator6.TabIndex = 100;
            // 
            // SaveManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(489, 451);
            this.Controls.Add(this.bunifuSeparator6);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuSeparator4);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuSeparator3);
            this.Controls.Add(this.bunifuSeparator5);
            this.Controls.Add(this.About_Label);
            this.Controls.Add(this.RyujinxSaves_Label);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.YuzuSaves_Label);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.YuzuSavesPath_ListBox);
            this.Controls.Add(this.RyuSavesPath_ListBox);
            this.Controls.Add(this.ToUserName_DropDown);
            this.Controls.Add(this.FromUserName_DropDown);
            this.Controls.Add(this.ExpandShrink_Button);
            this.Controls.Add(this.OpenSaveLocTo_Button);
            this.Controls.Add(this.To_Label);
            this.Controls.Add(this.From_Label);
            this.Controls.Add(this.MoveSaves_Button);
            this.Controls.Add(this.MoveTo_ComboBox);
            this.Controls.Add(this.MoveFrom_ComboBox);
            this.Controls.Add(this.OpenSaveLoc_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SaveManagerWindow";
            this.Text = "Save manager for ";
            this.Load += new System.EventHandler(this.SaveManagerWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RyuSavesPath_ListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YuzuSavesPath_ListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button OpenSaveLoc_Button;
        private Guna.UI2.WinForms.Guna2ComboBox MoveFrom_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox MoveTo_ComboBox;
        private Bunifu.UI.WinForms.BunifuImageButton MoveSaves_Button;
        private Bunifu.UI.WinForms.BunifuLabel From_Label;
        private Bunifu.UI.WinForms.BunifuLabel To_Label;
        private Guna.UI2.WinForms.Guna2Button OpenSaveLocTo_Button;
        private Bunifu.UI.WinForms.BunifuImageButton ExpandShrink_Button;
        private Guna.UI2.WinForms.Guna2ComboBox FromUserName_DropDown;
        private Guna.UI2.WinForms.Guna2ComboBox ToUserName_DropDown;
        private Telerik.WinControls.UI.RadListControl RyuSavesPath_ListBox;
        private Telerik.WinControls.UI.RadListControl YuzuSavesPath_ListBox;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuLabel YuzuSaves_Label;
        private Bunifu.UI.WinForms.BunifuLabel RyujinxSaves_Label;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator5;
        private Bunifu.UI.WinForms.BunifuLabel About_Label;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator3;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator6;
    }
}