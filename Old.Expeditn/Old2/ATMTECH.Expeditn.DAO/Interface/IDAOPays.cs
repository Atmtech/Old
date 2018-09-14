using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOPays
    {
        Pays ObtenirPays(int id);
        IList<Pays> ObtenirPays();
    }
}
