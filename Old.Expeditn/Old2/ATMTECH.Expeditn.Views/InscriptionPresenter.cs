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

        
        public IUtilisateurService UtilisateurService { get; set; }


        public void CreerUtilisateur()
        {
            User utilisateur = new User
                {
                    Email = View.Courriel,
                    Login = View.Courriel,
                    Password = View.MotPasse,
                    PasswordConfirmation = View.MotPasseConfirmation,
                    FirstName = View.Prenom,
                    LastName = View.Nom
                };
            UtilisateurService.Creer(utilisateur);
        }
    }
}