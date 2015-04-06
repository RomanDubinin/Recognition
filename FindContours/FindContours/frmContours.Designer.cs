using System.Windows.Forms;

namespace FindContours
{
    partial class FrmContours
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
			this.btnCapture = new System.Windows.Forms.Button();
			this.grpControls = new System.Windows.Forms.GroupBox();
			this.trackBar6 = new System.Windows.Forms.TrackBar();
			this.trackBar5 = new System.Windows.Forms.TrackBar();
			this.trackBar4 = new System.Windows.Forms.TrackBar();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.btnStopCapture = new System.Windows.Forms.Button();
			this.chkBoxInvert = new System.Windows.Forms.CheckBox();
			this.grpColor = new System.Windows.Forms.GroupBox();
			this.pictBoxColor = new System.Windows.Forms.PictureBox();
			this.grpGray = new System.Windows.Forms.GroupBox();
			this.pictBoxGray = new System.Windows.Forms.PictureBox();
			this.CameraStreamCapture = new System.Windows.Forms.Timer(this.components);
	        CameraStreamCapture.Enabled = true;
			this.grpControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			this.grpColor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictBoxColor)).BeginInit();
			this.grpGray.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictBoxGray)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCapture
			// 
			this.btnCapture.Location = new System.Drawing.Point(17, 19);
			this.btnCapture.Name = "btnCapture";
			this.btnCapture.Size = new System.Drawing.Size(88, 38);
			this.btnCapture.TabIndex = 0;
			this.btnCapture.Text = "Start Camera Stream";
			this.btnCapture.UseVisualStyleBackColor = true;
			this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
			// 
			// grpControls
			// 
			this.grpControls.Controls.Add(this.trackBar6);
			this.grpControls.Controls.Add(this.trackBar5);
			this.grpControls.Controls.Add(this.trackBar4);
			this.grpControls.Controls.Add(this.trackBar3);
			this.grpControls.Controls.Add(this.trackBar1);
			this.grpControls.Controls.Add(this.trackBar2);
			this.grpControls.Controls.Add(this.btnStopCapture);
			this.grpControls.Controls.Add(this.btnCapture);
			this.grpControls.Location = new System.Drawing.Point(12, 12);
			this.grpControls.Name = "grpControls";
			this.grpControls.Size = new System.Drawing.Size(931, 107);
			this.grpControls.TabIndex = 1;
			this.grpControls.TabStop = false;
			this.grpControls.Text = "Controls";
			// 
			// trackBar6
			// 
			this.trackBar6.LargeChange = 1;
			this.trackBar6.Location = new System.Drawing.Point(643, 62);
			this.trackBar6.Maximum = 255;
			this.trackBar6.Name = "trackBar6";
			this.trackBar6.Size = new System.Drawing.Size(254, 45);
			this.trackBar6.TabIndex = 2;
			this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
			// 
			// trackBar5
			// 
			this.trackBar5.LargeChange = 1;
			this.trackBar5.Location = new System.Drawing.Point(383, 63);
			this.trackBar5.Maximum = 255;
			this.trackBar5.Name = "trackBar5";
			this.trackBar5.Size = new System.Drawing.Size(254, 45);
			this.trackBar5.TabIndex = 2;
			this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
			// 
			// trackBar4
			// 
			this.trackBar4.LargeChange = 1;
			this.trackBar4.Location = new System.Drawing.Point(123, 62);
			this.trackBar4.Maximum = 255;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new System.Drawing.Size(254, 45);
			this.trackBar4.TabIndex = 2;
			this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
			// 
			// trackBar3
			// 
			this.trackBar3.LargeChange = 1;
			this.trackBar3.Location = new System.Drawing.Point(643, 12);
			this.trackBar3.Maximum = 255;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(254, 45);
			this.trackBar3.TabIndex = 2;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new System.Drawing.Point(123, 12);
			this.trackBar1.Maximum = 255;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(254, 45);
			this.trackBar1.TabIndex = 2;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// trackBar2
			// 
			this.trackBar2.LargeChange = 1;
			this.trackBar2.Location = new System.Drawing.Point(383, 12);
			this.trackBar2.Maximum = 255;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(254, 45);
			this.trackBar2.TabIndex = 2;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// btnStopCapture
			// 
			this.btnStopCapture.Location = new System.Drawing.Point(17, 63);
			this.btnStopCapture.Name = "btnStopCapture";
			this.btnStopCapture.Size = new System.Drawing.Size(88, 38);
			this.btnStopCapture.TabIndex = 0;
			this.btnStopCapture.Text = "Stop Camera Stream";
			this.btnStopCapture.UseVisualStyleBackColor = true;
			this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
			// 
			// chkBoxInvert
			// 
			this.chkBoxInvert.AutoSize = true;
			this.chkBoxInvert.Location = new System.Drawing.Point(29, 125);
			this.chkBoxInvert.Name = "chkBoxInvert";
			this.chkBoxInvert.Size = new System.Drawing.Size(85, 17);
			this.chkBoxInvert.TabIndex = 4;
			this.chkBoxInvert.Text = "Invert Image";
			this.chkBoxInvert.UseVisualStyleBackColor = true;
			// 
			// grpColor
			// 
			this.grpColor.Controls.Add(this.pictBoxColor);
			this.grpColor.Location = new System.Drawing.Point(13, 180);
			this.grpColor.Name = "grpColor";
			this.grpColor.Size = new System.Drawing.Size(399, 316);
			this.grpColor.TabIndex = 2;
			this.grpColor.TabStop = false;
			this.grpColor.Text = "Color Image";
			// 
			// pictBoxColor
			// 
			this.pictBoxColor.Location = new System.Drawing.Point(6, 39);
			this.pictBoxColor.Name = "pictBoxColor";
			this.pictBoxColor.Size = new System.Drawing.Size(370, 263);
			this.pictBoxColor.TabIndex = 0;
			this.pictBoxColor.TabStop = false;
			// 
			// grpGray
			// 
			this.grpGray.Controls.Add(this.pictBoxGray);
			this.grpGray.Location = new System.Drawing.Point(544, 180);
			this.grpGray.Name = "grpGray";
			this.grpGray.Size = new System.Drawing.Size(399, 316);
			this.grpGray.TabIndex = 2;
			this.grpGray.TabStop = false;
			this.grpGray.Text = "Monochrome";
			// 
			// pictBoxGray
			// 
			this.pictBoxGray.Location = new System.Drawing.Point(6, 39);
			this.pictBoxGray.Name = "pictBoxGray";
			this.pictBoxGray.Size = new System.Drawing.Size(370, 263);
			this.pictBoxGray.TabIndex = 0;
			this.pictBoxGray.TabStop = false;
			// 
			// CameraStreamCapture
			// 
			this.CameraStreamCapture.Tick += new System.EventHandler(this.CameraStreamCapture_Tick);
			// 
			// FrmContours
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(951, 505);
			this.Controls.Add(this.chkBoxInvert);
			this.Controls.Add(this.grpGray);
			this.Controls.Add(this.grpColor);
			this.Controls.Add(this.grpControls);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmContours";
			this.Text = "Contour Extraction";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContours_FormClosing);
			this.grpControls.ResumeLayout(false);
			this.grpControls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			this.grpColor.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictBoxColor)).EndInit();
			this.grpGray.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictBoxGray)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Button btnStopCapture;
        private System.Windows.Forms.GroupBox grpColor;
        private System.Windows.Forms.GroupBox grpGray;
        private System.Windows.Forms.CheckBox chkBoxInvert;
        private System.Windows.Forms.PictureBox pictBoxColor;
        private System.Windows.Forms.PictureBox pictBoxGray;
        private System.Windows.Forms.Timer CameraStreamCapture;
		private TrackBar trackBar6;
		private TrackBar trackBar5;
		private TrackBar trackBar4;
		private TrackBar trackBar3;
		private TrackBar trackBar1;
		private TrackBar trackBar2;
    }
}

