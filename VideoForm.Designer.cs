namespace AForge.WindowsForms
{
    partial class VideoForm
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
            this.senderBox = new System.Windows.Forms.PictureBox();
            this.cmbVideoSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.receiverBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.senderBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiverBox)).BeginInit();
            this.SuspendLayout();
            // 
            // senderBox
            // 
            this.senderBox.Location = new System.Drawing.Point(539, 416);
            this.senderBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.senderBox.Name = "senderBox";
            this.senderBox.Size = new System.Drawing.Size(315, 183);
            this.senderBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.senderBox.TabIndex = 0;
            this.senderBox.TabStop = false;
            // 
            // cmbVideoSource
            // 
            this.cmbVideoSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbVideoSource.FormattingEnabled = true;
            this.cmbVideoSource.Location = new System.Drawing.Point(20, 617);
            this.cmbVideoSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbVideoSource.Name = "cmbVideoSource";
            this.cmbVideoSource.Size = new System.Drawing.Size(291, 24);
            this.cmbVideoSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 597);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select video source";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(320, 607);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 36);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(448, 607);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 36);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // receiverBox
            // 
            this.receiverBox.Location = new System.Drawing.Point(20, 15);
            this.receiverBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receiverBox.Name = "receiverBox";
            this.receiverBox.Size = new System.Drawing.Size(400, 246);
            this.receiverBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.receiverBox.TabIndex = 5;
            this.receiverBox.TabStop = false;
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 657);
            this.Controls.Add(this.receiverBox);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVideoSource);
            this.Controls.Add(this.senderBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VideoForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.VideoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.senderBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiverBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox senderBox;
        private System.Windows.Forms.ComboBox cmbVideoSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.PictureBox receiverBox;
	}
}

