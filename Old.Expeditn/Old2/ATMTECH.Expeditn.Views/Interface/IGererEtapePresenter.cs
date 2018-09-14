using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererEtapePresenter : IViewBase
    {
        Expedition Expedition { set; }
        string IdExpedition { get;}
        IList<Etape> ListeEtape {set; }

        IList<Vehicule> ListeVehicule { set; }
        string IdVehicule { get; }
        string Nom { get; set; }
        DateTime Debut { get; set; }
        DateTime Fin { get; set; }
        string Distance { get; set; }
    }
}
