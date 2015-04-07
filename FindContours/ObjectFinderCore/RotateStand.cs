using System.IO.Ports;

namespace ObjectFinderCore
{
	public class RotateStand : IRotateStand
	{
		private readonly SerialPort Serial;
		public RotateStand(int serialNum)
		{
			Serial = new SerialPort(string.Format("COM{0}", serialNum), 115200);
			Serial.Open();
		}

		private volatile Angle InternalCurrentAngle;

		public Angle CurrentAngle
		{
			get { return InternalCurrentAngle; }
			set { InternalCurrentAngle = value; }
		}

		public void Rotate(Angle newAngle)
		{
			Serial.WriteLine(string.Format("rotate{0}", ((int)(newAngle.TotalDegrees)).ToString("D3")));
			CurrentAngle = newAngle;
		}
	}
}