using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.WebSite.Base;

namespace ATMTECH.Achievement.WebSite
{
    public partial class Achievement : PageBaseAchievement<AccomplissementPresenter, IAccomplissementPresenter>, IAccomplissementPresenter
    {
        public int FichierSelectionne { get; set; }


        public IList<Categorie> Categorie
        {
            set
            {
                if (value != null)
                {
                    datalistCategorie.DataSource = value;
                    datalistCategorie.DataBind();
                }
            }
        }

        public IList<Accomplissement> Accomplissement
        {
            set
            {
                if (value != null)
                {
                    if (value.Count > 0)
                    {
                        IList<Accomplissement> accomplissementsAccompli = AccomplissementAccompli;

                        placeHolderAccomplissement.Controls.Clear();

                        Literal htmlAccomplissement = new Literal();
                        string html = string.Empty;

                        html += "<h2>" + value[0].Categorie.Description + "</h2>";
                        html += "<table>";
                        html += "<tr>";
                        int i = 0;
                        foreach (Accomplissement accomplissement in value)
                        {
                            i += 1;
                            if (i == 6)
                            {
                                html += "</tr><tr>";
                            }

                            html += "<td>";
                            BadgeAffichage badgeAffichage = new BadgeAffichage
                                {
                                    Accomplissement = accomplissement,
                                    CouleurBordure = "gray",
                                    EstAvecAjout = true,
                                    EstAvecVote = false,
                                    EstSansTitre = false,
                                    EstVisualisableAvecLoupe = true
                                };

                            if (accomplissementsAccompli.Count(x => x.Id == accomplissement.Id) > 0)
                            {
                                badgeAffichage.EstAvecMentionFait = true;
                            }
                            html += badgeAffichage.CreerBadge();
                            html += "</td>";
                        }
                        html += "</tr>";
                        html += "</table>";
                        htmlAccomplissement.Text = html;
                        placeHolderAccomplissement.Controls.Add(htmlAccomplissement);
                    }
                }
            }
        }

        public string idCategorieCourante
        {
            get
            {
                return Session["idCategorie"] == null ? string.Empty : Session["idCategorie"].ToString();
            }
            set
            {
                Session["idCategorie"] = value;
            }
        }

        public IList<Accomplissement> AccomplissementAccompli { get { return (IList<Accomplissement>)Session["ListeAccomplissementAccompli"]; } set { Session["ListeAccomplissementAccompli"] = value; } }


        protected void btnOuvrirCategorie(object sender, EventArgs e)
        {
            idCategorieCourante = ((LinkButton)sender).CommandArgument;
            Presenter.ObtenirListeAccomplissementDeLaCategorie(Convert.ToInt32(idCategorieCourante));
        }


    }
}