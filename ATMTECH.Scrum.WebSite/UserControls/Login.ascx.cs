using System;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite.UserControls
{
    public partial class Login : UserControlScrumBase, ILoginPresenter
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
            Presenter.SignIn();
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

        
    }
}