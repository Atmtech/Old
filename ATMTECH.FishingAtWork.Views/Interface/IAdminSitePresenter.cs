using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IAdminSitePresenter : IViewBase
    {
        GoogleMapValue GoogleMapValue { get; set; }
    }
}
