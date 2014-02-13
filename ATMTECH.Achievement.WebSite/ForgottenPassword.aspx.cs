using System;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.WebSite.Base;

namespace ATMTECH.Achievement.WebSite
{
    public partial class ForgotPassword : PageBaseAchievement<MotPasseOubliePresenter, IMotPasseOubliePresenter>, IMotPasseOubliePresenter
    {
        protected void btnEnvoyerMotDePasseClick(object sender, EventArgs e)
        {
            Presenter.EnvoyerMonMotDePasse();
        }
    }
}