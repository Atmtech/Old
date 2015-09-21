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
                imgVaisseau.ImageUrl = "Images/Website/" + value.Image;
            }
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