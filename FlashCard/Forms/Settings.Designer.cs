namespace FlashCard
{
    partial class Settings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtCancel = new System.Windows.Forms.Button();
            this.BtOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumericHintInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NumericInitialHintInterval = new System.Windows.Forms.NumericUpDown();
            this.chkHintSpelling = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtSpeak = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtSpeechSample = new System.Windows.Forms.TextBox();
            this.CbVoices = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TrackSpeechSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHintInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericInitialHintInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSpeechSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtCancel);
            this.panel1.Controls.Add(this.BtOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 50);
            this.panel1.TabIndex = 0;
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(289, 10);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(81, 30);
            this.BtCancel.TabIndex = 1;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // BtOK
            // 
            this.BtOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtOK.Location = new System.Drawing.Point(202, 10);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(81, 30);
            this.BtOK.TabIndex = 0;
            this.BtOK.Text = "OK";
            this.BtOK.UseVisualStyleBackColor = true;
            this.BtOK.Click += new System.EventHandler(this.BtOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumericHintInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumericInitialHintInterval);
            this.groupBox1.Controls.Add(this.chkHintSpelling);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spelling Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hint Interval (s)";
            // 
            // NumericHintInterval
            // 
            this.NumericHintInterval.Location = new System.Drawing.Point(170, 73);
            this.NumericHintInterval.Name = "NumericHintInterval";
            this.NumericHintInterval.Size = new System.Drawing.Size(43, 22);
            this.NumericHintInterval.TabIndex = 4;
            this.NumericHintInterval.Value = new decimal(new int[] {
            99,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Initial Hint Interval (s)";
            // 
            // NumericInitialHintInterval
            // 
            this.NumericInitialHintInterval.Location = new System.Drawing.Point(170, 48);
            this.NumericInitialHintInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericInitialHintInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericInitialHintInterval.Name = "NumericInitialHintInterval";
            this.NumericInitialHintInterval.Size = new System.Drawing.Size(43, 22);
            this.NumericInitialHintInterval.TabIndex = 2;
            this.NumericInitialHintInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkHintSpelling
            // 
            this.chkHintSpelling.AutoSize = true;
            this.chkHintSpelling.Location = new System.Drawing.Point(17, 26);
            this.chkHintSpelling.Name = "chkHintSpelling";
            this.chkHintSpelling.Size = new System.Drawing.Size(141, 21);
            this.chkHintSpelling.TabIndex = 0;
            this.chkHintSpelling.Text = "Hint (Play Sound)";
            this.chkHintSpelling.UseVisualStyleBackColor = true;
            this.chkHintSpelling.CheckedChanged += new System.EventHandler(this.chkHintSpelling_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtSpeak);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtSpeechSample);
            this.groupBox2.Controls.Add(this.CbVoices);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TrackSpeechSpeed);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 167);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Speech";
            // 
            // BtSpeak
            // 
            this.BtSpeak.Location = new System.Drawing.Point(287, 110);
            this.BtSpeak.Name = "BtSpeak";
            this.BtSpeak.Size = new System.Drawing.Size(75, 26);
            this.BtSpeak.TabIndex = 8;
            this.BtSpeak.Text = "Speak";
            this.BtSpeak.UseVisualStyleBackColor = true;
            this.BtSpeak.Click += new System.EventHandler(this.BtSpeak_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sample";
            // 
            // TxtSpeechSample
            // 
            this.TxtSpeechSample.Location = new System.Drawing.Point(71, 112);
            this.TxtSpeechSample.Name = "TxtSpeechSample";
            this.TxtSpeechSample.Size = new System.Drawing.Size(212, 22);
            this.TxtSpeechSample.TabIndex = 6;
            this.TxtSpeechSample.Text = "HELLO";
            // 
            // CbVoices
            // 
            this.CbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbVoices.FormattingEnabled = true;
            this.CbVoices.Location = new System.Drawing.Point(71, 21);
            this.CbVoices.Name = "CbVoices";
            this.CbVoices.Size = new System.Drawing.Size(291, 24);
            this.CbVoices.TabIndex = 5;
            this.CbVoices.SelectedIndexChanged += new System.EventHandler(this.CbVoices_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Voice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fast";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Slow";
            // 
            // TrackSpeechSpeed
            // 
            this.TrackSpeechSpeed.Location = new System.Drawing.Point(61, 50);
            this.TrackSpeechSpeed.Minimum = -10;
            this.TrackSpeechSpeed.Name = "TrackSpeechSpeed";
            this.TrackSpeechSpeed.Size = new System.Drawing.Size(309, 56);
            this.TrackSpeechSpeed.TabIndex = 1;
            this.TrackSpeechSpeed.Scroll += new System.EventHandler(this.TrackSpeechSpeed_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Speed";
            // 
            // Settings
            // 
            this.AcceptButton = this.BtOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(387, 371);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericHintInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericInitialHintInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSpeechSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkHintSpelling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NumericHintInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumericInitialHintInterval;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar TrackSpeechSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbVoices;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtSpeak;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtSpeechSample;
    }
}