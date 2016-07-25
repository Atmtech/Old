using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipant
    {

        IList<Participant> ObtenirParticipant();
        int Enregistrer(Participant participant);
    }
}
