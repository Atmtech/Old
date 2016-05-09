using ATMTECH.FishingAtWork.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsLogged { set; }
        Player PlayerLogged { set; }
        bool IsOnline { set; }
    }
}
