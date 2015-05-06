using System;
using System.Data.SqlTypes;
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
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()
                                              .GetName()
                                              .Version
                                              .ToString();
        }

        protected void btnIdentificationClick(object sender, EventArgs e)
        {
            Presenter.RedirigerIdentification();
        }

        public User Utilisateur
        {
            set
            {
                if (value == null)
                {
                    pnlIdentification.Visible = true;
                    pnlIdentifier.Visible = false;
                    pnlDeconnecter.Visible = false;
                }
                else
                {
                    pnlIdentification.Visible = false;
                    UtilisateurIdentifier.Utilisateur = value;
                    UtilisateurIdentifier.EstUtilisateurAuthentifie = true;
                    pnlIdentifier.Visible = true;
                    pnlDeconnecter.Visible = true;
                }

            }
        }

        protected void btnDeconnecterClick(object sender, EventArgs e)
        {
            Presenter.Deconnecter();
        }
    }
}