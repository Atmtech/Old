using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererRechercheForfaitExpediPresenter : IViewBase
    {
        string Nom { get; set; }
        string Url { get; set; }
    }
}
