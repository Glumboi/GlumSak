namespace EmuSak_Revive.GUI
{
    partial class ConfigurationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationWindow));
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.Ryujinx_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Yuzu_Button = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Button_Close = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Button_Minimize = new Bunifu.UI.WinForms.BunifuImageButton();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.Title_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.Cache_CheckBox = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.Cache_Label = new Bunifu.UI.WinForms.BunifuLabel();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
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
            this.bunifuSeparator1.Location = new System.Drawing.Point(136, 41);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Vertical;
            this.bunifuSeparator1.Size = new System.Drawing.Size(14, 104);
            this.bunifuSeparator1.TabIndex = 13;
            // 
            // Ryujinx_Button
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;

            // 
            this.Ryujinx_Button.ActiveImage = null;
            this.Ryujinx_Button.AllowAnimations = true;
            this.Ryujinx_Button.AllowBuffering = false;
            this.Ryujinx_Button.AllowToggling = false;
            this.Ryujinx_Button.AllowZooming = false;
            this.Ryujinx_Button.AllowZoomingOnFocus = false;
            this.Ryujinx_Button.BackColor = System.Drawing.Color.Transparent;
            this.Ryujinx_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Ryujinx_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Ryujinx_Button.ErrorImage")));
            this.Ryujinx_Button.FadeWhenInactive = true;
            this.Ryujinx_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Ryujinx_Button.Image = ((System.Drawing.Image)(resources.GetObject("Ryujinx_Button.Image")));
            this.Ryujinx_Button.ImageActive = null;
            this.Ryujinx_Button.ImageLocation = null;
            this.Ryujinx_Button.ImageMargin = 40;
            this.Ryujinx_Button.ImageSize = new System.Drawing.Size(64, 64);
            this.Ryujinx_Button.ImageZoomSize = new System.Drawing.Size(104, 104);
            this.Ryujinx_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Ryujinx_Button.InitialImage")));
            this.Ryujinx_Button.Location = new System.Drawing.Point(173, 41);
            this.Ryujinx_Button.Name = "Ryujinx_Button";
            this.Ryujinx_Button.Rotation = 0;
            this.Ryujinx_Button.ShowActiveImage = true;
            this.Ryujinx_Button.ShowCursorChanges = true;
            this.Ryujinx_Button.ShowImageBorders = false;
            this.Ryujinx_Button.ShowSizeMarkers = false;
            this.Ryujinx_Button.Size = new System.Drawing.Size(104, 104);
            this.Ryujinx_Button.TabIndex = 14;
            this.Ryujinx_Button.ToolTipText = "Launches the app in the Ryujinx config";
            this.Ryujinx_Button.WaitOnLoad = false;
            this.Ryujinx_Button.Zoom = 40;
            this.Ryujinx_Button.ZoomSpeed = 10;
            this.Ryujinx_Button.Click += new System.EventHandler(this.Ryujinx_Button_Click);
            // 
            // Yuzu_Button
            // 
            this.Yuzu_Button.ActiveImage = null;
            this.Yuzu_Button.AllowAnimations = true;
            this.Yuzu_Button.AllowBuffering = false;
            this.Yuzu_Button.AllowToggling = false;
            this.Yuzu_Button.AllowZooming = false;
            this.Yuzu_Button.AllowZoomingOnFocus = false;
            this.Yuzu_Button.BackColor = System.Drawing.Color.Transparent;
            this.Yuzu_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Yuzu_Button.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Yuzu_Button.ErrorImage")));
            this.Yuzu_Button.FadeWhenInactive = true;
            this.Yuzu_Button.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Yuzu_Button.Image = ((System.Drawing.Image)(resources.GetObject("Yuzu_Button.Image")));
            this.Yuzu_Button.ImageActive = null;
            this.Yuzu_Button.ImageLocation = null;
            this.Yuzu_Button.ImageMargin = 40;
            this.Yuzu_Button.ImageSize = new System.Drawing.Size(64, 64);
            this.Yuzu_Button.ImageZoomSize = new System.Drawing.Size(104, 104);
            this.Yuzu_Button.InitialImage = ((System.Drawing.Image)(resources.GetObject("Yuzu_Button.InitialImage")));
            this.Yuzu_Button.Location = new System.Drawing.Point(12, 41);
            this.Yuzu_Button.Name = "Yuzu_Button";
            this.Yuzu_Button.Rotation = 0;
            this.Yuzu_Button.ShowActiveImage = true;
            this.Yuzu_Button.ShowCursorChanges = true;
            this.Yuzu_Button.ShowImageBorders = false;
            this.Yuzu_Button.ShowSizeMarkers = false;
            this.Yuzu_Button.Size = new System.Drawing.Size(104, 104);
            this.Yuzu_Button.TabIndex = 15;
            this.Yuzu_Button.ToolTipText = "Launches the app in the Yuzu config";
            this.Yuzu_Button.WaitOnLoad = false;
            this.Yuzu_Button.Zoom = 40;
            this.Yuzu_Button.ZoomSpeed = 10;
            this.Yuzu_Button.Click += new System.EventHandler(this.Yuzu_Button_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.ActiveImage = null;
            this.Button_Close.AllowAnimations = true;
            this.Button_Close.AllowBuffering = false;
            this.Button_Close.AllowToggling = false;
            this.Button_Close.AllowZooming = false;
            this.Button_Close.AllowZoomingOnFocus = false;
            this.Button_Close.BackColor = System.Drawing.Color.Transparent;
            this.Button_Close.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_Close.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Button_Close.ErrorImage")));
            this.Button_Close.FadeWhenInactive = true;
            this.Button_Close.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageActive = null;
            this.Button_Close.ImageLocation = null;
            this.Button_Close.ImageMargin = 0;
            this.Button_Close.ImageSize = new System.Drawing.Size(20, 20);
            this.Button_Close.ImageZoomSize = new System.Drawing.Size(20, 20);
            this.Button_Close.InitialImage = ((System.Drawing.Image)(resources.GetObject("Button_Close.InitialImage")));
            this.Button_Close.Location = new System.Drawing.Point(257, 7);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Rotation = 0;
            this.Button_Close.ShowActiveImage = true;
            this.Button_Close.ShowCursorChanges = true;
            this.Button_Close.ShowImageBorders = false;
            this.Button_Close.ShowSizeMarkers = false;
            this.Button_Close.Size = new System.Drawing.Size(20, 20);
            this.Button_Close.TabIndex = 16;
            this.Button_Close.ToolTipText = "";
            this.Button_Close.WaitOnLoad = false;
            this.Button_Close.Zoom = 0;
            this.Button_Close.ZoomSpeed = 10;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_Minimize
            // 
            this.Button_Minimize.ActiveImage = null;
            this.Button_Minimize.AllowAnimations = true;
            this.Button_Minimize.AllowBuffering = false;
            this.Button_Minimize.AllowToggling = false;
            this.Button_Minimize.AllowZooming = false;
            this.Button_Minimize.AllowZoomingOnFocus = false;
            this.Button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Button_Minimize.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_Minimize.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Button_Minimize.ErrorImage")));
            this.Button_Minimize.FadeWhenInactive = true;
            this.Button_Minimize.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.Button_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Button_Minimize.Image")));
            this.Button_Minimize.ImageActive = null;
            this.Button_Minimize.ImageLocation = null;
            this.Button_Minimize.ImageMargin = 0;
            this.Button_Minimize.ImageSize = new System.Drawing.Size(20, 20);
            this.Button_Minimize.ImageZoomSize = new System.Drawing.Size(20, 20);
            this.Button_Minimize.InitialImage = ((System.Drawing.Image)(resources.GetObject("Button_Minimize.InitialImage")));
            this.Button_Minimize.Location = new System.Drawing.Point(231, 7);
            this.Button_Minimize.Name = "Button_Minimize";
            this.Button_Minimize.Rotation = 0;
            this.Button_Minimize.ShowActiveImage = true;
            this.Button_Minimize.ShowCursorChanges = true;
            this.Button_Minimize.ShowImageBorders = false;
            this.Button_Minimize.ShowSizeMarkers = false;
            this.Button_Minimize.Size = new System.Drawing.Size(20, 20);
            this.Button_Minimize.TabIndex = 17;
            this.Button_Minimize.ToolTipText = "";
            this.Button_Minimize.WaitOnLoad = false;
            this.Button_Minimize.Zoom = 0;
            this.Button_Minimize.ZoomSpeed = 10;
            this.Button_Minimize.Click += new System.EventHandler(this.Button_Minimize_Click);
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TitleBar.Controls.Add(this.Title_Label);
            this.TitleBar.Controls.Add(this.Button_Minimize);
            this.TitleBar.Controls.Add(this.Button_Close);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(289, 35);
            this.TitleBar.TabIndex = 18;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // Title_Label
            // 
            this.Title_Label.AllowParentOverrides = false;
            this.Title_Label.AutoEllipsis = false;
            this.Title_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Title_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Title_Label.Font = new System.Drawing.Font("Russo One", 8.9F);
            this.Title_Label.ForeColor = System.Drawing.Color.White;
            this.Title_Label.Location = new System.Drawing.Point(10, 10);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Title_Label.Size = new System.Drawing.Size(85, 14);
            this.Title_Label.TabIndex = 18;
            this.Title_Label.Text = "Configuration";
            this.Title_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Title_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Cache_CheckBox
            // 
            this.Cache_CheckBox.AllowBindingControlAnimation = true;
            this.Cache_CheckBox.AllowBindingControlColorChanges = false;
            this.Cache_CheckBox.AllowBindingControlLocation = true;
            this.Cache_CheckBox.AllowCheckBoxAnimation = false;
            this.Cache_CheckBox.AllowCheckmarkAnimation = true;
            this.Cache_CheckBox.AllowOnHoverStates = true;
            this.Cache_CheckBox.AutoCheck = true;
            this.Cache_CheckBox.BackColor = System.Drawing.Color.Transparent;
            this.Cache_CheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cache_CheckBox.BackgroundImage")));
            this.Cache_CheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Cache_CheckBox.BindingControl = this.Cache_Label;
            this.Cache_CheckBox.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.Cache_CheckBox.BorderRadius = 12;
            this.Cache_CheckBox.Checked = false;
            this.Cache_CheckBox.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
            this.Cache_CheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.Cache_CheckBox.CustomCheckmarkImage = null;
            this.Cache_CheckBox.Location = new System.Drawing.Point(91, 161);
            this.Cache_CheckBox.MinimumSize = new System.Drawing.Size(17, 17);
            this.Cache_CheckBox.Name = "Cache_CheckBox";
            this.Cache_CheckBox.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Cache_CheckBox.OnCheck.BorderRadius = 12;
            this.Cache_CheckBox.OnCheck.BorderThickness = 2;
            this.Cache_CheckBox.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Cache_CheckBox.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.Cache_CheckBox.OnCheck.CheckmarkThickness = 2;
            this.Cache_CheckBox.OnDisable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Cache_CheckBox.OnDisable.BorderRadius = 12;
            this.Cache_CheckBox.OnDisable.BorderThickness = 2;
            this.Cache_CheckBox.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.Cache_CheckBox.OnDisable.CheckmarkColor = System.Drawing.Color.White;
            this.Cache_CheckBox.OnDisable.CheckmarkThickness = 2;
            this.Cache_CheckBox.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Cache_CheckBox.OnHoverChecked.BorderRadius = 12;
            this.Cache_CheckBox.OnHoverChecked.BorderThickness = 2;
            this.Cache_CheckBox.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Cache_CheckBox.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.Cache_CheckBox.OnHoverChecked.CheckmarkThickness = 2;
            this.Cache_CheckBox.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Cache_CheckBox.OnHoverUnchecked.BorderRadius = 12;
            this.Cache_CheckBox.OnHoverUnchecked.BorderThickness = 1;
            this.Cache_CheckBox.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.Cache_CheckBox.OnUncheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Cache_CheckBox.OnUncheck.BorderRadius = 12;
            this.Cache_CheckBox.OnUncheck.BorderThickness = 1;
            this.Cache_CheckBox.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.Cache_CheckBox.Size = new System.Drawing.Size(22, 22);
            this.Cache_CheckBox.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.Cache_CheckBox.TabIndex = 19;
            this.Cache_CheckBox.ThreeState = false;
            this.Cache_CheckBox.ToolTipText = resources.GetString("Cache_CheckBox.ToolTipText");
            // 
            // Cache_Label
            // 
            this.Cache_Label.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.Cache_Label.AllowParentOverrides = false;
            this.Cache_Label.AutoEllipsis = false;
            this.Cache_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Cache_Label.CursorType = System.Windows.Forms.Cursors.Default;
            this.Cache_Label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Cache_Label.ForeColor = System.Drawing.Color.White;
            this.Cache_Label.Location = new System.Drawing.Point(116, 165);
            this.Cache_Label.Name = "Cache_Label";
            this.Cache_Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Cache_Label.Size = new System.Drawing.Size(81, 15);
            this.Cache_Label.TabIndex = 20;
            this.Cache_Label.Text = "Use last session";
            this.Cache_Label.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Cache_Label.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(289, 194);
            this.Controls.Add(this.Cache_Label);
            this.Controls.Add(this.Cache_CheckBox);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.Yuzu_Button);
            this.Controls.Add(this.Ryujinx_Button);
            this.Controls.Add(this.bunifuSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationWindow";
            this.Text = "ConfigurationWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ConfigureWindow_Load);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuImageButton Ryujinx_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Yuzu_Button;
        private Bunifu.UI.WinForms.BunifuImageButton Button_Close;
        private Bunifu.UI.WinForms.BunifuImageButton Button_Minimize;
        private System.Windows.Forms.Panel TitleBar;
        private Bunifu.UI.WinForms.BunifuLabel Title_Label;
        private Bunifu.UI.WinForms.BunifuCheckBox Cache_CheckBox;
        private Bunifu.UI.WinForms.BunifuLabel Cache_Label;
    }
}