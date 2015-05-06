using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IExpeditionPresenter : IViewBase
    {
        Expedition Expedition { set; }
        bool EstAdministrateur { set; }
        int IdExpedition { get; }
    }
}
