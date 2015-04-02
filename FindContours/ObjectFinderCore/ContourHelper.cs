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
	}
}