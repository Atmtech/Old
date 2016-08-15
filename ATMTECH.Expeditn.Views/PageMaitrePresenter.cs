using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class PageMaitrePresenter : BaseExpeditnPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }


        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherUtilisateur();
        }

        public void AfficherUtilisateur()
        {
            View.Utilisateur = AuthenticationService.AuthenticateUser;
        }

        //public void RedirigerIdentification()
        //{
        //    NavigationService.Redirect(Pages.IDENTIFICATION);
        //}

        public void Deconnecter()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.DEFAULT);
        }

        //public void TestGoogleMap()
        //{
        //   // GoogleMapService.AfficherImage("1318 rue des frênes Canada Lévis", TypeCarteAffiche.Satellite);
        //}
    }
}