using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class EnumOrderInformation : BaseEntity
    {
        public const string ENTERPRISE = "Enterprise";
        public const string GROUP = "Group";
        public const string CODE = "Code";

        public Enterprise Enterprise { get; set; }
        public string Code { get; set; }
        public string Group { get; set; }

    }
}
