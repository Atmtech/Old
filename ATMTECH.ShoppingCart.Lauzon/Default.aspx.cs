using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using Pages = ATMTECH.Common.Utils.Web.Pages;

namespace ATMTECH.ShoppingCart.Lauzon
{
    public partial class Default1 : PageBaseShoppingCart<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        public string QueryStringContent
        {
            get { return QueryString.GetQueryStringValue(PagesId.CONTENT_ID); }
        }

        public string ContentValue
        {
            set { lblContent.Text = value; }
        }

        public IList<Product> FavoritesProduct
        {
            set
            {
                foreach (Product product in value)
                {
                    string header = "<a href='AddProductToBasket.aspx?" + PagesId.PRODUCT_ID + "=" + product.Id + "'><div class='tile image outline-color-white'>";
                    string image = "<div class='tile-content'><img src='" + product.PrincipalFileUrl + "'></div>";
                    string name = Session["currentLanguage"].ToString().Equals("fr")
                                    ? product.NameFrench
                                    : product.NameEnglish;
                    string productDisplay = product.Ident + " " + name;
                    string brand = "<div class='brand bg-color-product' style='height:40px;width:175px;'><div style='font-size:10px;padding-top: 3px; padding-left:3px; padding-right:20px;height:40px;width:165px;font-weight:bold;'>" + Pages.RemoveHtmlTag(productDisplay) + "</div></div>";
                    string footer = "</div></a>";
                    Literal literal = new Literal { Text = header + image + brand + footer };
                    placeHolderProductFavorite.Controls.Add(literal);
                }
            }
        }

        public Enterprise Enterprise { get; set; }
    }
}