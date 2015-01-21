using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.WebControls;

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {
        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductFile dataItem = (ProductFile)e.Item.DataItem;
                if (dataItem.File != null)
                {
                    ((ImageButton)e.Item.FindControl("imgProductFile")).ImageUrl = "../images/product/" + dataItem.File.FileName;
                    ((ImageButton)e.Item.FindControl("imgProductFile")).Attributes.Add("onmouseover", "changeImage('../images/product/" + dataItem.File.FileName + "')");
                }
                else
                {
                    ((ImageButton)e.Item.FindControl("imgProductFile")).ImageUrl = "../images/product/NoImageForThisProduct.jpg";
                }

                ((ImageButton)e.Item.FindControl("imgProductFile")).CommandArgument = dataItem.Id.ToString();

            }
        }
        public string IdProduct
        {
            get
            {
                return QueryString.GetQueryStringValue(PagesId.PRODUCT_ID);
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
                string name = Session["currentLanguage"].ToString().Equals("fr")
                                     ? product.NameFrench
                                     : product.NameEnglish;

                lblName.Text = name;
                lblUnitPrice.Text = product.UnitPrice.ToString("C");

                lblWeight.Text = product.Weight.ToString();
                switch (Presenter.CurrentLanguage)
                {
                    case LocalizationLanguage.FRENCH:
                        lblProductCategoryDescription.Text = product.ProductCategoryFrench.Description;
                        lblDescription.Text = product.DescriptionFrench;
                        break;
                    case LocalizationLanguage.ENGLISH:
                        lblProductCategoryDescription.Text = product.ProductCategoryEnglish.Description;
                        lblDescription.Text = product.DescriptionEnglish;
                        break;
                }

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
        public bool IsOrderLocked
        {
            set
            {
                if (value)
                {
                    btnAddAllToBasket.Enabled = false;
                }
            }
        }
        protected void StockAddCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Presenter.AddToBasket(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(e.Item.FindControl("txtQuantity")));
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
                        string feature = string.Empty;
                        switch (Presenter.CurrentLanguage)
                        {
                            case LocalizationLanguage.FRENCH:
                                feature = dataItem.FeatureFrench;
                                break;
                            case LocalizationLanguage.ENGLISH:
                                feature = dataItem.FeatureEnglish;
                                break;
                        }



                        if (dataItem.AdjustPrice != 0)
                        {
                            feature += " (+" + dataItem.AdjustPrice.ToString("c") + ")";
                        }
                        ((Label)e.Item.FindControl("lblDescription")).Text = feature;
                        Control lblStockId = e.Item.FindControl("lblStockId");
                        if (lblStockId != null)
                        {
                            var label = lblStockId as Label;
                            if (label != null) label.Text = id;
                        }
                        Numeric alpha = ((Numeric)e.Item.FindControl("txtQuantity"));

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
                                lblStock.Text = Presenter.LocalizeStock("lblStock");

                                int quantityInStock = Presenter.GetActualStockState(dataItem);
                                if (quantityInStock == 0)
                                {
                                    if (alpha != null) alpha.Visible = false;
                                }
                                lblStockQuantity.Text += quantityInStock;

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
                            Presenter.RefreshInformation();
                            imgProductPrincipal.ImageUrl = "../images/product/" + productFile.File.FileName;
                        }

                        lnkDisplay.ImageUrl = imgProductPrincipal.ImageUrl;
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

                Numeric numeric = dataListItem.FindControl("txtQuantity") as Numeric;

                if (numeric != null && !string.IsNullOrEmpty(numeric.Text))
                {
                    if (numeric.Text != "0")
                    {
                        if (idStock != null)
                            Presenter.AddToBasket(Convert.ToInt32(idStock.Text), Convert.ToInt32(numeric.Text));
                    }
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