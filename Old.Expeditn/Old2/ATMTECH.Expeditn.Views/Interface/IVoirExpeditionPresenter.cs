using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IVoirExpeditionPresenter : IViewBase
    {
        Expedition Expedition { set; }
        int IdExpedition { get; }
    }
}
