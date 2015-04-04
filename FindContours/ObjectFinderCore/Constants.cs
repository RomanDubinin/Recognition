using System;

namespace ObjectFinderCore
{
	public static class Constants
	{
		public static Angle MinAngle = Angle.FromDegrees(30);
		public static Angle MaxAngle = Angle.FromDegrees(120);

		public static TimeSpan TimeToDegree = TimeSpan.FromMilliseconds(10);
	}
}