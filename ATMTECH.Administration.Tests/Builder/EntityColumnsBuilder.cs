using ATMTECH.Entities;

namespace ATMTECH.Administration.Tests.Builder
{
    public static class EntityColumnsBuilder
    {
        public static EntityProperty Create()
        {
            return new EntityProperty();
        }

        public static EntityProperty WithEntityInformation(this EntityProperty entityProperty, EntityInformation entityInformation)
        {
            entityProperty.EntityInformation = entityInformation;
            return entityProperty;
        }
        public static EntityProperty WithPropertyName(this EntityProperty entityProperty, string PropertyName)
        {
            entityProperty.PropertyName = PropertyName;
            return entityProperty;
        }
        public static EntityProperty WithLabel(this EntityProperty entityProperty, string label)
        {
            entityProperty.Label = label;
            return entityProperty;
        }
        public static EntityProperty WithOrder(this EntityProperty entityProperty, int order)
        {
            entityProperty.Order = order;
            return entityProperty;
        }
    }
}
