using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;


namespace ATMTECH.ShoppingCart.Glv
{
    public partial class Login : PageBaseShoppingCart<LoginPresenter, ILoginPresenter>, ILoginPresenter
    {

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

        public bool IsCreateCustomerPossible
        {
            set
            {
                if (value)
                {
                    btnCreateCustomer.Visible = true;
                }
            }
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


    }
}