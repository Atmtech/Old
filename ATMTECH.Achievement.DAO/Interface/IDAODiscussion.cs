using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAODiscussion
    {
        IList<Discussion> ObtenirListeDiscussion(int idUtilisateur);
        Discussion ObtenirDiscussion(int id);
        int Creer(Discussion discussion);
    }
}
