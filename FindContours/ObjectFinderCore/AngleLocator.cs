﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ObjectFinderCore
{
	public class AngleLocator
	{
		private readonly IRotateStand Stand;

		public AngleLocator(Sensor sensor, IRotateStand stand)
		{
			Stand = stand;

			sensor.GotValue += OnGotValue;
			Task.Factory.StartNew(StandRotation);
			
		}

		private void OnGotValue(List<Angle> angles)
		{
			GotValue(angles.Select(angle => angle + Stand.CurrentAngle - Constants.MinAngle).ToList());

//			if (Math.Abs((Stand.CurrentAngle - Constants.MinAngle - Angle.FromDegrees(45)).TotalDegrees) < 2)
//			{
//				Console.Clear();
//				Console.WriteLine(123);
//				foreach (var angle in angles)
//				{
//					
//					Console.WriteLine(angle);
//				}
//			}

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