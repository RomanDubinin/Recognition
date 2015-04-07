using System.Drawing;
using Emgu.CV;

namespace ObjectFinderCore
{
	public class Camera : IImageProvider
	{
		private readonly Capture Сapture;

		public Camera(int camNum)
		{
			Сapture = new Capture(camNum);
		}

		public Bitmap GetBitmap()
		{
			var frame = Сapture.QueryFrame();
			return frame == null ? null : frame.Bitmap;
		}
	}
}