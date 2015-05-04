using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Expeditn.Services
{
    public class ExpeditionService : BaseService, IExpeditionService
    {
        public IDAOExpedition DAOExpedition { get; set; }

        public Expedition ObtenirExpedition(int id)
        {
            return DAOExpedition.ObtenirExpedition(id);
        }
    }
}
