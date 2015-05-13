using System;
using System.Web.UI;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Charte : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgCharte.ImageUrl = @"Images\WebSite\" + QueryString.GetQueryStringValue(PagesId.CHARTE) + ".jpg";
        }

        protected void btnRevenirAccueilClick(object sender, EventArgs e)
        {
            Response.Redirect("AddProductToBasket.aspx?" + PagesId.PRODUCT_ID + "=" + QueryString.GetQueryStringValue(PagesId.PRODUCT_ID));
        }
    }
}