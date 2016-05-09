using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface INewTripPresenter : IViewBase
    {
        IList<Site> SiteList { set; }
        IList<Lure> LureList { set; }
        IList<int> DeepList { set; }
        IList<EnumWaypointTechniqueType> EnumWaypointTechniqueTypesList { set; }
        IList<string> HourList { set; }

        int TripId { get; set; }
        int SelectedSiteId { get; }
        int SelectedLureId { get; }
        int SelectedDeep { get; }
        int SelectedTechnique { get; }

        string HourStart { get; }
        string HourEnd { get; }

        GoogleMapValue GoogleMapValue { get; set; }
        GoogleMapValue GoogleMapValueResume { get; set; }

        int CurrentWayPoint { get; set; }
        int MaximumWayPoint { get;  set; }
        bool IsVisibleStep1 { get; set; }
        bool IsVisibleStep2 { get; set; }
        bool IsVisibleStep3 { get; set; }
        bool IsVisibleStep4 { get; set; }
        bool IsAddWayPointVisible { get; set; }

        string Name { get; set; }
        DateTime DateStart { get; set; }

    }
}
