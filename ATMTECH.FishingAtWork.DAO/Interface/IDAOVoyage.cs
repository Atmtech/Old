using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOVoyage
    {
        IList<Voyage> ObtenirVoyage();
        int Enregistrer(Voyage voyage);
        
    }
}
