using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAOAccomplissementTrait
    {
        IList<AccomplissementTrait> ObtenirTousActive();
        IList<AccomplissementTrait> ObtenirTousActivePourAccomplissement(int idAccomplissement);
        int Enregistrer(AccomplissementTrait accomplissementTrait);
    }
}
