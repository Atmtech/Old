using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }

        public string SearchUpdate { get { return Description + " " + Name; } }
        public string ComboboxDescriptionUpdate { get { return Name; } }
    }
}
