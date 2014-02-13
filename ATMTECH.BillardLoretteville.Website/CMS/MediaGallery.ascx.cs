using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using WebFormsMvp.Web;
using System.IO;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class MediaGallery : MvpUserControl, IMediaGalleryPresenter
    {
        public MediaGalleryPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }


        //private bool IsImage(string fileName)
        //{
        //    if (fileName.IndexOf(".jpg") > 0 || fileName.IndexOf(".png") > 0 || fileName.IndexOf(".gif") > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public IList<Entities.File> Files
        {
            set
            {

                int i = 0;
                IList<Entities.File> files = value;
                if (files.Count > 0)
                {
                    string html = string.Empty;

                    html += "<div id=\"gallery\" class=\"ad-gallery\">";
                    html += "<div class=\"ad-image-wrapper\">";
                    html += "</div>";
                    html += "<div class=\"ad-controls\">";
                    html += "</div>";
                    html += "<div class=\"ad-nav\">";
                    html += "<div class=\"ad-thumbs\">";
                    html += "<ul class=\"ad-thumb-list\">";
                    foreach (Entities.File file in files)
                    {
                        if (File.Exists(Server.MapPath(@"Files\") +  file.FileName))
                        {
                            html += "<li>";
                            html += "<a href=\"Files/" + file.FileName + "\">";
                            html += "<img src=\"cms/ThumbNail.aspx?width=100&directory=files&filename=" + file.FileName + "\" alt=\"" + file.Description + "\" title=\"" + file.Title + "\" class=\"image" + i + "\">";
                            html += "</a>";
                            html += "</li>";
                            i++;
                        }
                    }

                    html += "</ul>";
                    html += "</div>";
                    html += "</div>";
                    html += "</div>";

                    HtmlGenericControl htmlGenericControl = new HtmlGenericControl { InnerHtml = html };
                    PlaceHolderMedia.Controls.Add(htmlGenericControl);

                    //else
                    //{
                    //    DirectoryInfo directoryInfo = new DirectoryInfo(Server.MapPath("Files"));
                    //    foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.*"))
                    //    {
                    //        if (IsImage(fileInfo.Name))
                    //        {
                    //            html += "<li>";
                    //            html += "<a href=\"Files/" + fileInfo.Name + "\">";
                    //            html += "<img src=\"cms/ThumbNail.aspx?width=100&directory=files&filename=" + fileInfo.Name + "\" class=\"image" + i + "\">";
                    //            html += "</a>";
                    //            html += "</li>";
                    //            i++;
                    //        }
                    //    }
                    //}
                }


            }
        }
    }
}