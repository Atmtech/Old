using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using System.Web.UI.WebControls;

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class CustomerInformation : PageBaseShoppingCart<CustomerInformationPresenter, ICustomerInformationPresenter>, ICustomerInformationPresenter
    {

        public DateTime DateStartSalesByMonthReport
        {
            get { return txtDateStartReport.ValeurDateTime; }
        }
        public DateTime DateEndSalesByMonthReport
        {
            get { return txtDateEndReport.ValeurDateTime; }
        }

        public DateTime DateStartSalesByOrderInformationReport
        {
            get { return txtDateStartSalesByOrderInformationReport.ValeurDateTime; }
        }
        public DateTime DateEndSalesByOrderInformationReport
        {
            get { return txtDateEndSalesByOrderInformationReport.ValeurDateTime; }
        }

        public bool IsDontAddPersonnalAddressShipping { set { if (value) pnlChangeAddressShipping.Visible = false; } }
        public bool IsDontAddPersonnalAddressBilling { set { if (value) pnlChangeAddressBilling.Visible = false; } }

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

        public bool IsSuperUser { get { return pnlSuperUser.Visible; } set { pnlSuperUser.Visible = value; } }

        public bool IsChangeAddressShippingPossible
        {
            set
            {
                if (value)
                {
                    pnlChangeAddressShipping.Visible = false;
                    btnCopyAddressBillingToShipping.Visible = false;
                }

            }
        }
        public bool IsChangeAddressBillingPossible
        {
            set
            {
                if (value)
                {
                    pnlChangeAddressBilling.Visible = false;
                    btnCopyAddressBillingToShipping.Visible = false;
                }
            }
        }


        public string BillingWay { get { return txtModifyBillingWay.Text; } set { txtModifyBillingWay.Text = value; } }
        public string BillingCountry { get { return ddlModifyBillingCountry.SelectedValue; } set { ddlModifyBillingCountry.SelectedValue = value; } }
        public string BillingCity { get { return txtModifyBillingCity.Text; } set { txtModifyBillingCity.Text = value; } }
        public string BillingPostalCode { get { return txtModifyBillingPostalCode.Text; } set { txtModifyBillingPostalCode.Text = value; } }


        public string ShippingWay { get { return txtModifyBillingWay.Text; } set { txtModifyShippingWay.Text = value; } }
        public string ShippingCountry { get { return ddlModifyShippingCountry.SelectedValue; } set { ddlModifyShippingCountry.SelectedValue = value; } }
        public string ShippingCity { get { return txtModifyShippingCity.Text; } set { txtModifyShippingCity.Text = value; } }
        public string ShippingPostalCode { get { return txtModifyShippingPostalCode.Text; } set { txtModifyShippingPostalCode.Text = value; } }

        public string Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }
        public string LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public string PasswordConfirmation
        {
            get { return txtConfirmPassword.Text; }
            set { txtConfirmPassword.Text = value; }
        }

        public IList<Order> OrdersOrdered
        {
            set
            {
                grvOrdered.DataSource = value;
                grvOrdered.DataBind();
            }
        }

        public IList<Order> OrdersShipped
        {
            set
            {
                grvShipped.DataSource = value;
                grvShipped.DataBind();
            }
        }

        public string Login
        {
            get { return txtLogin.Text; }
            set { txtLogin.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        protected void SaveCustomer_click(object sender, EventArgs e)
        {
            Presenter.SaveCustomer();
            pnlChangePassword.Visible = false;
        }

        protected void ChangePassword_click(object sender, EventArgs e)
        {
            pnlChangePassword.Visible = true;
        }

        protected void OnRowCommandOrdered(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lookup")
            {
                Presenter.PrintOrder(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "Tracking")
            {
                Presenter.Tracking(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void SaveAddressBillingClick(object sender, EventArgs e)
        {
            Presenter.SaveAddress();
        }

        protected void SaveAddressShippingClick(object sender, EventArgs e)
        {
            Presenter.SaveAddress();
        }

        protected void CopyAddressBillingToShippingClick(object sender, EventArgs e)
        {
            txtModifyShippingWay.Text = txtModifyBillingWay.Text;
            txtModifyShippingPostalCode.Text = txtModifyBillingPostalCode.Text;
            txtModifyShippingCity.Text = txtModifyBillingCity.Text;
            ddlModifyShippingCountry.SelectedValue = ddlModifyBillingCountry.SelectedValue;
            Presenter.SaveAddress();
        }

        protected void btnSalesByMonthReportClick(object sender, EventArgs e)
        {
            pnlSalesByMonthReport.Visible = true;
            pnlSalesByOrderInformationReport.Visible = false;
        }

        protected void btnGenerateSalesByMonthReportClick(object sender, EventArgs e)
        {
            Presenter.GenerateSalesByMonthReport();
        }

        protected void btnSalesByOrderInformationReportClick(object sender, EventArgs e)
        {
            pnlSalesByOrderInformationReport.Visible = true;
            pnlSalesByMonthReport.Visible = false;
        }

        protected void brGeneratebtnSalesByOrderInformationReportClick(object sender, EventArgs e)
        {
            Presenter.GenerateSalesByOrderInformationReport();
        }
    }
}