using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAODiscussionReponse
    {
        IList<DiscussionReponse> ObtenirDiscussionReponse(int idDiscussion);
        int Enregistrer(DiscussionReponse discussionReponse);
    }
}
