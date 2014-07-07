using System.Web;

namespace ATMTECH.ShoppingCart.Entities
{
    public partial class OrderLine
    {
        public string ProductDescription
        {
            get { return Stock != null ?  HttpUtility.HtmlDecode(Stock.ProductDescription) : ""; }
        }

        public string ProductDescriptionEnglish
        {
            get { return Stock != null ? HttpUtility.HtmlDecode(Stock.ProductDescriptionEnglish) : ""; }
        }
    }
}
