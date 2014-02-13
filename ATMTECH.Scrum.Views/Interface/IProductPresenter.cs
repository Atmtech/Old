using System.Collections.Generic;
using ATMTECH.Scrum.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Interface
{
    public interface IProductPresenter : IViewBase
    {
        Product ProductView { set; }
    }
}
