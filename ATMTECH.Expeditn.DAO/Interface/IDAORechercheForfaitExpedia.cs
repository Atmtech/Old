using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAORechercheForfaitExpedia
    {
        IList<RechercheForfaitExpedia> ObtenirRechercheForfaitExpedia();
        RechercheForfaitExpedia ObtenirRechercheForfaitExpedia(int id);
    }
}
