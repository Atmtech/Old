using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.DTO;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using System.Web;

namespace ATMTECH.ShoppingCart.Services
{
    public class OrderService : BaseService, IOrderService
    {

        public IAddressService AddressService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public ITaxesService TaxesService { get; set; }
        public IShippingService ShippingService { get; set; }
        public IMailService MailService { get; set; }
        public IValidateOrderService ValidateOrderService { get; set; }
        public IMessageService MessageService { get; set; }
        public IDAOOrder DAOOrder { get; set; }
        public IDAOTaxes DAOTaxes { get; set; }

        public IDAOOrderLine DAOOrderLine { get; set; }
        public IDAOProductPriceHistory DAOProductPriceHistory { get; set; }
        public IProductService ProductService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IStockService StockService { get; set; }
        public IPaypalService PaypalService { get; set; }
        public IReportService ReportService { get; set; }
        public ILocalizationService LocalizationService { get; set; }
        public IDAOEnterpriseEmail DAOEnterpriseEmail { get; set; }
        public IDAOEnumOrderInformation DAOEnumOrderInformation { get; set; }
        public IDAOProductFile DAOProductFile { get; set; }
        public INavigationService NavigationService { get; set; }

        public Order AddOrderLine(OrderLine orderLine, Order order)
        {
            bool orderLineExist = false;

            if (order.OrderLines != null)
            {
                foreach (OrderLine line in order.OrderLines.Where(line => orderLine.Stock.Id == line.Stock.Id))
                {
                    orderLineExist = true;
                    line.Quantity += orderLine.Quantity;
                }
            }

            if (!orderLineExist)
            {
                order.OrderLines = new List<OrderLine>();
                orderLine.IsActive = true;
                order.OrderLines.Add(orderLine);
            }
            return order;
        }
        public int Save(Order order)
        {
            if (order.Customer.BillingAddress.ComboboxDescription == null)
            {
                order.Customer.BillingAddress = order.BillingAddress;
                CustomerService.SaveCustomer(order.Customer);
            }
            if (order.Customer.ShippingAddress.ComboboxDescription == null)
            {
                order.Customer.ShippingAddress = order.ShippingAddress;
                CustomerService.SaveCustomer(order.Customer);
            }
            return DAOOrder.Save(order);
        }
        public int UpdateOrder(Order order, ShippingParameter shippingParameter)
        {
            ValidateOrderService.IsValidOrder(order);
            Taxes taxes = DAOTaxes.GetTaxes(order.Customer.Taxes.Id);
            order = CalculateTotal(order, taxes.Type, shippingParameter);
            return DAOOrder.UpdateOrder(order);
        }
        public void FinalizeOrderPaypal(Order order, ShippingParameter shippingParameter)
        {
            ValidateOrderService.IsValidAddress(order);
            ValidateOrderService.IsValidOrder(order);
            ValidateOrderService.IsValidIfOrderInformationIsEnabled(order);

            UpdateOrder(order, shippingParameter);

            foreach (OrderLine orderLine in order.OrderLines)
            {
                orderLine.Stock.Product = ProductService.GetProduct(orderLine.Stock.Product.Id);
            }

            string productName = HttpUtility.HtmlDecode(order.OrderLines.Aggregate(string.Empty, (current, line) => current + (line.ProductDescription + " (" + line.Quantity + ") , ")));
            PaypalDto paypalDto = new PaypalDto
                                      {
                                          OrderDescription =
                                              string.Format(ParameterService.GetValue("OrderMessagePaypal"), order.DateModified.ToString(), order.Enterprise.Name),
                                          Price = (double)order.GrandTotal,
                                          Quantity = 1,
                                          OrderId = order.Id.ToString(),
                                          ProductName = productName
                                      };

            PaypalService.SendPaypalRequest(paypalDto);
        }
        public int FinalizeOrder(Order order, ShippingParameter shippingParameter)
        {
            ValidateOrderService.IsValidAddress(order);
            ValidateOrderService.IsValidOrder(order);
            ValidateOrderService.IsValidIfOrderInformationIsEnabled(order);

            order.ShippingTotal = GetShippingTotal(order, shippingParameter);

            SendMailToUser(order);
            SendMailToAdmin(order);
            SendMailToEnterprise(order);

            order.OrderStatus = OrderStatus.IsOrdered;
            order.FinalizedDate = DateTime.Now;

            foreach (OrderLine orderLine in order.OrderLines.Where(orderLine => !orderLine.Stock.IsWithoutStock))
            {
                StockService.StockTransaction(orderLine.Stock.Id, orderLine.Quantity, order, Services.StockService.TransactionType.Remove);
                SendWarningOnLowStock(orderLine.Stock, order);
            }

            ContextSessionManager.Context.Session["CurrentOrder"] = null;

            return UpdateOrder(order, shippingParameter);

        }
        public void SendWarningOnLowStock(Stock stock, Order order)
        {
            Stock stockFound = StockService.GetStock(stock.Id);
            int stockStatut = StockService.GetCurrentStockStatus(stock);
            if (stockFound.IsWarningOnLow && stockStatut <= stock.MinimumAccept)
            {
                IList<EnterpriseEmail> enterpriseEmails = DAOEnterpriseEmail.GetEnterpriseEmail(order.Enterprise);
                foreach (EnterpriseEmail enterpriseEmail in enterpriseEmails)
                {
                    MailService.SendEmail(enterpriseEmail.Email, ParameterService.GetValue(Constant.ADMIN_MAIL),
                                          string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_ORDER_FINALIZED), order.EnterpriseName, "No.: " + order.Id),
                                          ParameterService.GetValue(Constant.MAIL_BODY_ORDER_FINALIZED));
                }
            }
        }
        public Order GetOrder(int idOrder)
        {
            if (idOrder == 0)
                return null;

            return GetAddressOrder(DAOOrder.GetOrder(idOrder));
        }
        public int CreateOrder(Order order, ShippingParameter shippingParameter)
        {
            ValidateOrderService.IsValidOrder(order);

            if (order.Enterprise.IsShippingQuotationRequired)
            {
                order.IsAskShipping = true;
            }

            if (order.Id == 0)
            {
                string type = DAOTaxes.GetTaxes(order.Customer.Taxes.Id).Type;
                order = CalculateTotal(order, type, shippingParameter);
                return DAOOrder.CreateOrder(order);
            }
            MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDER_CREATE_NOT_ZERO);

            return 0;
        }
        public Order GetWishListFromCustomer(Customer customer)
        {
            if (customer != null)
            {
                IList<Order> orders = DAOOrder.GetOrderFromCustomer(customer);
                return GetAddressOrder(orders.FirstOrDefault(order => order.OrderStatus == OrderStatus.IsWishList));
            }

            MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_NO_USER_AUTHENTICATED);
            return null;
        }
        public IList<Order> GetOrdersFromCustomer(Customer customer, int orderStatus)
        {
            if (customer != null)
            {
                return DAOOrder.GetOrderFromCustomer(customer, orderStatus);
            }

            MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_NO_USER_AUTHENTICATED);
            return null;
        }
        public IList<Order> GetOrderToReport(int idOrder)
        {
            IList<Order> orders = new List<Order>();
            orders.Add(GetAddressOrder(DAOOrder.GetOrder(idOrder)));
            return orders;
        }
        public IList<OrderLine> GetOrderLineToReport(int idOrder)
        {
            return GetOrder(idOrder).OrderLines;
        }
        public decimal GetShippingTotal(Order order, ShippingParameter shippingParameter)
        {
            return order.Enterprise.IsShippingManaged ? ShippingService.GetShippingTotal(order, shippingParameter) : 0;
        }
        public void UpdateOrderLine(OrderLine orderLine)
        {
            Stock stock = StockService.GetStock(orderLine.Stock.Id);
            orderLine.Stock = stock;
            DAOOrderLine.Update(orderLine);
        }
        public IList<Order> GetAll()
        {
            return DAOOrder.GetAll();
        }
        public void AskForShipping(Order order)
        {
            order.IsOrderLocked = true;

            IList<EnterpriseEmail> enterpriseEmails = DAOEnterpriseEmail.GetEnterpriseEmail(order.Enterprise);
            foreach (EnterpriseEmail enterpriseEmail in enterpriseEmails)
            {
                MailService.SendEmail(enterpriseEmail.Email, order.Customer.User.Email,
                                 string.Format(ParameterService.GetValue(Constant.MAIL_ASK_QUOTE_SHIPPING_SUBJECT), order.Id),
                                 string.Format(ParameterService.GetValue(Constant.MAIL_ASK_QUOTE_SHIPPING_BODY), order.Id, order.Customer.User.Email));
            }

            Save(order);

            MailService.SendEmail(order.Customer.User.Email, ParameterService.GetValue(Constant.ADMIN_MAIL), ParameterService.GetValue(Constant.MAIL_ASK_QUOTE_SHIPPING_SUBJECT_CUSTOMER),
                                    ParameterService.GetValue(Constant.MAIL_ASK_QUOTE_SHIPPING_BODY_CUSTOMER));

            NavigationService.Refresh();
        }
        public Stream ReturnOrderReport(Order order)
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Order_" + LocalizationService.CurrentLanguage + ".rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            int idOrder = order.Id;
            reportParameter.AddDatasource("dsOrder", GetOrderToReport(idOrder));
            reportParameter.AddDatasource("dsOrderLine", GetOrderLineToReport(idOrder));
            return ReportService.SaveReportToStream("Order.pdf", ReportService.GetReport(reportParameter));
        }
        public void PrintOrder(Order order)
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Order_" + LocalizationService.CurrentLanguage + ".rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            int idOrder = order.Id;
            reportParameter.AddDatasource("dsOrder", GetOrderToReport(idOrder));
            reportParameter.AddDatasource("dsOrderLine", GetOrderLineToReport(idOrder));
            ReportService.SaveReport("Order.pdf", ReportService.GetReport(reportParameter));
        }
        public void ConfirmOrder(int idOrder)
        {
            Order order = GetOrder(idOrder);
            order.ShippingDate = DateTime.Now;
            DAOOrder.UpdateOrder(order);

            MailService.SendEmail(order.Customer.User.Email, ParameterService.GetValue(Constant.ADMIN_MAIL),
                                 string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_ORDER_CONFIRMED), order.Id, order.Enterprise.Name),
                                 string.Format(ParameterService.GetValue(Constant.MAIL_BODY_ORDER_CONFIRMED), order.Id, order.Enterprise.Name, order.TrackingNumber),
                                 ReturnOrderReport(order), "order.pdf");
        }
        public IList<ProductBySale> GetProductBySale(Enterprise enterprise)
        {
            IList<Product> products = ProductService.GetProductsSimple(enterprise.Id);
            IList<OrderLine> orderLines = DAOOrder.GetAllOrderLine(enterprise);
            IList<ProductBySale> productBySales = new List<ProductBySale>();

            foreach (Product product in products)
            {
                IList<OrderLine> orderLinesFilter = orderLines.Where(x => x.Stock.Product.Id == product.Id).ToList();

                int numberTotalSale = 0;
                decimal totalSale = 0;

                if (orderLinesFilter.Count > 0)
                {
                    numberTotalSale = orderLinesFilter.Sum(x => x.Quantity);
                    totalSale = orderLinesFilter.Sum(x => x.SubTotal);
                }

                productBySales.Add(new ProductBySale { Product = product, NumberTotalSale = numberTotalSale, TotalSale = totalSale });
            }

            return productBySales;
        }
        public IList<Product> GetFavoriteProductFromOrder(Enterprise enterprise, int take)
        {

            IList<Product> products = ProductService.GetProductsSimple(enterprise.Id);

            Random r = new Random();
            IList<Product> productses = products.OrderBy(x => r.Next()).Take(take).ToList();
            foreach (Product productse in productses)
            {
                productse.ProductFiles = DAOProductFile.GetProductFile(productse.Id);
            }
            return productses;
        }
        public IList<SalesReportLine> GetSalesReportLine(Enterprise enterprise, DateTime dateStart, DateTime dateEnd)
        {
            IList<SalesReportLine> salesReportLines = new List<SalesReportLine>();
            IList<Product> products = ProductService.GetProductsWithoutLanguage(enterprise.Id);
            IList<Order> orders = DAOOrder.GetAllFinalized(enterprise, dateStart, dateEnd);
            IList<OrderLine> orderLines = orders.SelectMany(order => order.OrderLines).ToList();
            IList<Stock> stocks = products.SelectMany(product => product.Stocks).ToList();

            foreach (OrderLine orderLine in orderLines)
            {
                if (orderLine.Order.FinalizedDate != null)
                {
                    SalesReportLine salesReportLine = new SalesReportLine
                        {
                            OrderId = orderLine.Order.Id,
                            Quantity = orderLine.Quantity,
                            Total = orderLine.SubTotal,
                            ClientName = HttpUtility.HtmlDecode(orderLine.Order.Customer.User.FirstNameLastName),
                            Enterprise = enterprise.Name,
                            ProductId = orderLine.Stock.Product.Id,
                            Product = HttpUtility.HtmlDecode(orderLine.Stock.Product.Ident + " " + orderLine.Stock.Product.NameFrench + " " + orderLine.Stock.FeatureFrench),
                            StockActualState = StockService.GetCurrentStockStatus(orderLine.Stock, dateStart, dateEnd),
                            StockInitialState = orderLine.Stock.InitialState,
                            UnitPrice = orderLine.Stock.Product.UnitPrice,
                            UnitPriceOrderLine = orderLine.UnitPrice,
                            FinalizedDate = (DateTime)orderLine.Order.FinalizedDate,
                            DateStart = dateStart,
                            DateEnd = dateEnd
                        };
                    salesReportLines.Add(salesReportLine);
                }
            }

            salesReportLines = RemoveLinkedStock(salesReportLines);

            Decimal grandTotalStock = StockWithActualStates(dateStart, dateEnd, stocks).Sum(x => x.ActualValue);
            Decimal grandTotalSales = salesReportLines.Sum(x => x.UnitPriceOrderLine * x.Quantity);

            salesReportLines = salesReportLines.Select(c => { c.GrandTotalStock = grandTotalStock; return c; }).ToList();
            salesReportLines = salesReportLines.Select(c => { c.GrandTotalSales = grandTotalSales; return c; }).ToList();


            return salesReportLines.OrderBy(x => x.OrderId).Where(x => x.OrderId != 0).ToList();
        }
        public IList<SalesByOrderInformationReportLine> GetSalesByOrderInformationReportLine(Enterprise enterprise, DateTime dateStart, DateTime dateEnd)
        {
            IList<SalesByOrderInformationReportLine> salesReportLines = new List<SalesByOrderInformationReportLine>();
            IList<Product> products = ProductService.GetProductsWithoutLanguage(enterprise.Id);
            IList<Order> orders = DAOOrder.GetAllFinalized(enterprise, dateStart, dateEnd);
            IList<OrderLine> orderLines = orders.SelectMany(order => order.OrderLines).ToList();
            IList<Stock> stocks = products.SelectMany(product => product.Stocks).ToList();

            IList<EnumOrderInformation> enumOrderInformations = DAOEnumOrderInformation.GetOrderInformation().Where(x => x.Enterprise.Id == enterprise.Id).ToList();
            if (enumOrderInformations.Count > 0)
            {
                foreach (Stock stock in stocks)
                {
                    if (orderLines.Count(x => x.Stock.Id == stock.Id) > 0)
                    {
                        foreach (OrderLine orderLine in orderLines)
                        {
                            if (orderLine.Stock.Id == stock.Id)
                            {
                                if (orderLine.Order.FinalizedDate != null)
                                {
                                    SalesByOrderInformationReportLine salesByOrderInformationReportLine = new SalesByOrderInformationReportLine
                                        {
                                            OrderId = orderLine.Order.Id,
                                            Quantity = orderLine.Quantity,
                                            SubTotal = orderLine.SubTotal,
                                            ClientName = HttpUtility.HtmlDecode(orderLine.Order.Customer.User.FirstNameLastName),
                                            Enterprise = enterprise.Name,
                                            ProductId = orderLine.Stock.Product.Id,
                                            Product = HttpUtility.HtmlDecode(orderLine.Stock.Product.Ident + " " + orderLine.Stock.Product.NameFrench + " " + orderLine.Stock.FeatureFrench),
                                            UnitPriceOrderLine = orderLine.UnitPrice,
                                            FinalizedDate = (DateTime)orderLine.Order.FinalizedDate,
                                            DateStart = dateStart,
                                            DateEnd = dateEnd,
                                            OrderInformation = enumOrderInformations.FirstOrDefault(x => x.Code == orderLine.Order.OrderInformation1).Description + " - " + enumOrderInformations.FirstOrDefault(x => x.Code == orderLine.Order.OrderInformation2).Description
                                        };
                                    salesReportLines.Add(salesByOrderInformationReportLine);
                                }
                            }
                        }
                    }
                }
            }


            return salesReportLines.OrderBy(x => x.OrderInformation).ThenBy(x => x.ProductId).ToList();
        }
        public IList<OrderLine> GetAllOrderLine()
        {
            return DAOOrderLine.GetAll();
        }
        public int SaveOrderLine(OrderLine orderLine)
        {
            return DAOOrderLine.Update(orderLine);
        }
        public IList<ProductPriceHistoryReportLine> GetProductPriceHistoryReportLine(Enterprise enterprise,
                                                                                     DateTime dateStart,
                                                                                     DateTime dateEnd)
        {
            IList<ProductPriceHistoryReportLine> productPriceHistoryReportLines = new List<ProductPriceHistoryReportLine>();
            IList<ProductPriceHistory> productPriceHistories = DAOProductPriceHistory.GetProductPriceHistory(
                enterprise, dateStart, dateEnd);
            foreach (ProductPriceHistory productPriceHistory in productPriceHistories)
            {
                if (productPriceHistory.DateChanged != null)
                    productPriceHistoryReportLines.Add(new ProductPriceHistoryReportLine
                        {
                            DateChanged = (DateTime)productPriceHistory.DateChanged,
                            PriceAfter = productPriceHistory.PriceAfter,
                            PriceBefore = productPriceHistory.PriceBefore,
                            Product = HttpUtility.HtmlDecode(productPriceHistory.Product.Ident + " " + productPriceHistory.Product.NameFrench)
                        });
            }

            if (productPriceHistoryReportLines.Count == 0)
            {
                productPriceHistoryReportLines.Add(new ProductPriceHistoryReportLine() { Product = "Aucun changement de prix pour la période" });
            }
            return productPriceHistoryReportLines;
        }

        public IList<SalesByMonthReportLine> GetSalesByMonthReportLine(Enterprise enterprise, DateTime dateStart,
                                                                       DateTime dateEnd)
        {
            IList<SalesByMonthReportLine> salesByMonthReportLines = new List<SalesByMonthReportLine>();
            IList<Product> products = ProductService.GetProductsWithoutLanguage(enterprise.Id);
            IList<Order> orders = DAOOrder.GetAllFinalized(enterprise, dateStart, dateEnd);
            IList<OrderLine> orderLines = orders.SelectMany(order => order.OrderLines).ToList();
            IList<Stock> stocks = products.SelectMany(product => product.Stocks).Where(x => x.IsActive).Distinct().ToList();

            foreach (Stock stock in stocks)
            {
                int januarySales = 0;
                int februarySales = 0;
                int marchSales = 0;
                int maySales = 0;
                int aprilSales = 0;
                int juneSales = 0;
                int julySales = 0;
                int augustSales = 0;
                int septemberSales = 0;
                int octoberSales = 0;
                int novemberSales = 0;
                int decemberSales = 0;
                decimal grandTotalSales = 0;
                decimal unitPrice = 0;

                int stockActualState = StockService.GetCurrentStockStatus(stock, dateStart, dateEnd);
                int stockInitialState = stock.InitialState;

                if (orderLines.Count(x => x.Stock.Id == stock.Id) > 0)
                {
                    string product = string.Empty;

                    foreach (OrderLine orderLine in orderLines.Where(orderLine => orderLine.Stock.Id == stock.Id))
                    {
                        grandTotalSales += orderLine.SubTotal;

                        if (orderLine.Order.FinalizedDate != null)
                            switch (((DateTime)(orderLine.Order.FinalizedDate)).Month)
                            {
                                case 1:
                                    januarySales += orderLine.Quantity;
                                    break;
                                case 2:
                                    februarySales += orderLine.Quantity;
                                    break;
                                case 3:
                                    marchSales += orderLine.Quantity;
                                    break;
                                case 4:
                                    aprilSales += orderLine.Quantity;
                                    break;
                                case 5:
                                    maySales += orderLine.Quantity;
                                    break;
                                case 6:
                                    juneSales += orderLine.Quantity;
                                    break;
                                case 7:
                                    julySales += orderLine.Quantity;
                                    break;
                                case 8:
                                    augustSales += orderLine.Quantity;
                                    break;
                                case 9:
                                    septemberSales += orderLine.Quantity;
                                    break;
                                case 10:
                                    octoberSales += orderLine.Quantity;
                                    break;
                                case 11:
                                    novemberSales += orderLine.Quantity;
                                    break;
                                case 12:
                                    decemberSales += orderLine.Quantity;
                                    break;
                            }
                        product = HttpUtility.HtmlDecode(orderLine.Stock.Product.Ident + " " + orderLine.Stock.Product.NameFrench + " " + orderLine.Stock.FeatureFrench);
                        unitPrice = orderLine.Stock.Product.UnitPrice;
                    }

                    SalesByMonthReportLine salesByMonthReportLine = new SalesByMonthReportLine
                        {
                            Product = product,
                            Enterprise = enterprise.Name,
                            DateStart = dateStart,
                            DateEnd = dateEnd,
                            JanuarySales = januarySales,
                            FebruarySales = februarySales,
                            MarchSales = marchSales,
                            MaySales = maySales,
                            AprilSales = aprilSales,
                            JuneSales = juneSales,
                            JulySales = julySales,
                            AugustSales = augustSales,
                            SeptemberSales = septemberSales,
                            OctoberSales = octoberSales,
                            NovemberSales = novemberSales,
                            DecemberSales = decemberSales,
                            StockActualState = stockActualState,
                            StockInitialState = stockInitialState,
                            GrandTotalSales = grandTotalSales,
                            UnitPrice = unitPrice,
                            TotalValueStockActualState = stockActualState * stock.Product.UnitPrice,
                            TotalValueStockInitialState = stockInitialState * stock.Product.UnitPrice
                        };
                    salesByMonthReportLines.Add(salesByMonthReportLine);

                }
                else
                {
                    SalesByMonthReportLine salesByMonthReportLine = new SalesByMonthReportLine
                    {
                        Product = stock.Product.Ident + " " + stock.Product.NameFrench + " " + stock.FeatureFrench,
                        Enterprise = enterprise.Name,
                        DateStart = dateStart,
                        DateEnd = dateEnd,
                        JanuarySales = januarySales,
                        FebruarySales = februarySales,
                        MarchSales = marchSales,
                        MaySales = maySales,
                        AprilSales = aprilSales,
                        JuneSales = juneSales,
                        JulySales = julySales,
                        AugustSales = augustSales,
                        SeptemberSales = septemberSales,
                        OctoberSales = octoberSales,
                        NovemberSales = novemberSales,
                        DecemberSales = decemberSales,
                        StockActualState = stockActualState,
                        StockInitialState = stockInitialState,
                        GrandTotalSales = 0,
                        UnitPrice = stock.Product.UnitPrice,
                        TotalValueStockActualState = stockActualState * stock.Product.UnitPrice,
                        TotalValueStockInitialState = stockInitialState * stock.Product.UnitPrice
                    };
                    salesByMonthReportLines.Add(salesByMonthReportLine);
                }
            }

            return salesByMonthReportLines;
        }

        public IList<EnumOrderInformation> GetOrderInformation(Enterprise enterprise, string group)
        {
            IList<EnumOrderInformation> enumOrderInformations = new List<EnumOrderInformation>();
            enumOrderInformations.Add(new EnumOrderInformation());
            foreach (EnumOrderInformation enumOrderInformation in DAOEnumOrderInformation.GetOrderInformation(enterprise, group))
            {
                enumOrderInformations.Add(enumOrderInformation);
            }

            return enumOrderInformations.OrderBy(x => x.Code).ToList();
        }
        public IList<Order> GetOrder(int idEnterprise, int pageIndex)
        {
            return GetAddressOrder(DAOOrder.GetOrder(idEnterprise, pageIndex));
        }
        public string GetOrderWithFormat(int idOrder)
        {
            Order order = GetOrder(idOrder);
            String html = "<table>";
            html += "<td></td><td>Qte</td><td></td>";
            foreach (OrderLine orderLine in order.OrderLines)
            {
                html += "<tr>";
                html += "<td>" + orderLine.ProductDescription + "</td><td>" + orderLine.Quantity + "</td><td>" + orderLine.SubTotal.ToString("C") + "</td>";
                html += "</tr>";
            }

            html += "<tr><td></td><td>S-Total:</td><td>" + order.SubTotal.ToString("C") + "</td></tr>";
            html += "<tr><td></td><td><b>G-Total:</td><td>" + order.GrandTotal.ToString("C") + "</b></td></tr>";
            html += "</table>";

            return html;
        }

        public IList<StockControlReportLine> GetStockControlReport()
        {
            IList<StockTransaction> stockTransactions = StockService.GetStockTransaction();
            IList<OrderLine> orderLines = GetAllOrderLine().Where(x => x.IsActive).ToList();
            IList<StockControlReportLine> stockControlReportLines = new List<StockControlReportLine>();

            foreach (OrderLine orderLine in orderLines)
            {

                if (stockTransactions.Count(x => x.Stock.Id == orderLine.Stock.Id) == 0)
                {
                    stockControlReportLines.Add(AddStockControlReportLine(orderLine, @"N\A", ErrorCode.ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_NO_MATCH));
                }

                int transactionTotal = stockTransactions.Where(x => x.Stock.Id == orderLine.Stock.Id).Sum(x => x.Transaction);
                if (transactionTotal != orderLine.Quantity * -1)
                {
                    stockControlReportLines.Add(AddStockControlReportLine(orderLine, transactionTotal.ToString(), ErrorCode.ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_ORDERLINE_QUANTITY_VS_TRANSACTION_NOT_EQUAL));
                }
            }

            foreach (StockTransaction stockTransaction in stockTransactions)
            {
                if (orderLines.Count(x => x.Stock.Id == stockTransaction.Stock.Id) == 0)
                {
                    stockControlReportLines.Add(AddStockControlReportLine(new OrderLine() { Order = new Order() { Id = stockTransaction.Order.Id } }, stockTransaction.Transaction.ToString(), ErrorCode.ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_TRANSACTION_NOT_EXISTS_IN_ORDERLINE));
                }
            }
            return stockControlReportLines.OrderBy(x => x.Order).ToList();
        }

        private StockControlReportLine AddStockControlReportLine(OrderLine orderLine, string stockTransactionQuantity, string message)
        {

            if (orderLine.Order != null)
            {
                orderLine.Order = GetOrder(orderLine.Order.Id);
            }

            if (orderLine.Stock == null)
            {
                StockControlReportLine stockControlReportLine = new StockControlReportLine()
                {
                    Order = @"Commande: " + orderLine.Order.Id,
                    Stock = @"N\A",
                    OrderLineQuantity = @"N\A",
                    StockTransactionQuantity = stockTransactionQuantity,
                    Problem = message
                };
                return stockControlReportLine;
            }
            else
            {
                orderLine.Stock = StockService.GetStock(orderLine.Stock.Id);
                StockControlReportLine stockControlReportLine = new StockControlReportLine()
                {
                    Order = HttpUtility.HtmlDecode(orderLine.Order.ComboboxDescription),
                    Stock = HttpUtility.HtmlDecode(orderLine.Stock.ComboboxDescription),
                    OrderLineQuantity = orderLine.Quantity.ToString(),
                    StockTransactionQuantity = stockTransactionQuantity,
                    Problem = message
                };
                return stockControlReportLine;
            }


        }
        private IList<SalesReportLine> RemoveLinkedStock(IList<SalesReportLine> salesReportLines)
        {
            return salesReportLines;
        }
        private IList<StockWithActualState> StockWithActualStates(DateTime dateStart, DateTime dateEnd, IList<Stock> stocks)
        {
            IList<StockWithActualState> stockWithActualStates = new List<StockWithActualState>();
            foreach (Stock stock in stocks)
            {
                int actualState = StockService.GetCurrentStockStatus(stock, dateStart, dateEnd);
                decimal unitePrice = stock.Product.UnitPrice;
                stockWithActualStates.Add(new StockWithActualState
                    {
                        ActualState = actualState,
                        ActualValue = actualState * unitePrice,
                        Stock = stock
                    });
            }
            return stockWithActualStates;
        }
        public Order CalculateTotal(Order order, string taxType, ShippingParameter shippingParameter)
        {
            decimal total = 0;
            order.TotalWeight = 0;
            foreach (OrderLine orderLine in order.OrderLines)
            {
                if (orderLine.IsActive)
                {
                    Product product = ProductService.GetProduct(orderLine.Stock.Product.Id);
                    decimal subTotal = (product.UnitPrice + orderLine.Stock.AdjustPrice) * orderLine.Quantity;
                    total += subTotal;
                    orderLine.SubTotal = subTotal;
                    orderLine.UnitPrice = product.UnitPrice;
                    order.TotalWeight += (product.Weight * orderLine.Quantity);
                }
            }
            if (!order.Enterprise.IsShippingQuotationRequired)
            {
                order.ShippingTotal = GetShippingTotal(order, shippingParameter);
            }
            decimal shippingCost = 0;
            if (order.Enterprise.IsShippingIncluded || order.Enterprise.IsShippingQuotationRequired)
            {
                shippingCost = order.ShippingTotal;
            }

            order.SubTotal = total;
            order = CalculateTaxes(order, taxType);
            order.GrandTotal = order.SubTotal + order.CountryTax + order.RegionalTax + shippingCost;
            return order;
        }
        private Order CalculateTaxes(Order order, string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_NO_TAXE_TYPE);
            }
            else
            {
                decimal countryTax = TaxesService.GetCountryTaxes(order.SubTotal, type);
                decimal regionalTax = TaxesService.GetRegionTaxes(order.SubTotal, type);
                order.CountryTax = Common.Math.RoundingMoney(countryTax);
                order.RegionalTax = Common.Math.RoundingMoney(regionalTax);
            }

            return order;
        }
        private bool SendMailToAdmin(Order order)
        {
            return MailService.SendEmail(ParameterService.GetValue(Constant.ADMIN_MAIL), ParameterService.GetValue(Constant.ADMIN_MAIL),
                                   string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_ORDER_FINALIZED), order.EnterpriseName, "No.: " + order.Id),
                                   ParameterService.GetValue(Constant.MAIL_BODY_ORDER_FINALIZED), ReturnOrderReport(order), "order.pdf");
        }
        private bool SendMailToUser(Order order)
        {
            return MailService.SendEmail(order.Customer.User.Email, ParameterService.GetValue(Constant.ADMIN_MAIL),
                                    string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_ORDER_FINALIZED), order.EnterpriseName, "No.: " + order.Id),
                                    ParameterService.GetValue(Constant.MAIL_BODY_ORDER_FINALIZED), ReturnOrderReport(order), "order.pdf");
        }
        private void SendMailToEnterprise(Order order)
        {
            IList<EnterpriseEmail> enterpriseEmails = DAOEnterpriseEmail.GetEnterpriseEmail(order.Enterprise);

            foreach (EnterpriseEmail enterpriseEmail in enterpriseEmails)
            {
                MailService.SendEmail(enterpriseEmail.Email, ParameterService.GetValue(Constant.ADMIN_MAIL),
                                      string.Format(ParameterService.GetValue(Constant.MAIL_SUBJECT_ORDER_FINALIZED), order.EnterpriseName, "No.: " + order.Id),
                                       ParameterService.GetValue(Constant.MAIL_BODY_ORDER_FINALIZED), ReturnOrderReport(order), "order.pdf");
            }


        }
        private Order GetAddressOrder(Order order)
        {
            if (order != null)
            {
                order.BillingAddress = AddressService.GetAddress(order.BillingAddress.Id);
                order.ShippingAddress = AddressService.GetAddress(order.ShippingAddress.Id);
                return order;
            }
            return null;
        }
        private IList<Order> GetAddressOrder(IList<Order> orders)
        {
            if (orders == null)
            {
                return null;
            }
            foreach (Order order in orders)
            {
                order.BillingAddress = AddressService.GetAddress(order.BillingAddress.Id);
                order.ShippingAddress = AddressService.GetAddress(order.ShippingAddress.Id);
            }
            return orders;
        }
    }
}

