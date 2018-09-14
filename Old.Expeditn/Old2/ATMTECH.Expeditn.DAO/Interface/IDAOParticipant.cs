using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOParticipant
    {
        IList<Participant> ObtenirParticipant(Expedition expedition);
        IList<Participant> ObtenirParticipant();
        IList<Participant> ObtenirParticipant(User utilisateur);
        int Enregistrer(Participant participant);
    }
}
