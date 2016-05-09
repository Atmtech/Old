using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOEnum<T> : BaseDao<T, int>, IDAOEnum<T> where T : BaseEnumeration
    {
        public IList<T> GetList()
        {
            return GetAllActive();
        }

        public T GetEnum(int id)
        {
            return GetById(id);
        }
    }
}
