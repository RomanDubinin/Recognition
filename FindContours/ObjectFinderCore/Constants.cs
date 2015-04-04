using System;

namespace ObjectFinderCore
{
	public static class Constants
	{
		public static Angle MinAngle = Angle.FromDegrees(0);
		public static Angle MaxAngle = Angle.FromDegrees(180);

		public static TimeSpan TimeToDegree = TimeSpan.FromMilliseconds(5);
	}
}