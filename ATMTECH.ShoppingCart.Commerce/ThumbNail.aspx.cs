using System;
using System.Drawing;
using System.Web.UI;

namespace ATMTECH.ShoppingCart.Commerce
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
                string height = Request.QueryString["height"];
                Image image = Image.FromFile(strFilename);
                if (width != "original")
                {
                    short widthImage = (short)Convert.ToInt32(width);
                    short heightImage = (short)Convert.ToInt32(height);
                    Image thumbnail = image.GetThumbnailImage(widthImage, heightImage, null, IntPtr.Zero);
                    thumbnail.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    thumbnail.Dispose();
                    //Bitmap bmp = new Bitmap(widthImage, heightImage);
                    //Graphics gr = Graphics.FromImage(bmp);
                    //Rectangle rectDestination = new Rectangle(0, 0, widthImage, heightImage);
                    //gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
                    //bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //bmp.Dispose();
                    //image.Dispose();
                }
            }
        }
    }
}