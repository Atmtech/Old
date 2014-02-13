using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Administration.DAO.Interface
{
    public interface IDAOEntityProperty
    {
        IList<EntityProperty> GetEntityProperty(int idEntityInformation);
        int SaveEntityProperty(EntityProperty entityProperty);
        string GetEntityPropertyLabel(int idEntityInformation, string propertyName);
    }
}
