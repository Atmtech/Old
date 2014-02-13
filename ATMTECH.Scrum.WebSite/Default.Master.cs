using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite
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

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public bool IsLogged
        {
            set
            {
                if (value)
                {
                   
                }
                else
                {
                    
                }
            }
        }

     
    }
}