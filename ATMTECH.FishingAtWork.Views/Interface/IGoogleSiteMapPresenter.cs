using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IGoogleSiteMapPresenter
    {
        void SetLatituteLongitude(double latitude, double longitude);
        void SetWayPoint(IList<Waypoint> waypoint);
    }
}
