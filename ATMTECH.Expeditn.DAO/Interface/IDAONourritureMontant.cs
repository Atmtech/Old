using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourritureMontant
    {
        IList<NourritureMontant> ObtenirNourritureMontant(Expedition expedition);
        int Enregistrer(NourritureMontant nourritureMontant);
        void InitialiserNourritureMontant(Expedition expedition);
        void InitialiserNourritureMontantParticipant(Expedition expedition, int idParticipant, decimal montant);
    }
}
