using System;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration.Commerce
{
    public partial class ExecuteSql : PageBase<ExecuteSqlPresenter, IExecuteSqlPresenter>, IExecuteSqlPresenter
    {
        public string ReturnExecuteSql { set { lblResult.Text = value; } }

        protected void btnExecuteSqlClick(object sender, EventArgs e)
        {
            Presenter.ExecuteSql(txtSql.Text);
        }
    }
}