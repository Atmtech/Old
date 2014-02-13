using System.Collections.Generic;
using ATMTECH.Vachier.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Vachier.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        IList<Entities.Vachier> Liste { set; }
        IList<Entities.Vachier> ListeTop { set; }
        Entities.Vachier MerdeDuJour { set; }
        int CompteTotal { set; }
       
    }
}
