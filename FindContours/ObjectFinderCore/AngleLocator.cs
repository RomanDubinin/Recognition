using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectFinderCore
{
	public class AngleLocator
	{
		private readonly ColorSensor MyColorSensor;
		private readonly IRotateStand Stand;
		private Angle RotationStep;

		public AngleLocator(ColorSensor myColorSensor, IRotateStand stand, Angle rotationStep)
		{
			MyColorSensor = myColorSensor;
			Stand = stand;
			RotationStep = rotationStep;
			Task.Factory.StartNew(StandRotation);
		}

		private void StandRotation()
		{
			var currentAngle = Constants.MinAngle;
			Stand.Rotate(currentAngle);
			while (true)
			{
				while (currentAngle.TotalDegrees >= Constants.MinAngle.TotalDegrees &&
				       currentAngle.TotalDegrees <= Constants.MaxAngle.TotalDegrees)
				{
					var degreesForLastData = Stand.CurrentAngle.TotalDegrees;
					var dataFromSensor = MyColorSensor.Read();

					GotValue(dataFromSensor.Select(angle => Angle.FromDegrees(degreesForLastData) + angle - Constants.MinAngle).ToList());

					currentAngle += RotationStep;
					Stand.Rotate(currentAngle);
					Thread.Sleep(Constants.TimeToDegree);
				}
				RotationStep = Angle.FromDegrees(-1*RotationStep.TotalDegrees);
				currentAngle += RotationStep + RotationStep;
				Stand.Rotate(currentAngle);
				Thread.Sleep(Constants.TimeToDegree);
			}
		}

		public event Action<List<Angle>> GotValue = delegate {};
	}
}