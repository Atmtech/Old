using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOEtape
    {
        IList<Etape> ObtenirEtape(Expedition expedition);
        Etape ObtenirEtape(int id);
        int Enregistrer(Etape etape);
    }
}
