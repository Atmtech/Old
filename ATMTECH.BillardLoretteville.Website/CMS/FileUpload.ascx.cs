using System;
using System.Collections.Generic;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using WebFormsMvp.Web;
using System.Web.UI.WebControls;
using System.Web;
using ATMTECH.Entities;
using System.IO;
using File = ATMTECH.Entities.File;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class FileUpload : MvpUserControl, IFileUploadPresenter
    {
        public FileUploadPresenter Presenter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public void SaveFile()
        {
            HttpFileCollection files = Page.Request.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = files[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        Entities.File file = new Entities.File();
                        file.Size = httpPostedFile.ContentLength;
                        file.DateModified = DateTime.Now;

                        string filename = Path.GetFileName(httpPostedFile.FileName);

                        file.FileName = filename;
                        string serverPath = Server.MapPath("files\\" + filename);
                        file.ServerPath = serverPath;

                        //Entities.File fileInsert = Presenter.GetExistingFile(file);
                        //if (fileInsert != null)
                        //{
                        //    Presenter.InsertFile(fileInsert);
                        //}
                        //else
                        //{
                        //    Presenter.InsertFile(file);
                        //}

                        httpPostedFile.SaveAs(serverPath);
                    }
                }
            }
        }

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public void SaveImageFile()
        {
            throw new NotImplementedException();
        }

        public string Category { get; set; }
        public IList<File> AllFiles { set; private get; }
        public string RootImagePath { get; private set; }
    }
}