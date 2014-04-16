using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ImportExcelPresenter : BaseAdministrationPresenter<IImportExcelPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IFileService FileService { get; set; }
        public IProductService ProductService { get; set; }

        public ImportExcelPresenter(IImportExcelPresenter view)
            : base(view)
        {
        }

        public void ImportFile(HttpPostedFile httpPostedFile, string table)
        {
            string filename = Path.GetFileName(httpPostedFile.FileName);
            string serverPath = Server.MapPath(string.Format(@"{0}\{1}", "Files", filename));
            httpPostedFile.SaveAs(serverPath);

            ImportExcelfile(serverPath);


            File.Delete(serverPath);
        }

        private void ImportExcelfile(string file)
        {
            using (
          OleDbConnection conn =
              new OleDbConnection(("provider=Microsoft.Jet.OLEDB.4.0; " +
                                   ("data source=" + file + "; " + "Extended Properties=Excel 8.0;"))))
            {
                conn.Open();
                // Select the data from Sheet1 of the workbook.
                OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Feuil1$]", conn);
                DataSet ds = new DataSet();
                ada.Fill(ds, "result_name");
                DataTable dt = ds.Tables["result_name"];
                foreach (DataRow row in dt.Rows)
                {
                    ImportExcelToProduct(row);
                }
            }
        }

        private void ImportExcelToProduct(DataRow row)
        {
            Enterprise enterprise = new Enterprise();
            enterprise.Id = Convert.ToInt32(row["Enterprise"].ToString());
            ProductCategory productCategory = new ProductCategory();
            productCategory.Id = Convert.ToInt32(row["ProductCategory"].ToString());

            Product product = new Product();
            product.Description = row["Description"].ToString();
            product.IsActive = true;
            product.DateCreated = DateTime.Now;
            product.DateModified = DateTime.Now;
            product.Language = row["Language"].ToString();
            product.Ident = row["Ident"].ToString();
            product.Name = row["Name"].ToString();
            product.UnitPrice = Convert.ToDecimal(row["UnitPrice"].ToString());
            product.CostPrice = Convert.ToDecimal(row["CostPrice"].ToString());
            product.Enterprise = enterprise;
            product.Weight = Convert.ToDecimal(row["Weight"].ToString());
            product.ProductCategory = productCategory;
            ProductService.Save(product);
        }


    }
}
