using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Services
{
    public class UtilisateurService : BaseService, IUtilisateurService
    {
        public IDAOUser DAOUser { get; set; }
        public ICourrielService CourrielService { get; set; }
        public IMessageService MessageService { get; set; }

        public void Creer(User utilisateur)
        {
            if (string.IsNullOrEmpty(utilisateur.FirstName) || string.IsNullOrEmpty(utilisateur.LastName))
            {
                MessageService.ThrowMessage(CodeErreur.NOM_ET_PRENOM_OBLIGATOIRE);
                return;
            }
            if (string.IsNullOrEmpty(utilisateur.Login))
            {
                MessageService.ThrowMessage(CodeErreur.COURRIEL_EST_OBLIGATOIRE);
                return;
            }
            if (string.IsNullOrEmpty(utilisateur.Login))
            {
                MessageService.ThrowMessage(CodeErreur.MOT_PASSE_OBLIGATOIRE);
                return;
            }
            if (utilisateur.Password != utilisateur.PasswordConfirmation)
            {
                MessageService.ThrowMessage(CodeErreur.MOT_PASSE_INEGALE_AVEC_CONFIRMATION);
                return;
            }

            if (!EstUtilisateurExistant(utilisateur))
            {
                int id = DAOUser.CreateUser(utilisateur);
                User user = DAOUser.GetUser(id);
                user.IsActive = false;
                DAOUser.UpdateUser(user);
                CourrielService.EnvoyerConfirmationCreationUtilisateur(user);
                MessageService.ThrowMessage(CodeErreur.CREATION_UTILISATEUR_EST_UN_SUCCES);
            }
        }

        private bool EstUtilisateurExistant(User utilisateur)
        {
            User user = DAOUser.GetUser(utilisateur.Login);
            if (user != null)
            {
                MessageService.ThrowMessage(CodeErreur.CET_UTILISATEUR_EXISTE_DEJA);
                return true;
            }
            return false;
        }
    }
}
