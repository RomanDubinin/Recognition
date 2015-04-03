using System;

namespace ObjectFinderCore
{
	public class Angle
	{
		private double Value { get; set; }

		public double TotalDegrees
		{
			get { return Value; }
		}

		public double TotalRadians
		{
			get { return Value*Math.PI/180; }
		}

		public Angle Simplify180()
		{
			var degrees = TotalDegrees;
			while (degrees > 180)
				degrees -= 360;
			while (degrees < -180)
				degrees += 360;
			return FromDegrees(degrees);
		}

		public double Sin()
		{
			return Math.Sin(TotalRadians);
		}

		public double Cos()
		{
			return Math.Cos(TotalRadians);
		}

		public static Angle operator +(Angle a, Angle b)
		{
			return new Angle { Value = a.Value + b.Value };
		}

		private static double GetValue180FromRadian(double radian)
		{
			return GetValue180FromDegrees(radian*180/Math.PI);
		}

		private static double GetValue180FromDegrees(double degrees)
		{
			while (degrees > 180)
				degrees -= 360;
			while (degrees < -180)
				degrees += 360;
			return degrees;
		}

		public static Angle FromRadians(double radians)
		{
			return new Angle{Value = GetValue180FromRadian(radians)};
		}
		
		public static Angle FromDegrees(double d)
		{
			return new Angle {Value = GetValue180FromDegrees(d)};
		}

		public override string ToString()
		{
			return string.Format("{{{0} deg}}", TotalDegrees);
		}
	}
}