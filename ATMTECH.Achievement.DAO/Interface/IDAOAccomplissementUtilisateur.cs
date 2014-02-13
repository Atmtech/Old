using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAOAccomplissementUtilisateur
    {
        IList<AccomplissementUtilisateur> ObtenirListeAccomplissementUtilisateur(int idUtilisateur);
        int Enregistrer(AccomplissementUtilisateur accomplissementUtilisateur);
    }
}
