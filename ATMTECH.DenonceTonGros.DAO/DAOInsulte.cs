using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.DenonceTonGros.Entities;

namespace ATMTECH.DenonceTonGros.DAO
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
