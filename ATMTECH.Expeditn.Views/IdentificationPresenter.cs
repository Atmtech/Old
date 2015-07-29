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
                NavigationService.Redirect(Pages.DEFAULT);
            }
        }
        //public void CreerUtilisateur()
        //{
        //    if (View.MotPasseCreation != View.MotPasseConfirmationCreation)
        //    {
        //        MessageService.ThrowMessage(CodeErreur.SC_MOT_PASSE_INEGALE_AVEC_CONFIRMATION);
        //    }

        //    User utilisateur = new User
        //        {
        //            Email = View.CourrielCreation,
        //            Login = View.CourrielCreation,
        //            Password = View.MotPasseCreation,
        //            FirstName = View.PrenomCreation,
        //            LastName = View.NomCreation
        //        };

        //    if (UtilisateurService.Creer(utilisateur) != null)
        //    {
        //        MessageService.ThrowMessage(CodeErreur.ADM_CREATION_UTILISATEUR_EST_UN_SUCCES);
        //    }
        //}
    }
}