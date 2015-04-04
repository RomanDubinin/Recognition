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
			Serial = new SerialPort(string.Format("COM{0}", serialNum));
			Serial.Open();
			Console.WriteLine("open");
		}

		public Angle CurrentAngle { get; set; }
		public void Rotate(Angle newAngle)
		{
			Serial.WriteLine(string.Format("rotate{0}", ((int)(newAngle.TotalDegrees)).ToString("D3")));
			CurrentAngle = newAngle;
		}
	}
}