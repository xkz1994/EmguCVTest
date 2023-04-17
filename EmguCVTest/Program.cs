/*using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;

// 加载图像
var matImage = CvInvoke.Imread("1.jpg");
var image = matImage.ToImage<Bgr, byte>();
// 获取子矩形区域
var rect = new Rectangle(100, 100, 200, 200);
var subImage = image.GetSubRect(rect);

// 显示原图和子图像
CvInvoke.Imshow("Original Image", image);
CvInvoke.Imshow("Sub Image", subImage);
CvInvoke.WaitKey(0);*/


/*using Emgu.CV;
using Emgu.CV.Structure;

// 加载图像
var srcImage = new Image<Bgr, byte>("1.jpg");

// 定义缩放比例
var scaleX = 0.5;
var scaleY = 0.5;

// 计算目标图像大小
var dstWidth = (int)(srcImage.Width * scaleX);
var dstHeight = (int)(srcImage.Height * scaleY);

// 缩放图像
var dstImage = srcImage.Resize(dstWidth, dstHeight, Emgu.CV.CvEnum.Inter.Linear); // 指定尺寸
dstImage = srcImage.Resize(scaleX, Emgu.CV.CvEnum.Inter.Area); // 指定缩放比例

// 显示图像
CvInvoke.Imshow("Source Image", srcImage);
CvInvoke.Imshow("Destination Image", dstImage);
CvInvoke.WaitKey(0);*/


/*using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.CvEnum;

// 读取图像
var image = new Image<Gray, byte>("1.jpg");

// 查找最小值和最大值及其位置
double minVal = 0, maxVal = 0;
Point minLoc = new Point(0, 0), maxLoc = new Point(0, 0);
CvInvoke.MinMaxLoc(image, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

// 在图像中绘制矩形框，标记最小值和最大值
var minRect = new Rectangle(minLoc, new Size(20, 20));
var maxRect = new Rectangle(maxLoc, new Size(20, 20));
image.Draw(minRect, new Gray(0), 2);
image.Draw(maxRect, new Gray(255), 2);

// 显示图像
CvInvoke.Imshow("Image", image.Resize(0.5, Inter.Area));
CvInvoke.WaitKey(0);*/

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

// 读取源图像和模板图像
var sourceImage = new Image<Bgr, byte>("1.jpg").Resize(0.6, Inter.Area);
var templateImage = new Image<Bgr, byte>("2.jpg").Resize(0.6, Inter.Area);

// 创建一个结果图像，宽度和高度为源图像减去模板图像的宽度和高度
var resultImage = sourceImage.MatchTemplate(templateImage, TemplateMatchingType.CcoeffNormed); // 模式匹配

// 获取匹配结果中最大的值和其坐标
resultImage.MinMax(out var minVal, out var maxVal, out var minLoc, out var maxLoc);
var ptPos = new Point(maxLoc[0].X, maxLoc[0].Y); // 匹配返回的是模板的左上角位置
// ptPos.X += templateImage.Width / 2; // 移动到模板的右下角
// ptPos.Y += templateImage.Height / 2; // 移动到模板的右下角
// 在源图像中绘制矩形框，标记匹配结果
var matchRect = new Rectangle(ptPos, templateImage.Size);
sourceImage.Draw(matchRect, new Bgr(0, 0, 255), 2);
sourceImage.Draw(new Rectangle(new Point(100,100), new Size(100,100)), new Bgr(0, 0, 255), 2);

// 显示源图像和匹配结果
CvInvoke.Imshow("Source Image", sourceImage);
CvInvoke.WaitKey(0);

/*using Emgu.CV;
using Emgu.CV.Structure;

// 创建一个大小为3x3的二维数组
Matrix<float> matrix = new Matrix<float>(3, 3);

// 将第1行第2列的值设置为3.14
CvInvoke.cvSetReal2D(matrix.Ptr, 1, 2, 3.14);

// 输出二维数组中的值
for (int i = 0; i < matrix.Rows; i++)
{
    for (int j = 0; j < matrix.Cols; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}*/