using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.ErrorCode;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class PlayerInformationPresenter : BaseFishingAtWorkPresenter<IPlayerInformationPresenter>
    {
        public IPlayerService PlayerService { get; set; }

        public PlayerInformationPresenter(IPlayerInformationPresenter view)
            : base(view)
        {

        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            if (PlayerService.AuthenticatePlayer != null)
            {
                Player player = PlayerService.AuthenticatePlayer;

                View.Name = player.User.FirstNameLastName;
                View.FirstName = player.User.FirstName;
                View.LastName = player.User.LastName;
                View.Login = player.User.Login;
                View.Password = player.User.Password;
                View.PasswordConfirmation = player.User.Password;
                View.Email = player.User.Email;
                View.Image = "Images/Player/" + player.Image;
            }
        }

        public void SavePlayer()
        {
            Player player = PlayerService.AuthenticatePlayer;

            player.User.FirstName = View.FirstName;
            player.User.LastName = View.LastName;
            player.Image = View.Image;
            if (!string.IsNullOrEmpty(View.Password))
            {
                if (View.Password != View.PasswordConfirmation)
                {
                    MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
                }

                player.User.Password = View.Password;
            }

            player.User.Email = View.Email;
            PlayerService.SavePlayer(player);

            View.Name = player.User.FirstNameLastName;
        }

    }
}
