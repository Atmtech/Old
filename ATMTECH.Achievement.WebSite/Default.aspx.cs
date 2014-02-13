using System;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.WebSite.Base;

namespace ATMTECH.Achievement.WebSite
{
    public partial class Default : PageBaseAchievement<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        protected void btnSignInClick(object sender, EventArgs e)
        {
            Presenter.LoginPage();
        }
    }
}