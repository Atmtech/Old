using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class ForgetPassword : PageBaseShoppingCart<ForgetPasswordPresenter, IForgetPasswordPresenter>,IForgetPasswordPresenter
    {
        protected void SendMail_click(object sender, EventArgs e)
        {
            Presenter.SendMail();
            lblConfirmSendEmail.Visible = true;
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
    }
}