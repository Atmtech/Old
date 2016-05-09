using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.ErrorCode;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class CreatePlayerPresenter : BaseFishingAtWorkPresenter<ICreatePlayerPresenter>
    {
        public IPlayerService PlayerService { get; set; }
        
        public CreatePlayerPresenter(ICreatePlayerPresenter view)
            : base(view)
        {
        }

        public void CreatePlayer()
        {
            if (View.CaptchaTextBox != View.CaptchaSession)
            {
                MessageService.ThrowMessage(ErrorCode.SC_CAPTCHA_INVALID);
            }

            if (View.Password != View.PasswordConfirmation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
            }
            User user = new User { FirstName = View.FirstName, LastName = View.LastName, Password = View.Password, Login = View.UserName, Email = View.Email };
            Player player = new Player {User = user};

            View.CreateSuccess = PlayerService.CreatePlayer(player);
        }
    }
}
