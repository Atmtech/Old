using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.Template.Views;
using ATMTECH.Template.Views.Interface;

namespace ATMTECH.Template.WebSite
{
    public partial class Template : MasterPage, IDefaultMasterPresenter
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

        public bool ThrowExceptionIfNoPresenterBound { get; private set; }
        public void ShowMessage(Message message)
        {
           
        }
    }
}