using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface ICreatePlayerPresenter : IViewBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string PasswordConfirmation { get; set; }

        string Email { get; set; }
      
        bool CreateSuccess {  set; }
        string CaptchaTextBox { get; set; }
        string CaptchaSession { get;  }
    }
}
