using System.Collections.Generic;
using ATMTECH.XWingCampaign.Entities;

namespace ATMTECH.XWingCampaign.DAO.Interface
{
    public interface IDAOVaisseau
    {
        Vaisseau ObtenirVaisseau(int id);
        IList<Vaisseau> ObtenirVaisseau();
    }
}
