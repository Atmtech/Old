using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
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
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAOExpedition DAOExpedition { get; set; }

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
            if (string.IsNullOrEmpty(utilisateur.Password))
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

        public void Confirmer(User user)
        {
            user.IsActive = true;
            Enregistrer(user);
        }

        public void Enregistrer(User utilisateur)
        {
            DAOUser.UpdateUser(utilisateur);
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant(utilisateur);
            IList<User> users = DAOUser.GetAllActive();
            foreach (Participant participant in obtenirParticipant)
            {
                participant.Expedition = DAOExpedition.ObtenirExpedition(participant.Expedition.Id);
                participant.Utilisateur = users.FirstOrDefault(x => x.Id == participant.Utilisateur.Id);
                DAOParticipant.Enregistrer(participant);
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
