namespace ObjectFinderCore
{
	public interface IRotateStand
	{
		Angle CurrentAngle { get; set; }
		void Rotate(Angle newAngle);
	}
}