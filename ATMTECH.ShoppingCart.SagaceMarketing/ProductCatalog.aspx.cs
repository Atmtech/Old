using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web.Controls.Affichage;

namespace ATMTECH.ShoppingCart.SagaceMarketing
{
    public partial class ProductCatalog : PageBaseShoppingCart<ProductCatalogPresenter, IProductCatalogPresenter>, IProductCatalogPresenter
    {

        public IList<ProductCategory> ProductCategories
        {
            set
            {
                dataListCategory.DataSource = value;
                dataListCategory.DataBind();

                if (value.Count == 0)
                {
                    pnlNoCategory.Visible = true;
                }
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

        protected void ProductCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewProduct")
            {
                Session[PagesId.PRODUCT_ID] = e.CommandArgument.ToString();
                addProductToBasket.RefreshInformation();
                windowAddToBasket.OuvrirFenetre();
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