using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOBasket : BaseDao<Basket, int>, IDAOBasket
    {
        public int CreateBasket(Basket basket)
        {
            return Save(basket);
        }
    }
}
