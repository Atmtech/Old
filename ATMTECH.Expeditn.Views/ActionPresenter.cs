using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ActionPresenter : BaseExpeditnPresenter<IActionPresenter>
    {
        //public IExpeditionService ExpeditionService { get; set; }
        //public IDAOGeoLocalisation DaoGeoLocalisation { get; set; }
        //public IDAOPays DAOPays { get; set; }
        //public IDAOParticipant DAOParticipant { get; set; }
        //public IAuthenticationService AuthenticationService { get; set; }

        public ActionPresenter(IActionPresenter view)
            : base(view)
        {
        }

        //public void AfficherExpedition()
        //{
        //    if (!string.IsNullOrEmpty(View.IdExpedition))
        //    {
        //        Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
        //        if (expedition != null)
        //        {
        //            View.BudgetEstime = expedition.BudgetEstime;
        //            View.Nom = expedition.Nom;
        //            View.Debut = expedition.Debut;
        //            View.Fin = expedition.Fin;
        //            View.EstExpeditionPrive = expedition.EstPrive;
        //            View.Longitude = expedition.GeoLocalisation.Longitude;
        //            View.Latitude = expedition.GeoLocalisation.Latitude;
        //            View.Region = expedition.GeoLocalisation.Region;
        //            View.Pays = expedition.GeoLocalisation.Pays.Id.ToString();
        //            View.Ville = expedition.GeoLocalisation.Ville;
        //        }
        //    }
        //}


        public void NouvelleExpedition()
        {
            NavigationService.Redirect("AjouterExpeditionEtape1.aspx");
        }

        public void ModifierExpedition()
        {
           
        }
    }
}