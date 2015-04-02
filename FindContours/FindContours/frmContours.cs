using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using ObjectFinderCore;

namespace FindContours
{
	public partial class FrmContours : Form
	{
		private Capture capture;
		private FindContours processor = new FindContours();
		private ObjectFinder ObjectFinder;

		public FrmContours()
		{
			InitializeComponent();
			ObjectFinder = new ObjectFinder();
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
				capture = new Emgu.CV.Capture(1); // cam num
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
			
			var colourFrom = new Hsv(trackBar1.Value, trackBar2.Value, trackBar3.Value);
			var colourTo = new Hsv(trackBar4.Value, trackBar5.Value, trackBar6.Value);
			
			var image = bm;
			var myEye = new Image<Bgr, byte>(image);
			var roboEye = new Image<Hsv, byte>(image).InRange(colourFrom, colourTo);

			var contours = ObjectFinder.FindAllContours(image, colourFrom, colourTo, chkBoxInvert.Checked);
			foreach (var contour in contours)
			{
				myEye.Draw(contour.BoundingRectangle, new Bgr(Color.DeepPink), 2);
			}



			pictBoxColor.Image = myEye.Bitmap;
			pictBoxGray.Image = roboEye.Bitmap;
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
