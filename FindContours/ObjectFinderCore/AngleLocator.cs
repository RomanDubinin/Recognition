using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ObjectFinderCore
{
	public class AngleLocator
	{
		private readonly Sensor MySensor;
		private readonly IRotateStand Stand;

		public AngleLocator(Sensor mySensor, IRotateStand stand)
		{
			MySensor = mySensor;
			Stand = stand;
			Task.Factory.StartNew(StandRotation);
			Task.Factory.StartNew(StartReading);

		}

		private void StartReading()
		{
			while (true)
			{
				var degreesForLastData = Stand.CurrentAngle.TotalDegrees;
				var dataFromSensor = MySensor.Read();
				GotValue(dataFromSensor.Select(angle => Angle.FromDegrees(degreesForLastData) + angle - Constants.MinAngle).ToList());
				//Console.Clear();
//				foreach (var angle in dataFromSensor)
//				{
//					Console.WriteLine(angle);
//				}
			}

		}

		private void StandRotation()
		{
			
			var step = Angle.FromDegrees(1);
			var currentAngle = Constants.MinAngle + Angle.FromDegrees(1);
			Stand.Rotate(currentAngle);

			while (true)
			{
				while (currentAngle.TotalDegrees > Constants.MinAngle.TotalDegrees && 
					   currentAngle.TotalDegrees < Constants.MaxAngle.TotalDegrees)
				{
					currentAngle += step;
					Stand.Rotate(currentAngle);
					Thread.Sleep(Constants.TimeToDegree);
					
				}

				step = Angle.FromDegrees(-1*step.TotalDegrees);
				currentAngle += step;
			}
		}

		public event Action<List<Angle>> GotValue = delegate {};
	}
}