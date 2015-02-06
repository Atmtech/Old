using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Administration.Views.Pages;
using ATMTECH.Entities;

namespace ATMTECH.Administration
{
    public partial class Default : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

            pnlShoppingCart.Visible = true;
        }

        public bool IsAdministrator { set; get; }
        public string FullName
        {
            get
            {
                return lblName.Text;
            }
            set { lblName.Text = value; }
        }
        public string UserName
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public bool IsLogged
        {
            get { return pnlLogged.Visible; }
            set
            {
                if (value)
                {
                    pnlLogged.Visible = true;
                    pnlLogin.Visible = false;
                    pnlWelcome.Visible = true;
                }
                else
                {
                    pnlLogged.Visible = false;
                    pnlLogin.Visible = true;
                    pnlWelcome.Visible = false;
                }
            }
        }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }

        protected void SignInClick(object sender, EventArgs e)
        {
            Presenter.SignIn(Pages.DEFAULT);
        }
        protected void SignOutClick(object sender, EventArgs e)
        {
            Presenter.SignOut(Pages.DEFAULT);
        }
        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlSuccess");
                    Label literal = (Label)Master.FindControl("lblSuccess");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
            }
            else
            {
                if (Master != null)
                {
                    Panel panel = (Panel)Master.FindControl("pnlError");
                    Label literal = (Label)Master.FindControl("lblError");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
            }
        }

        protected void BtnGenerateColumns(object sender, EventArgs e)
        {
            Presenter.SetAllEntityInformation();
        }

        protected void btnGenererRapportControlStockClick(object sender, EventArgs e)
        {
            Presenter.GenerateStockControlReport();
        }


        private void ImportTest()
        {
            using (OleDbConnection conn = new OleDbConnection(("provider=Microsoft.Jet.OLEDB.4.0; " + (@"data source=C:\Dev\Atmtech\ATMTECH.Administration\Data\Products.xls; " + "Extended Properties=Excel 8.0;"))))
            {
                conn.Open();
                OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Products$]", conn);
                DataSet ds = new DataSet();

                try
                {
                    ada.Fill(ds, "result_name");
                    DataTable dt = ds.Tables["result_name"];
                    IList<ImportProduit> importProduits = new List<ImportProduit>();
                    foreach (DataRow row in dt.Rows)
                    {
                        string ligneExcel = row.ItemArray[0].ToString();
                        string premierePartie = ligneExcel.Substring(0, ligneExcel.IndexOf("\"") - 1);
                        string[] tableauPremierePartie = premierePartie.Split(',');
                        string secondePartie = ligneExcel.Substring(ligneExcel.IndexOf("\""));
                        string[] tableauSecondePartie = secondePartie.Split('"');
                        string[] tableauDernierePartie = tableauSecondePartie[4].Split(',');

                        ImportProduit importProduit = new ImportProduit
                            {
                                ItemID = tableauPremierePartie[0],
                                Brand = tableauPremierePartie[1],
                                Size = tableauPremierePartie[2],
                                ColorId = tableauPremierePartie[3],
                                Color_EN = tableauPremierePartie[4],
                                Color_FR = tableauPremierePartie[5],
                                Title_EN = tableauPremierePartie[6],
                                Title_FR = tableauPremierePartie[7],

                                Desc_EN = tableauSecondePartie[1],
                                Desc_FR = tableauSecondePartie[3],
                                Sex = tableauDernierePartie[0],
                                Category1 = tableauDernierePartie[1],
                                Category2 = tableauDernierePartie[2],
                                Category3 = tableauDernierePartie[3],
                                Category4 = tableauDernierePartie[4],
                                Category5 = tableauDernierePartie[5],
                            };
                        importProduits.Add(importProduit);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

    }

    public class ImportProduit
    {
        public string ItemID { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string ColorId { get; set; }
        public string Color_EN { get; set; }
        public string Color_FR { get; set; }
        public string Title_EN { get; set; }
        public string Title_FR { get; set; }
        public string Desc_EN { get; set; }
        public string Desc_FR { get; set; }
        public string Sex { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string Category5 { get; set; }


    }
}