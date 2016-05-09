using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views.Interface
{
    public interface IWallPostPresenter : IViewBase
    {
        string Post { get; set; }
        bool IsPanelWritePost { get; set; }
    }
}
