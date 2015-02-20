using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Login : PageBaseShoppingCart<IdentificationPresenter, IIdentificationPresenter>, IIdentificationPresenter
    {

        protected void btnConnecterLoginClick(object sender, EventArgs e)
        {
            Presenter.Identification();
        }

        protected void btnCreerLoginClick(object sender, EventArgs e)
        {
            Presenter.CreerUtilisateur();
            PrenomCreation = "";
            NomCreation = "";
            CourrielCreation = "";
            MotPasseCreation = "";
            MotPasseConfirmationCreation = "";
        }

        protected void btnOublieMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.FORGET_PASSWORD);
        }

        public string NomUtilisateurIdentification { get; set; }
        public string MotPasseIdentification { get; set; }
        public string PrenomCreation { get; set; }
        public string NomCreation { get; set; }
        public string CourrielCreation { get; set; }
        public string MotPasseCreation { get; set; }
        public string MotPasseConfirmationCreation { get; set; }
    }
}