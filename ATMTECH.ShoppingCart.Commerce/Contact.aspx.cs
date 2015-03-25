using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Contact : PageBase<ContacterNousPresenter, IContacterNousPresenter>, IContacterNousPresenter
    {
        public string Nom { get { return txtVotreNom.Text; } set { txtVotreNom.Text = value; } }

        public string Courriel
        {
            get { return txtCourrielContacterNous.Text; }
            set { txtCourrielContacterNous.Text = value; }
        }

        public string Telephone
        {
            get { return txtNoTelephoneContacterNous.Text; }
            set { txtNoTelephoneContacterNous.Text = value; }
        }

        public string Message
        {
            get { return txtMessageContacterNous.Text; }
            set { txtMessageContacterNous.Text = value; }
        }

        protected void btnEnvoyerCommentaireClick(object sender, EventArgs e)
        {
            Presenter.EnvoyerMessage();
        }
    }
}