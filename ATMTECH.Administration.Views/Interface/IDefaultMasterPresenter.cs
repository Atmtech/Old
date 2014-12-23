using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsLogged { get; set; }
        bool IsAdministrator { set; }
        string FullName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
