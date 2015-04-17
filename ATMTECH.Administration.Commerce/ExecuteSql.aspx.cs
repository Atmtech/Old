using System;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration.Commerce
{
    public partial class ExecuteSql : PageBase<ExecuteSqlPresenter, IExecuteSqlPresenter>, IExecuteSqlPresenter
    {

        protected void btnExecuteSqlClick(object sender, EventArgs e)
        {
            Presenter.ExecuteSql(txtSql.Text);
        }

        public string ReturnExecuteSql { set { lblResult.Text = value; } }
    }
}