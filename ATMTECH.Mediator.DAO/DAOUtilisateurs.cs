using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Mediator.DAO.Interface;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.DAO
{
    public class DAOUtilisateurs : BaseDao<Utilisateur, int>, IDAOMediator
    {
        public Utilisateur ObtenirUtilisateur(string noUser)
        {
            return GetAllOneCriteria(Utilisateur.NO_UTILISATEUR, noUser)[0];
        }
        public IList<Utilisateur> ObtenirListeUtilisateur()
        {
            return GetAll();
        }
    }
}
