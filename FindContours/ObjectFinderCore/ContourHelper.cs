using System;
using System.Drawing;
using Emgu.CV;

namespace ObjectFinderCore
{
	public static class ContourHelper
	{
		public static double HorizontEpsilon = 100;
		public static double MinimalArea = 80;

		public static bool IsOnHorizont(Contour<Point> contour, int maxY)
		{
			var rectangle = contour.BoundingRectangle;
			var horizont = maxY / 2;
			var rectangleMiddleY = rectangle.Y + rectangle.Height/2;

			return Math.Abs(rectangleMiddleY - horizont) < HorizontEpsilon;
		}

		public static Point Center(this Contour<Point> contour)
		{
			var rectangle = contour.BoundingRectangle;
			return new Point(rectangle.X + rectangle.Width/2, rectangle.Y + rectangle.Height/2);
		}
	}
}