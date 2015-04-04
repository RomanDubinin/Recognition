using System;

namespace ObjectFinderCore
{
	public static class Constants
	{
		public static Angle MinAngle = Angle.FromDegrees(40);
		public static Angle MaxAngle = Angle.FromDegrees(150);

		public static TimeSpan TimeToDegree = TimeSpan.FromMilliseconds(30);
	}
}