using System;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.ShoppingCart.SagaceMarketing.UserControls
{
    public partial class AddProductToBasket : UserControlShoppingCartBase<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductFile dataItem = (ProductFile)e.Item.DataItem;
                ((ImageButton)e.Item.FindControl("imgProductFile")).ImageUrl = "../images/product/" + dataItem.File.FileName;
                ((ImageButton)e.Item.FindControl("imgProductFile")).CommandArgument = dataItem.Id.ToString();
                ((ImageButton)e.Item.FindControl("imgProductFile")).Attributes.Add("onmouseover", "changeImage('../images/product/" + dataItem.File.FileName + "')");
            }
        }

        public string IdProduct
        {
            get
            {
                if (Session[PagesId.PRODUCT_ID] != null)
                {
                    return Session[PagesId.PRODUCT_ID].ToString();
                }
                return null;

            }
            set { Session[PagesId.PRODUCT_ID] = value; }
        }

        public Product Product
        {
            get { return (Product)Session["Product"]; }
            set
            {
                Session["Product"] = value;

                Product product = (Product)Session["Product"];
                lblCostPrice.Text = product.CostPrice.ToString();
                lblIdent.Text = product.Ident;
                lblName.Text = product.Name;
                lblUnitPrice.Text = product.UnitPrice.ToString("C");
                lblProductCategoryDescription.Text = product.ProductCategory.Description;
                lblWeight.Text = product.Weight.ToString();
                lblDescription.Text = product.Description;

                imgProductPrincipal.ImageUrl = "../images/product/" + product.PrincipalFileUrl;

                if (product.ProductFiles.Count > 1)
                {
                    DataListProductFile.DataSource = product.ProductFiles;
                    DataListProductFile.DataBind();
                }

                DataListStockOrderable.DataSource = product.Stocks;
                DataListStockOrderable.DataBind();

                DataListStockNotOrderable.DataSource = product.Stocks;
                DataListStockNotOrderable.DataBind();

                if (product.Stocks.Count == 0)
                {
                    lblStockNotPresent.Visible = true;
                }
            }
        }

        public bool IsOrderable
        {
            set
            {
                if (value)
                {
                    DataListStockNotOrderable.Visible = false;
                    DataListStockOrderable.Visible = true;
                }
                else
                {
                    DataListStockNotOrderable.Visible = true;
                    DataListStockOrderable.Visible = false;
                }
            }
        }

        public int IsSuccesfullyAdded
        {
            set
            {
                if (value == 1)
                {
                    lblAddToBasketSucessfull.Visible = true;
                }
            }
        }

        protected void StockAddCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Presenter.AddToBasket(Convert.ToInt32(e.CommandArgument), ((AlphaNumTextBoxAvance)e.Item.FindControl("txtQuantity")).ValeurInt);

            }
        }

        protected void StockDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Stock dataItem = (Stock)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDescription")).Text = dataItem.Feature;
                ((Button)e.Item.FindControl("btnAddToBasket")).CommandArgument = dataItem.Id.ToString();
                ((Button)e.Item.FindControl("btnAddToBasket")).ValidationGroup = "AddBasket" + dataItem.Id.ToString();
                ((AlphaNumTextBoxAvance)e.Item.FindControl("txtQuantity")).ValidationGroup = "AddBasket" + dataItem.Id.ToString();
                ((Label)e.Item.FindControl("lblStockQuantity")).Text += Presenter.GetActualStockState(dataItem);
            }
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ChangeImage")
            {
                ProductFile productFile = Presenter.GetProductFile(Convert.ToInt32(e.CommandArgument.ToString()));
                if (productFile.ProductLinked.Id != 0)
                {
                    Presenter.GetLinkedProduct(productFile.ProductLinked);
                }

                RefreshInformation();

            }
        }

        public void RefreshInformation()
        {
            Presenter.RefreshInformation();
        }


    }
}