using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.Web.Controls.Edition;
using Image = System.Drawing.Image;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {

        public string IdProduct
        {
            get { return QueryString.GetQueryStringValue(PagesId.PRODUCT_ID); }
            set { }
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
                lblUnitPrice.Text = product.UnitPrice.ToString();
                lblProductCategoryDescription.Text = product.ProductCategory.Description;
                lblWeight.Text = product.Weight.ToString();

                imgProductPrincipal.ImageUrl = "ThumbNail.aspx?width=300&directory=images/product/&filename=" + product.PrincipalFileUrl;

                if (product.ProductFiles.Count > 1)
                {
                    DataListProductFile.DataSource = product.ProductFiles;
                    DataListProductFile.DataBind();
                }

                DataListStockOrderable.DataSource = product.Stocks;
                DataListStockOrderable.DataBind();

                DataListStockNotOrderable.DataSource = product.Stocks;
                DataListStockNotOrderable.DataBind();
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


        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductFile dataItem = (ProductFile)e.Item.DataItem;
                ((ImageButton)e.Item.FindControl("imgProductFile")).ImageUrl = "ThumbNail.aspx?width=100&directory=images/product/&filename=" + dataItem.File.FileName;
                ((ImageButton)e.Item.FindControl("imgProductFile")).CommandArgument = dataItem.File.FileName;
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

                ((Label)e.Item.FindControl("lblDescription")).Text += Presenter.GetActualStockState(dataItem);
                //((Label)e.Item.FindControl("lblStockQuantity")).Text = dataItem.ActualState.ToString();
                ((AlphaNumTextBoxAvance)e.Item.FindControl("txtQuantity")).ValidationGroup = "AddBasket" + dataItem.Id.ToString();
            }
        }

        protected void StockAddCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Presenter.AddToBasket(Convert.ToInt32(e.CommandArgument), ((AlphaNumTextBoxAvance)e.Item.FindControl("txtQuantity")).ValeurInt);
            }
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ChangeImage")
            {
                imgDisplayImage.ImageUrl = "ThumbNail.aspx?width=original&directory=images/product/&filename=" + ((ImageButton)e.Item.FindControl("imgProductFile")).CommandArgument;
                string strServerPath = Server.MapPath("images/product/");
                string strFilename = strServerPath + Server.UrlDecode(((ImageButton)e.Item.FindControl("imgProductFile")).CommandArgument);
                Image image = Image.FromFile(strFilename);
                int srcWidth = image.Width + 100;
                int srcHeight = image.Height + 50;
                windowDisplayImage.Largeur = srcWidth.ToString();
                windowDisplayImage.Hauteur = srcHeight.ToString();
                windowDisplayImage.OuvrirFenetre();
            }
        }

        protected void OpenWindowImage(object sender, ImageClickEventArgs e)
        {
            imgDisplayImage.ImageUrl = "ThumbNail.aspx?width=original&directory=images/product/&filename=" + Product.PrincipalFileUrl;
            string strServerPath = Server.MapPath("images/product/");
            string strFilename = strServerPath + Server.UrlDecode(Product.PrincipalFileUrl);
            Image image = Image.FromFile(strFilename);
            int srcWidth = image.Width + 100;
            int srcHeight = image.Height + 50;
            windowDisplayImage.Largeur = srcWidth.ToString();
            windowDisplayImage.Hauteur = srcHeight.ToString();
            windowDisplayImage.OuvrirFenetre();
        }
    }
}