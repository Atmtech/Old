using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.SessionState;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace ATMTECH.ShoppingCart.Lauzon
{
    public class Captcha : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            const int iHeight = 80;
            const int iWidth = 190;
            Random random = new Random();

            int[] fontEmSizes = new int[] { 15, 20, 25, 30, 35 };

            string[] fontNames = new string[]
                    {
                     "Comic Sans MS",
                     "Arial",
                     "Times New Roman",
                     "Georgia",
                     "Verdana",
                     "Geneva"
                    };
            FontStyle[] fontStyles = new FontStyle[]
                    {  
                     FontStyle.Bold,
                     FontStyle.Italic,
                     FontStyle.Regular,
                     FontStyle.Strikeout,
                     FontStyle.Underline
                    };
            HatchStyle[] hatchStyles = new HatchStyle[]
                {
                 HatchStyle.BackwardDiagonal, HatchStyle.Cross, 
	                HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal,
                 HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical, 
	                HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross,
                 HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid, 
	                HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
                 HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard, 
	                HatchStyle.LargeConfetti, HatchStyle.LargeGrid,
                 HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal, 
	                HatchStyle.LightUpwardDiagonal, HatchStyle.LightVertical,
                 HatchStyle.Max, HatchStyle.Min, HatchStyle.NarrowHorizontal, 
	                HatchStyle.NarrowVertical, HatchStyle.OutlinedDiamond,
                 HatchStyle.Plaid, HatchStyle.Shingle, HatchStyle.SmallCheckerBoard, 
	                HatchStyle.SmallConfetti, HatchStyle.SmallGrid,
                 HatchStyle.SolidDiamond, HatchStyle.Sphere, HatchStyle.Trellis, 
	                HatchStyle.Vertical, HatchStyle.Wave, HatchStyle.Weave,
                 HatchStyle.WideDownwardDiagonal, HatchStyle.WideUpwardDiagonal, HatchStyle.ZigZag
                };

            //Get Captcha in Session
            string captchaText = context.Session["Captcha"].ToString();

            //Creates an output Bitmap
            Bitmap outputBitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(outputBitmap);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //Create a Drawing area
            RectangleF rectangleF = new RectangleF(0, 0, iWidth, iHeight);
            Brush brush = default(Brush);

            //Draw background (Lighter colors RGB 100 to 255)
            brush = new HatchBrush(hatchStyles[random.Next
                (hatchStyles.Length - 1)], Color.FromArgb((random.Next(100, 255)),
                (random.Next(100, 255)), (random.Next(100, 255))), Color.White);
            graphics.FillRectangle(brush, rectangleF);

            Matrix matrix = new Matrix();
            int i;
            for (i = 0; i <= captchaText.Length - 1; i++)
            {
                matrix.Reset();
                int iChars = captchaText.Length;
                int x = iWidth / (iChars + 1) * i;
                int y = iHeight / 2;

                //Rotate text Random
                matrix.RotateAt(random.Next(-40, 40), new PointF(x, y));
                graphics.Transform = matrix;

                //Draw the letters with Random Font Type, Size and Color
                graphics.DrawString
                (
                    //Text
                captchaText.Substring(i, 1),
                    //Random Font Name and Style
                new Font(fontNames[random.Next(fontNames.Length - 1)],
                   fontEmSizes[random.Next(fontEmSizes.Length - 1)],
                   fontStyles[random.Next(fontStyles.Length - 1)]),
                    //Random Color (Darker colors RGB 0 to 100)
                new SolidBrush(Color.FromArgb(random.Next(0, 100),
                   random.Next(0, 100), random.Next(0, 100))),
                x,
                random.Next(10, 40)
                );
                graphics.ResetTransform();
            }

            MemoryStream memoryStream = new MemoryStream();
            outputBitmap.Save(memoryStream, ImageFormat.Png);
            byte[] bytes = memoryStream.GetBuffer();

            outputBitmap.Dispose();
            memoryStream.Close();

            context.Response.BinaryWrite(bytes);
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}