namespace FlashCard
{
    partial class SelectionDialog
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
            this.components = new System.ComponentModel.Container();
            this.PNBottom = new System.Windows.Forms.Panel();
            this.BtCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.refButton = new CodeArtEng.GameControls.OptionButton(this.components);
            this.PnDescription = new System.Windows.Forms.Panel();
            this.lbDesc = new System.Windows.Forms.Label();
            this.picDesc = new System.Windows.Forms.PictureBox();
            this.PNBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ItemsPanel.SuspendLayout();
            this.PnDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // PNBottom
            // 
            this.PNBottom.Controls.Add(this.BtCancel);
            this.PNBottom.Location = new System.Drawing.Point(13, 367);
            this.PNBottom.Margin = new System.Windows.Forms.Padding(4);
            this.PNBottom.Name = "PNBottom";
            this.PNBottom.Size = new System.Drawing.Size(244, 57);
            this.PNBottom.TabIndex = 1;
            // 
            // BtCancel
            // 
            this.BtCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtCancel.Location = new System.Drawing.Point(0, 0);
            this.BtCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(244, 57);
            this.BtCancel.TabIndex = 0;
            this.BtCancel.Text = "CANCEL";
            this.BtCancel.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ItemsPanel);
            this.panel2.Controls.Add(this.PNBottom);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panel2.Size = new System.Drawing.Size(268, 431);
            this.panel2.TabIndex = 2;
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.AutoScroll = true;
            this.ItemsPanel.Controls.Add(this.refButton);
            this.ItemsPanel.Location = new System.Drawing.Point(13, 15);
            this.ItemsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(244, 336);
            this.ItemsPanel.TabIndex = 1;
            // 
            // refButton
            // 
            this.refButton.BackColor = System.Drawing.SystemColors.Control;
            this.refButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.refButton.HighlightColor = System.Drawing.Color.Lime;
            this.refButton.HoverColor = System.Drawing.Color.Yellow;
            this.refButton.HoverEnabled = true;
            this.refButton.Location = new System.Drawing.Point(0, 0);
            this.refButton.Margin = new System.Windows.Forms.Padding(4);
            this.refButton.Name = "refButton";
            this.refButton.Selected = false;
            this.refButton.Size = new System.Drawing.Size(244, 53);
            this.refButton.TabIndex = 2;
            this.refButton.Text = "* Reference *";
            this.refButton.UseVisualStyleBackColor = true;
            // 
            // PnDescription
            // 
            this.PnDescription.BackColor = System.Drawing.Color.Transparent;
            this.PnDescription.Controls.Add(this.lbDesc);
            this.PnDescription.Controls.Add(this.picDesc);
            this.PnDescription.Location = new System.Drawing.Point(271, 0);
            this.PnDescription.Margin = new System.Windows.Forms.Padding(4);
            this.PnDescription.Name = "PnDescription";
            this.PnDescription.Padding = new System.Windows.Forms.Padding(5);
            this.PnDescription.Size = new System.Drawing.Size(444, 431);
            this.PnDescription.TabIndex = 3;
            // 
            // lbDesc
            // 
            this.lbDesc.Location = new System.Drawing.Point(5, 354);
            this.lbDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(433, 66);
            this.lbDesc.TabIndex = 1;
            this.lbDesc.Text = "<Description Label>";
            // 
            // picDesc
            // 
            this.picDesc.Location = new System.Drawing.Point(5, 9);
            this.picDesc.Margin = new System.Windows.Forms.Padding(4);
            this.picDesc.Name = "picDesc";
            this.picDesc.Size = new System.Drawing.Size(433, 342);
            this.picDesc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDesc.TabIndex = 0;
            this.picDesc.TabStop = false;
            // 
            // SelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::FlashCard.Properties.Resources.Clouds;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(716, 432);
            this.ControlBox = false;
            this.Controls.Add(this.PnDescription);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title";
            this.VisibleChanged += new System.EventHandler(this.SelectionDialog_VisibleChanged);
            this.PNBottom.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ItemsPanel.ResumeLayout(false);
            this.PnDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDesc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNBottom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Panel ItemsPanel;
        private System.Windows.Forms.Panel PnDescription;
        private System.Windows.Forms.PictureBox picDesc;
        private System.Windows.Forms.Label lbDesc;
        private CodeArtEng.GameControls.OptionButton refButton;
    }
}