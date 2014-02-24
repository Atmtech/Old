using ATMTECH.Achievement.Services.Interface;
using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class DiscussionPresenter : BaseAccomplissementPresenter<IDiscussionPresenter>
    {
        public IDiscussionService DiscussionService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public DiscussionPresenter(IDiscussionPresenter view)
            : base(view)
        {
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Discussions = DiscussionService.ObtenirListeDiscussion(AuthenticationService.AuthenticateUser.Id);
        }

        public void PublierCommentaire(int id, string commentaire)
        {
            DiscussionService.AjouterCommentaire(id, commentaire);
            NavigationService.Refresh();
        }

        public void JaimeMessage(int id)
        {

        }

        public void JaimeCommentaire(int id)
        {

        }

        public void PublierMessageSurLeMur(string message)
        {
            DiscussionService.Creer(message);
            NavigationService.Refresh();
        }
    }
}
