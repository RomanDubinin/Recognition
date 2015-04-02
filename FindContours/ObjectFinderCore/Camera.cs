using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace ObjectFinderCore
{
	public class Camera : IImageProvider
	{
		private Capture сapture;

		public Camera(int camNum)
		{
			сapture = new Capture(camNum);
		}

		public Bitmap GetBitmap()
		{
			var frame = сapture.QueryFrame();

			if (frame == null)
				return null;
			return frame.Bitmap;
		}
	}
}