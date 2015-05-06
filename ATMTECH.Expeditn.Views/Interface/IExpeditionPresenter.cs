using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IExpeditionPresenter : IViewBase
    {
        Expedition Expedition { set; }
        int IdExpedition { get; }
    }
}
