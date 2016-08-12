using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IProfilePresenter : IViewBase
    {
        
        string Nom { get; set; }
        string Prenom { get; set; }
        string Courriel { get; set; }
        string MotPasse { get; set; }
        string RootPath { get;  }
        string Image { set; }
    }
}
