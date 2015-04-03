using System;

namespace ObjectFinderCore
{
	public static class Constants
	{
		public static Angle MinAngle = Angle.FromDegrees(0);
		public static Angle MaxAngle = Angle.FromDegrees(180);

		public static TimeSpan timeToDegree = TimeSpan.FromMilliseconds(10);
	}
}