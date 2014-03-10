using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
   public interface IDAOOrderLine
   {
       IList<OrderLine> GetOrderLine(int id);
       int Update(OrderLine orderLine);
       IList<OrderLine> GetAll();
   }
}
