using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.SagaceMarketing
{
    public partial class ProductSearch : PageBaseShoppingCart<ProductSearchPresenter, IProductSearchPresenter>, IProductSearchPresenter
    {

        public IList<Product> Products
        {
            set
            {
                dataListProduct.DataSource = value;
                dataListProduct.DataBind();
            }
        }

        public string Search
        {
            get
            {
                return QueryString.GetQueryStringValue("Search");
            }
        }

        protected void ProductCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewProduct")
            {
                Session[PagesId.PRODUCT_ID] = e.CommandArgument.ToString();
                addProductToBasket.RefreshInformation();
                windowAddToBasket.OuvrirFenetre();
            }
        }

        protected void ProductDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Product dataItem = (Product)e.Item.DataItem;
                ((Image)e.Item.FindControl("imgProduct")).ImageUrl = "images/product/" + dataItem.PrincipalFileUrl;//"ThumbNail.aspx?width=250&directory=images/product/&filename=" + dataItem.PrincipalFileUrl;
                ((Label)e.Item.FindControl("lblIdent")).Text = dataItem.Ident;
                ((Button)e.Item.FindControl("btnName")).Text = dataItem.Name;
                ((Button)e.Item.FindControl("btnName")).CommandArgument = dataItem.Id.ToString();
                ((ImageButton)e.Item.FindControl("imgProduct")).CommandArgument = dataItem.Id.ToString();
                ((Label)e.Item.FindControl("lblUnitPrice")).Text = dataItem.UnitPrice.ToString("C");
            }
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            Presenter.Search(txtSearch.Text);
        }
    }
}