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

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            string id = NavigationService.GetQueryStringValue(Pages.PagesId.ID_DISCUSSION);
            if (id != null)
            {
                View.IdDiscussion = id;
                string test = View.Commentaire;
            }


            View.Discussions = DiscussionService.ObtenirDiscussion(AuthenticationService.AuthenticateUser.Id);
        }
    }
}
