using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface ITableauBordPresenter : IViewBase
    {
        IList<Expedition> MesExpeditions { set; }
        IList<RechercheForfaitExpedia> MesRechercheForfaitExpedias { set; }
            User Utilisateur { get; set; }
    }
}
