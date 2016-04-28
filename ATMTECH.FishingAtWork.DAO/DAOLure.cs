using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOLure : BaseDao<Lure, int>, IDAOLure
    {
        public IList<Lure> GetLureList()
        {
            return GetAllActive();
        }

        public IList<Lure> GetLureList(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            return GetAllActive(pagingOperation, orderOperation);
        }
   
        public Lure GetLure(int id)
        {
            return GetById(id);
        }
    }
}
