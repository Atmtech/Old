using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOVoyage
    {
        Voyage ObtenirVoyage(int id);
        IList<Voyage> ObtenirVoyage();
        int Enregistrer(Voyage voyage);
        
    }
}
