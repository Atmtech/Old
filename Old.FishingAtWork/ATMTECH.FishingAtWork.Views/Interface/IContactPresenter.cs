using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IContactPresenter : IViewBase
    {
        string Name { get; set; }
        string Email { get; set; }
        string Body { get; }
    }
}
