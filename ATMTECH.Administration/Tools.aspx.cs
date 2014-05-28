using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.Administration
{
    public partial class Tools : PageBaseAdministration, IToolsPresenter
    {
        public ToolsPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public IList<Product> ProductWithoutStock
        {
            set
            {
                cboProductWithoutStock.DataSource = value;
                cboProductWithoutStock.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboProductWithoutStock.DataValueField = BaseEntity.ID;
                cboProductWithoutStock.DataBind();
            }
        }
        public IList<StockTemplate> StockTemplate
        {
            set
            {
                IList<StockTemplate> stockTemplates = new List<StockTemplate>();

                foreach (StockTemplate stockTemplate in value)
                {
                    if (stockTemplates.Count(x => x.Group == stockTemplate.Group) == 0)
                    {
                        stockTemplates.Add(stockTemplate);
                    }
                }



                cboStockTemplate.DataSource = stockTemplates;
                cboStockTemplate.DataTextField = ShoppingCart.Entities.StockTemplate.GROUP;
                cboStockTemplate.DataValueField = BaseEntity.ID;
                cboStockTemplate.DataBind();

            }
        }
        public IList<Enterprise> Enterprise
        {
            set
            {
                cboEnterprise1.DataSource = value;
                cboEnterprise1.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboEnterprise1.DataValueField = BaseEntity.ID;
                cboEnterprise1.DataBind();

                cboEnterprise2.DataSource = value;
                cboEnterprise2.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboEnterprise2.DataValueField = BaseEntity.ID;
                cboEnterprise2.DataBind();

                cboEnterprise3.DataSource = value;
                cboEnterprise3.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboEnterprise3.DataValueField = BaseEntity.ID;
                cboEnterprise3.DataBind();
            }
        }
        public int EnterpriseSelect
        {
            get
            {
                return !string.IsNullOrEmpty(cboEnterprise3.SelectedValue) ? Convert.ToInt32(cboEnterprise3.SelectedValue) : 1;
            }
        }
        public IList<User> Users
        {
            set
            {
                cboUser.DataSource = value;
                cboUser.DataTextField = BaseEntity.COMBOBOX_DESCRIPTION;
                cboUser.DataValueField = BaseEntity.ID;
                cboUser.DataBind();
            }
        }

        protected void btnCreateEnterpriseFromClick(object sender, EventArgs e)
        {
            Presenter.CreateEnterpriseFromAnother(Convert.ToInt32(cboEnterprise3.SelectedValue), txtNewName.Text);
        }
        protected void ApplyStockTemplateClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantityStockTemplate.Text))
            {
                txtQuantityStockTemplate.Text = "0";
            }
            Presenter.ApplyStockTemplate(cboProductWithoutStock.SelectedValue, cboStockTemplate.SelectedItem.Text, Convert.ToInt32(txtQuantityStockTemplate.Text), Convert.ToBoolean(chkIsWithoutStock.Checked));
        }
        protected void DisplayOrderClick(object sender, EventArgs e)
        {
            Presenter.DisplayOrder(Convert.ToInt32(txtOrder2.Text));
        }
        protected void ConfirmOrderClick(object sender, EventArgs e)
        {
            Presenter.ConfirmOrder(txtOrder1.Text);
        }
        protected void AssociateUserOpenWindowClick(object sender, EventArgs e)
        {
            Presenter.AssociateUser(Convert.ToInt32(cboUser.SelectedValue),
                                    Convert.ToInt32(cboEnterprise1.SelectedValue));
        }
    }
}