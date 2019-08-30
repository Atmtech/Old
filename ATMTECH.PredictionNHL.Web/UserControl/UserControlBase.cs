
using ATMTECH.PredictionNHL.Services;

namespace ATMTECH.PredictionNHL.Web.UserControl
{
    public class UserControlBase : System.Web.UI.UserControl
    {
    //    public ExpeditionService ExpeditionService => new ExpeditionService();
        public UtilisateurService UtilisateurService => new UtilisateurService();
    //    public SuiviPrixService SuiviPrixService => new SuiviPrixService();
        public NavigationService NavigationService => new NavigationService();

    //    public string IdExpedition => Request.QueryString["IdExpedition"];
    //    public string IdSuiviPrix => Request.QueryString["IdSuiviPrix"];

        public Site PageMaitre => Page.Master as Site;

    }


}