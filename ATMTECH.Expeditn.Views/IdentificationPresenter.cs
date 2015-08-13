using ATMTECH.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class IdentificationPresenter : BaseExpeditnPresenter<IIdentificationPresenter>
    {
        public IdentificationPresenter(IIdentificationPresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IUtilisateurService UtilisateurService { get; set; }

        public void Identification()
        {
            User user = AuthenticationService.SignIn(View.NomUtilisateurIdentification, View.MotPasseIdentification);
            if (user != null)
            {
                NavigationService.Redirect(Pages.ACTION);
            }
        }
       
    }
}