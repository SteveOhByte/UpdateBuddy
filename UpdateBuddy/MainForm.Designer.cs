namespace UpdateBuddy
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialLabel lblCurrentVersion;
        private MaterialSkin.Controls.MaterialLabel lblNewVersion;
        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialButton btnSkip;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblCurrentVersion = new MaterialSkin.Controls.MaterialLabel();
            lblNewVersion = new MaterialSkin.Controls.MaterialLabel();
            btnUpdate = new MaterialSkin.Controls.MaterialButton();
            btnSkip = new MaterialSkin.Controls.MaterialButton();
            lblTitle = new MaterialSkin.Controls.MaterialLabel();
            progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            tipButton = new MaterialSkin.Controls.MaterialButton();
            dismissTipButton = new LinkLabel();
            kofiButton = new LinkLabel();
            patreonButton = new LinkLabel();
            closeTipButton = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Depth = 0;
            lblCurrentVersion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCurrentVersion.Location = new Point(70, 137);
            lblCurrentVersion.MouseState = MaterialSkin.MouseState.HOVER;
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(111, 19);
            lblCurrentVersion.TabIndex = 1;
            lblCurrentVersion.Text = "Current version:";
            lblCurrentVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNewVersion
            // 
            lblNewVersion.AutoSize = true;
            lblNewVersion.Depth = 0;
            lblNewVersion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNewVersion.Location = new Point(272, 137);
            lblNewVersion.MouseState = MaterialSkin.MouseState.HOVER;
            lblNewVersion.Name = "lblNewVersion";
            lblNewVersion.Size = new Size(91, 19);
            lblNewVersion.TabIndex = 2;
            lblNewVersion.Text = "New version:";
            lblNewVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = false;
            btnUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpdate.Depth = 0;
            btnUpdate.HighEmphasis = true;
            btnUpdate.Icon = null;
            btnUpdate.Location = new Point(110, 223);
            btnUpdate.Margin = new Padding(4, 6, 4, 6);
            btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.NoAccentTextColor = Color.Empty;
            btnUpdate.Size = new Size(77, 36);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpdate.UseAccentColor = false;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSkip
            // 
            btnSkip.AutoSize = false;
            btnSkip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSkip.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSkip.Depth = 0;
            btnSkip.HighEmphasis = true;
            btnSkip.Icon = null;
            btnSkip.Location = new Point(301, 223);
            btnSkip.Margin = new Padding(4, 6, 4, 6);
            btnSkip.MouseState = MaterialSkin.MouseState.HOVER;
            btnSkip.Name = "btnSkip";
            btnSkip.NoAccentTextColor = Color.Empty;
            btnSkip.Size = new Size(77, 36);
            btnSkip.TabIndex = 7;
            btnSkip.Text = "Skip";
            btnSkip.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSkip.UseAccentColor = false;
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Click += btnSkip_Click;
            // 
            // lblTitle
            // 
            lblTitle.Depth = 0;
            lblTitle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTitle.Location = new Point(149, 74);
            lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(211, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Update available for:\r\n";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.Depth = 0;
            progressBar.Location = new Point(70, 181);
            progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(332, 5);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 8;
            progressBar.Visible = false;
            // 
            // tipButton
            // 
            tipButton.AutoSize = false;
            tipButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tipButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            tipButton.Depth = 0;
            tipButton.HighEmphasis = true;
            tipButton.Icon = null;
            tipButton.Location = new Point(463, 240);
            tipButton.Margin = new Padding(4, 6, 4, 6);
            tipButton.MouseState = MaterialSkin.MouseState.HOVER;
            tipButton.Name = "tipButton";
            tipButton.NoAccentTextColor = Color.Empty;
            tipButton.Size = new Size(30, 19);
            tipButton.TabIndex = 9;
            tipButton.Text = "Tip";
            tipButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            tipButton.UseAccentColor = false;
            tipButton.UseVisualStyleBackColor = true;
            tipButton.Visible = false;
            tipButton.Click += tipButton_Click;
            // 
            // dismissTipButton
            // 
            dismissTipButton.LinkColor = Color.Green;
            dismissTipButton.Location = new Point(435, 265);
            dismissTipButton.Name = "dismissTipButton";
            dismissTipButton.Size = new Size(59, 19);
            dismissTipButton.TabIndex = 10;
            dismissTipButton.TabStop = true;
            dismissTipButton.Text = "Dismiss";
            dismissTipButton.TextAlign = ContentAlignment.MiddleCenter;
            dismissTipButton.Visible = false;
            dismissTipButton.LinkClicked += dismissTipButton_LinkClicked;
            // 
            // kofiButton
            // 
            kofiButton.Cursor = Cursors.Hand;
            kofiButton.Image = Properties.Resources.kofi;
            kofiButton.Location = new Point(364, 181);
            kofiButton.Name = "kofiButton";
            kofiButton.Size = new Size(129, 50);
            kofiButton.TabIndex = 11;
            kofiButton.Visible = false;
            kofiButton.Click += kofiButton_Click;
            // 
            // patreonButton
            // 
            patreonButton.Cursor = Cursors.Hand;
            patreonButton.Image = Properties.Resources.patreon;
            patreonButton.Location = new Point(364, 128);
            patreonButton.Name = "patreonButton";
            patreonButton.Size = new Size(129, 50);
            patreonButton.TabIndex = 12;
            patreonButton.Visible = false;
            patreonButton.Click += patreonButton_Click;
            // 
            // closeTipButton
            // 
            closeTipButton.AutoSize = false;
            closeTipButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            closeTipButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            closeTipButton.Depth = 0;
            closeTipButton.HighEmphasis = true;
            closeTipButton.Icon = null;
            closeTipButton.Location = new Point(478, 105);
            closeTipButton.Margin = new Padding(4, 6, 4, 6);
            closeTipButton.MouseState = MaterialSkin.MouseState.HOVER;
            closeTipButton.Name = "closeTipButton";
            closeTipButton.NoAccentTextColor = Color.Empty;
            closeTipButton.Size = new Size(15, 19);
            closeTipButton.TabIndex = 13;
            closeTipButton.Text = "X";
            closeTipButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            closeTipButton.UseAccentColor = false;
            closeTipButton.UseVisualStyleBackColor = true;
            closeTipButton.Visible = false;
            closeTipButton.Click += closeTipButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 286);
            Controls.Add(closeTipButton);
            Controls.Add(patreonButton);
            Controls.Add(kofiButton);
            Controls.Add(dismissTipButton);
            Controls.Add(tipButton);
            Controls.Add(progressBar);
            Controls.Add(btnSkip);
            Controls.Add(btnUpdate);
            Controls.Add(lblNewVersion);
            Controls.Add(lblCurrentVersion);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Buddy";
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialSkin.Controls.MaterialButton tipButton;
        private LinkLabel dismissTipButton;
        private LinkLabel kofiButton;
        private LinkLabel patreonButton;
        private MaterialSkin.Controls.MaterialButton closeTipButton;
    }
}
