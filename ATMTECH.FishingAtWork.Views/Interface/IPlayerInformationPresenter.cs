using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IPlayerInformationPresenter : IViewBase
    {
        string Name { get; set; }
        string Login { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string PasswordConfirmation { get; set; }
        string Image { get; set; }
    }
}
