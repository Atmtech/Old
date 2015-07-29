using System;
using System.Reflection;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
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


        public User Utilisateur { get; set; }

    }
}