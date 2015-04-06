using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
		}

		public List<Angle> Read()
		{

			var photo = ImageProvider.GetBitmap();
			while (photo == null) //на некоторых машинах бывают проблемы
			{
				photo = ImageProvider.GetBitmap();
			}

			List<Angle> angles;
			using (var memStorage = new MemStorage())
			{
				var contours = Recognizer.FindAllContours(photo, memStorage);
				var selected = contours
					.Where(c => Selector(c, photo)).ToList();
				HasContours(selected);
				Console.WriteLine(selected.Count);
				angles = selected
					.Select(contour => Angle.FromDegrees(ScaleValue(contour.Center().X, 0, photo.Width, MinValue, MaxValue)))
					.ToList();
			}

			return angles;
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
//			if (!ContourHelper.IsOnHorizont(contour, image.Height))
//				return false;

			if (contour.Area < ContourHelper.MinimalArea)
				return false;

			return true;
		}

		public event Action<List<Contour<Point>>> HasContours = delegate { };
	}
}