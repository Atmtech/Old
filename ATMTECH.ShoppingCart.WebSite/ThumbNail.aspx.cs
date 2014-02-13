using System;
using System.Drawing;
using System.Web.UI;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class ThumbNail : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string directory = Request.QueryString["directory"];
            string strServerPath = Server.MapPath(directory + "/");
            string strFilename = strServerPath + Server.UrlDecode(Request.QueryString["filename"]);

            if (System.IO.File.Exists(strFilename))
            {
                string width = Request.QueryString["width"];

                Image image = Image.FromFile(strFilename);
                int srcWidth = image.Width;
                int srcHeight = image.Height;

                if (width != "original")
                {
                    short widthImage = (short)Convert.ToInt32(width);
                    short shtHeight = (short)(srcHeight / (srcWidth / widthImage));
                    Bitmap bmp = new Bitmap(widthImage, shtHeight);
                    Graphics gr = Graphics.FromImage(bmp);
                    //gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    //gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    Rectangle rectDestination = new Rectangle(0, 0, widthImage, shtHeight);
                    gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                    bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bmp.Dispose();
                    image.Dispose();
                }
                else
                {
                    Bitmap bmp = new Bitmap(srcWidth, srcHeight);
                    Graphics gr = Graphics.FromImage(bmp);
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    Rectangle rectDestination = new Rectangle(0, 0, srcWidth, srcHeight);
                    gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                    bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bmp.Dispose();
                    image.Dispose();
                }
            }

         
        }

    }
}