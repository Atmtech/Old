using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using System.Web.UI.WebControls;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class CustomerInformation : PageBaseShoppingCart<CustomerInformationPresenter, ICustomerInformationPresenter>, ICustomerInformationPresenter
    {
       
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

        public string OrderReportPath
        {
            get { return Server.MapPath("~/Reports/Order.rdlc"); }
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
            lblCustomerInformationSaved.Visible = true;
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
        }
    }
}