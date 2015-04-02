using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
/**
 * Developed by : Lasitha Ishan Petthawadu
 * Email        : petthawadu3@gmail.com
 * Description  : http://wp.me/p429SV-8G
 * Date : 12/06/2014
 */
namespace FindContours
{
    class FindContours
    {
        public void IdentifyContours(Bitmap actualImage,int thresholdValue1, int thresholdValue2, bool invert,out Bitmap processedGray,out Bitmap processedColor)
        {

            //1. Convert the image to grayscale.
            
            #region Conversion To grayscale
			var actim = new Image<Hsv, byte>(actualImage).InRange(new Hsv(44, 40, 50), new Hsv(85, 240, 210));
	        //processedColor = actim.Bitmap;
            var grayImage = (actim);
            var colorImage = new Image<Bgr, byte>(actualImage);
	        //processedGray = grayImage.Bitmap;
			//return;
            
            #endregion
            
            //2. Threshold it.
            
            #region  Image normalization and inversion (if required)

			grayImage = grayImage.ThresholdBinaryInv(new Gray(thresholdValue1),new Gray(thresholdValue2));
          
            if (invert)
            {
                grayImage._Not();
            }  
            #endregion
            
            //3. Extract the contours.
            
            #region Extracting the Contours
            using (MemStorage storage = new MemStorage())
            {

                for (Contour<Point> contours = grayImage.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_TC89_L1, RETR_TYPE.CV_RETR_EXTERNAL, storage); contours != null; contours = contours.HNext)
                {

                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.015, storage);
                    if (currentContour.BoundingRectangle.Width > 20)
                    {
                        CvInvoke.cvDrawContours(colorImage, contours, new MCvScalar(105), new MCvScalar(25), -1, 2, LINE_TYPE.EIGHT_CONNECTED, new Point(0, 0));
                        colorImage.Draw(currentContour.BoundingRectangle, new Bgr(Color.DeepPink), 2);
                    }
                }

            } 
            #endregion
            
            //4. Setting the results to the output variables.

            #region Asigning output
            processedColor = colorImage.ToBitmap();
            processedGray = grayImage.ToBitmap();
            #endregion
        }
    }
}
