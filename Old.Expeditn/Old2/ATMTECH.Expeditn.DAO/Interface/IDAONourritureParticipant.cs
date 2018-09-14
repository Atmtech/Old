using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourritureParticipant
    {
        IList<NourritureParticipant> ObtenirNourritureParticipant(Nourriture nourriture);
        int Enregistrer(NourritureParticipant nourritureParticipant);
        
    }
}
