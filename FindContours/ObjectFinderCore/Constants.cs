using System;
using Emgu.CV.Structure;

namespace ObjectFinderCore
{
	public static class Constants
	{
		public static Angle MinAngle = Angle.FromDegrees(40);
		public static Angle MaxAngle = Angle.FromDegrees(100);

		public static TimeSpan TimeToDegree = TimeSpan.FromMilliseconds(30);

		public static Hsv GreenFrom = new Hsv(49, 79, 42);
		public static Hsv GreenTo = new Hsv(108, 231, 194);

		public static Hsv PinkFrom = new Hsv(165, 52, 210);
		public static Hsv PinkTo = new Hsv(194, 165, 255);
	}
}