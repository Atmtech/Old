using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.WebSite.Base;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.WebSite
{
    public partial class Propose : PageBaseAchievement<ProposerPresenter, IProposerPresenter>, IProposerPresenter
    {
        public string Titre { get { return txtTitre.Text; } }
        public string Description { get { return txtDescription.Text; } }
        public IList<string> ListeCodeTraits
        {
            get
            {
                IList<ListItem> listItems = listeTraits.ObtenirListeResultat();
                return listItems.Select(x => x.Value).ToList();
            }
        }
        public string Image { get { return imgSelectionne.ImageUrl; } }
        public string Couleur { get { return ddlCouleur.SelectedValue; } }
        public string Categorie { get { return ddlCategorie.SelectedValue; } }

        public IList<File> Fichier
        {
            set
            {
                if (value != null)
                {
                    datalistImage.DataSource = value;
                    datalistImage.DataBind();
                }
            }
        }

        public IList<Trait> Traits
        {
            set
            {
                listeTraits.ChargerListeDepart(value, BaseEnumeration.CODE, BaseEntity.DESCRIPTION);
            }
        }

        public IList<string> Couleurs
        {
            set
            {
                if (value != null)
                {
                    ddlCouleur.DataSource = value;
                    ddlCouleur.DataBind();

                    AffecterCouleurEnBackgroundSurListe();
                }
            }
        }

        private void AffecterCouleurEnBackgroundSurListe()
        {
            int row;
            for (row = 0; row < ddlCouleur.Items.Count - 1; row++)
            {
                ddlCouleur.Items[row].Attributes.Add("style", "background-color:" + ddlCouleur.Items[row].Value);
            }
            ddlCouleur.BackColor = Color.FromName(ddlCouleur.SelectedItem.Text);
        }

        public IList<Categorie> Categories
        {
            set
            {
                ddlCategorie.DataTextField = BaseEntity.DESCRIPTION;
                ddlCategorie.DataValueField = BaseEnumeration.CODE;
                ddlCategorie.DataSource = value;
                ddlCategorie.DataBind();
            }
        }

        protected void OnItemCommandClick(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "selectionnerImage")
            {
                string[] t = e.CommandArgument.ToString().Split('#');
                imgSelectionne.ImageUrl = "images/badge/" + t[1];
            }
        }

        protected void btnEtape2Click(object sender, EventArgs e)
        {
            AffecterCouleurEnBackgroundSurListe();
            pnlEtape1.Visible = false;
            pnlEtape2.Visible = true;
            pnlEtape3.Visible = false;
            pnlEtape4.Visible = false;
            pnlSommaire.Visible = false;
        }

        protected void btnEtape3Click(object sender, EventArgs e)
        {
            pnlEtape1.Visible = false;
            pnlEtape2.Visible = false;
            pnlEtape3.Visible = true;
            pnlEtape4.Visible = false;
            pnlSommaire.Visible = false;
        }

        protected void btnEtape4Click(object sender, EventArgs e)
        {
            Presenter.RemplirListeTrait();
            pnlEtape1.Visible = false;
            pnlEtape2.Visible = false;
            pnlEtape3.Visible = false;
            pnlEtape4.Visible = true;
            pnlSommaire.Visible = false;
        }

        protected void btnSommaireClick(object sender, EventArgs e)
        {
            pnlEtape1.Visible = false;
            pnlEtape2.Visible = false;
            pnlEtape3.Visible = false;
            pnlEtape4.Visible = false;
            pnlSommaire.Visible = true;

            Literal literal = new Literal();
            BadgeAffichage badgeAffichage = new BadgeAffichage
                {
                    Accomplissement = Presenter.GenererAccomplissementDuWizard(),
                    CouleurBordure = "gray"
                };
            literal.Text = badgeAffichage.CreerBadge();
            placeHolderSommaire.Controls.Add(literal);

        }

        protected void btnAnnulerClick(object sender, EventArgs e)
        {
            Presenter.RetournerAccueil();
        }

        protected void btnAjouterAccomplissementClick(object sender, EventArgs e)
        {
            Presenter.CreerAccomplissement();
        }


    }
}