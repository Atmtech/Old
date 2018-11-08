using ATMTECH.StockGame.Services;

namespace ATMTECH.StockGame.Site.UserControl
{
    public class UserControlBase : System.Web.UI.UserControl
    {
        public UtilisateurService UtilisateurService => new UtilisateurService();
        public NavigationService NavigationService => new NavigationService();

        //public string IdExpedition => Request.QueryString["IdExpedition"];
        //public string IdSuiviPrix => Request.QueryString["IdSuiviPrix"];

        public Site PageMaitre => Page.Master as Site;

    }


}