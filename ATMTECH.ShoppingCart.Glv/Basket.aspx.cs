using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.WebControls;

namespace ATMTECH.ShoppingCart.Glv
{
    public partial class Basket : PageBaseShoppingCart<BasketPresenter, IBasketPresenter>, IBasketPresenter
    {
        public IList<EnumOrderInformation> EnumOrderInformation1
        {
            set
            {
                ddlOrderInformation1.DataSource = value;
                ddlOrderInformation1.DataTextField = BaseEntity.DESCRIPTION;
                ddlOrderInformation1.DataValueField = EnumOrderInformation.CODE;
                ddlOrderInformation1.DataBind();
            }
        }
        public IList<EnumOrderInformation> EnumOrderInformation2
        {
            set
            {
                ddlOrderInformation2.DataSource = value;
                ddlOrderInformation2.DataTextField = BaseEntity.DESCRIPTION;
                ddlOrderInformation2.DataValueField = EnumOrderInformation.CODE;
                ddlOrderInformation2.DataBind();
            }
        }

        public bool IsDontAddPersonnalAddressShipping { set { if (value) btnModifyShippingAddress.Visible = false; } }
        public bool IsDontAddPersonnalAddressBilling { set { if (value) btnModifyBillingAddress.Visible = false; } }

        public string OrderInformation1Value { get { return ddlOrderInformation1.SelectedValue; } }
        public string OrderInformation2Value { get { return ddlOrderInformation2.SelectedValue; } }
        public string NoAddressFound
        {
            set
            {
                lblNoBillingAddress.Text = value;
                lblNoShippingAddress.Text = value;
            }
        }
        public bool IsAskShipping
        {
            set
            {
                if (value)
                {
                    btnFinalizeOrder.Visible = false;
                    btnFinalizeOrderPaypal.Visible = false;
                    btnAskShipping.Visible = true;
                    lblAskShippingInformation.Visible = true;
                }
            }
        }
        public string AskShippingLabel { set { lblAskShipping.Text = value; } }
        public bool IsOrderLocked
        {
            set
            {
                if (value)
                {
                    btnFinalizeOrder.Visible = false;
                    btnPrintOrder.Visible = false;
                    btnFinalizeOrderPaypal.Visible = false;
                    btnRecalculateBasket.Visible = false;
                    btnModifyBillingAddress.Visible = false;
                    btnModifyShippingAddress.Visible = false;
                    btnAskShipping.Visible = false;
                    lblAskShippingInformation.Visible = false;
                    grvBasket.Enabled = false;
                    lblAskShipping.Visible = true;
                    pnlAskShipping.Visible = true;
                }
            }
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
        public bool IsBillingAddressFixed
        {
            set
            {
                if (value)
                {
                    ddlBilling.Enabled = false;
                    btnModifyBillingAddress.Visible = false;
                }
            }
        }
        public bool IsShippingAddressFixed
        {
            set
            {
                if (value)
                {

                    ddlShipping.Enabled = false;
                    btnModifyShippingAddress.Visible = false;
                }
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
        public bool IsShippingManaged
        {
            set
            {
                lblShippingTotalLabel.Visible = value;
                lblShippingWeight.Visible = value;
                lblShippingTotal.Visible = value;
            }
        }
        public int ShippingAddressSelected
        {
            get { return Convert.ToInt32(ddlShipping.SelectedValue); }
            set { ddlShipping.SelectedValue = value.ToString(); }
        }
        public int BillingAddressSelected
        {
            get { return Convert.ToInt32(ddlBilling.SelectedValue); }
            set { ddlBilling.SelectedValue = value.ToString(); }
        }
        public bool IsPaypal
        {
            set
            {
                btnFinalizeOrderPaypal.Visible = value;
            }
        }
        public bool IsPaypalRequired
        {
            set
            {
                if (value)
                {
                    btnFinalizeOrder.Visible = false;
                    btnFinalizeOrderPaypal.Visible = true;
                }

            }
        }
        public bool IsManageOrderInformation1 { set { pnlOrderInformation1.Visible = value; } }
        public bool IsManageOrderInformation2 { set { pnlOrderInformation2.Visible = value; } }
        public IList<Address> ShippingAddress
        {
            set
            {
                ddlShipping.DataSource = value;
                ddlShipping.DataTextField = Address.DISPLAY_ADDRESS;
                ddlShipping.DataValueField = BaseEntity.ID;
                ddlShipping.DataBind();

                if (ddlShipping.Items.Count == 1)
                {
                    ddlShipping.Enabled = false;
                    if (value[0].Country == null)
                    {
                        btnAskShipping.Enabled = false;
                        btnFinalizeOrder.Enabled = false;
                        btnFinalizeOrderPaypal.Enabled = false;
                        lblNoShippingAddress.Visible = true;
                        ddlShipping.Visible = false;
                    }
                }

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

                if (ddlBilling.Items.Count == 1)
                {
                    ddlBilling.Enabled = false;
                    if (value[0].Country == null)
                    {
                        btnAskShipping.Enabled = false;
                        btnFinalizeOrder.Enabled = false;
                        btnFinalizeOrderPaypal.Enabled = false;
                        lblNoBillingAddress.Visible = true;
                        ddlBilling.Visible = false;
                    }
                }
            }
        }

        protected void FinalizeOrderClick(object sender, EventArgs e)
        {
            Presenter.FinalizeOrder(false);
        }
        protected void RecalculerClick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Numeric textBox in from GridViewRow row in grvBasket.Rows select (Numeric)row.FindControl("txtQuantity"))
            {
                CurrentOrder.OrderLines[i].Quantity = Convert.ToInt32(textBox.Text);
                i++;
            }

            Presenter.RecalculateBasket();

            var @default = (Default)Master;
            if (@default != null) @default.RefreshTotal();
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
        protected void FinalizeOrderPaypal(object sender, EventArgs eventArgs)
        {
            Presenter.FinalizeOrder(true);
        }
        protected void ContinueShoppingClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.PRODUCT_CATALOG);
        }
        protected void btnAskShippingClick(object sender, EventArgs e)
        {
            Presenter.AskForShipping();
        }
        protected void btnModifyShippingAddressClick(object sender, EventArgs e)
        {
            Presenter.GotoAccount();
        }
        protected void btnModifyBillingAddressClick(object sender, EventArgs e)
        {
            Presenter.GotoAccount();
        }

        protected void ddlBillingIndexSelectedChanged(object sender, EventArgs e)
        {
            Presenter.SetBillingAddress(ddlBilling.SelectedValue);
            Presenter.RecalculateBasket();
        }

        protected void ddlShippingIndexSelectedChanged(object sender, EventArgs e)
        {
            Presenter.SetShippingAddress(ddlShipping.SelectedValue);
            Presenter.RecalculateBasket();
        }
    }
}