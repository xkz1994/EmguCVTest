using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace EmguCVTestFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 加载图像
            var matImage = CvInvoke.Imread("lena.jpg");
            var image = matImage.ToImage<Bgr, byte>();
            // 获取子矩形区域
            Rectangle rect = new Rectangle(100, 100, 200, 200);
            Image<Bgr, byte> subImage = image.GetSubRect(rect);

            // 显示原图和子图像
            CvInvoke.Imshow("Original Image", image);
            CvInvoke.Imshow("Sub Image", subImage);
            CvInvoke.WaitKey(0);

        }
    }
}
