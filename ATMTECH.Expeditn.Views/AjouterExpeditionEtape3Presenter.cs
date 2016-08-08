using System;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AjouterExpeditionEtape3Presenter : BaseExpeditnPresenter<IAjouterExpeditionEtape3Presenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOEtape DAOEtape { get; set; }
        public IDAOVehicule DAOVehicule { get; set; }

        public AjouterExpeditionEtape3Presenter(IAjouterExpeditionEtape3Presenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherEtape(expedition);
            View.ListeVehicule = DAOVehicule.ObtenirVehicule();
        }

        private void AfficherEtape(Expedition expedition)
        {
            View.ListeEtape = DAOEtape.ObtenirEtape(expedition);
        }

        public void AjouterActivite()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Vehicule vehicule = DAOVehicule.ObtenirVehicule(Convert.ToInt32(View.IdVehicule));
            Etape etape = new Etape
            {
                Nom = View.Nom,
                Debut = View.Debut,
                Fin = View.Fin,
                Distance = Convert.ToInt32(View.Distance),
                Expedition = expedition,
                Vehicule = vehicule
            };
            DAOEtape.Enregistrer(etape);
            AfficherEtape(expedition);

        }
    }
}