using System.Collections.Generic;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO.Interface
{
    public interface IDAOInsulte
    {
        IList<Insulte> ObtenirListeInsulte();
        Insulte ObtenirInsulte(int id);
    }
}
