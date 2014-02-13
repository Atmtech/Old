﻿using System.Web;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;


namespace ATMTECH.Views
{
    public class FileUploadPresenter : BasePresenter<IFileUploadPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IFileService FileService { get; set; }

        public FileUploadPresenter(IFileUploadPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            User user = AuthenticationService.AuthenticateUser;
            if (user == null) return;
            if (!user.IsAdministrator)
            {
                NavigationService.Redirect("default.aspx");
            }
        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.SaveImageFile();
            View.AllFiles = FileService.GetAllFile(View.RootImagePath);
        }

        public void ResizeAll(string directory)
        {
            FileService.ResizeFile(directory);
        }


        public File GetFile(int id)
        {
            return FileService.GetFile(id);
        }
        public File GetFile(File file)
        {
            return FileService.GetFile(file);
        }

        public int SaveFile(HttpPostedFile httpPostedFile, string type)
        {
            return FileService.SaveFile(httpPostedFile, type, View.RootImagePath);
        }

        public int SaveFile(Entities.File file)
        {
            return FileService.SaveFile(file);
        }

        public void DeleteFile(int id)
        {
            FileService.DeleteFile(FileService.GetFile(id));
        }

        public void Refresh()
        {
            View.AllFiles = FileService.GetAllFile();
        }
    }
}
