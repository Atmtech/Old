using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Login : PageBase<IdentificationPresenter, IIdentificationPresenter>, IIdentificationPresenter
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            txtMotDePasseCreer.Attributes["value"] = txtMotDePasseCreer.Text;
            txtMotDePasseCreerConfirmation.Attributes["value"] = txtMotDePasseCreerConfirmation.Text;

        }


        public string NomUtilisateurIdentification { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }
        public string MotPasseIdentification { get { return txtMotDePasse.Text; } set { txtMotDePasse.Text = value; } }
        public string PrenomCreation { get { return txtPrenom.Text; } set { txtPrenom.Text = value; } }
        public string NomCreation { get { return txtNom.Text; } set { txtNom.Text = value; } }
        public string CourrielCreation { get { return txtCourrielCreer.Text; } set { txtCourrielCreer.Text = value; } }
        public string MotPasseCreation { get { return txtMotDePasseCreer.Text; } set { txtMotDePasseCreer.Text = value; } }
        public string MotPasseConfirmationCreation { get { return txtMotDePasseCreerConfirmation.Text; } set { txtMotDePasseCreerConfirmation.Text = value; } }
        public string AdresseLongueLivraison { get { return adresseLivraison.AdresseLongue; } set { adresseLivraison.AdresseLongue = value; } }
        public string CodePostalLivraison { get { return adresseLivraison.CodePostal; } set { adresseLivraison.CodePostal = value; } }
        public string AdresseLongueFacturation
        {
            get { return adresseFacturation.AdresseLongue; }
            set { adresseFacturation.AdresseLongue = value; }
        }


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
            AdresseLongueLivraison = "";
            CodePostalLivraison = "";
            AdresseLongueFacturation = "";

        }
        protected void btnOublieMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.FORGET_PASSWORD);
        }

        protected void btnUtiliserMemeAdresseQueLivraisonClick(object sender, EventArgs e)
        {
            AdresseLongueFacturation = AdresseLongueLivraison;
        }
    }
}