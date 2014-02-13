using System.Collections.Generic;
using ATMTECH.Scrum.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface ISprintPresenter : IViewBase
    {
        int IdSprint { get; set; }
        Sprint Sprint { set; }
        IList<Product> Products { set; } 
        int IdProduct { get; }
        string Description { get; set; }
        string DateEnd { get; set; }
        string DateStart { get; set; }
    }
}
