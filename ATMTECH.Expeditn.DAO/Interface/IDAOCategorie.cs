using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOCategorie
    {
        Categorie ObtenirCategorie(int id);
        IList<Categorie> ObtenirCategorie();
    }
}
