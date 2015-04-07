using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV;

namespace ObjectFinderCore
{
	//todo: название
	public class ColorSensor
	{
		private readonly IImageProvider ImageProvider;
		private readonly ColourRecognizer Recognizer;
		private readonly double MaxValue;
		private readonly double MinValue;

		public ColorSensor(IImageProvider imageProvider, ColourRecognizer recognizer, double minValue, double maxValue)
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
				photo = ImageProvider.GetBitmap();

			var contours = Recognizer.FindAllContours(photo);
			var selectedContours = contours
				.Where(c => Selector(c, photo)).ToList();

			var angles = selectedContours
				.Select(contour => Angle.FromDegrees(ScaleValue(contour.Center().X, 0, photo.Width, MinValue, MaxValue)))
				.ToList();
			
			HasContours(selectedContours);
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

		//штука нужна только для рисования
		public event Action<List<Contour<Point>>> HasContours = delegate { };
	}
}