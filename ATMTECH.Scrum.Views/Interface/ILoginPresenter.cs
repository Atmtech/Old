using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface ILoginPresenter : IViewBase
    {
        string UserName { get; set; }
        string Password { get; set; }
        bool IsLogged { set; } 
    }
}
