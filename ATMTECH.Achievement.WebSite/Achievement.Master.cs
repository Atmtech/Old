using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.Views.Pages;
using ATMTECH.Achievement.WebSite.Base;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.WebSite
{
    public partial class MasterAchievement : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public void ShowMessage(Message message)
        {
            string test = message.Description;
        }

        public bool IsAuthenticated
        {
            set
            {
                if (value)
                {
                    pnlSignIn.Visible = false;
                    pnlUtilisateurAuthentifie.Visible = true;
                    pnlAccomplissementTitre.Visible = true;
                    pnlMenu.Visible = true;
                }
                else
                {
                    pnlSignIn.Visible = true;
                    pnlUtilisateurAuthentifie.Visible = false;
                    pnlAccomplissementTitre.Visible = false;
                    pnlMenu.Visible = false;
                }
            }
        }

        public string NomUtilisateur { set { lblNomUtilisateurAuthentifie.Text = value; } }
        public string ImageUtilisateur
        {
            set
            {
                imgUtilisateur.ImageUrl = value;
            }
        }

        public IList<AccomplissementUtilisateur> AccomplissementUtilisateur
        {
            set
            {
                Literal htmlAccomplissement = new Literal();
                string html = string.Empty;
                html += "<table>";
                html += "<tr>";

                foreach (AccomplissementUtilisateur accomplissementUtilisateur in value)
                {
                    BadgeAffichage badgeAffichage = new BadgeAffichage
                    {
                        Accomplissement = accomplissementUtilisateur.Accomplissement,
                        CouleurBordure = "gray",
                        EstAvecAjout = true,
                        EstAvecVote = false,
                        EstSansTitre = true
                    };
                    html += "<td>";
                    html += badgeAffichage.CreerBadge();
                    html += "</td>";
                }

                html += "</tr>";
                html += "</table>";
                htmlAccomplissement.Text = html;
                placeHolderAccomplissement.Controls.Add(htmlAccomplissement);
            }
        }

        protected void btnSignInClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.LOGIN);

        }

        protected void btnLogoutClick(object sender, ImageClickEventArgs e)
        {
            Presenter.SignOut();
        }

        protected void btnAccomplissementClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.ACHIEVEMENT);
        }

        protected void btnProposerClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.PROPOSER);
        }

        protected void btnVoterAccomplissementClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.VOTE);
        }

        protected void btnMurClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.DISCUSSION);
        }
    }
}