using System;
using System.Reflection;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly()
                .GetName()
                .Version
                .ToString();
        }


        public User Utilisateur
        {
            set
            {
                if (value != null)
                {
                    pnlConnecte.Visible = true;
                    pnlDeconnecte.Visible = false;
                    lblNomPrenomUtilisateur.Text = value.FirstNameLastName;
                }
                else
                {
                    pnlConnecte.Visible = false;
                    pnlDeconnecte.Visible = true;
                }
            }
        }

        public string Courriel { get { return txtEmail.Text; } }
        public string Message { get { return txtMessage.Text; } }

        protected void lnkDeconnecterClick(object sender, EventArgs e)
        {
            Presenter.Deconnecter();
        }

        protected void btnContacterNousClick(object sender, EventArgs e)
        {
            Presenter.EnvoyerCourrielCommentaire();
        }
    }
}