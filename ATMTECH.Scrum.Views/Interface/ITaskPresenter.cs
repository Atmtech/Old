using System.Collections.Generic;
using ATMTECH.Scrum.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface ITaskPresenter : IViewBase
    {
        Task Task { set; }
        int IdTask { get; set; }
        int IdStory { get; set; }
        string Description { get; set; }
        string EstimatedTime { get; set; }
        string StoryDescription { get; set; }
    }
}
