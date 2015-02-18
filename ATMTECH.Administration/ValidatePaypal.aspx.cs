using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration
{
    public partial class ValidatePaypal: PageBaseAdministration, IValidatePaypalPresenter
    {
        public ValidatePaypalPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public DateTime DateStart
        {
            get { return Convert.ToDateTime(txtDateStart.Text); }
        }
        public DateTime DateEnd
        {
            get { return Convert.ToDateTime(txtDateEnd.Text); }
        }

        public string EnterpriseSelected
        {
            get { return cboEnterprise.SelectedValue; }
        }

        public IList<Enterprise> Enterprises
        {
            set
            {
                cboEnterprise.DataSource = value;
                cboEnterprise.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboEnterprise.DataValueField = BaseEntity.ID;
                cboEnterprise.DataBind();
            }
        }

        protected void btnGenerateClick(object sender, EventArgs e)
        {
            Literal lit = new Literal {Text = Presenter.Generate()};
            placeHolder.Controls.Add(lit);
        }
    }
}