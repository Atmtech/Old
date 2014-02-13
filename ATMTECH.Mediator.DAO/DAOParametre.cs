using ATMTECH.DAO;
using ATMTECH.Mediator.DAO.Interface;
using ATMTECH.Mediator.Entities;

namespace ATMTECH.Mediator.DAO
{
    public class DAOParametre : BaseDao<Parametre, int>, IDAOMediator
    {
        public Parametre ObtenirParametre(string nomParametre)
        {
            return GetAllOneCriteria(Parametre.NOM_PARAMETRE, nomParametre)[0];
        }
    }
}
