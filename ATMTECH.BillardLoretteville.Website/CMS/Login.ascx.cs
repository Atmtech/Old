using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using WebFormsMvp.Web;

namespace ATMTECH.BillardLoretteville.Website.CMS
{
    public partial class Login : MvpUserControl, ILoginPresenter
    {
        public LoginPresenter Presenter { get; set; }

        public void ShowMessage(Message message)
        {
            windowError.OuvrirFenetre(message.Title);
            lblError.Text = message.Description;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public string WelcomeMessage
        {
            get { return lblWelcome.Text; }
            set
            {
                lblWelcome.Text = value;
            }
        }

        public bool IsAuthenticate
        {
            set
            {
                if (value)
                {
                    pnlLogged.Visible = true;
                    pnlToLog.Visible = false;
                }
                else
                {
                    pnlLogged.Visible = false;
                    pnlToLog.Visible = true;
                }
            }
        }

        protected void OnbtnLog(object sender, EventArgs e)
        {
          //  Presenter.AuthenticateUser(txtUsername.Text, txtPassword.Text);
            SetSecurity(Page.Controls);
        }

        protected void OnbtnUnLog(object sender, EventArgs e)
        {
            //Presenter.DeAuthenticateUser();
            SetSecurity(Page.Controls);
        }

        public void SetSecurity(ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                if (ctl is Content)
                {
                    (ctl as Content).Presenter.SetSecurity();
                }

                //if (ctl is Menu)
                //{
                //    (ctl as Menu).Presenter.SetSecurity();
                //}

                if (ctl.Controls.Count > 0)
                    SetSecurity(ctl.Controls);
            }
        }


        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLogged { set; private get; }
        public bool IsAdministrator { set; private get; }
    }
}