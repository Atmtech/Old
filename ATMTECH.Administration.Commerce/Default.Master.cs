using System;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Entities;

namespace ATMTECH.Administration.Commerce
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }


        public bool EstConnecte
        {
            set
            {
                if (value)
                {
                    pnlConnecte.Visible = true;
                    pnlDeconnecte.Visible = false;
                    pnlConnecteSite.Visible = true;
                }
                else
                {
                    pnlConnecte.Visible = false;
                    pnlDeconnecte.Visible = true;
                    pnlConnecteSite.Visible = false;
                }
            }
        }

        public string NomUtilisateur
        {
            get { return txtCourriel.Text; }
            set { txtCourriel.Text = value; }
        }

        public string MotDePasse
        {
            get { return txtMotDePasse.Text; }
            set { txtMotDePasse.Text = value; }
        }

        protected void SignInClick(object sender, EventArgs e)
        {
            Presenter.OuvrirSession();
        }

        protected void SignOutClick(object sender, EventArgs e)
        {
            Presenter.FermerSession();
        }

        protected void btnAjusterColonneRechercheClick(object sender, EventArgs e)
        {
            string message = Presenter.AjusterRecherche();
            ShowMessage(new Message { Description = message, MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }

        protected void btnImporterProduitXmlClick(object sender, EventArgs e)
        {
            Presenter.ImporterXml();
            ShowMessage(new Message { Description = "Importation terminé", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
    }


}