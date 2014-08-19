using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class ToolsPresenter : BaseAdministrationPresenter<IToolsPresenter>
    {
        public IOrderService OrderService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }
        public IDAOStockTransaction DAOStockTransaction { get; set; }
        public IStockService StockService { get; set; }
        public IDatabaseService DatabaseService { get; set; }
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
            View.StockTemplate = StockService.GetStockTemplate();
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
            StockService.CreateStockWithTemplate(product, templateGroup, quantity, isWithoutStock);
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
            IList<StockTransaction> stockTransactions = StockService.GetAllStockTransaction();
            IList<Stock> stocks = StockService.GetAllStock();
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

        public string BalanceSearch(string objet)
        {
            string rtn = string.Empty;

            switch (objet)
            {
                case "Address": return Save<Address>();
                case "Country": return Save<Country>();
                case "City": return Save<City>();
                case "User": return Save<User>();
                case "Customer": return Save<Customer>();
                case "CustomerType": return Save<CustomerType>();
                case "Enterprise": return Save<Enterprise>();
                case "EnterpriseAddress": return Save<EnterpriseAddress>();
                case "EnterpriseEmail": return Save<EnterpriseEmail>();
                case "EnumOrderInformation": return Save<EnumOrderInformation>();
                case "GroupProduct": return Save<GroupProduct>();
                case "Order": return Save<Order>();
                case "OrderLine": return Save<OrderLine>();
                case "Product": return Save<Product>();
                case "ProductCategory": return Save<ProductCategory>();
                case "ProductFile": return Save<ProductFile>();
                case "File": return Save<File>();
                case "ProductPriceHistory": return Save<ProductPriceHistory>();
                case "Stock": return Save<Stock>();
                case "StockLink": return Save<StockLink>();
                case "StockTemplate": return Save<StockTemplate>();
                case "Supplier": return Save<Supplier>();
                case "Taxes": return Save<Taxes>();
                case "StockTransaction": return Save<StockTransaction>();
            }

            return "Aucune transaction";
        }

        private string Save<TModel>()
        {


            switch (typeof(TModel).FullName)
            {
                case "ATMTECH.ShoppingCart.Entities.Enterprise":
                    foreach (Enterprise enterprise in EnterpriseService.GetAll())
                    {
                        EnterpriseService.Save(EnterpriseService.GetEnterprise(enterprise.Id));
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Order":
                    foreach (Order order in OrderService.GetAll())
                    {
                        OrderService.Save(OrderService.GetOrder(order.Id));
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Stock":
                    foreach (Stock stock in StockService.GetAllStock())
                    {
                        if (ProductService.GetProductSimple(stock.Product.Id) != null)
                        {
                            StockService.Save(StockService.GetStock(stock.Id));
                        }
                    }
                    break;
                case "ATMTECH.ShoppingCart.Entities.Customer":
                    BaseDao<Customer, int> daoModelCustomer = new BaseDao<Customer, int>();

                    foreach (Customer customer in CustomerService.GetAll())
                    {
                        customer.User = AuthenticationService.GetUser(customer.User.Id);
                        daoModelCustomer.Save(customer);
                    }
                    break;
                default:
                    BaseDao<TModel, int> daoModel = new BaseDao<TModel, int>();
                    IList<TModel> model = daoModel.GetAll();
                    foreach (TModel model1 in model)
                    {
                        daoModel.Save(model1);
                    }
                    break;
            }



            return typeof(TModel).FullName + " Exécuté !!!<br>";
        }

        public string CreateBackup(string path)
        {
            return DatabaseService.CreateMssqlBackup(path, "ShoppingCart.bak", "ShoppingCart");
        }

        public string AdjustOrderline(int id, int quantite)
        {
            OrderLine orderLine = OrderService.GetAllOrderLine().Where(x => x.Id == id).ToList()[0];
            Order order = OrderService.GetOrder(orderLine.Order.Id);
            StockTransaction stockTransaction = StockService.GetAllStockTransaction().Where(x => x.Order.Id == orderLine.Order.Id).ToList()[0];


            order.OrderLines.Where(x => x.Id == id).ToList()[0].Quantity = quantite;

            stockTransaction.Transaction = quantite * -1;

            OrderService.UpdateOrder(order, null);
            StockService.SaveStockTransaction(stockTransaction);
            return "Ok";
        }
    }
}
