using System.Collections.Generic;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO.Interface
{
    public interface IDAOInsulte
    {
        IList<Insulte> ObtenirListeInsulte();
        Insulte ObtenirInsulte(int id);
    }
}
