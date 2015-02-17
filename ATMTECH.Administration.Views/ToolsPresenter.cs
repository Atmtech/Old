using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Interface;
using File = ATMTECH.Entities.File;

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
        public IParameterService ParameterService { get; set; }
        public IImportXmlService ImportXmlService { get; set; }
        public IFileService FileService { get; set; }
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
            MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT);
        }
        public void ConfirmOrder(string id)
        {
            OrderService.ConfirmOrder(Convert.ToInt32(id));
            MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT);
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
                    MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT);
                }

            }
        }
        public void CreateEnterpriseFromAnother(int id, string newName)
        {
            EnterpriseService.CreateEnterpriseFromAnother(id, newName, AuthenticationService.AuthenticateUser);
            MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_SAVE_IS_CORRECT);
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
                        if (orderLine.Stock != null)
                        {
                            result += "Commande: " + orderLine.Order.Id + " Inventaire: " + orderLine.Stock.Id + " " +
                                      orderLine.Stock.FeatureFrench + "<br>";
                            if (orderLine.Order.FinalizedDate != null)
                                DAOStockTransaction.StockTransaction(orderLine.Stock, orderLine.Quantity * -1, orderLine.Order, (DateTime)orderLine.Order.FinalizedDate);
                        }
                        //StockServices.StockTransaction(orderLine.Stock.Id, orderLine.Quantity, orderLine.Order, StockService.TransactionType.Remove);
                    }
                }
            }
            return result;
        }
        public string BalanceSearch(string objet)
        {

            switch (objet)
            {
                case "Localization": return Save<Localization>();   
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

                    IList<Product> allActive = ProductService.GetAllActive();
                    foreach (Stock stock in StockService.GetAllStock())
                    {
                        Product product = allActive.FirstOrDefault(x => x.Id == stock.Product.Id);
                        if (product != null)
                        {
                            stock.Product = product;
                            StockService.Save(stock);
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

            IList<OrderLine> orderLines = order.OrderLines.Where(x => x.Id == id).ToList();
            if (orderLines.Count == 0)
            {
                MessageService.ThrowMessage(new Exception("Aucune ligne de commande active pour la commande: " + order.Id));
            }

            OrderLine orderLineAjuster = orderLines[0];

            IList<StockTransaction> stockTransactions =
                StockService.GetAllStockTransaction().Where(x => x.Order.Id == orderLine.Order.Id).ToList();


            IList<StockTransaction> stockTransactionTrouve = stockTransactions.Where(x => x.Stock.Id == orderLine.Stock.Id).ToList();
            StockTransaction stockTransaction = stockTransactionTrouve.Count == 0 ? new StockTransaction { Stock = orderLine.Stock, IsActive = true, Order = order } : stockTransactionTrouve[0];

            if (quantite == 0)
            {

                orderLineAjuster.IsActive = false;
                stockTransaction.IsActive = false;
            }
            else
            {
                orderLineAjuster.Quantity = quantite;
                stockTransaction.Transaction = quantite * -1;
            }

            OrderService.UpdateOrder(order, null);
            stockTransaction.Stock = StockService.GetStock(stockTransaction.Stock.Id);
            StockService.SaveStockTransaction(stockTransaction);

            return "Ok";
        }
        public string RestoreBackup(string mapPath)
        {
            return DatabaseService.RestoreMssqlBackup(mapPath, "ShoppingCart.bak", "ShoppingCart");
        }
        public void CloseApplication()
        {
            ParameterService.SetValue("IsOffline", "1");
        }
        public void OpenApplication()
        {
            ParameterService.SetValue("IsOffline", "0");
        }

        public string BalanceOrder()
        {
            IList<Order> orders = OrderService.GetAllWithCustomer().Where(x => x.IsActive && x.FinalizedDate != null).ToList();
            IList<OrderLine> orderLines = OrderService.GetAllOrderLine();
            IList<Stock> stocks = StockService.GetAllStock();
            foreach (OrderLine orderLine in orderLines)
            {
                orderLine.Stock = stocks.FirstOrDefault(x => x.Id == orderLine.Stock.Id);
            }
            foreach (Order order in orders)
            {
                order.OrderLines = orderLines.Where(x => x.Order.Id == order.Id).ToList();
                OrderService.UpdateOrder(order, null);
            }
            return "ok";
        }

        public void ImportProductFromXml()
        {
            ImportXmlService.ImportProductAndStockXml(new Enterprise { Id = 1 }, @"C:\Dev\Atmtech\ATMTECH.Administration\Data\Products.xml");
        }

        public void SynchronizeImage(string directory)
        {
            string[] files = Directory.GetFiles(directory + @"\product");
            IList<File> filesDatabase = FileService.GetAllFile();

            foreach (string file in files)
            {
                long fileSize;
                using (var fichier = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fileSize = fichier.Length;
                }
                if (filesDatabase.FirstOrDefault(x => x.FileName == Path.GetFileName(file) && x.RootImagePath == directory) == null)
                {
                    File fileToSave = new File
                        {
                            Category = "Product",
                            Size = (int)fileSize,
                            RootImagePath = directory,
                            FileName = Path.GetFileName(file)
                        };
                    FileService.SaveFile(fileToSave);
                }

            }
        }
    }
}
