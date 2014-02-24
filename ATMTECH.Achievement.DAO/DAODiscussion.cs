using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;

namespace ATMTECH.Achievement.DAO
{
    public class DAODiscussion : BaseDao<Discussion, int>, IDAODiscussion
    {
        public IDAODiscussionReponse DAODiscussionReponse { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IList<Discussion> ObtenirListeDiscussion(int idUtilisateur)
        {
            
            IList<Discussion> discussions = GetAllOneCriteria(Discussion.UTILISATEUR, idUtilisateur.ToString()).OrderByDescending(x => x.Id).ToList();
            foreach (Discussion discussion in discussions)
            {
                discussion.ListeDiscussionReponse = DAODiscussionReponse.ObtenirDiscussionReponse(discussion.Id);
                discussion.Utilisateur = DAOUser.GetUser(discussion.Utilisateur.Id);
            }
            return discussions;
        }

        public Discussion ObtenirDiscussion(int id)
        {
            return GetById(id);
        }

        public int Creer(Discussion discussion)
        {
            return Save(discussion);
        }
    }
}

