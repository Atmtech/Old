using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IAccueilPresenter : IViewBase
    {
        IList<Expedition> Expeditions { set; }
    }
}
