using System;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views.Pages;
using ATMTECH.Entities;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Controls.Affichage;
using WebFormsMvp.Web;

namespace ATMTECH.Administration.UserControls
{
    public partial class Login : MvpUserControl, ILoginPresenter
    {
        public LoginPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void SignInClick(object sender, EventArgs e)
        {
            Presenter.SignIn(Pages.DEFAULT);
        }

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
            set
            {
                if (value)
                {
                    pnlLogin.Visible = false;
                    pnlWelcome.Visible = true;
                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlWelcome.Visible = false;
                }
            }
        }

        public bool IsAdministrator
        {
            set { bool test = value; }
        }

        protected void CreateCustomerClick(object sender, EventArgs e)
        {
            // Presenter.NavigationService.Redirect(Pages.CREATE_CUSTOMER);
        }

        protected void ForgetPasswordClick(object sender, EventArgs e)
        {
            //   Presenter.NavigationService.Redirect(Pages.FORGET_PASSWORD);
        }

        protected void SignOutClick(object sender, EventArgs e)
        {
            Presenter.SignOut(Pages.DEFAULT);
        }

        public void ShowMessage(Message message)
        {
            Default masterPage = (Default)Page.Master;
            if (masterPage != null)
            {
                if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
                {
                    Panel panel = (Panel)masterPage.FindControl("pnlSuccess");
                    Label literal = (Label)masterPage.FindControl("lblSuccess");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
                else
                {
                    Panel panel = (Panel)masterPage.FindControl("pnlError");
                    Label literal = (Label)masterPage.FindControl("lblError");
                    literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                    panel.Visible = true;
                }
            }
        }
    }
}