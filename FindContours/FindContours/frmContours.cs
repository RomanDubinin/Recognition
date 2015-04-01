using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Developed by : Lasitha Ishan Petthawadu
 * Email        : petthawadu3@gmail.com
 * Description  : http://wp.me/p429SV-8G
 * Date : 12/06/2014
 */
namespace FindContours
{
    /// <summary>
    /// Main form to interact with EmguCV for contour processing.
    /// </summary>
    public partial class FrmContours : Form
    {
        Emgu.CV.Capture capture;
        FindContours processor = new FindContours();
        Bitmap colorImage;

        /// <summary>
        /// Initializes the initial tracker value to th tracker label.
        /// </summary>
        public FrmContours()
        {
            InitializeComponent();
            lblThresholdValue1.Text = trackbarThreshold1.Value.ToString();
            lblThresholdValue2.Text = trackbarThreshold2.Value.ToString();
        }

        /// <summary>
        /// Updates the threshold label when the tracker changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackbarThreshold_Scroll1(object sender, EventArgs e)
        {
            lblThresholdValue1.Text = trackbarThreshold1.Value.ToString();
        }

		private void trackbarThreshold_Scroll2(object sender, EventArgs e)
		{
			lblThresholdValue2.Text = trackbarThreshold1.Value.ToString();
		}

        /// <summary>
        /// Starts the camera capture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapture_Click(object sender, EventArgs e)
        {
			if (capture == null)
            {
				capture = new Emgu.CV.Capture();
            }
            CameraStreamCapture.Enabled = true;

        }

        /// <summary>
        /// Stops the Camera capture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            CameraStreamCapture.Enabled = false;
			if (capture != null)
            {
				capture.Dispose();
				capture = null;
            }

        }
        /// <summary>
        /// Start capturing from the camera stream.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraStreamCapture_Tick(object sender, EventArgs e)
        {
			var qf = capture.QueryFrame();
	        if (qf == null)
	        {
				return;
	        }
			var bm = qf.ToBitmap();
			var image = bm;
            Bitmap color;
            Bitmap gray;
			//image = new Bitmap("C:\\Users\\Roman\\Desktop\\Untitled3.png");
			//image = new Bitmap("C:\\Emgu\\emgucv-windows-universal-cuda 2.4.10.1940\\bin\\pedestrian.png");
			//image = new Bitmap("C:\\Emgu\\emgucv-windows-universal-cuda 2.4.10.1940\\bin\\stop-sign.jpg");
            processor.IdentifyContours(image, trackbarThreshold1.Value, trackbarThreshold2.Value, chkBoxInvert.Checked, out gray, out color);
            pictBoxColor.Image = color;
            pictBoxGray.Image = gray;
        }

        /// <summary>
        /// Stop the camera and release resources when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmContours_FormClosing(object sender, FormClosingEventArgs e)
        {
            CameraStreamCapture.Enabled = false;
			capture = null;
        }
    }
}
