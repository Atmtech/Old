using System;
using System.Reflection;
using ATMTECH.XWingCampaign.Views;
using ATMTECH.XWingCampaign.Views.Interface;

namespace ATMTECH.XWingCampaign.WebSite
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly()
                .GetName()
                .Version
                .ToString();
        }


    }
}