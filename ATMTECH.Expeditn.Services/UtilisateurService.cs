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

        public User Creer(User utilisateur)
        {
            if (EstUtilisateurExistant(utilisateur))
            {
                int id = DAOUser.CreateUser(utilisateur);
                User user = DAOUser.GetUser(id);
                user.IsActive = false;
                DAOUser.UpdateUser(user);
                CourrielService.EnvoyerConfirmationCreationUtilisateur(user);
                return utilisateur;
            }
            return null;
        }
        private bool EstUtilisateurExistant(User utilisateur)
        {
            User user = DAOUser.GetUser(utilisateur.Login);
            if (user != null)
            {
                MessageService.ThrowMessage(CodeErreur.SC_CET_UTILISATEUR_EXISTE_DEJA);
                return true;
            }
            return false;
        }
    }
}
