using System;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.XWingCampaign.Entities;
using ATMTECH.XWingCampaign.Views;
using ATMTECH.XWingCampaign.Views.Interface;

namespace ATMTECH.XWingCampaign.WebSite
{
    public partial class Default1 : PageBase<AccueilPresenter, IAccueilPresenter>, IAccueilPresenter
    {

        public string Resultat
        {
            get { return lblRetour.Text; }
            set { lblRetour.Text = value; }
        }

        public Vaisseau VaisseauSelectionne
        {
            get
            {
                return (Vaisseau)Session["VaisseauSelectionne"];
            }
            set
            {
                Session["VaisseauSelectionne"] = value;
                if (value != null)
                    ConstruireTableauQuadrant();
                //imgVaisseau.ImageUrl = "Images/Website/" + value.Image;
            }
        }

        private void ConstruireTableauQuadrant()
        {
            //VaisseauSelectionne

            ConstruireQuadrant(quadrantNW, "NW", "R3;R2F");
            ConstruireQuadrant(quadrantNW, "NW", "R1;R2C");

            ConstruireQuadrant(quadrantN, "N", "R3;R2F");
            ConstruireQuadrant(quadrantN, "N", "R1;R2C");

            ConstruireQuadrant(quadrantNE, "NE", "R3;R2F");
            ConstruireQuadrant(quadrantNE, "NE", "R1;R2C");

            ConstruireQuadrant(quadrantW, "W", "R3;R2F");
            ConstruireQuadrant(quadrantW, "W", "R1;R2C");

            ConstruireQuadrant(quadrantE, "E", "R3;R2F");
            ConstruireQuadrant(quadrantE, "E", "R1;R2C");

            ConstruireQuadrant(quadrantSW, "SW", "R3;R2F");
            ConstruireQuadrant(quadrantSW, "SW", "R1;R2C");

            ConstruireQuadrant(quadrantS, "S", "R3;R2F");
            ConstruireQuadrant(quadrantS, "S", "R1;R2C");

            ConstruireQuadrant(quadrantSE, "SE", "R3;R2F");
            ConstruireQuadrant(quadrantSE, "SE", "R1;R2C");

        }

        private void ConstruireQuadrant(PlaceHolder quadrant, string pointCardinal, string position)
        {
            string html = position == "R3;R2F" ? string.Format("<div Class='quadrantDesVert{0}' >", pointCardinal) : string.Format("<div Class='quadrantDesRouge{0}' >", pointCardinal);
            html += "<table>";
            foreach (IntelligenceArtificiel intelligenceArtificiel in VaisseauSelectionne.ListeMouvement.Where(x => x.PositionVaisseau == position && x.Quadran == pointCardinal).ToList())
            {
                html += "<tr>";

                string imageMouvement = intelligenceArtificiel.Stress
                    ? string.Format("<img src='Images/WebSite/{0}_S.png' style='height:15px;width:15px;'>",
                        intelligenceArtificiel.Mouvement)
                    : string.Format("<img src='Images/WebSite/{0}.png' style='height:15px;width:15px;'>",
                        intelligenceArtificiel.Mouvement);


               // string imageMouvement = string.Format("<img src='Images/Website/{0}.png' width='15px' height='15px' />", intelligenceArtificiel.Mouvement);
                string imageMiniDe = string.Empty;
                string[] des = intelligenceArtificiel.DeRequis.Split(';');
                foreach (string de in des)
                {
                    imageMiniDe += string.Format("<img src='Images/Website/De{0}Mini.png' style='padding-left:2px;' />", de);
                }
                html += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td>", imageMouvement, intelligenceArtificiel.NombreMouvement, imageMiniDe);
                html += "</tr>";
            }
            html += "</table>";
            html += "</div>";
            quadrant.Controls.Add(new Literal { Text = html });

        }




        public bool AfficherResultat
        {
            get { return pnlResultat.Visible; }
            set { pnlResultat.Visible = value; }
        }


        protected void imgVaisseauClick(object sender, ImageMapEventArgs e)
        {
            Presenter.ObtenirMouvement(e.PostBackValue);
        }

        protected void SelectionnerVaisseau(object sender, EventArgs e)
        {
            Presenter.SelectionnerVaisseau(Convert.ToInt32((sender as Button).CommandArgument));
        }

        protected void btnFermerClick(object sender, EventArgs e)
        {
            AfficherResultat = false;
        }
    }
}