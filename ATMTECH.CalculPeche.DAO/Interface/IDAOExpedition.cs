using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOExpedition
    {
       
        IList<Expedition> ObtenirExpedition();
       
    }
}
