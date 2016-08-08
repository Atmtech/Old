using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAONourritureExpedition : BaseDao<NourritureExpedition, int>, IDAONourritureExpedition
    {
        public IList<NourritureExpedition> ObtenirNourritureExpedition(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria { Column = "Expedition", Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteria);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }
    }
}
