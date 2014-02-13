using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Vachier.Entities;

namespace ATMTECH.Vachier.DAO
{
    public class DAOInsulte : BaseDao<Insulte, int>, IDAOInsulte
    {
        public Insulte ObtenirInsulte(int id)
        {
            return GetById(id);
        }
        public IList<Insulte> ObtenirListeInsulte()
        {
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Ascending };
            return GetAllActive(orderOperation);
        }
    }


}
