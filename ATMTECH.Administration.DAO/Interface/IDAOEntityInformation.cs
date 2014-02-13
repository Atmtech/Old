using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Administration.DAO.Interface
{
    public interface IDAOEntityInformation
    {
        int SaveEntity(EntityInformation entityInformation);
        EntityInformation GetEntity(string nameSpace);
        IList<EntityInformation> GetAllEntityInformation();
        int GetEntityInformationId(string className);
    }
}
