using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.XWingCampaign.DAO.Interface;
using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.DAO
{
    public class DAOVaisseau : BaseDao<Vaisseau, int>, IDAOVaisseau
    {
        public Vaisseau ObtenirVaisseau(int id)
        {
            return GetById(id);
        }

        public IList<Vaisseau> ObtenirVaisseau()
        {
            return GetAllActive();
        }
    }
}
