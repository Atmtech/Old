using System;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;
using ATMTECH.FishingAtWork.WebSite.Base;
using ATMTECH.Web;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class ConfirmCreate : PageBaseFishingAtWork, IConfirmCreatePresenter
    {
        public ConfirmCreatePresenter Presenter { get; set; }

        public int IdConfirm
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesQueryString.CONFIRM_CREATE)); }
        }

        public bool IsConfirmed
        {
            set
            {
                if (value)
                {
                    pnlConfirmed.Visible = true;
                    pnlNotConfirmed.Visible = false;
                }
                else
                {
                    pnlConfirmed.Visible = false;
                    pnlNotConfirmed.Visible = true;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
        protected void ConfirmCreate_click(object sender, EventArgs e)
        {
            Presenter.ConfirmCreate();
        }
    }
}