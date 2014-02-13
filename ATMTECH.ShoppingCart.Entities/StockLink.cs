using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class StockLink : BaseEntity
    {
        public const string PRODUCT = "Product";
        public Stock Stock { get; set; }
        public Stock StockLinked { get; set; }

        public  string SearchUpdate { get { return Stock.Feature + " " + StockLinked.Feature; } }
    }
}
