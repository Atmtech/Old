using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class ProductCategory : BaseEnumeration
    {
        public const string ENTERPRISE = "Enterprise";
        public Enterprise Enterprise { get; set; }

        public string SearchUpdate { get { return Description + " " + Code; } }
        public string ComboboxDescriptionUpdate { get { return Description; } }

    }
}
