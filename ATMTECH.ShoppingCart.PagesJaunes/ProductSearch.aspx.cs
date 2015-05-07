using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using Pages = ATMTECH.Common.Utils.Web.Pages;

namespace ATMTECH.ShoppingCart.PagesJaunes
{
    public partial class ProductSearch : PageBaseShoppingCart<ProductSearchPresenter, IProductSearchPresenter>, IProductSearchPresenter
    {

        public IList<Product> Products
        {
            set
            {

                foreach (Product product in value)
                {
                    string header = "<a href='AddProductToBasket.aspx?" + PagesId.PRODUCT_ID + "=" + product.Id + "'><div class='tile double-vertical double image outline-color-white'>";
                    string image = "<div class='tile-content'><img src='" + product.PrincipalFileUrl + "'></div>";
                    string name = Session["currentLanguage"].ToString().Equals("fr")
                                      ? product.NameFrench
                                      : product.NameEnglish;
                    string productDisplay = product.Ident + " " + name + " " + product.UnitPrice.ToString("C");
                    string brand = "<div class='brand bg-color-button-product' style='height:45px;width:500px;'><div style='font-size:12px;padding: 3px 3px 3px 3px;font-weight:bold;'>" + Pages.RemoveHtmlTag(productDisplay) + "</div></div>";
                    string footer = "</div></a>";
                    Literal literal = new Literal { Text = header + image + brand + footer };
                    placeHolderProduct.Controls.Add(literal);
                }
            }
        }

        public string Search
        {
            get
            {
                return QueryString.GetQueryStringValue("Search");
            }
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            Presenter.Search(txtSearch.Text);
        }
    }
}