using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAOTrait
    {
        Trait ObtenirTrait(int id);
        IList<Trait> ObtenirTrait();
        Trait ObtenirTraitParCode(string code);
    }
}
