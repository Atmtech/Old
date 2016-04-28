using ATMTECH.Common;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IAdminLurePresenter : IViewBase
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        bool IsInEditMode { set; }
    }
}
