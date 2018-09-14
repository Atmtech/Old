using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AccueilPresenter : BaseExpeditnPresenter<IAccueilPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        //public IExpediaService ExpediaService { get; set; }

        public IDAOHistoriqueForfaitExpedia DaoHistoriqueForfait { get; set; }
        public IDAORechercheForfaitExpedia DaoRechercheForfaitExpedia { get; set; }

        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeExpedition();
        }

       


        public void AfficherListeExpedition()
        {
            View.Expeditions = ExpeditionService.ObtenirExpeditionTop(20);
        }

        public void Test()
        {
            ExpeditionService.ObtenirMenuPdf(ExpeditionService.ObtenirExpedition(1));
        }
    }

  
}