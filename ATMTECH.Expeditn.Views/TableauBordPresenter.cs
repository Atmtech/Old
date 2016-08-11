using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class TableauBordPresenter : BaseExpeditnPresenter<ITableauBordPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }

        public TableauBordPresenter(ITableauBordPresenter view)
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
            View.MesExpeditions = ExpeditionService.ObtenirMesExpedition(AuthenticationService.AuthenticateUser.Id);
        }

        public void AjouterExpedition()
        {
            NavigationService.Redirect(Pages.GERER_EXPEDITION);
        }

        public void ModifierParticipant(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect(Pages.GERER_PARTICIPANT, queryStrings);
        }

        public void ModifierEtape(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect(Pages.GERER_ETAPE, queryStrings);
        }

        public void ModifierMenu(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect(Pages.GERER_NOURRITURE, queryStrings);
        }

        public void ModifierExpedition(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect(Pages.GERER_EXPEDITION, queryStrings);
        }

        public void ModifierRepartitionBudget(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect(Pages.GERER_BUDGET, queryStrings);
        }
    }
}