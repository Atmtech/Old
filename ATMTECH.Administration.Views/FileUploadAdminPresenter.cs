using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class FileUploadAdminPresenter : BasePresenter<IFileUploadPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IFileService FileService { get; set; }
        public IProductService ProductService { get; set; }

        public FileUploadAdminPresenter(IFileUploadPresenter view)
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
            FillAllFiles();

        }

        public void FillAllFiles()
        {
            View.AllFiles = !string.IsNullOrEmpty(View.Filter) ? FileService.GetAllFile(View.RootImagePath).Where(x => x.ComboboxDescription.Contains(View.Filter)).ToList() : FileService.GetAllFile(View.RootImagePath);
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

        public int SaveFile(File file)
        {
            return FileService.SaveFile(file);
        }

        public void DeleteFile(int id)
        {

            File file = FileService.GetFile(id);
            FileService.DeleteFile(file);

            IList<ProductFile> productFiles = ProductService.GetProductFile(file);
            foreach (ProductFile productFile in productFiles)
            {
                ProductService.DeleteProductFile(productFile);
            }

            View.AllFiles = FileService.GetAllFile(View.RootImagePath);
        }

        public void Refresh()
        {
            View.AllFiles = FileService.GetAllFile();
        }
    }
}
