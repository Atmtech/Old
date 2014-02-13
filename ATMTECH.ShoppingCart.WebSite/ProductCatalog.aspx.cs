using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class ProductCatalog : PageBaseShoppingCart<ProductCatalogPresenter, IProductCatalogPresenter>,IProductCatalogPresenter
    {

        public IList<ProductCategory> ProductCategories
        {
            set
            {
                dataListCategory.DataSource = value;
                dataListCategory.DataBind();
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

        protected void ProductCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewProduct")
            {
                string idProduct = e.CommandArgument.ToString();
                Presenter.OpenProduct(idProduct);
            }
        }


        protected void CategoryDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductCategory dataItem = (ProductCategory)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDescription")).Text = dataItem.Description;


                IList<Product> products = Presenter.GetProductCategory(dataItem.Id);
                if (products.Count > 0)
                {
                    e.Item.FindControl("pnlProduct").Visible = true;
                    ((DataList)e.Item.FindControl("dataListProductByCategory")).DataSource = products;
                    e.Item.FindControl("dataListProductByCategory").DataBind();
                }
                else
                {
                    e.Item.FindControl("pnlProduct").Visible = false;
                    e.Item.FindControl("pnlNoProduct").Visible = true;
                }

            }

        }
    }
}