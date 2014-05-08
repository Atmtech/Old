using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOOrder : BaseDao<Order, int>, IDAOOrder
    {
        public IDAOEnterprise DAOEntreprise { get; set; }
        public IDAOCustomer DAOCustomer { get; set; }
        public IDAOAddress DAOAddress { get; set; }
        public IDAOStock DAOStock { get; set; }
        public IDAOProduct DAOProduct { get; set; }
        public IDAOOrderLine DAOOrderLine { get; set; }


        public IList<Order> GetOrderFromCustomer(Customer customer)
        {
            Criteria criteriaCustomer = new Criteria { Column = Order.CUSTOMER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = customer.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaCustomer);
            criterias.Add(IsActive());
            IList<Order> orders = GetByCriteria(criterias);


            foreach (Order order in orders)
            {

                order.OrderLines = DAOOrderLine.GetOrderLine(order.Id);
                order.Enterprise = DAOEntreprise.GetEnterprise(order.Enterprise.Id);
                order.Customer = DAOCustomer.GetCustomer(order.Customer.Id);
                foreach (OrderLine orderLine in order.OrderLines)
                {
                    orderLine.Stock = DAOStock.GetStock(orderLine.Stock.Id);
                    orderLine.Stock.Product = DAOProduct.GetProduct(orderLine.Stock.Product.Id);
                }
            }
            return orders;
        }
        public Order GetOrder(int idOrder)
        {
            Order order = GetById(idOrder);
            order.Enterprise = DAOEntreprise.GetEnterprise(order.Enterprise.Id);
            order.Customer = DAOCustomer.GetCustomer(order.Customer.Id);

            IList<OrderLine> orderLines = DAOOrderLine.GetOrderLine(order.Id);
            foreach (OrderLine orderLine in orderLines)
            {
                orderLine.Stock = DAOStock.GetStock(orderLine.Stock.Id);
                orderLine.Stock.Product = DAOProduct.GetProduct(orderLine.Stock.Product.Id);
            }
            order.OrderLines = orderLines;

            return order;
        }
        public int UpdateOrder(Order order)
        {
            foreach (OrderLine orderLine in order.OrderLines)
            {
                orderLine.Order = order;
                DAOOrderLine.Update(orderLine);
            }

            return Save(order);
        }
        public int CreateOrder(Order order)
        {

            int idOrder = Save(order);
            order.Id = idOrder;
            foreach (OrderLine orderLine in order.OrderLines)
            {
                Order orderForLine = new Order() { Id = idOrder };
                orderLine.Order = orderForLine;
                DAOOrderLine.Update(orderLine);
            }

            return idOrder;


        }

        public IList<OrderLine> GetAllOrderLine(Enterprise enterprise)
        {
            Criteria criteriaEnterprise = new Criteria { Column = Order.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());
            IList<Order> orders = GetByCriteria(criterias);
            foreach (Order order in orders)
            {
                order.OrderLines = DAOOrderLine.GetOrderLine(order.Id);
                foreach (OrderLine orderLine in order.OrderLines)
                {
                    orderLine.Stock = DAOStock.GetStock(orderLine.Stock.Id);
                }
            }
            return orders.SelectMany(order => order.OrderLines).ToList();
        }

        public IList<Order> GetAllFinalized(Enterprise enterprise, DateTime dateStart, DateTime dateEnd)
        {
            Criteria criteriaEnterprise = new Criteria { Column = Order.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
            Criteria criteriaDateFinalizedNotNull = new Criteria { Column = Order.FINALIZED_DATE, Operator = DatabaseOperator.OPERATOR_IS_NOT_NULL};
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaDateFinalizedNotNull);
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());
            IList<Order> orders = GetByCriteria(criterias);

            orders = orders.Where(x => x.FinalizedDate >= dateStart && x.FinalizedDate <= dateEnd).ToList();
            foreach (Order order in orders)
            {
                order.Customer = DAOCustomer.GetCustomer(order.Customer.Id);
                IList<OrderLine> orderLines = DAOOrderLine.GetOrderLine(order.Id);
                foreach (OrderLine orderLine in orderLines)
                {
                    orderLine.Order = order;
                    orderLine.Stock = DAOStock.GetStock(orderLine.Stock.Id);
                    orderLine.Stock.Product = DAOProduct.GetProduct(orderLine.Stock.Product.Id);
                }
                order.OrderLines = orderLines;

            }

            return orders;
        }

        public IList<Order> GetOrder(int idEnterprise, int pageIndex)
        {
            Criteria criteriaEnterprise = new Criteria { Column = Order.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Order.FINALIZED_DATE, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = pageIndex, PageSize = 100000 };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }

    }
}
