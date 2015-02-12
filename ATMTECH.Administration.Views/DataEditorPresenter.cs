using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.Administration.Services;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Common.Utils;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class DataEditorPresenter : BaseAdministrationPresenter<IDataEditorPresenter>
    {

        public IDataEditorService DataEditorService { get; set; }
        public IDAOEntityProperty DAOEntityProperty { get; set; }
        public IDAOEntityInformation DAOEntityInformation { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IDAOFile DAOFile { get; set; }

        public IDAOGroupProduct DAOGroupProduct { get; set; }
        public IStockService StockService { get; set; }
        public IProductService ProductService { get; set; }
        public IMailService MailService { get; set; }
        public IOrderService OrderService { get; set; }
        public IParameterService ParameterService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IGenerateControlsService GenerateControlsService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }


        public string Entity
        {
            get { return View.Entity; }
        }
        public string NameSpace
        {
            get { return View.NameSpace; }
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            RefreshData();


            User user = AuthenticationService.AuthenticateUser;
            if (user == null) return;
            if (!user.IsAdministrator)
            {
                NavigationService.Redirect("default.aspx");
            }

        }


        public DataEditorPresenter(IDataEditorPresenter view)
            : base(view)
        {
        }


        private void SetEntityInformationAndProperty()
        {
            View.EntityInformations = DAOEntityInformation.GetAllEntityInformationSimple();
            View.EntityProperties = DAOEntityProperty.GEtAllEntityProperty();
        }


        public Object RechercheInformation(string recherche, int pageIndex)
        {
            switch (Entity.ToLower())
            {
                case "orderline":

                    IList<Order> orderlast = OrderService.GetOrder(Convert.ToInt32(View.Enterprise), pageIndex)
                        .OrderByDescending(x => x.FinalizedDate).ToList()
                        .Where(x => x.Search.IndexOf(recherche, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    foreach (Order order in orderlast)
                    {
                        order.OrderLines = OrderService.GetOrderLine(order.Id);
                    }

                    return orderlast.SelectMany(order => order.OrderLines).ToList();
                //return OrderService.GetAllOrderLine().Where(orderLine => orderlast.Count(x => x.Id == orderLine.Order.Id && x.IsActive) > 0).ToList();
                case "customer":
                    IList<Customer> customers = CustomerService.GetCustomerByEnterprise(Convert.ToInt32(View.Enterprise));
                    if (!string.IsNullOrEmpty(recherche))
                    {
                        customers = customers.Where(x => x.Search.Contains(recherche)).ToList();
                    }
                    return customers;
                case "stocktransaction":
                    IList<StockTransaction> stockTransactions = StockService.GetStockTransaction();
                    IList<Stock> listStock = StockService.GetAllStockByEnterprise(Convert.ToInt32(View.Enterprise));
                    IList<Product> listProduct = ProductService.GetProducts(Convert.ToInt32(View.Enterprise));

                    IList<StockTransaction> rtn = new List<StockTransaction>();

                    foreach (StockTransaction stockTransaction in stockTransactions)
                    {
                        stockTransaction.Stock = listStock.FirstOrDefault(x => x.Id == stockTransaction.Stock.Id);
                        if (stockTransaction.Stock != null)
                        {
                            stockTransaction.Stock.Product = listProduct.FirstOrDefault(x => x.Id == stockTransaction.Stock.Product.Id);

                            if (stockTransaction.Stock.Product.Enterprise.Id.ToString() == View.Enterprise)
                            {
                                rtn.Add(stockTransaction);
                            }
                        }
                    }

                    return rtn.Where(x => x.Search != null && x.Search.IndexOf(recherche, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                case "stock":
                    IList<Stock> stocks = StockService.GetAllStockByEnterprise(Convert.ToInt32(View.Enterprise)).Where(x => x.Product != null).ToList();
                    stocks = stocks.Where(x => x.Search.IndexOf(recherche, StringComparison.OrdinalIgnoreCase) >= 0).ToList().Take(10).Skip(pageIndex).ToList();

                    foreach (Stock stock in stocks)
                    {
                        stock.Product = ProductService.GetProductSimple(stock.Product.Id);
                    }



                    return stocks;
                case "stocklink":
                    return StockService.GetStockLink(Convert.ToInt32(View.Enterprise));
                case "productfile":
                    IList<ProductFile> productFiles = ProductService.GetProductFile(Convert.ToInt32(View.Enterprise));
                    productFiles = productFiles.Where(x => x.Search.IndexOf(recherche, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    return productFiles;
                case "order":
                    IList<Order> orders = OrderService.GetOrder(Convert.ToInt32(View.Enterprise), pageIndex);
                    orders = orders.Where(x => x.OrderStatus != 1).ToList();
                    orders = orders.OrderByDescending(x => x.FinalizedDate).ToList();
                    return orders.Where(x => x.Search.IndexOf(recherche, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                case "groupproduct":
                    return DAOGroupProduct.GetGroupProduct();

            }

            return IsEnterpriseRuled(NameSpace, Entity) ?
                DataEditorService.GetByCriteria(NameSpace, Entity, 5000, pageIndex, "Enterprise", View.Enterprise, recherche) :
                DataEditorService.GetByCriteria(NameSpace, Entity, 5000, pageIndex, recherche);
        }
        public void UpdateProductPriceHistory(int idProduct,decimal priceBefore, decimal priceAfter)
        {
            ProductService.UpdateProductPriceHistory(idProduct, priceBefore, priceAfter);
        }
        private bool IsEnterpriseRuled(string nameSpace, string className)
        {
            ManageClass manageClass = new ManageClass();
            Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
            Activator.CreateInstance(type, null);
            PropertyInfo[] properties = type.GetProperties();
            return properties.Any(propertyInfo => propertyInfo.Name.ToLower().Contains("enterprise"));
        }
        public void Save(object entite)
        {
            if (Entity == "Customer")
            {
                Customer customer = (Customer)entite;
                customer.User = DAOUser.GetUser(customer.User.Id);
            }

            if (Entity == "StockTransaction")
            {
                StockTransaction stockTransaction = (StockTransaction)entite;
                stockTransaction.Stock = StockService.GetStock(stockTransaction.Stock.Id);
                stockTransaction.Stock.Product = ProductService.GetProductSimple(stockTransaction.Stock.Product.Id);
                entite = stockTransaction;
            }

            if (Entity == "Stock")
            {
                Stock stock = (Stock)entite;
                stock.Product = ProductService.GetProduct(stock.Product.Id);
            }

            if (Entity == "ProductFile")
            {
                ProductFile productFile = (ProductFile)entite;
                productFile.File = DAOFile.GetFile(productFile.File.Id);
                ProductService.SaveProductFile(productFile);
                RefreshData();
                return;
            }

            if (Entity == "Product")
            {
                Product product = (Product)entite;
                decimal priceBefore = 0;
                if (product.Id != 0)
                    priceBefore = ProductService.GetProduct(product.Id).UnitPrice;
                int id = ProductService.Save(product);
                UpdateProductPriceHistory(id, priceBefore, product.UnitPrice);
                return;
            }

            if (Entity == "OrderLine")
            {
                OrderLine orderLine = (OrderLine)entite;
                OrderService.UpdateOrderLine(orderLine);
                RefreshData();
                return;
            }

            DataEditorService.Save(NameSpace, Entity, entite);
            RefreshData();
        }
        private EntityInformation FindEntityInformation()
        {
            SetEntityInformationAndProperty();
            ManageClass manageClass = new ManageClass();
            EntityInformation entityInformation = null;
            if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", Entity))
            {
                //entityInformation = DAOEntityInformation.GetEntity("ATMTECH.ShoppingCart.Entities." + Entity);
                entityInformation =
                    View.EntityInformations.Where(x => x.NameSpace == "ATMTECH.ShoppingCart.Entities." + Entity)
                        .ToList()[0];
                entityInformation.EntityProperties =
                    View.EntityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
            }
            if (manageClass.IsExistInNameSpace("ATMTECH.Entities", Entity))
            {
                //  entityInformation = DAOEntityInformation.GetEntity("ATMTECH.Entities." + Entity);

                entityInformation =
                  View.EntityInformations.Where(x => x.NameSpace == "ATMTECH.Entities." + Entity)
                      .ToList()[0];
                entityInformation.EntityProperties =
                    View.EntityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();

            }
            return entityInformation;
        }
        private void RefreshData()
        {
            View.EnterpriseList = EnterpriseService.GetEnterpriseByAccess(AuthenticationService.AuthenticateUser);
            EntityInformation entityInformation = FindEntityInformation();
            if (entityInformation != null) View.InnerTitle = entityInformation.PageTitle;
        }
        public void Inactivate(int id)
        {
            Object entity = null;
            if (id != 0)
            {
                entity = DataEditorService.GetById(NameSpace, Entity, id);
            }
            ManageClass manageClass = new ManageClass();
            if (entity != null)
            {
                Type type = entity.GetType();
                manageClass.AssignValue(type, entity, "false", "IsActive");
            }

            DataEditorService.Save(NameSpace, Entity, entity);
        }
        public void Copy(int id)
        {
            Object entity = null;
            if (id != 0)
            {
                entity = DataEditorService.GetById(NameSpace, Entity, id);
            }
            ManageClass manageClass = new ManageClass();
            if (entity != null)
            {
                Type type = entity.GetType();
                manageClass.AssignValue(type, entity, "0", "Id");
            }
            View.IdCopy = DataEditorService.Save(NameSpace, Entity, entity);
        }


        public IList<PropertyWithLabel> ListeProprieteSansCelleSysteme(string nameSpace, string entity)
        {
            return GenerateControlsService.ListeProprieteSansCelleSysteme(nameSpace, entity, View.EntityInformations, View.EntityProperties);
        }
        public IList<ControlWithLabel> CreateControls(string nameSpace, string entity, bool isInserting, int id,
                                               int idEnterprise)
        {
            return GenerateControlsService.CreateControls(nameSpace, entity, isInserting, id, idEnterprise, View.EntityInformations, View.EntityProperties);
        }


    }


}
