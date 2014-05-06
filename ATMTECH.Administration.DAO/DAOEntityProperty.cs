using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.DAO;
using ATMTECH.Entities;

namespace ATMTECH.Administration.DAO
{
    public class DAOEntityProperty : BaseDao<EntityProperty, int>, IDAOEntityProperty
    {
        public string GetEntityPropertyLabel(int idEntityInformation, string propertyName)
        {
            if (propertyName != "SearchUpdate" )
            {
                if (propertyName != "ComboboxDescriptionUpdate")
                {
                    IList<EntityProperty> entityProperties = GetAllOneCriteria(EntityProperty.ENTITY_INFORMATION, idEntityInformation.ToString());
                    EntityProperty firstOrDefault = entityProperties.FirstOrDefault(x => x.PropertyName == propertyName);
                    if (firstOrDefault != null)
                        return firstOrDefault.Label;
                    else
                    {
                        return "UnReferenced";
                    }
                }
            }
            return string.Empty;
        }

        public IList<EntityProperty> GEtAllEntityProperty()
        {
            return GetAllActive();
        }

        public IList<EntityProperty> GetEntityProperty(int idEntityInformation)
        {
            return GetAllOneCriteria(EntityProperty.ENTITY_INFORMATION, idEntityInformation.ToString());
        }

        public int SaveEntityProperty(EntityProperty entityProperty)
        {
            return Save(entityProperty);
        }
    }
}
