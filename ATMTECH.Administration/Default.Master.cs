using System;
using System.Configuration;
using System.Web.UI;
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
            lblMessage.Text = message.Description;
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
    }
}