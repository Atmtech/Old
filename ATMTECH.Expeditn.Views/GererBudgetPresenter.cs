using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class GererBudgetPresenter : BaseExpeditnPresenter<IGererBudgetPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }

        //public IDAOEtape DAOEtape { get; set; }
        public IDAOEtapeParticipant DAOEtapeParticipant { get; set; }
        //public IDAOVehicule DAOVehicule { get; set; }
        //public IDAOParticipant DAOParticipant { get; set; }

        public GererBudgetPresenter(IGererBudgetPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            //View.Expedition = expedition;
            //View.ListeVehicule = DAOVehicule.ObtenirVehicule();
            
            AfficherBudget(expedition);
        }

        private void AfficherBudget(Expedition expedition)
        {
            foreach (Etape etape in expedition.Etape)
            {
                IList<EtapeParticipant> obtenirEtapeParticipant = DAOEtapeParticipant.ObtenirEtapeParticipant(etape);
            }

            //View.ListeEtapeParticipant = expedition.Etape.
            //View.ListeEtape = DAOEtape.ObtenirEtape(expedition);
            //View.ListeEtape = DAOEtape.ObtenirEtape(expedition);
        }

   
    }
}