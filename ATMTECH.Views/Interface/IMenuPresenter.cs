using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Views.Interface
{
    public interface IMenuPresenter : IViewBase
    {
        bool IsAdministratorOnly { get; set; }
        bool IsVisible { set; }
        string MenuId { get; set; }
        IList<Menu> Menus {set; }
    }
}
