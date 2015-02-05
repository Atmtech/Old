
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOLocalization
    {
        Localization GetLocalization(string objectId, string page);
        int Save(Localization localization);
        IList<Localization> GetAll();
    }
}
