using ATMTECH.Entities;

namespace ATMTECH.Views.Interface
{
    public interface ILoginPresenter : IViewBase
    {
        string FullName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsLogged { set; }
        bool IsAdministrator { set; }
    }
}
