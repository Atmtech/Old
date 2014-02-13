using System;
using System.Drawing;
using System.Web.UI;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class ThumbNail : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            string directory = Request.QueryString["directory"];
            string strServerPath = Server.MapPath("../" + directory + "/");
            string strFilename = strServerPath + Server.UrlDecode(Request.QueryString["filename"]);
            if (System.IO.File.Exists(strFilename))
            {
                Image objImage = Image.FromFile(strFilename);
                string width = Request.QueryString["width"];
                short widthImage = (short) Convert.ToInt32(width);

                if (string.IsNullOrEmpty(width))
                {
                    widthImage = ((short) objImage.Width);
                }
                else if (widthImage < 1)
                {
                    widthImage = 100;
                }
               
                short shtHeight = (short) (objImage.Height / (objImage.Width / widthImage));
                Image objThumbnail = objImage.GetThumbnailImage(widthImage, shtHeight, null, IntPtr.Zero);
                Response.ContentType = "image/jpeg";
                objThumbnail.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                objImage.Dispose();
                objThumbnail.Dispose();
            }
        }

    }
}