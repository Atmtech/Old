using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class BaseEnumeration : BaseEntity
    {
        public const string TYPE_ENUMERATION = "Type";
        public const string CODE = "Code";

        public string Code { get; set; }
        public string Type { get; set; }

    }
}
