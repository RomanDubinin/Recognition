using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ObjectFinderCore
{
	public class ObjectFinder
	{
		public List<Contour<Point>> FindAllContours(Bitmap image, Hsv colourFrom, Hsv colourTo, bool invert)
		{
			var cuttedColoursImage = new Image<Hsv, byte>(image).InRange(colourFrom, colourTo);

			if (invert)
				cuttedColoursImage._Not();

			var resultContours = new List<Contour<Point>>();

			for (
				var contours = cuttedColoursImage.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_TC89_L1, RETR_TYPE.CV_RETR_EXTERNAL);
				contours != null;
				contours = contours.HNext)
			{
				var currentContour = contours.ApproxPoly(contours.Perimeter*0.015);
				resultContours.Add(currentContour);
			}


			return resultContours;
		}

		public List<Contour<Point>> FindContoursInRightSize(Bitmap image, Hsv colourFrom, Hsv colourTo, bool invert,
			double areaFrom, double areaTo)
		{
			var allContours = FindAllContours(image, colourFrom, colourTo, invert);
			return allContours.Where(contour => contour.Area >= areaFrom && contour.Area <= areaTo).ToList();
		}
	}
}