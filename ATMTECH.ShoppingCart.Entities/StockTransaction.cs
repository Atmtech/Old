using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class StockTransaction : BaseEntity
    {
        public const string STOCK = "Stock";

        public Stock Stock { get; set; }
        public Order Order { get; set; }
        public int Transaction { get; set; }

        public string ComboboxDescriptionUpdate { get { return Stock.FeatureFrench == null ? "" : Stock.FeatureFrench + " " + Order.Id + " " + Stock.Product.Name + " " + Stock.Product.Ident; } }
    }
}
