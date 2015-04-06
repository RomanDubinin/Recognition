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
//			Task.Factory.StartNew(StartReading);

		}

		private void StartReading()
		{
			while (true)
			{
				var degreesForLastData = Stand.CurrentAngle.TotalDegrees;
				var dataFromSensor = MySensor.Read();
				GotValue(dataFromSensor.Select(angle => Angle.FromDegrees(degreesForLastData) + angle - Constants.MinAngle).ToList());
				Console.Clear();
				foreach (var angle in dataFromSensor)
				{
					Console.WriteLine(angle + Angle.FromDegrees(degreesForLastData));
				}
			}

		}

		private void StandRotation()
		{
			
			var step = Angle.FromDegrees(4);
			var currentAngle = Constants.MinAngle + Angle.FromDegrees(1);
			Stand.Rotate(currentAngle);
			int i = 0;
			while (i < 2)
			{
				while (currentAngle.TotalDegrees > Constants.MinAngle.TotalDegrees && 
					   currentAngle.TotalDegrees < Constants.MaxAngle.TotalDegrees)
				{
					var degreesForLastData = Stand.CurrentAngle.TotalDegrees;
					var dataFromSensor = MySensor.Read();
					GotValue(dataFromSensor.Select(angle => Angle.FromDegrees(degreesForLastData) + angle - Constants.MinAngle).ToList());
					//Console.Clear();
					foreach (var angle in dataFromSensor)
					{
						Console.WriteLine(angle);
						Console.WriteLine(Angle.FromDegrees(degreesForLastData));
						Console.WriteLine(angle + Angle.FromDegrees(degreesForLastData));
						Console.WriteLine("===========");
					}

					currentAngle += step;
					Stand.Rotate(currentAngle);
					Thread.Sleep(Constants.TimeToDegree);
					
				}
				Console.WriteLine("==========================");
				step = Angle.FromDegrees(-1*step.TotalDegrees);
				currentAngle += step;
				Stand.Rotate(currentAngle);
				Thread.Sleep(Constants.TimeToDegree);
				i++;
			}
		}

		public event Action<List<Angle>> GotValue = delegate {};
	}
}