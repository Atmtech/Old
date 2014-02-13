using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAOAccomplissement
    {
        IList<Accomplissement> ObtenirAccomplissementActifParCategorie(int idCategorie);
        IList<Accomplissement> ObtenirTousActive();
        Accomplissement ObtenirAccomplissement(int id);
        int Enregistrer(Accomplissement accomplissement);
    }
}
