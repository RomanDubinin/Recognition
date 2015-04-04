using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV;

namespace ObjectFinderCore
{
	//todo: название
	public class Sensor
	{
		private readonly IImageProvider ImageProvider;
		private readonly ColourRecognizer Recognizer;
		private readonly double MaxValue;
		private readonly double MinValue;

		public Sensor(IImageProvider imageProvider, ColourRecognizer recognizer, double minValue, double maxValue)
		{
			ImageProvider = imageProvider;
			Recognizer = recognizer;
			MinValue = minValue;
			MaxValue = maxValue;

			Task.Factory.StartNew(StartReadData);
		}

		private void StartReadData()
		{
			while (true)
			{
				var photo = ImageProvider.GetBitmap();
				if (photo == null)
					continue;
				List<Angle> angles;
				using (var memStorage = new MemStorage())
				{
					var contours = Recognizer.FindAllContours(photo, memStorage);
					angles = contours
						.Where(c => Selector(c, photo))
						.Select(contour => Angle.FromDegrees(ScaleValue(contour.Center().X, 0, photo.Width, MinValue, MaxValue)))
						.ToList();
				}
				

				GotValue(angles);
			}
		}

		private double ScaleValue(double value, double valuemin, double valuemax, double scalemin, double scalemax)
		{
			var vPerc = (value - valuemin) / (valuemax - valuemin);
			var bigSpan = vPerc * (scalemax - scalemin);

			var retVal = scalemin + bigSpan;

			return retVal;
		}

		private bool Selector(Contour<Point> contour, Bitmap image)
		{
			if (!ContourHelper.IsOnHorizont(contour, image.Height))
				return false;

			if (contour.Area < ContourHelper.MinimalArea)
				return false;

			return true;
		}

		public event Action<List<Angle>> GotValue = delegate {};
	}
}