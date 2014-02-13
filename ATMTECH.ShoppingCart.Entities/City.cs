using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class City : BaseEnumeration
    {
        public Country Country { get; set; }
        public string SearchUpdate { get { return Description + " " + Code; } }
        public string ComboboxDescriptionUpdate { get { return Code + "-" + Description; } }
    }
}
