using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsLogged { set; }
    }
}
