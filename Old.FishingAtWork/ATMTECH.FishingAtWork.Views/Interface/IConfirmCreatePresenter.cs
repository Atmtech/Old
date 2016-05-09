using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IConfirmCreatePresenter : IViewBase
    {
        int IdConfirm { get; }
        bool IsConfirmed { set; }
    }
}
