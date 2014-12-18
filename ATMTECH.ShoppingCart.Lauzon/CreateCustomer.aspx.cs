using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Lauzon
{
    public partial class CreateCustomer : PageBaseShoppingCart<CreateCustomerPresenter, ICreateCustomerPresenter>, ICreateCustomerPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCaptchaText();
            }
        }

        private void SetCaptchaText()
        {
            Random oRandom = new Random();
            int iNumber = oRandom.Next(100000, 999999);
            Session["Captcha"] = iNumber.ToString();
        }

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

        public string CaptchaTextBox
        {
            get { return txtCaptcha.Text; }
            set { txtCaptcha.Text = value; }
        }

        public string CaptchaSession
        {
            get { return Session["Captcha"].ToString(); }
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
            txtCaptcha.Text = "";
            txtConfirmPassword.Text = "";
        }

        protected void ReloadCaptcha_click(object sender, EventArgs e)
        {
            SetCaptchaText();
        }

    }
}