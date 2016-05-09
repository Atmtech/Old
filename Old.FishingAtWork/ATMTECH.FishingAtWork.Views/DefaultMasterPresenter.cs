using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class DefaultMasterPresenter : BaseFishingAtWorkPresenter<IDefaultMasterPresenter>
    {

        public IAuthenticationService AuthenticationService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IParameterService ParameterService { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }


        public override void OnViewLoaded()
        {
            Player player = PlayerService.AuthenticatePlayer;
            if (player != null)
            {
                View.PlayerLogged = player;
                View.IsLogged = true;
            }
            else
            {
                View.IsLogged = false;
            }

            View.IsOnline = ParameterService.GetValue(Constant.STATISTIC_SERVER_ONLINE) == "1";
        }

        public void SignOut()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }


    }
}
