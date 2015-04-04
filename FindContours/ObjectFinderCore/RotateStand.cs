using System;
using System.IO.Ports;

namespace ObjectFinderCore
{
	public class RotateStand : IRotateStand
	{
		private readonly SerialPort Serial;
		public RotateStand(int serialNum)
		{
			Console.WriteLine("serial");
			Serial = new SerialPort(string.Format("COM{0}", serialNum), 115200);
			Serial.Open();
			Console.WriteLine("open");
		}

		private volatile Angle a;

		public Angle CurrentAngle { get { return a; } set { a = value; } }
		public void Rotate(Angle newAngle)
		{
			Serial.WriteLine(string.Format("rotate{0}", ((int)(newAngle.TotalDegrees)).ToString("D3")));
			CurrentAngle = newAngle;
		}
	}
}