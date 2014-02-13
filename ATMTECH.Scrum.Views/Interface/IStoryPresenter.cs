using System.Collections.Generic;
using ATMTECH.Scrum.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface IStoryPresenter : IViewBase
    {
        Story Story { set; }
        int IdStory { get; set; }
        IList<Product> Products { set; }
        Dictionary<string, string> Status { set; }
        IList<int> Points { set; }

        string Description { get; set; }
        string IdStatus { get; }
        int IdPoints { get; }
        int IdProduct { get; }
        int IdSprint { get; }
        string Batch { get; set; }
        int? Priority { get; set; }
    }
}
