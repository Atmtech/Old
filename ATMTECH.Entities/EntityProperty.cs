using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class EntityProperty : BaseEntity
    {
        public const string ENTITY_INFORMATION = "EntityInformation";
        public const string PROPERTY_NAME = "PropertyName";

        public EntityInformation EntityInformation { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
        public string PropertyName { get; set; }
        public bool IsRequired { get; set; }
    }
}
