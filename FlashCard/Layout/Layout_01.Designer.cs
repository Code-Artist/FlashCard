namespace FlashCard
{
    partial class Layout_01
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
                if (Synth != null) { Synth.Dispose(); Synth = null; }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BtMenu = new CodeArtEng.GameControls.Button3D();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCardCounter = new System.Windows.Forms.Label();
            this.LbScore = new System.Windows.Forms.Label();
            this.Stars = new CodeArtEng.GameControls.StarProgressBar();
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.hintTimer = new System.Windows.Forms.Timer(this.components);
            this.PuzzleHint = new CodeArtEng.GameControls.BallonText();
            this.CardLabel = new CodeArtEng.GameControls.BallonText();
            this.TopPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.BtMenu);
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Controls.Add(this.LbScore);
            this.TopPanel.Controls.Add(this.Stars);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1067, 114);
            this.TopPanel.TabIndex = 0;
            // 
            // BtMenu
            // 
            this.BtMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtMenu.AutoSize = true;
            this.BtMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtMenu.Location = new System.Drawing.Point(941, 0);
            this.BtMenu.Margin = new System.Windows.Forms.Padding(4);
            this.BtMenu.Name = "BtMenu";
            this.BtMenu.Size = new System.Drawing.Size(131, 40);
            this.BtMenu.TabIndex = 0;
            this.BtMenu.Click += new System.EventHandler(this.BtMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbCardCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 26);
            this.panel1.TabIndex = 7;
            // 
            // lbCardCounter
            // 
            this.lbCardCounter.AutoSize = true;
            this.lbCardCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCardCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbCardCounter.Location = new System.Drawing.Point(8, 5);
            this.lbCardCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCardCounter.Name = "lbCardCounter";
            this.lbCardCounter.Size = new System.Drawing.Size(59, 17);
            this.lbCardCounter.TabIndex = 7;
            this.lbCardCounter.Text = "99 / 99";
            // 
            // LbScore
            // 
            this.LbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbScore.Image = global::FlashCard.Properties.Resources.Star_65;
            this.LbScore.Location = new System.Drawing.Point(4, 30);
            this.LbScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbScore.Name = "LbScore";
            this.LbScore.Size = new System.Drawing.Size(87, 80);
            this.LbScore.TabIndex = 6;
            this.LbScore.Text = "99";
            this.LbScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Stars
            // 
            this.Stars.BackColor = System.Drawing.Color.Transparent;
            this.Stars.Count = 10;
            this.Stars.DimmedImageIndex = 0;
            this.Stars.HighlightedImageIndex = 1;
            this.Stars.Location = new System.Drawing.Point(99, 37);
            this.Stars.Margin = new System.Windows.Forms.Padding(5);
            this.Stars.Name = "Stars";
            this.Stars.Size = new System.Drawing.Size(748, 68);
            this.Stars.StarSize = 50;
            this.Stars.TabIndex = 0;
            this.Stars.Value = 0;
            // 
            // MainPicture
            // 
            this.MainPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPicture.Location = new System.Drawing.Point(296, 114);
            this.MainPicture.Margin = new System.Windows.Forms.Padding(4);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(771, 362);
            this.MainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainPicture.TabIndex = 0;
            this.MainPicture.TabStop = false;
            // 
            // hintTimer
            // 
            this.hintTimer.Interval = 5000;
            this.hintTimer.Tick += new System.EventHandler(this.hintTimer_Tick);
            // 
            // PuzzleHint
            // 
            this.PuzzleHint.Dock = System.Windows.Forms.DockStyle.Left;
            this.PuzzleHint.Location = new System.Drawing.Point(0, 114);
            this.PuzzleHint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PuzzleHint.Name = "PuzzleHint";
            this.PuzzleHint.ShowHint = true;
            this.PuzzleHint.Size = new System.Drawing.Size(296, 362);
            this.PuzzleHint.Spacing = 10;
            this.PuzzleHint.TabIndex = 2;
            this.PuzzleHint.Text = "Hints";
            // 
            // CardLabel
            // 
            this.CardLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardLabel.Location = new System.Drawing.Point(0, 476);
            this.CardLabel.Margin = new System.Windows.Forms.Padding(5);
            this.CardLabel.Name = "CardLabel";
            this.CardLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.CardLabel.ShowHint = true;
            this.CardLabel.Size = new System.Drawing.Size(1067, 116);
            this.CardLabel.Spacing = 0;
            this.CardLabel.TabIndex = 1;
            this.CardLabel.Text = "Word";
            // 
            // Layout_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPicture);
            this.Controls.Add(this.PuzzleHint);
            this.Controls.Add(this.CardLabel);
            this.Controls.Add(this.TopPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Layout_01";
            this.Size = new System.Drawing.Size(1067, 592);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private CodeArtEng.GameControls.StarProgressBar Stars;
        private System.Windows.Forms.PictureBox MainPicture;
        private CodeArtEng.GameControls.BallonText CardLabel;
        private System.Windows.Forms.Label LbScore;
        private CodeArtEng.GameControls.Button3D BtMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCardCounter;
        private System.Windows.Forms.Timer hintTimer;
        private CodeArtEng.GameControls.BallonText PuzzleHint;

    }
}
