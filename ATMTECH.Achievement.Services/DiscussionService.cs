using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Services
{

    public class DiscussionService : BaseService, IDiscussionService
    {
        public IDAODiscussion DAODiscussion { get; set; }
        public IDAODiscussionReponse DAODiscussionReponse { get; set; }
        public IMessageService MessageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public IList<Discussion> ObtenirListeDiscussion(int idUtilisateur)
        {
            return DAODiscussion.ObtenirListeDiscussion(idUtilisateur);
        }

        public Discussion ObtenirDiscussion(int id)
        {
            return DAODiscussion.ObtenirDiscussion(id);
        }

        public int Creer(string message)
        {
            if (string.IsNullOrEmpty(message))
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ACH_MESSAGE_OBLIGATOIRE);
            
            Discussion discussion = new Discussion
                {
                    Utilisateur = AuthenticationService.AuthenticateUser,
                    Description = message
                };

            return DAODiscussion.Creer(discussion);
        }

        public int AjouterCommentaire(int idDiscussion, string commentaire)
        {
            if (string.IsNullOrEmpty(commentaire))
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ACH_COMMENTAIRE_OBLIGATOIRE);

            Discussion discussion = ObtenirDiscussion(idDiscussion);

            DiscussionReponse discussionReponse = new DiscussionReponse
                {
                    Discussion = discussion,
                    Utilisateur = AuthenticationService.AuthenticateUser,
                    Description = commentaire
                };
            return DAODiscussionReponse.Enregistrer(discussionReponse);
        }
    }
}
