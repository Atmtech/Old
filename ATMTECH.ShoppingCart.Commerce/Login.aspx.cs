using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Login : PageBase<IdentificationPresenter, IIdentificationPresenter>, IIdentificationPresenter
    {

        protected void btnConnecterLoginClick(object sender, EventArgs e)
        {
            Presenter.Identification();
        }

        protected void btnCreerLoginClick(object sender, EventArgs e)
        {
            Presenter.CreerUtilisateur();

            if (Presenter.EstUtilisateurExistant(txtCourrielCreer.Text))
            {
                PrenomCreation = "";
                NomCreation = "";
                CourrielCreation = "";
                MotPasseCreation = "";
                MotPasseConfirmationCreation = "";
            }
        }

        protected void btnOublieMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.FORGET_PASSWORD);
        }

        public string NomUtilisateurIdentification { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }
        public string MotPasseIdentification { get { return txtMotDePasse.Text; } set { txtMotDePasse.Text = value; } }
        public string PrenomCreation { get { return txtPrenom.Text; } set { txtPrenom.Text = value; } }
        public string NomCreation { get { return txtNom.Text; } set { txtNom.Text = value; } }
        public string CourrielCreation { get { return txtCourrielCreer.Text; } set { txtCourrielCreer.Text = value; } }
        public string MotPasseCreation { get { return txtMotDePasseCreer.Text; } set { txtMotDePasseCreer.Text = value; } }
        public string MotPasseConfirmationCreation { get { return txtMotDePasseCreerConfirmation.Text; } set { txtMotDePasseCreerConfirmation.Text = value; } }
    }
}