using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IOpenTripPresenter : IViewBase
    {
        bool IsPanelOpenSiteGridViewOpen { get; set; }
        bool IsPanelOpenSiteTripDetail { get; set; }
        bool IsPanelEditWayPoint { get; set; }
        bool IsPanelSelectWaypoint { get; set; }
        bool IsAddWaypointVisible { get; set; }
        GoogleMapValue googleMapValueThumbnail { get; set; }

        IList<Site> SiteList { set; }
        int SiteSelectedValue { get; set; }
        string Name { get; set; }
        DateTime DateStart { get; set; }
        DateTime DateEnd { get; set; }
        string Waypoints { get; set; }

        int SelectedLureId { get; set; }
        int SelectedDeep { get; set; }
        int SelectedTechnique { get; set; }

        string HourStart { get; set; }
        string HourEnd { get; set; }

        IList<Lure> LureList { set; }
        IList<int> DeepList { set; }
        IList<EnumWaypointTechniqueType> EnumWaypointTechniqueTypesList { set; }
        IList<string> HourList { set; }
        string Latitude { get; set; }
        string Longitude { get; set; }

        GoogleMapValue GoogleMapValue { get; set; }

    }
}
