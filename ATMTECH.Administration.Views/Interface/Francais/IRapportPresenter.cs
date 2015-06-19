using System;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface.Francais
{
    public interface IRapportPresenter : IViewBase
    {
        string NomRapport { get; }
        DateTime DateDepart { get; }
        DateTime DateFin { get;  }
        int NoCommande { get; }
    }
}
