using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ExpeditionPresenter : BaseExpeditnPresenter<IExpeditionPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
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

            Expedition expedition = ExpeditionService.ObtenirExpedition(View.IdExpedition);
            View.Expedition = expedition;
            View.EstAdministrateur = AuthenticationService.AuthenticateUser != null &&
                                     expedition.Chef.Utilisateur.Id == AuthenticationService.AuthenticateUser.Id;
        }
    }
}