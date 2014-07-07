using System.Linq;

namespace ATMTECH.ShoppingCart.Entities
{
    public partial class Stock
    {
        public string ProductDescription
        {
            get { return Product != null ? Product.Ident + " " + Product.NameFrench + " " + FeatureFrench : ""; }
        }

        public string ProductDescriptionEnglish
        {
            get { return Product != null ? Product.Ident + " " + Product.NameEnglish + " " + FeatureEnglish : ""; }
        }

        public decimal StockPrice
        {
            get { return Product != null ? Product.UnitPrice + AdjustPrice : 0; }
        }
    }
}
