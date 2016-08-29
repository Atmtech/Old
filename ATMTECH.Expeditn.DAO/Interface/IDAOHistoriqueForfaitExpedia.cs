using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOHistoriqueForfaitExpedia
    {
        int Enregistrer(HistoriqueForfaitExpedia historiqueForfaitExpedia);
        IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia();
        IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia(RechercheForfaitExpedia rechercheForfaitExpedia);
    }
}
