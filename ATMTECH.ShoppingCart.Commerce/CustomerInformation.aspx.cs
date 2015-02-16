using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class CustomerInformation : PageBaseShoppingCart<CustomerInformationPresenter, ICustomerInformationPresenter>, ICustomerInformationPresenter
    {

        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get { return txtCourrielCreer.Text; } set { txtCourrielCreer.Text = value; } }
        public string FirstName { get { return txtPrenom.Text; } set { txtPrenom.Text = value; } }
        public string LastName { get { return txtNom.Text; } set { txtNom.Text = value; } }
        public string Password { get { return txtMotDePasseCreer.Text; } set { txtMotDePasseCreer.Text = value; } }
        public string PasswordConfirmation { get { return txtMotDePasseCreerConfirmation.Text; } set { txtMotDePasseCreerConfirmation.Text = value; } }
        public IList<Order> OrdersOrdered { set; private get; }
        public IList<Order> OrdersShipped { set; private get; }
        public IList<Country> Countrys
        {
            set
            {
                ddlPaysFacturationClient.DataSource = value;
                ddlPaysFacturationClient.DataTextField = BaseEntity.DESCRIPTION;
                ddlPaysFacturationClient.DataValueField = BaseEntity.ID;
                ddlPaysFacturationClient.DataBind();

                ddlPaysLivraisonClient.DataSource = value;
                ddlPaysLivraisonClient.DataTextField = BaseEntity.DESCRIPTION;
                ddlPaysLivraisonClient.DataValueField = BaseEntity.ID;
                ddlPaysLivraisonClient.DataBind();
            }
        }
        public bool IsSuperUser { get; set; }
        public bool IsChangeAddressShippingPossible { set; private get; }
        public bool IsChangeAddressBillingPossible { set; private get; }
        public bool IsDontAddPersonnalAddressShipping { set; private get; }
        public bool IsDontAddPersonnalAddressBilling { set; private get; }
        public string BillingWay { get { return txtRueFacturationClient.Text; } set { txtRueFacturationClient.Text = value; } }
        public string BillingCountry { get { return ddlPaysFacturationClient.SelectedValue; } set { ddlPaysFacturationClient.SelectedValue = value; } }
        public string BillingCity { get { return txtVilleFacturationClient.Text; } set { txtVilleFacturationClient.Text = value; } }
        public string BillingPostalCode { get { return txtCodePostalFacturationClient.Text; } set { txtCodePostalFacturationClient.Text = value; } }

        public string ShippingWay { get { return txtRueLivraisonClient.Text; } set { txtRueLivraisonClient.Text = value; } }
        public string ShippingCountry { get { return ddlPaysLivraisonClient.SelectedValue; } set { ddlPaysLivraisonClient.SelectedValue = value; } }
        public string ShippingCity { get { return txtVilleLivraisonClient.Text; } set { txtVilleLivraisonClient.Text = value; } }
        public string ShippingPostalCode { get { return txtCodePostalLivraisonInformationClient.Text; } set { txtCodePostalLivraisonInformationClient.Text = value; } }

        public DateTime DateStartSalesByMonthReport { get; private set; }
        public DateTime DateEndSalesByMonthReport { get; private set; }
        public DateTime DateStartSalesByOrderInformationReport { get; private set; }
        public DateTime DateEndSalesByOrderInformationReport { get; private set; }
    }
}