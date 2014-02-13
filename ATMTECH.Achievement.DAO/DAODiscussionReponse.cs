using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;

namespace ATMTECH.Achievement.DAO
{
    public class DAODiscussionReponse : BaseDao<DiscussionReponse, int>, IDAODiscussionReponse
    {
        public IDAOUser DAOUser { get; set; }
        public IList<DiscussionReponse> ObtenirDiscussionReponse(int idDiscussion)
        {
            IList<DiscussionReponse> discussionReponses = GetAllOneCriteria(DiscussionReponse.DISCUSSION, idDiscussion.ToString());
            foreach (DiscussionReponse discussionReponse in discussionReponses)
            {
                discussionReponse.Utilisateur = DAOUser.GetUser(discussionReponse.Utilisateur.Id);
            }
            return discussionReponses;
        }
    }
}
