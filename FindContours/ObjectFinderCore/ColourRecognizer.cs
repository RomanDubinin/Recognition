using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ObjectFinderCore
{
	public class ColourRecognizer
	{
		public Hsv ColourFrom { get; set; }
		public Hsv ColourTo { get; set; }
		public bool Invert { get; set; }

		public ColourRecognizer(Hsv colourFrom, Hsv colourTo, bool invert)
		{
			ColourFrom = colourFrom;
			ColourTo = colourTo;
			Invert = invert;
		}

		public List<Contour<Point>> FindAllContours(Bitmap image, MemStorage memStorage)
		{
			var cuttedColoursImage = new Image<Hsv, byte>(image).InRange(ColourFrom, ColourTo);

			if (Invert)
				cuttedColoursImage._Not();

			var resultContours = new List<Contour<Point>>();

			for (
				var contours = cuttedColoursImage.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_TC89_L1, RETR_TYPE.CV_RETR_EXTERNAL, memStorage);
				contours != null;
				contours = contours.HNext)
			{
				var currentContour = contours.ApproxPoly(contours.Perimeter*0.015, memStorage);
				resultContours.Add(currentContour);
			}


			return resultContours;
		}

		public List<Contour<Point>> FindAllContours(Bitmap image)
		{
			var cuttedColoursImage = new Image<Hsv, byte>(image).InRange(ColourFrom, ColourTo);

			if (Invert)
				cuttedColoursImage._Not();

			var resultContours = new List<Contour<Point>>();

			for (
				var contours = cuttedColoursImage.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_TC89_L1, RETR_TYPE.CV_RETR_EXTERNAL);
				contours != null;
				contours = contours.HNext)
			{
				var currentContour = contours.ApproxPoly(contours.Perimeter * 0.015);
				resultContours.Add(currentContour);
			}


			return resultContours;
		}
	}
}