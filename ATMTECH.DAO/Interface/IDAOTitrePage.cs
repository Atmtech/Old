using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOTitrePage
    {
        TitrePage ObtenirTitrePage(string page);
        IList<TitrePage> GetAllActive();
    }
}
