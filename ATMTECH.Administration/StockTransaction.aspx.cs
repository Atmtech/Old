using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration
{
    public partial class StockTransaction : PageBaseAdministration, IStockTransactionPresenter
    {
        public StockTransactionPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void btnGenerateClick(object sender, EventArgs e)
        {
            Literal lit = new Literal { Text = Presenter.GetStockInformation(Convert.ToInt32(ddlStock.SelectedValue)) };
            placeHtml.Controls.Add(lit);
        }

        public IList<Stock> Stocks
        {
            set
            {
                ddlStock.DataTextField = Stock.COMBOBOX_DESCRIPTION;
                ddlStock.DataValueField = BaseEntity.ID;
                ddlStock.DataSource = value;
                ddlStock.DataBind();
            }
        }
    }
}