using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.WebSite.UserControls
{
    public partial class Order : UserControlShoppingCartBase, IOrderPresenter
    {
        public OrderPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public Entities.Order CurrentOrder
        {
            get { return (Entities.Order)ViewState["CurrentOrder"]; }
            set
            {
                if (value != null)
                {
                    ViewState["CurrentOrder"] = value;
                    grvBasket.DataSource = value.OrderLines;
                    grvBasket.DataBind();
                    lblOrderId.Text = value.Id.ToString();
                    lblGrandTotal.Text = value.GrandTotal.ToString("c");
                    lblSubTotal.Text = value.SubTotal.ToString("c");
                    lblSubTotalTaxesCountry.Text = value.CountryTax.ToString("c");
                    lblSubTotalTaxesRegion.Text = value.RegionalTax.ToString("c");
                    lblShippingTotal.Text = value.ShippingTotal.ToString("c");
                }

            }
        }

        public int IdOrder
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.ORDER_ID)); }
        }
    }
}