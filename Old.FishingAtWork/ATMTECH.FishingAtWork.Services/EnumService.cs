using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class EnumService<T> : BaseService, IEnumService<T> where T : BaseEnumeration
    {
        public IDAOEnum<T> DAOEnum { get; set; }
        public IList<T> GetList()
        {
            return DAOEnum.GetList();
        }

        public T GetEnum(int id)
        {
            return DAOEnum.GetEnum(id);
        }
    }
}
