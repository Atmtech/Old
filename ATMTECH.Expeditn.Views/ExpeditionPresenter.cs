using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ExpeditionPresenter : BaseExpeditnPresenter<IExpeditionPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public ExpeditionPresenter(IExpeditionPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherExpedition();
        }

        public void AfficherExpedition()
        {
            View.Expedition = ExpeditionService.ObtenirExpedition(View.IdExpedition);
        }
    }
}