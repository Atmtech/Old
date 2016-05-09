using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        GoogleMapValue GoogleMapValue { get; set; }
        Trip CurrentTrip { get; set; }

        bool IsPanelCurrentTrip { get; set; }
        bool IsPanelNoTrip { get; set; }

        int TotalPlayerOnTrip { get; set; }
        bool IsLogged { get; set; }
    }
}
