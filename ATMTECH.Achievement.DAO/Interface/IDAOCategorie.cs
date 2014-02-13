using System.Collections.Generic;
using ATMTECH.Achievement.Entities;

namespace ATMTECH.Achievement.DAO.Interface
{
    public interface IDAOCategorie
    {
        Categorie ObtenirParId(int id);
        IList<Categorie> ObtenirTousActive();
        Categorie ObtenirParCode(string code);
    }
}
