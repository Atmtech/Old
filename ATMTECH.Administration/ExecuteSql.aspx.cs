using System;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration
{
    public partial class ExecuteSql : PageBaseAdministration, IExecuteSqlPresenter
    {

        public ExecuteSqlPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void btnExecuteSqlClick(object sender, EventArgs e)
        {
            Presenter.ExecuteSql(txtSql.Text);
        }

        public string ReturnExecuteSql { set { lblResult.Text = value; } }
    }
}