using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.PagesJaunes
{
    public partial class CreateCustomer : PageBaseShoppingCart<CreateCustomerPresenter, ICreateCustomerPresenter>, ICreateCustomerPresenter
    {
        
        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string UserName
        {
            get { return txtLogin.Text; }
            set { txtLogin.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        public string PasswordConfirmation
        {
            get { return txtConfirmPassword.Text; }
            set { txtConfirmPassword.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public bool CreateSuccess
        {
            set
            {
                if (value)
                {
                    pnlCreate.Visible = false;
                    pnlCreated.Visible = true;
                }
                else
                {
                    pnlCreate.Visible = true;
                    pnlCreated.Visible = false;
                }
            }
        }

        protected void CreateCustomer_click(object sender, EventArgs e)
        {
            Presenter.CreateCustomer();
        }

        protected void CancelCreateCustomer_click(object sender, EventArgs e)
        {
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLogin.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }


    }
}