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
        public IStockService StockService { get; set; }

        public ImportExcelPresenter(IImportExcelPresenter view)
            : base(view)
        {
        }

        public void ImportFile(HttpPostedFile httpPostedFile)
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
                ImportWorkSheetProduct(conn);
                ImportWorkSheetStock(conn);
            }
        }

        private void ImportWorkSheetProduct(OleDbConnection conn)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Product$]", conn);
            DataSet ds = new DataSet();
            try
            {
                ada.Fill(ds, "result_name");
                DataTable dt = ds.Tables["result_name"];
                foreach (DataRow row in dt.Rows)
                {
                    ImportExcelToProduct(row);
                }
            }
            catch (Exception ex)
            {
                MessageService.ThrowMessage(ex);

            }

        }

        private void ImportWorkSheetStock(OleDbConnection conn)
        {
            OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Stock$]", conn);
            DataSet ds = new DataSet();
            try
            {
                ada.Fill(ds, "result_name");
                DataTable dt = ds.Tables["result_name"];
                foreach (DataRow row in dt.Rows)
                {
                    ImportExcelToStock(row);
                }
            }
            catch (Exception ex)
            {
                MessageService.ThrowMessage(ex);

            }
        }

        private void ImportExcelToStock(DataRow row)
        {
            Stock stock = new Stock
                {
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,

                    Product = new Product { Id = Convert.ToInt32(row["Product"]) },
                    InitialState = Convert.ToInt32(row["InitialState"]),
                    MinimumAccept = Convert.ToInt32(row["MinimumAccept"]),
                    IsWarningOnLow = Convert.ToInt32(row["IsWarningOnLow"]) == 1,
                    FeatureFrench = row["FeatureFrench"].ToString(),
                    FeatureEnglish = row["FeatureEnglish"].ToString(),
                    AdjustPrice = Convert.ToDecimal(row["AdjustPrice"]),
                    IsWithoutStock = Convert.ToInt32(row["IsWithoutStock"]) == 1
                };

            StockService.Save(stock);
        }


        private void ImportExcelToProduct(DataRow row)
        {

            Product product = new Product
                {
                    DescriptionEnglish = row["DescriptionEnglish"].ToString(),
                    DescriptionFrench = row["DescriptionFrench"].ToString(),
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Ident = row["Ident"].ToString(),
                    NameFrench = row["NameFrench"].ToString(),
                    NameEnglish = row["NameEnglish"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"].ToString()),
                    CostPrice = Convert.ToDecimal(row["CostPrice"].ToString()),
                    Enterprise = new Enterprise() { Id = Convert.ToInt32(Convert.ToInt32(row["Enterprise"])) },
                    Weight = Convert.ToDecimal(row["Weight"].ToString()),
                    ProductCategoryFrench = new ProductCategory() { Id = Convert.ToInt32(row["ProductCategoryFrench"]) },
                    ProductCategoryEnglish = new ProductCategory() { Id = Convert.ToInt32(row["ProductCategoryEnglish"]) }
                };

            ProductService.Save(product);
        }


    }
}
