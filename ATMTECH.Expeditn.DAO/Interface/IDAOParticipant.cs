using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOParticipant
    {
        IList<Participant> ObtenirParticipant(Expedition expedition);
        IList<Participant> ObtenirParticipant();
        int Enregistrer(Participant participant);
    }
}
