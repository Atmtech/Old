using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.DAO
{
    public class DAOCategorie : BaseDao<Categorie, int>, IDAOCategorie
    {
        public Categorie ObtenirParId(int id)
        {
            return GetById(id);
        }

        public Categorie ObtenirParCode(string code)
        {
            return GetAllOneCriteria(BaseEnumeration.CODE, code)[0];
        }

        public IList<Categorie> ObtenirTousActive()
        {
            return GetAllActive();
        }
    }
}
