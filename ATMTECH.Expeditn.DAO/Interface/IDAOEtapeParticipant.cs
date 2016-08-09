using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOEtapeParticipant
    {
        IList<EtapeParticipant> ObtenirEtapeParticipant(Etape etape);
        int Enregistrer(EtapeParticipant etapeParticipant);
        EtapeParticipant ObtenirEtapeParticipant(int id);
    }
}
