using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Login : PageBaseShoppingCart<LoginPresenter, ILoginPresenter>, ILoginPresenter
    {
        public string FullName { get; set; }
        public string UserName { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }
        public string Password { get { return txtMotDePasse.Text; } set { txtMotDePasse.Text = value; } }
        public bool IsLogged { set; private get; }
        public bool IsAdministrator { set; private get; }
        public bool IsCreateCustomerPossible { set; private get; }
        public string FirstNameCreate { get { return txtPrenom.Text; } set { txtPrenom.Text = value; } }
        public string LastNameCreate { get { return txtNom.Text; } set { txtNom.Text = value; } }
        public string EmailCreate { get { return txtCourrielCreer.Text; } set { txtCourrielCreer.Text = value; } }
        public string PasswordCreate { get { return txtMotDePasseCreer.Text; } set { txtMotDePasseCreer.Text = value; } }
        public string PasswordConfirmation { get { return txtMotDePasseCreerConfirmation.Text; } set { txtMotDePasseCreerConfirmation.Text = value; } }



        protected void btnConnecterLoginClick(object sender, EventArgs e)
        {
            Presenter.SignIn(Pages.DEFAULT);
        }

        protected void btnCreerLoginClick(object sender, EventArgs e)
        {
            Presenter.CreateCustomer();
            FirstNameCreate = "";
            LastNameCreate = "";
            EmailCreate = "";
            PasswordCreate = "";
            PasswordConfirmation = "";
        }

        protected void btnOublieMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.FORGET_PASSWORD);
        }
    }
}