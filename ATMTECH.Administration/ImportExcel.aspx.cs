using System;
using System.Web;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration
{
    public partial class ImportExcel : PageBaseAdministration, IImportExcelPresenter
    {
        public ImportExcelPresenter Presenter { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        
        }

        protected void btnImportClick(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection hfc = Request.Files;
                string files = string.Empty;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile httpPostedFile = hfc[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        Presenter.ImportFile(httpPostedFile);
                        lblFileImported.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
        }
    }
}