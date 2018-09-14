using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Identification : PageBase<IdentificationPresenter, IIdentificationPresenter>, IIdentificationPresenter
    {
        public string NomUtilisateurIdentification
        {
            get { return txtNomUtilisateur.Text; }
            set { txtNomUtilisateur.Text = value; }
        }

        public string MotPasseIdentification
        {
            get { return txtMotPasse.Text; }
            set { txtMotPasse.Text = value; }
        }

        protected void lnkIdentifiezVousClick(object sender, EventArgs e)
        {
            Presenter.Identification();
        }
    }
}