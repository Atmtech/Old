using ATMTECH.Entities;
using ATMTECH.Expeditn.Services;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class InscriptionPresenter : BaseExpeditnPresenter<IInscriptionPresenter>
    {
        public InscriptionPresenter(IInscriptionPresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IUtilisateurService UtilisateurService { get; set; }


        public void CreerUtilisateur()
        {
            if (View.MotPasse != View.MotPasseConfirmation)
            {
                MessageService.ThrowMessage(CodeErreur.SC_MOT_PASSE_INEGALE_AVEC_CONFIRMATION);
            }

            User utilisateur = new User
                {
                    Email = View.Courriel,
                    Login = View.Courriel,
                    Password = View.MotPasse,
                    FirstName = View.Prenom,
                    LastName = View.Nom
                };

            if (UtilisateurService.Creer(utilisateur) != null)
            {
                MessageService.ThrowMessage(CodeErreur.ADM_CREATION_UTILISATEUR_EST_UN_SUCCES);
            }
        }
    }
}