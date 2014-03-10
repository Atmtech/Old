using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
   public interface IDAOOrder
   {
       Order GetOrder(int idOrder);
       int CreateOrder(Order order);
       int UpdateOrder(Order order);
       IList<Order> GetOrderFromCustomer(Customer customer);
       IList<Order> GetAllFinalized(Enterprise enterprise, DateTime dateStart, DateTime dateEnd);
       IList<OrderLine> GetAllOrderLine(Enterprise enterprise);
       IList<Order> GetOrder(int idEnterprise, int pageIndex);
       IList<Order> GetAll();
       int Save(Order id);
   }
}
