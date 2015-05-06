using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class AccueilPresenter : BaseExpeditnPresenter<IAccueilPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IDAOCategorie DAOCategorie { get; set; }
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherCategorie();
            if (!string.IsNullOrEmpty(View.idUtilisateur))
            {
                AfficherListeExpeditionUtilisateur(Convert.ToInt32(View.idUtilisateur));
            }
            else
            {
                AfficherListeExpedition();    
            }
            
        }

        public void AfficherCategorie()
        {
            View.Categories = DAOCategorie.ObtenirCategorie();

        }
        public void AfficherListeExpedition()
        {
            View.Expeditions = ExpeditionService.ObtenirExpedition();
        }

        public void AfficherListeExpeditionUtilisateur(int id)
        {
            View.Expeditions = ExpeditionService.ObtenirMesExpedition(id);
        }
    }
}