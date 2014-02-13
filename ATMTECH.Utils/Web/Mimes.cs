using System;

namespace ATMTECH.Utils.Web
{
    public class Mimes
    {
        public static string GetMime(String extension)
        {
            
            extension = extension.Replace(".", string.Empty).ToLower();
            string mimeType;
            switch (extension)
            {
                case "rtf":
                case "dot":
                    mimeType = "application/msword";
                    break;
                case "zip":
                    mimeType = "application/zip";
                    break;
                case "tif":
                case "tiff":
                case "itif":
                    mimeType = "image/tiff";
                    break;
                case "cal":
                    mimeType = "application/cal";
                    break;
                case "dwg":
                    mimeType = "application/autocad_dwg";
                    break;
                case "ppt":
                case "pps":
                    mimeType = "application/mspowerpoint";
                    break;
                case "mdb":
                    mimeType = "application/access";
                    break;
                case "docx":
                case "docm":
                case "doc":
                    mimeType = "application/word";
                    break;
                case "jpg":
                case "jpeg":
                    mimeType = "image/jpeg";
                    break;
                case "gif":
                    mimeType = "image/gif";
                    break;
                case "png":
                    mimeType = "image/png";
                    break;
                case "pdf":
                    mimeType = "application/pdf";
                    break;
                case "pptx":
                    mimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    break;
                case "xls":
                    mimeType = "application/excel";
                    break;
                case "xlsx":
                    mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "csv":
                    mimeType = "application/csv";
                    break;
                case "xml":
                    mimeType = "application/XML";
                    break;
                case "bmp":
                    mimeType = "image/bmp";
                    break;
                case "txt":
                    mimeType = "text/plain";
                    break;
                default:
                    mimeType = "multipart/mixed";
                    break;
            }

            return mimeType;
        }
    }
}
