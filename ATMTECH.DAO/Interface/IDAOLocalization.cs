
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOLocalization
    {
        Localization GetLocalization(string objectId, string page);
    }
}
