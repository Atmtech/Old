using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsLogged { get; set; }
    }
}
