using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IForgetPasswordPresenter : IViewBase
    {
        string Email { get; set; }
    }
}
