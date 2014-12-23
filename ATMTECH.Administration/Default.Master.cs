using System;
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
            Presenter.GenerateEntityInformation();
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