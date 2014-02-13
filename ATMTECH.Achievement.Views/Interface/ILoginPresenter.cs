using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Interface
{
    public interface ILoginPresenter : IViewBase
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
