using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOEmplacement
    {
        IList<Emplacement> ObtenirEmplacement();
        int Enregistrer(Emplacement emplacement);
    }
}
