using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public partial class OrderLine : BaseEntity
    {
        public const string ORDERS = "Order";

        public Order Order { get; set; }
        public Stock Stock { get; set; }
        public Decimal SubTotal { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string SearchUpdate
        {
            get { return Order.Id + "-" + Stock.Product.Name + "-" + Stock.Feature; }
        }

        public string ComboboxDescriptionUpdate
        {
            get { return Stock.Product.Name + "-" + Stock.Feature; }
        }
    }
}
