using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ToolsPresenter : BaseAdministrationPresenter<IToolsPresenter>
    {
        public IOrderService OrderService { get; set; }
        public IStockService StockServices { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }
        public IDAOStockTransaction DAOStockTransaction { get; set; }

        public ICustomerService CustomerService { get; set; }
        public IDAOUser DAOUser { get; set; }
        public ToolsPresenter(IToolsPresenter view)
            : base(view)
        {

        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.ProductWithoutStock = ProductService.GetProductsWithoutStock(View.EnterpriseSelect);
            View.StockTemplate = StockServices.GetStockTemplate();
            IList<Customer> customers = CustomerService.GetAll();
            IList<User> user = DAOUser.GetAllUser();
            View.Users = user.Where(user1 => customers.Count(x => x.User.Id == user1.Id) == 0).ToList();
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Enterprise = EnterpriseService.GetAll().Where(x => x.IsActive).ToList();
        }

        public void ApplyStockTemplate(string productId, string templateGroup, int quantity, bool isWithoutStock)
        {
            Product product = ProductService.GetProductSimple(Convert.ToInt32(productId));
            StockServices.CreateStockWithTemplate(product, templateGroup, quantity, isWithoutStock);
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
        public void ConfirmOrder(string id)
        {
            OrderService.ConfirmOrder(Convert.ToInt32(id));
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
        public void DisplayOrder(int id)
        {
            Order order = OrderService.GetOrder(id);
            OrderService.PrintOrder(order);
        }
        public void AssociateUser(int idUser, int idEnterprise)
        {
            User user = AuthenticationService.GetUser(idUser);
            if (user != null)
            {
                Customer customer = CustomerService.GetCustomer(user.Id);
                if (customer == null)
                {
                    customer = new Customer
                    {
                        IsActive = true,
                        Enterprise = new Enterprise { Id = idEnterprise },
                        User = new User
                        {
                            Id = idUser
                        }

                    };

                    CustomerService.SaveCustomer(customer);
                    MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
                }

            }
        }
        public void CreateEnterpriseFromAnother(int id, string newName)
        {
            EnterpriseService.CreateEnterpriseFromAnother(id, newName, AuthenticationService.AuthenticateUser);
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }

        public string BalanceStock()
        {
            string result = "Résultat des lignes de commande sans transaction d'inventaires<br><br>";
            IList<OrderLine> orderLines = OrderService.GetAllOrderLine().Where(x => x.IsActive).ToList();
            IList<Order> orders = OrderService.GetAll().Where(x => x.IsActive && (x.OrderStatus == 2 || x.OrderStatus == 3)).ToList();
            IList<StockTransaction> stockTransactions = StockServices.GetAllStockTransaction();
            IList<Stock> stocks = StockServices.GetAllStock();
            foreach (OrderLine orderLine in orderLines)
            {
                orderLine.Stock = stocks.FirstOrDefault(x => x.Id == orderLine.Stock.Id);
                orderLine.Order = orders.FirstOrDefault(x => x.Id == orderLine.Order.Id);
                if (orderLine.Order != null)
                {
                    if (orderLine.Stock != null && orderLine.Stock.IsWithoutStock) continue;
                    if (stockTransactions.Count(x => x.Stock.Id == orderLine.Stock.Id && x.Order.Id == orderLine.Order.Id) == 0)
                    {
                        result += "Commande: " + orderLine.Order.Id + " Inventaire: " + orderLine.Stock.Id + " " +
                                  orderLine.Stock.FeatureFrench + "<br>";
                        DAOStockTransaction.StockTransaction(orderLine.Stock, orderLine.Quantity * -1, orderLine.Order, (DateTime)orderLine.Order.FinalizedDate);
                        //StockServices.StockTransaction(orderLine.Stock.Id, orderLine.Quantity, orderLine.Order, StockService.TransactionType.Remove);
                    }
                }
            }
            return result;
        }
    }
}
