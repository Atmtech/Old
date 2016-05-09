using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IEnumService<T> where T : BaseEnumeration
    {
        IList<T> GetList();
        T GetEnum(int id);
    }
}
