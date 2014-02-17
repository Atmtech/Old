using System.Collections.Generic;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.DAO
{
    public class DAOTrait : BaseDao<Trait, int>, IDAOTrait
    {
      
        public Trait ObtenirTrait(int id)
        {
            return GetById(id);
        }

        public IList<Trait> ObtenirTrait()
        {
            return GetAllActive();
        }

        public Trait ObtenirTraitParCode(string code)
        {
            return GetAllOneCriteria(BaseEnumeration.CODE, code)[0];
        }
    }
}
