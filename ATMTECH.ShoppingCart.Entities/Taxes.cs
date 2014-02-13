using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Taxes : BaseEntity
    {

        public const string TYPE = "Type";

        public string Type { get; set; }
        public decimal RegionalTax { get; set; }
        public decimal CountryTax { get; set; }
    }
}
