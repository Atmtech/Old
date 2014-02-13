using System.Linq;

namespace ATMTECH.ShoppingCart.Entities
{
    public partial class Stock
    {
        public string ProductDescription
        {
            get { return Product != null ? Product.Ident + " " + Product.Name + " " + Feature : ""; }
        }

        public decimal StockPrice
        {
            get { return Product != null ? Product.UnitPrice + AdjustPrice : 0; }
        }
    }
}
