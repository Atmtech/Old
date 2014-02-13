using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Country : BaseEnumeration
    {
        public string Iso { get; set; }
    }
}
