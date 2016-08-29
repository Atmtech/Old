using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.Services.Interface
{
    public interface IExpediaService
    {
        RechercheForfaitExpedia ObtenirRechercheForfaitExpedia(int id);
        void ObtenirPrixRechercheForfaitExpedia();
        IList<RechercheForfaitExpedia> ObtenirRechercheForfaitExpedia(User utilisateur);
        IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia(RechercheForfaitExpedia rechercheForfaitExpedia);
    }
}
