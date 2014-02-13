using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class ProductPriceHistory : BaseEntity
    {
        public Product Product { get; set; }
        public decimal PriceBefore { get; set; }
        public decimal PriceAfter { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
