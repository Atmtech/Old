using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ATMTECH.ImageBatch
{
    public partial class FormConvertir : Form
    {
        public FormConvertir()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            Convertir();
        }

        public void Convertir()
        {
            string repertoireSource = txtSource.Text;
            string repertoireCible = txtCible.Text;

            txtStatus.Text = string.Empty;

            string[] fileEntries = Directory.GetFiles(repertoireSource);
            foreach (string fileName in fileEntries)
            {
                string nomFichierSource = Path.GetFileName(fileName);
                string nomFichierCible = repertoireCible + @"\" + nomFichierSource.Replace(".jpg", ".png").Replace(".jpeg", ".png");
                string nomFichierCibleTemp = repertoireCible + @"\Temp\" + nomFichierSource.Replace(".jpg", ".png").Replace(".jpeg", ".png");

                if (!File.Exists(nomFichierCible))
                {
                    txtStatus.Text += nomFichierSource + Environment.NewLine;

                    using (Bitmap bitmap = (Bitmap)Image.FromFile(fileName))
                    {
                        using (Bitmap newBitmap = new Bitmap(bitmap))
                        {
                            newBitmap.SetResolution(Convert.ToSingle(txtDPI.Text), Convert.ToSingle(txtDPI.Text));
                            newBitmap.Save(nomFichierCibleTemp, ImageFormat.Png);
                            using (var image = Image.FromFile(nomFichierCibleTemp))
                            using (
                                var newImage = ScaleImage(image, Convert.ToInt32(txtLargeur.Text),
                                    Convert.ToInt32(txtHauteur.Text)))
                            {
                                newImage.Save(nomFichierCible, ImageFormat.Png);
                            }
                        }
                    }
                }
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

    }
}
