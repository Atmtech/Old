using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.WebSite
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
                string idProduct = e.CommandArgument.ToString();
                Presenter.OpenProduct(idProduct);
            }
        }

        protected void ProductDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Product dataItem = (Product)e.Item.DataItem;
                ((Image)e.Item.FindControl("imgProduct")).ImageUrl = "ThumbNail.aspx?width=100&directory=images/product/&filename=" + dataItem.PrincipalFileUrl;
                ((Label)e.Item.FindControl("lblIdent")).Text = dataItem.Ident;
                ((Label)e.Item.FindControl("lblName")).Text = dataItem.Name;
                ((LinkButton)e.Item.FindControl("lnkViewProduct")).CommandArgument = dataItem.Id.ToString();
            }
        }

        protected void SearchClick(object sender, EventArgs e)
        {
            Presenter.Search(txtSearch.Text);
        }
    }
}