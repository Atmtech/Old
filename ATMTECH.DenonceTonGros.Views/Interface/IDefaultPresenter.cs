using System.Collections.Generic;
using ATMTECH.DenonceTonGros.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.DenonceTonGros.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        IList<Entities.DenonceTonGrosTas> Liste { set; }
        IList<Entities.DenonceTonGrosTas> ListeTop { set; }
        Entities.DenonceTonGrosTas MerdeDuJour { set; }
        int CompteTotal { set; }
        string TotalMarde { set; }
       
    }
}
