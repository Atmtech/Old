using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Achievement.Services
{

    public class DiscussionService : BaseService, IDiscussionService
    {
        public IDAODiscussion DAODiscussion { get; set; }
        public IDAODiscussion DAODiscussionReponse { get; set; }

        public IList<Discussion> ObtenirDiscussion(int idUtilisateur)
        {
            return DAODiscussion.ObtenirListeDiscussion(idUtilisateur);
        }

        public int Creer(Discussion discussion)
        {
            return DAODiscussion.Creer(discussion);
        }
    }
}
