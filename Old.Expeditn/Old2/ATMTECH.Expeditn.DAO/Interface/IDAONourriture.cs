using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourriture
    {
        IList<Nourriture> ObtenirNourriture(Expedition expedition);
        int Enregistrer(Nourriture nourriture);
    }
}
