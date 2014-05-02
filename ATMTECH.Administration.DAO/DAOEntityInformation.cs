using System.Collections.Generic;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.DAO;
using ATMTECH.Entities;


namespace ATMTECH.Administration.DAO
{
    public class DAOEntityInformation : BaseDao<EntityInformation, int>, IDAOEntityInformation
    {
        public IDAOEntityProperty DAOEntityProperty { get; set; }
        public int SaveEntity(EntityInformation entityInformation)
        {
            entityInformation.Entity = entityInformation.PageTitle;
            return Save(entityInformation);
        }

        public int GetEntityInformationId(string className)
        {
            return GetAllOneCriteria(EntityInformation.ENTITY, className)[0].Id;
        }

        public IList<EntityInformation> GetAllEntityInformation()
        {
            IList<EntityInformation> entityInformations = GetAllActive();
            foreach (EntityInformation entityInformation in entityInformations)
            {
                entityInformation.EntityProperties = DAOEntityProperty.GetEntityProperty(entityInformation.Id);
            }
            return entityInformations;
        }

        public EntityInformation GetEntity(string nameSpace)
        {
            if (!string.IsNullOrEmpty(nameSpace))
            {
                IList<EntityInformation> enList = GetAllOneCriteria(EntityInformation.NAMESPACE, nameSpace);
                if (enList.Count > 0)
                {
                    EntityInformation entityInformation = enList[0];
                    if (DAOEntityProperty == null)
                        DAOEntityProperty = new DAOEntityProperty();
                    entityInformation.EntityProperties = DAOEntityProperty.GetEntityProperty(entityInformation.Id);
                    return entityInformation;
                }
            }
            return null;
        }
    }
}
