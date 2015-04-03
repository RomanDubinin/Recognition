using System;
using System.Drawing;
using Emgu.CV;

namespace ObjectFinderCore
{
	public static class ContourHelper
	{
		public static bool IsOnHorizont(Contour<Point> contour, int maxY, double epsilon)
		{
			var rectangle = contour.BoundingRectangle;
			var horizont = maxY / 2;
			var rectangleMiddleY = rectangle.Y + rectangle.Height/2;

			return Math.Abs(rectangleMiddleY - horizont) < epsilon;
		}

		public static Point Center(this Contour<Point> contour)
		{
			var rectangle = contour.BoundingRectangle;
			return new Point(rectangle.X + rectangle.Width/2, rectangle.Y + rectangle.Height/2);
		}
	}
}