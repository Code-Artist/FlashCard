namespace FlashCard
{
    partial class Layout_02
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCardCounter = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.optionButton4 = new CodeArtEng.GameControls.OptionButton(this.components);
            this.optionButton1 = new CodeArtEng.GameControls.OptionButton(this.components);
            this.optionButton2 = new CodeArtEng.GameControls.OptionButton(this.components);
            this.optionButton3 = new CodeArtEng.GameControls.OptionButton(this.components);
            this.OptionPanelFrame = new System.Windows.Forms.Panel();
            this.tbResults = new System.Windows.Forms.DataGridView();
            this.BtMenu = new CodeArtEng.GameControls.Button3D();
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.colWords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.optionPanel.SuspendLayout();
            this.OptionPanelFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbCardCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 21);
            this.panel1.TabIndex = 7;
            // 
            // lbCardCounter
            // 
            this.lbCardCounter.AutoSize = true;
            this.lbCardCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCardCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbCardCounter.Location = new System.Drawing.Point(6, 4);
            this.lbCardCounter.Name = "lbCardCounter";
            this.lbCardCounter.Size = new System.Drawing.Size(49, 13);
            this.lbCardCounter.TabIndex = 7;
            this.lbCardCounter.Text = "99 / 99";
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.panel1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(733, 39);
            this.TopPanel.TabIndex = 6;
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.optionButton4);
            this.optionPanel.Controls.Add(this.optionButton1);
            this.optionPanel.Controls.Add(this.optionButton2);
            this.optionPanel.Controls.Add(this.optionButton3);
            this.optionPanel.Location = new System.Drawing.Point(22, 0);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(405, 149);
            this.optionPanel.TabIndex = 7;
            // 
            // optionButton4
            // 
            this.optionButton4.BackColor = System.Drawing.SystemColors.Control;
            this.optionButton4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionButton4.HighlightColor = System.Drawing.Color.Lime;
            this.optionButton4.HoverColor = System.Drawing.Color.Yellow;
            this.optionButton4.HoverEnabled = true;
            this.optionButton4.Location = new System.Drawing.Point(204, 77);
            this.optionButton4.Name = "optionButton4";
            this.optionButton4.Selected = false;
            this.optionButton4.Size = new System.Drawing.Size(195, 68);
            this.optionButton4.TabIndex = 8;
            this.optionButton4.Tag = "2";
            this.optionButton4.Text = "option3";
            this.optionButton4.UseVisualStyleBackColor = true;
            this.optionButton4.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // optionButton1
            // 
            this.optionButton1.BackColor = System.Drawing.SystemColors.Control;
            this.optionButton1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionButton1.HighlightColor = System.Drawing.Color.Lime;
            this.optionButton1.HoverColor = System.Drawing.Color.Yellow;
            this.optionButton1.HoverEnabled = true;
            this.optionButton1.Location = new System.Drawing.Point(3, 3);
            this.optionButton1.Name = "optionButton1";
            this.optionButton1.Selected = false;
            this.optionButton1.Size = new System.Drawing.Size(195, 68);
            this.optionButton1.TabIndex = 3;
            this.optionButton1.Tag = "0";
            this.optionButton1.Text = "option1";
            this.optionButton1.UseVisualStyleBackColor = true;
            this.optionButton1.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // optionButton2
            // 
            this.optionButton2.BackColor = System.Drawing.SystemColors.Control;
            this.optionButton2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionButton2.HighlightColor = System.Drawing.Color.Lime;
            this.optionButton2.HoverColor = System.Drawing.Color.Yellow;
            this.optionButton2.HoverEnabled = true;
            this.optionButton2.Location = new System.Drawing.Point(204, 3);
            this.optionButton2.Name = "optionButton2";
            this.optionButton2.Selected = false;
            this.optionButton2.Size = new System.Drawing.Size(195, 68);
            this.optionButton2.TabIndex = 4;
            this.optionButton2.Tag = "1";
            this.optionButton2.Text = "option2";
            this.optionButton2.UseVisualStyleBackColor = true;
            this.optionButton2.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // optionButton3
            // 
            this.optionButton3.BackColor = System.Drawing.SystemColors.Control;
            this.optionButton3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionButton3.HighlightColor = System.Drawing.Color.Lime;
            this.optionButton3.HoverColor = System.Drawing.Color.Yellow;
            this.optionButton3.HoverEnabled = true;
            this.optionButton3.Location = new System.Drawing.Point(3, 77);
            this.optionButton3.Name = "optionButton3";
            this.optionButton3.Selected = false;
            this.optionButton3.Size = new System.Drawing.Size(195, 68);
            this.optionButton3.TabIndex = 5;
            this.optionButton3.Tag = "2";
            this.optionButton3.Text = "option3";
            this.optionButton3.UseVisualStyleBackColor = true;
            this.optionButton3.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // OptionPanelFrame
            // 
            this.OptionPanelFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionPanelFrame.Controls.Add(this.optionPanel);
            this.OptionPanelFrame.Location = new System.Drawing.Point(9, 343);
            this.OptionPanelFrame.Name = "OptionPanelFrame";
            this.OptionPanelFrame.Size = new System.Drawing.Size(522, 149);
            this.OptionPanelFrame.TabIndex = 8;
            // 
            // tbResults
            // 
            this.tbResults.AllowUserToAddRows = false;
            this.tbResults.AllowUserToDeleteRows = false;
            this.tbResults.AllowUserToResizeColumns = false;
            this.tbResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue;
            this.tbResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tbResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWords,
            this.colScore});
            this.tbResults.Location = new System.Drawing.Point(537, 45);
            this.tbResults.MultiSelect = false;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.RowHeadersVisible = false;
            this.tbResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tbResults.ShowEditingIcon = false;
            this.tbResults.Size = new System.Drawing.Size(190, 447);
            this.tbResults.TabIndex = 9;
            this.tbResults.SelectionChanged += new System.EventHandler(this.tbResults_SelectionChanged);
            // 
            // BtMenu
            // 
            this.BtMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtMenu.AutoSize = true;
            this.BtMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtMenu.Location = new System.Drawing.Point(606, -1);
            this.BtMenu.Name = "BtMenu";
            this.BtMenu.Size = new System.Drawing.Size(131, 40);
            this.BtMenu.TabIndex = 1;
            this.BtMenu.Click += new System.EventHandler(this.BtMenu_Click);
            // 
            // MainPicture
            // 
            this.MainPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPicture.Location = new System.Drawing.Point(9, 45);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(522, 292);
            this.MainPicture.TabIndex = 2;
            this.MainPicture.TabStop = false;
            // 
            // colWords
            // 
            this.colWords.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWords.HeaderText = "Words";
            this.colWords.Name = "colWords";
            this.colWords.ReadOnly = true;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            this.colScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colScore.Width = 50;
            // 
            // Layout_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.OptionPanelFrame);
            this.Controls.Add(this.BtMenu);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.MainPicture);
            this.Name = "Layout_02";
            this.Size = new System.Drawing.Size(733, 496);
            this.SizeChanged += new System.EventHandler(this.Layout_02_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.optionPanel.ResumeLayout(false);
            this.OptionPanelFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CodeArtEng.GameControls.Button3D BtMenu;
        private System.Windows.Forms.PictureBox MainPicture;
        private CodeArtEng.GameControls.OptionButton optionButton1;
        private CodeArtEng.GameControls.OptionButton optionButton2;
        private CodeArtEng.GameControls.OptionButton optionButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCardCounter;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel optionPanel;
        private CodeArtEng.GameControls.OptionButton optionButton4;
        private System.Windows.Forms.Panel OptionPanelFrame;
        private System.Windows.Forms.DataGridView tbResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
    }
}
