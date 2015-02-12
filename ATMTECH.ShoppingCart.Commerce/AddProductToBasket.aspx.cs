using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {
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
                string name = Session["currentLanguage"].ToString().Equals("fr")
                                  ? product.NameFrench
                                  : product.NameEnglish;
                lblName.Text = name;
                lblIdent.Text = product.Ident;
                lblUnitPrice.Text = product.UnitPrice.ToString("C");
                string description = Session["currentLanguage"].ToString().Equals("fr")
                                  ? product.DescriptionFrench
                                  : product.DescriptionEnglish;
                lblDescription.Text = description;

                ddlStock.DataTextField = Session["currentLanguage"].ToString().Equals("fr")
                                             ? Stock.FEATURE_FRENCH
                                             : Stock.FEATURE_ENGLISH;
                ddlStock.DataValueField = Stock.ID;
                ddlStock.DataSource = product.Stocks;
                ddlStock.DataBind();
            }
        }
        public bool IsOrderable
        {
            set
            {
                if (value)
                {
                    btnAddAllToBasket.Visible = true;
                    txtQuantite.Visible = true;
                }
                else
                {
                    btnAddAllToBasket.Visible = false;
                    txtQuantite.Visible = false;
                }
            }
        }
        public int IsSuccesfullyAdded { set; private get; }
        public bool IsOrderableAgainstSecurity { get; set; }
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

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void AddToBasketClick(object sender, EventArgs e)
        {
            Presenter.AddToBasket(Convert.ToInt32(ddlStock.SelectedValue), Convert.ToInt32(txtQuantite.Text));
            Presenter.RedirectBasket();
        }


    }
}