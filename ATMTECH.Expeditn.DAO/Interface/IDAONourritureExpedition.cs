using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAONourritureExpedition
    {
        IList<NourritureExpedition> ObtenirNourritureExpedition(Expedition expedition);
    }
}
