using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourriture
    {
        Nourriture ObtenirNourriture(int id);
        IList<Nourriture> ObtenirNourriture();
        IList<Nourriture> ObtenirNourriture(Expedition expedition);
    }
}
