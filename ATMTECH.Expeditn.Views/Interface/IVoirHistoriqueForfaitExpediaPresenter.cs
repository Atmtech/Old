﻿using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IVoirHistoriqueForfaitExpediaPresenter : IViewBase
    {
        IList<string> ListeHotel { set; }
        int IdRechercheForfaitExpedia { get; }
        IList<HistoriqueForfaitExpedia> HistoriqueForfaitExpedia { set; }
        string FiltreHotel { get; }
    }
}
