using System;
using ATMTECH.Achievement.Views;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Achievement.Views.Pages;
using ATMTECH.Achievement.WebSite.Base;

namespace ATMTECH.Achievement.WebSite
{
    public partial class Login : PageBaseAchievement<LoginPresenter, ILoginPresenter>, ILoginPresenter
    {
        public string UserName { get { return txtUtilisateur.Text; } set { txtUtilisateur.Text = value; } }
        public string Password { get { return txtMotDePasse.Text; } set { txtMotDePasse.Text = value; } }

        protected void ForgetPasswordClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.FORGET_PASSWORD);
        }

        protected void btnSignInClick(object sender, EventArgs e)
        {
            Presenter.SignIn(Pages.DISCUSSION);
        }
    }
}