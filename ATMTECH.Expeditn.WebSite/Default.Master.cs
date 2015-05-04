using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()
                                              .GetName()
                                              .Version
                                              .ToString();
        }

        protected void btnIdentificationClick(object sender, EventArgs e)
        {
            Presenter.RedirigerIdentification();
        }
    }
}