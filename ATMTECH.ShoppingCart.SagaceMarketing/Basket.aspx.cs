using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.ShoppingCart.SagaceMarketing
{
    public partial class Basket : PageBaseShoppingCart<BasketPresenter, IBasketPresenter>, IBasketPresenter
    {
        public IList<Country> Countrys
        {
            set
            {
                ddlModifyBillingCountry.DataSource = value;
                ddlModifyBillingCountry.DataTextField = BaseEntity.DESCRIPTION;
                ddlModifyBillingCountry.DataValueField = BaseEntity.ID;
                ddlModifyBillingCountry.DataBind();

                ddlModifyShippingCountry.DataSource = value;
                ddlModifyShippingCountry.DataTextField = BaseEntity.DESCRIPTION;
                ddlModifyShippingCountry.DataValueField = BaseEntity.ID;
                ddlModifyShippingCountry.DataBind();
            }
        }

        public bool IsPanelModifyShippingAddressOpen
        {
            get { return pnlModifyShippingAddress.Visible; }
        }

        public bool IsPanelModifyBillingAddressOpen
        {
            get { return pnlModifyBillingAddress.Visible; }
        }

        public string ModifyShippingAddressWay
        {
            get { return txtModifyShippingWay.Text; }
            set { txtModifyShippingWay.Text = value; }
        }

        public int ModifyShippingCountry
        {
            get { return Convert.ToInt32(ddlModifyShippingCountry.SelectedValue); }
            set { ddlModifyShippingCountry.SelectedValue = value.ToString(); }
        }

        public string ModifyShippingCity
        {
            get { return txtModifyShippingCity.Text; }
            set { txtModifyShippingCity.Text = value; }
        }

        public string ModifyShippingPostalCode
        {
            get { return txtModifyShippingPostalCode.Text; }
            set { txtModifyShippingPostalCode.Text = value; }
        }

        public string ModifyBillingAddressWay
        {
            get { return txtModifyBillingWay.Text; }
            set { txtModifyBillingWay.Text = value; }
        }

        public int ModifyBillingCountry
        {
            get { return Convert.ToInt32(ddlModifyBillingCountry.SelectedValue); }
            set { ddlModifyBillingCountry.SelectedValue = value.ToString(); }
        }

        public string ModifyBillingCity
        {
            get { return txtModifyBillingCity.Text; }
            set { txtModifyBillingCity.Text = value; }
        }

        public string ModifyBillingPostalCode
        {
            get { return txtModifyBillingPostalCode.Text; }
            set { txtModifyBillingPostalCode.Text = value; }
        }

        public string Project
        {
            get { return txtProject.Text; }
            set { txtProject.Text = value; }
        }

        public decimal ShippingWeight
        { set { lblShippingWeight.Text = string.Format("({0} lbs)", value.ToString()); } }


        public decimal ShippingTotal
        { set { lblShippingTotal.Text = value.ToString("c"); } }

        public Order CurrentOrder
        {
            get
            {
                return (Order)Session["CurrentOrder"];
            }
            set
            {
                if (value != null)
                {
                    if (value.OrderLines.Count(x => x.IsActive) == 0)
                    {
                        pnlBasketEmpty.Visible = true;
                        pnlBasketNotEmpty.Visible = false;
                    }
                    else
                    {
                        RefreshOrderDisplay(value);
                    }


                }
                else
                {
                    pnlBasketEmpty.Visible = true;
                    pnlBasketNotEmpty.Visible = false;
                }
            }
        }

        public void RefreshOrderDisplay(Order value)
        {
            if (value.OrderLines.Count == 0)
            {
                pnlBasketEmpty.Visible = true;
                pnlBasketNotEmpty.Visible = false;
            }
            else
            {
                pnlBasketEmpty.Visible = false;
                pnlBasketNotEmpty.Visible = true;

                Session["CurrentOrder"] = value;

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

        public bool IsOrderFinalized
        {
            set
            {
                if (value)
                {
                    pnlBasketNotEmpty.Visible = false;
                    pnlOrderFinalized.Visible = true;
                }
            }
        }

        public bool IsShippingNotIncluded
        {
            set { lblShippingNotIncluded.Visible = value; }
        }

        public IList<Address> ShippingAddress
        {
            set
            {
                ddlShipping.DataSource = value;
                ddlShipping.DataTextField = Address.DISPLAY_ADDRESS;
                ddlShipping.DataValueField = BaseEntity.ID;
                ddlShipping.DataBind();
            }
        }

        public IList<Address> BillingAddress
        {
            set
            {
                ddlBilling.DataSource = value;
                ddlBilling.DataTextField = Address.DISPLAY_ADDRESS;
                ddlBilling.DataValueField = BaseEntity.ID;
                ddlBilling.DataBind();
            }
        }

        protected void FinalizeOrderClick(object sender, EventArgs e)
        {
            Presenter.FinalizeOrder(false);
        }

        protected void RecalculerClick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (GridViewRow row in grvBasket.Rows)
            {
                AlphaNumTextBoxAvance textBox = (AlphaNumTextBoxAvance)row.FindControl("txtQuantity");
                CurrentOrder.OrderLines[i].Quantity = Convert.ToInt32(textBox.Text);
                i++;
            }

            Presenter.RecalculateBasket();

            ((Default)Master).RefreshTotal();
        }

        protected void GrvBasketCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOrderLine")
            {
                Presenter.RemoveOrderLine(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void PrintOrderClick(object sender, EventArgs e)
        {
            Presenter.PrintOrder();
        }

        protected void ShowModifyShippingAddress(object sender, EventArgs e)
        {
            ddlShipping.Visible = false;
            btnModifyShippingAddress.Visible = false;
            pnlModifyShippingAddress.Visible = true;
        }

        protected void ShowModifyBillingAddress(object sender, EventArgs e)
        {
            ddlBilling.Visible = false;
            btnModifyBillingAddress.Visible = false;
            pnlModifyBillingAddress.Visible = true;
        }

        protected void FinalizeOrderPaypal(object sender, EventArgs eventArgs)
        {
            Presenter.FinalizeOrder(true);
        }

        protected void ContinueShoppingClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.PRODUCT_CATALOG);
        }

        protected void CancelModifiedBillingAddressClick(object sender, EventArgs e)
        {
            ddlBilling.Visible = true;
            btnModifyBillingAddress.Visible = true;
            pnlModifyBillingAddress.Visible = false;
        }

        protected void CancelModifiedShippingAddressClick(object sender, EventArgs e)
        {
            ddlShipping.Visible = true;
            btnModifyShippingAddress.Visible = true;
            pnlModifyShippingAddress.Visible = false;
        }
    }
}