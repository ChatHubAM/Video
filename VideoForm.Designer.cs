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
			// pictureBox1
			// 
			this.senderBox.Location = new System.Drawing.Point(404, 338);
			this.senderBox.Name = "senderBox";
			this.senderBox.Size = new System.Drawing.Size(236, 149);
			this.senderBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.senderBox.TabIndex = 0;
			this.senderBox.TabStop = false;
			// 
			// cmbVideoSource
			// 
			this.cmbVideoSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmbVideoSource.FormattingEnabled = true;
			this.cmbVideoSource.Location = new System.Drawing.Point(15, 501);
			this.cmbVideoSource.Name = "cmbVideoSource";
			this.cmbVideoSource.Size = new System.Drawing.Size(219, 21);
			this.cmbVideoSource.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 485);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select video source";
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStart.Location = new System.Drawing.Point(240, 493);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(90, 29);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStop.Location = new System.Drawing.Point(336, 493);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(90, 29);
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// receiverBox
			// 
			this.receiverBox.Location = new System.Drawing.Point(15, 12);
			this.receiverBox.Name = "receiverBox";
			this.receiverBox.Size = new System.Drawing.Size(300, 200);
			this.receiverBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.receiverBox.TabIndex = 5;
			this.receiverBox.TabStop = false;
			// 
			// VideoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 534);
			this.Controls.Add(this.receiverBox);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbVideoSource);
			this.Controls.Add(this.senderBox);
			this.Name = "VideoForm";
			this.Text = "Form1";
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

