using ATMTECH.Entities;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Scrum.Views
{
    public class DefaultMasterPresenter : BaseScrumPresenter<IDefaultMasterPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            User user = AuthenticationService.AuthenticateUser;
            if (user != null)
            {
                View.IsLogged = true;
            }
        }
    }
}
