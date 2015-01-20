
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Services
{
    public class FileService : IFileService
    {
        public IDAOFile DAOFile { get; set; }
        public File GetFile(int id)
        {
            return DAOFile.GetFile(id);
        }
        public File GetFile(File file)
        {
            return DAOFile.GetFile(file);
        }
        

        public IList<File> GetAllFile(string rootImagePath)
        {
            return DAOFile.GetAllFile().Where(x => x.RootImagePath == rootImagePath).ToList();
        }
        public IList<File> GetAllFile()
        {
            return DAOFile.GetAllFile();
        }
        public void DeleteFile(File file)
        {
            DAOFile.DeleteFile(file);

            if (System.IO.File.Exists(file.ServerPath))
            {
                System.IO.File.Delete(file.ServerPath);
            }
        }
        public void ResizeFile(string directory)
        {
            string[] strings = Directory.GetFiles(directory);
            bool saved = false;
            foreach (var file in strings)
            {
                using (Image image = new Bitmap(file))
                {
                    if (image.Height > 300 || image.Width > 300)
                    {
                        saved = true;
                        SaveJpeg(file + "z", resizeImage(image, new Size(300, 300)), 85);
                    }
                }

                if (saved)
                {
                    System.IO.File.Delete(file);
                    System.IO.File.Copy(file + "z", file);
                    System.IO.File.Delete(file + "z");
                }

                saved = false;

            }
        }
        public int SaveFile(File file)
        {
            file.FileType = GetFileType(file);
            file.IsActive = true;
            return DAOFile.UpdateFile(file);
        }
        public int SaveFile(HttpPostedFile httpPostedFile, string type, string rootImagePath)
        {
            File file = new File { Size = httpPostedFile.ContentLength, DateModified = DateTime.Now };

            string filename = Path.GetFileName(httpPostedFile.FileName);

            file.FileName = filename;
            file.Description = filename.Substring(0, filename.IndexOf("."));
            string serverPath = string.Format(@"{0}\{1}\{2}", rootImagePath, type, Path.GetFileName(httpPostedFile.FileName));
            file.ServerPath = serverPath;
            file.Category = type;
            file.RootImagePath = rootImagePath;

            Entities.File fileInsert = GetFile(file);
            int rtn = SaveFile(fileInsert ?? file);

            httpPostedFile.SaveAs(serverPath);
            return rtn;
        }
        public void SaveFileWithoutDatabase(HttpPostedFile httpPostedFile, string root)
        {
            string filename = Path.GetFileName(httpPostedFile.FileName);
            string serverPath = string.Format(@"{0}\{1}\{2}", root, filename);
            httpPostedFile.SaveAs(serverPath);
        }
      
        private FileType GetFileType(File file)
        {
            string fileName = file.ServerPath == null ? file.FileName.ToLower() : file.ServerPath.ToLower();

            FileType fileType = null;
            if (fileName.IndexOf(".jpg") != -1)
            {
                fileType = new BaseDao<FileType, int>().GetAllOneCriteria(FileType.TYPE, FileType.Codes.JPG)[0];
            }
            else if (fileName.IndexOf(".pdf") != -1)
            {
                fileType = new BaseDao<FileType, int>().GetAllOneCriteria(FileType.TYPE, FileType.Codes.PDF)[0];
            }
            else if (fileName.IndexOf(".png") != -1)
            {
                fileType = new BaseDao<FileType, int>().GetAllOneCriteria(FileType.TYPE, FileType.Codes.PNG)[0];
            }
            else
            {
                fileType = new BaseDao<FileType, int>().GetAllOneCriteria(FileType.TYPE, FileType.Codes.UNKNOWN)[0];
            }

            return fileType;
        }
        private static void SaveJpeg(string path, Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(path, jpegCodec, encoderParams);
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo t in codecs)
                if (t.MimeType == mimeType)
                    return t;
            return null;
        }
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercentW = ((float)size.Width / (float)sourceWidth);
            float nPercentH = ((float)size.Height / (float)sourceHeight);
            float nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
    }
}
