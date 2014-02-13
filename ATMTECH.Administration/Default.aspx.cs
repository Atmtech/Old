using System;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;

namespace ATMTECH.Administration
{
    public partial class Default1 : PageBaseAdministration, IDefaultPresenter
    {
        public DefaultPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
    }
}