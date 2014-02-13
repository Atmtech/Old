using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration
{
    public partial class SalesByMonth : PageBaseAdministration, ISalesByMonthReportPresenter
    {
        public SalesByMonthReportPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void GenerateClick(object sender, EventArgs e)
        {
            Presenter.GenerateReport();
        }

        public DateTime DateStart
        {
            get { return txtDateStart.ValeurDateTime; }
        }
        public DateTime DateEnd
        {
            get { return txtDateEnd.ValeurDateTime; }
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
    }
}