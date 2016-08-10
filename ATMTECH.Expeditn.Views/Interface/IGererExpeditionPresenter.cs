using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererExpeditionPresenter : IViewBase
    {
        string IdExpedition { get; }
        string Nom { get; set; }
        DateTime Debut { get; set; }
        DateTime Fin { get; set; }
        decimal BudgetEstime { get; set; }
        string Longitude { get; set; }
        string Latitude { get; set; }
        string Region { get; set; }
        string Pays { get; set; }
        string Ville { get; set; }
        bool EstExpeditionPrive { get; set; }
        IList<Pays> ListePays { set; }
    }
}
