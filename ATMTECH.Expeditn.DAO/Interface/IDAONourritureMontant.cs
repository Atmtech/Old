using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourritureMontant
    {
        IList<NourritureMontant> ObtenirNourritureMontant(Expedition expedition);
        int Enregistrer(NourritureMontant nourritureMontant);
    }
}
