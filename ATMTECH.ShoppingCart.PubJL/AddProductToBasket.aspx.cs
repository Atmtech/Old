using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
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
                return ObtenirParametreQueryString(PagesId.PRODUCT_ID);
            }
            set
            {
                IList<QueryString> queryStrings = new List<QueryString>();
                queryStrings.Add(new QueryString(PagesId.PRODUCT_ID, value));
                Presenter.Redirect(Pages.ADD_PRODUCT_TO_BASKET, queryStrings);
            }
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

                imgProductPrincipal.ImageUrl = product.PrincipalFileUrl;
                var firstOrDefault = product.ProductFiles.FirstOrDefault(x => x.IsPrincipal);
                if (firstOrDefault != null)
                    imgProductPrincipal.CommandArgument = firstOrDefault.Id.ToString();

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
                    btnAddAllToBasket.Visible = false;
                    DataListStockNotOrderable.Visible = true;
                    DataListStockOrderable.Visible = false;
                }
            }
        }

        public int IsSuccesfullyAdded
        {
            set
            {
                //if (value == 1)
                //{
                //    lblAddToBasketSucessfull.Visible = true;
                //}
            }
        }

        public bool IsOrderableAgainstSecurity
        {
            get { return lblCannotOrderBecauseSecurity.Visible; }
            set
            {
                if (value)
                {
                    DataListStockNotOrderable.Visible = false;
                    DataListStockOrderable.Visible = true;
                    lblCannotOrderBecauseSecurity.Visible = false;
                }
                else
                {
                    btnAddAllToBasket.Visible = false;
                    DataListStockNotOrderable.Visible = true;
                    DataListStockOrderable.Visible = false;
                    lblCannotOrderBecauseSecurity.Visible = true;
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
            switch (e.Item.ItemType)
            {
                case ListItemType.AlternatingItem:
                case ListItemType.Item:
                    {
                        Stock dataItem = (Stock)e.Item.DataItem;
                        string id = dataItem.Id.ToString();
                        string feature = dataItem.Feature;
                        if (dataItem.AdjustPrice != 0)
                        {
                            feature += " (+" + dataItem.AdjustPrice.ToString("c") + ")";
                        }
                        ((Label)e.Item.FindControl("lblDescription")).Text = feature;
                        Control lblStockId = e.Item.FindControl("lblStockId");
                        if (lblStockId != null)
                        {
                            (lblStockId as Label).Text = id;
                        }
                        AlphaNumTextBoxAvance alpha = ((AlphaNumTextBoxAvance)e.Item.FindControl("txtQuantity"));

                        if (alpha != null)
                        {
                            alpha.ValidationGroup = "AddBasket" + dataItem.Id.ToString();
                        }

                        Label lblStockQuantity = ((Label)e.Item.FindControl("lblStockQuantity"));
                        Label lblStock = ((Label)e.Item.FindControl("lblStock"));

                        if (lblStockQuantity != null)
                        {
                            if (dataItem.IsWithoutStock)
                            {
                                lblStockQuantity.Visible = false;
                                lblStock.Visible = false;
                            }
                            else
                            {
                                lblStockQuantity.Text += Presenter.GetActualStockState(dataItem);
                            }
                        }

                    }
                    break;
            }
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ChangeImage":
                    {
                        ProductFile productFile = Presenter.GetProductFile(Convert.ToInt32(e.CommandArgument.ToString()));
                        if (productFile.ProductLinked.Id != 0)
                        {
                            Presenter.GetLinkedProduct(productFile.ProductLinked);
                        }
                        else
                        {
                            imgProductPrincipal.ImageUrl = "../images/product/" + productFile.File.FileName;
                        }
                    }
                    break;
            }
        }

        protected void RedirectProductCatalog(object sender, EventArgs e)
        {
            Presenter.RedirectProductCatalog();
        }

        protected void AddToBasketClick(object sender, EventArgs e)
        {
            foreach (DataListItem dataListItem in DataListStockOrderable.Items)
            {
                Label idStock = dataListItem.FindControl("lblStockId") as Label;

                AlphaNumTextBoxAvance alphaNumTextBoxAvance = dataListItem.FindControl("txtQuantity") as AlphaNumTextBoxAvance;
                if (!string.IsNullOrEmpty(alphaNumTextBoxAvance.Text))
                {
                    Presenter.AddToBasket(Convert.ToInt32(idStock.Text), alphaNumTextBoxAvance.ValeurInt);
                }
            }

            Presenter.RedirectBasket();

        }

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            ProductFile productFile = Presenter.GetProductFile(Convert.ToInt32(imgProductPrincipal.CommandArgument));
            if (productFile.ProductLinked.Id != 0)
            {
                Presenter.GetLinkedProduct(productFile.ProductLinked);
            }
        }
    }
}