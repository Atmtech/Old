using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOExpedition : BaseDao<Expedition, int>, IDAOExpedition
    {
      
        public IList<Expedition> ObtenirExpedition()
        {
            return GetAllActive().ToList();
        }
    }
}
