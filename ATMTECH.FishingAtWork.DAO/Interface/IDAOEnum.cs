using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOEnum<T> where T : BaseEnumeration
    {
        IList<T> GetList();
        T GetEnum(int id);
    }
}
