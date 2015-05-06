using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class PageMaitrePresenter : BaseExpeditnPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherUtilisateur();
        }

        public void AfficherUtilisateur()
        {
            View.Utilisateur = AuthenticationService.AuthenticateUser;
        }

        public void RedirigerIdentification()
        {
            NavigationService.Redirect(Pages.IDENTIFICATION);
        }

        public void Deconnecter()
        {
            AuthenticationService.SignOut();
        }
    }
}