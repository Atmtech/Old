using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOExpedition
    {
        Expedition ObtenirExpedition(int id);
        IList<Expedition> ObtenirExpedition();
        IList<Expedition> ObtenirExpeditionTop(int nombreExpeditionPrise);
    }
}
