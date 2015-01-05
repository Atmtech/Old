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
            Trace.Write("Avant PostBack");
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
                Trace.Write("Apres PostBack");
            }
            Trace.Write("Avant Loaded");
            Presenter.OnViewLoaded();
            Trace.Write("Apres Loaded");
        }
    }
}