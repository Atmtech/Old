using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class EnterpriseAddress : BaseEntity
    {
        public const string ENTERPRISE = "Enterprise";
        public const string ADDRESS_TYPE = "AddressType";

        public const string CODE_ADRESS_TYPE_SHIPPING = "Shipping";
        public const string CODE_ADRESS_TYPE_BILLING = "Billing";

        public Address Address { get; set; }
        public Enterprise Enterprise { get; set; }
        public string AddressType { get; set; }

        public string ComboboxDescriptionUpdate { get { return Address.DisplayAddress; } }

    }
}
