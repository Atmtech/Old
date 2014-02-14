using System;
using System.Web.UI;
using ATMTECH.BillardLoretteville.Views;
using ATMTECH.BillardLoretteville.Views.Interface;

namespace ATMTECH.BillardLoretteville.Website
{
    public partial class Default : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }

        protected void IntranetClick(object sender, EventArgs e)
        {
            pnlIntranet.Visible = true;
        }
    }
}