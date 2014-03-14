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

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class Basket : PageBaseShoppingCart<BasketPresenter, IBasketPresenter>, IBasketPresenter
    {
        public Address PersonnalBillingAddress
        {
            set
            {
                ListItem listItem = new ListItem
                    {
                        Value = value.Id.ToString(),
                        Text = value.DisplayAddress,
                        Selected = true
                    };
                ddlBilling.Items.Add(listItem);
            }
        }

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

        public string AskShippingLabel { set { lblAskShipping.Text = value; } }

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

        public string OrderInformation1Value { get { return ddlOrderInformation1.SelectedValue.ToString(); } }
        public string OrderInformation2Value { get { return ddlOrderInformation2.SelectedValue.ToString(); } }

        public bool IsPanelModifyShippingAddressOpen
        {
            get { return pnlModifyShippingAddress.Visible; }
            set
            {
                ddlShipping.Visible = false;
                pnlModifyShippingAddress.Visible = value;
            }
        }

        public bool IsPanelModifyBillingAddressOpen
        {
            get { return pnlModifyBillingAddress.Visible; }
            set
            {
                ddlBilling.Visible = false;
                pnlModifyBillingAddress.Visible = value;
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
                }
            }
        }

        public bool IsOrderLocked
        {
            set
            {
                if (value)
                {
                    btnAskShipping.Visible = false;
                    btnCancelModifiedBillingAddress.Visible = false;
                    btnCancelModifiedShippingAddress.Visible = false;
                    btnFinalizeOrder.Visible = false;
                    btnPrintOrder.Visible = false;
                    btnFinalizeOrderPaypal.Visible = false;
                    btnRecalculateBasket.Visible = false;
                    btnModifyBillingAddress.Visible = false;
                    btnModifyShippingAddress.Visible = false;
                    btnAskShipping.Visible = false;
                    grvBasket.Enabled = false;
                    lblAskShipping.Visible = true;
                    pnlAskShipping.Visible = true;
                }
            }
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
        }

        public int BillingAddressSelected
        {
            get { return Convert.ToInt32(ddlBilling.SelectedValue); }
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

        public Address PersonnalShippingAddress
        {
            set
            {
                ListItem listItem = new ListItem();
                listItem.Value = value.Id.ToString();
                listItem.Text = value.DisplayAddress;
                listItem.Selected = true;
                ddlShipping.Items.Add(listItem);
            }
        }

        protected void FinalizeOrderClick(object sender, EventArgs e)
        {
            Presenter.FinalizeOrder(false);
        }

        protected void RecalculerClick(object sender, EventArgs e)
        {
            int i = 0;
            foreach (AlphaNumTextBoxAvance textBox in from GridViewRow row in grvBasket.Rows select (AlphaNumTextBoxAvance)row.FindControl("txtQuantity"))
            {
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

        protected void btnAskShippingClick(object sender, EventArgs e)
        {
            Presenter.AskForShipping();
        }
    }
}