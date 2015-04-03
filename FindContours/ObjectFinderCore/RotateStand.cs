namespace ObjectFinderCore
{
	public class RotateStand : IRotateStand
	{
		public Angle CurrentAngle { get; set; }
		public void Rotate(Angle newAngle)
		{
			CurrentAngle = newAngle;
		}
	}
}