using System;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Mail : PageBaseFishingAtWork, IMailPresenter
    {
        public MailPresenter Presenter { get; set; }

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