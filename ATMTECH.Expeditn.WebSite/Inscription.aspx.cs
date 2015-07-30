using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Inscription : PageBase<InscriptionPresenter, IInscriptionPresenter>, IInscriptionPresenter
    {
        public string Prenom
        {
            get { return txtPrenom.Text; }
            set { txtPrenom.Text = value; }
        }

        public string Nom
        {
            get { return txtNom.Text; }
            set { txtNom.Text = value; }
        }

        public string Courriel
        {
            get { return txtCourriel.Text; }
            set { txtCourriel.Text = value; }
        }

        public string MotPasse
        {
            get { return txtMotDePasse.Text; }
            set { txtMotDePasse.Text = value; }
        }

        public string MotPasseConfirmation
        {
            get { return txtConfirmationMotDePasse.Text; }
            set { txtConfirmationMotDePasse.Text = value; }
        }

        protected void lnkCreerMonCompteClick(object sender, EventArgs e)
        {
            Presenter.CreerUtilisateur();
        }
    }
}