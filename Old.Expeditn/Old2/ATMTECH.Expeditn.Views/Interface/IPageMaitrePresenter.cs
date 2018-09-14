using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IPageMaitrePresenter : IViewBase
    {
        User Utilisateur { set; }
        string Courriel { get; }
        string Message { get; }
    }
}
