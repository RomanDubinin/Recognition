﻿using System;
using System.Collections.Generic;
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
		private readonly ColourRecognizer ColourRecognizer;
		private readonly Camera Camera1;

		public FrmContours()
		{
			InitializeComponent();
			ColourRecognizer = new ColourRecognizer(new Hsv(0,0,0), new Hsv(0,0,0), false);
			Camera1 = new Camera(0); 

			var sensor = new ColorSensor(Camera1, ColourRecognizer,-16, 16);
			var angleLocator = new AngleLocator(sensor, new RotateStand(4), Angle.FromDegrees(20));
			angleLocator.GotValue += PrintData;
			sensor.HasContours += ViewContours;
		}

		private void ViewContours(List<Contour<Point>> contours)
		{
			foreach (var contour in contours)
			{
				var myEye = new Image<Bgr, byte>(640, 640);
				myEye.Draw(contour.BoundingRectangle, new Bgr(Color.DeepPink), -1);
				pictBoxColor.Image = myEye.PyrDown().Bitmap;
			}
		}

		private void PrintData(List<Angle> angles)
		{
			Console.Clear();
			foreach (var angle in angles)
			{
				Console.WriteLine(angle);
			}
		}

		/// <summary>
		/// Starts the camera capture.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCapture_Click(object sender, EventArgs e)
		{
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
		}

		/// <summary>
		/// Start capturing from the camera stream.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CameraStreamCapture_Tick(object sender, EventArgs e)
		{

			var image = Camera1.GetBitmap();

			var colourFrom = Constants.PinkFrom;//new Hsv(trackBar1.Value, trackBar2.Value, trackBar3.Value);
			var colourTo = Constants.PinkTo;//new Hsv(trackBar4.Value, trackBar5.Value, trackBar6.Value);

			var myEye = new Image<Bgr, byte>(image);
			var roboEye = new Image<Hsv, byte>(image).InRange(colourFrom, colourTo);

			ColourRecognizer.Invert = chkBoxInvert.Checked;
			ColourRecognizer.ColourFrom = colourFrom;
			ColourRecognizer.ColourTo = colourTo;
			

			
			pictBoxGray.Image = roboEye.PyrDown().Bitmap;
		}

		/// <summary>
		/// Stop the camera and release resources when the form is closing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmContours_FormClosing(object sender, FormClosingEventArgs e)
		{
			CameraStreamCapture.Enabled = false;
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
