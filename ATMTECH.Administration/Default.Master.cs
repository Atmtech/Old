using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
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

            switch (ConfigurationManager.AppSettings["webSite"])
            {
                case "ShoppingCart":
                    pnlShoppingCart.Visible = true;
                    break;
                case "Achievement":
                    pnlAchievement.Visible = true;
                    break;
            }


        }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }

        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                Panel panel = (Panel)Master.FindControl("pnlSuccess");
                Label literal = (Label)Master.FindControl("lblSuccess");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
            else
            {
                Panel panel = (Panel)Master.FindControl("pnlError");
                Label literal = (Label)Master.FindControl("lblError");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
        }


        public bool IsLogged
        {
            get { return pnlLogged.Visible; }
            set { pnlLogged.Visible = value; }
        }


        protected void BtnGenerateColumns(object sender, EventArgs e)
        {
            Presenter.GenerateEntityInformation();
        }


        protected void btnGenererDatabase(object sender, EventArgs e)
        {
            Presenter.GenerateDatabaseAchievement();
        }

        protected void btnInitialiserColonneRechercheClick(object sender, EventArgs e)
        {
            lblResultat.Text = "";

            lblResultat.Text += Presenter.InitialiserColonneRecherche();
        }

        protected void btnGenererRapportControlStockClick(object sender, EventArgs e)
        {
            Presenter.GenerateStockControlReport();
        }

        protected void lnkExportClick(object sender, EventArgs e)
        {
            Presenter.Export();
        }
    }
}