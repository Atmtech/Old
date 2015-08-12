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
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()
                                              .GetName()
                                              .Version
                                              .ToString();
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
        protected void btnImporterImageProduitClick(object sender, EventArgs e)
        {
            Presenter.CopierFichierImageProduitNonFormateVersProduct();
            Presenter.SynchronizerImage();
            Presenter.SynchronizeProductFile();
            ShowMessage(new Message { Description = "Images synchronisé", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnFermerSystemeClick(object sender, EventArgs e)
        {
            Presenter.FermerSysteme();
            ShowMessage(new Message { Description = "Système fermé", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnOuvrirSystemeClick(object sender, EventArgs e)
        {
            Presenter.OuvrirSysteme();
            ShowMessage(new Message { Description = "Système ouvert", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnCopierSauvegardeClick(object sender, EventArgs e)
        {
            string resultat = Presenter.CreationCopieSauvegarde(Server.MapPath("data"));
            ShowMessage(new Message { Description = resultat, MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnInitialiserSystemeClick(object sender, EventArgs e)
        {
            Presenter.InitialiserSysteme();
            ShowMessage(new Message { Description = "Initialisation complétée", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }

        protected void btnFlagPourmettreSystemeProductionClick(object sender, EventArgs e)
        {
            Presenter.MettreSystemeEnProduction();
        }


        //protected void btnVerifierBackOrderClick(object sender, EventArgs e)
        //{
        //    Presenter.VerifierBackOrder();
        //    ShowMessage(new Message { Description = "Vérification complétée", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        //}
    }


}