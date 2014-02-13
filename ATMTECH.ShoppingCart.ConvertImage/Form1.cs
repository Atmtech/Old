using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace ATMTECH.ShoppingCart.ConvertImage
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path">Path to which the image would be saved.</param> 
        // <param name="quality">An integer from 0 to 100, with 100 being the 
        /// highest quality</param> 
        public static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");


            // Encoder parameter for image quality 
            EncoderParameter qualityParam =
                new EncoderParameter(Encoder.Quality, quality);
            // Jpeg image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = FillDataset("select distinct * from convertir order by ident");
            txtResult.Text += "DELETE FROM FILE WHERE Category <> 'Enterprise';" + Environment.NewLine; ;
            txtResult.Text += "DELETE FROM ProductFILE;" + Environment.NewLine; ;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string ident = row["ident"].ToString();
                string url = row["url"].ToString();
                string newUrl = row["NewUrl"].ToString();

                if (File.Exists(txtPathImage.Text + url))
                {
                    using (Image image = new Bitmap(txtPathImage.Text + url))
                    {
                        if (File.Exists(txtPathImage.Text + @"Cible\" + newUrl))
                        {
                            File.Delete(txtPathImage.Text + @"Cible\" + newUrl);
                        }

                        SaveJpeg(txtPathImage.Text + @"Cible\" + newUrl, resizeImage(image, new Size(300, 300)), 85);

                        FileInfo fileInfo = new FileInfo(txtPathImage.Text + @"Cible\" + newUrl);

                        string fileInsert = "INSERT INTO FILE (IsActive, DateCreated, Size, FileType,FileName, Category, IsInUse, Title) VALUES (1,datetime('now')," + fileInfo.Length + ",1,'" + newUrl + "','Product',1,'" + newUrl + "');";
                        string productFile = "INSERT INTO ProductFile (IsActive, DateCreated, Product, File, IsPrincipal) VALUES (1,datetime('now'),{0}, (SELECT Id From File WHERE FileName = '" + newUrl + "'),1);";
                        txtResult.Text += fileInsert + Environment.NewLine;
                        DataSet productId = FillDataset("SELECT Id FROM product where Ident = '" + ident + "'");
                        foreach (DataRow dataRow in productId.Tables[0].Rows)
                        {
                            txtResult.Text += string.Format(productFile, dataRow["Id"]) + Environment.NewLine;
                        }

                    }

                }
            }
        }

        private static DataSet FillDataset(string sql)
        {
            SQLiteConnection sqLiteConnection =
                new SQLiteConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            DataSet dataSet = new DataSet();
            using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter())
            {
                using (SQLiteCommand sqlCommand = new SQLiteCommand(sql, sqLiteConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    sqlDataAdapter.Fill(dataSet);
                }
            }
            return dataSet;
        }
    }
}
