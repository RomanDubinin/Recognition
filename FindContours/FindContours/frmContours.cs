using System;
using System.Drawing;
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
				capture = new Emgu.CV.Capture(1);// cam num
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
            processor.IdentifyContours(image, trackBar1.Value, trackBar2.Value, trackBar3.Value, trackBar4.Value, trackBar5.Value, trackBar6.Value, chkBoxInvert.Checked, out gray, out color);
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

		private void trackBar6_Scroll(object sender, EventArgs e)
		{

		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{

		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{

		}

		private void trackBar3_Scroll(object sender, EventArgs e)
		{

		}

		private void trackBar4_Scroll(object sender, EventArgs e)
		{

		}

		private void trackBar5_Scroll(object sender, EventArgs e)
		{

		}
    }
}
