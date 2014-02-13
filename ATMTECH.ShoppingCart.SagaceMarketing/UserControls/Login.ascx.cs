using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using WebFormsMvp.Web;

namespace ATMTECH.ShoppingCart.SagaceMarketing.UserControls
{
    public partial class Login : MvpUserControl, ILoginPresenter
    {
        public LoginPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Control> allControls = new List<Control>();
                GetControlList(Controls, allControls);
                Presenter.Controls = allControls;
                Presenter.Localize();
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasControls())
                    GetControlList(control.Controls, resultCollection);
            }
        }

        protected void SignInClick(object sender, EventArgs e)
        {
            Presenter.SignIn(Pages.DEFAULT);
        }

        public string FullName
        {
            get { return lblName.Text; }
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
            set { lnkAdministration.Visible = value; }
        }

        protected void CreateCustomerClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.CREATE_CUSTOMER);
        }

        protected void ForgetPasswordClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.FORGET_PASSWORD);
        }

        protected void SignOutClick(object sender, EventArgs e)
        {
            Presenter.SignOut(Pages.DEFAULT);
        }



        public void ShowMessage(Message message)
        {
            Panel panel = (Panel)this.FindControl("pnlError");
            Literal literal = (Literal)FindControl("lblError");
            literal.Text = message.Title + "<br>" + message.Description;
            panel.Visible = true;
        }
    }
}