using System.Collections.Generic;
using ATMTECH.Scrum.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        IList<Product> Products { set; }
        IList<Story> Storys { set; }
        IList<Sprint> Sprints { set; }
    }
}
