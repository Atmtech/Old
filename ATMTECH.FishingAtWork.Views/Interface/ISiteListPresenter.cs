using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface ISiteListPresenter : IViewBase
    {
        IList<Site> SitesList { set; }
        Site SiteInformation { set; }
    }
}
