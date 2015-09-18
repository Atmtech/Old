using System.Web.UI.WebControls;
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


        protected void imgVaisseauClick(object sender, ImageMapEventArgs e)
        {
            Presenter.ObtenirMouvement(e.PostBackValue, 1);
        }
    }
}