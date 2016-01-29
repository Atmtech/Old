using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.Test;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;
using ErrorCode = ATMTECH.ShoppingCart.Services.ErrorCode;

namespace ATMTECH.ShoppingCart.Tests.Services
{
    [Ignore]
    [TestClass]
    public class OrderServiceTest : BaseTest<OrderService>
    {
        public Mock<IDAOEnumOrderInformation> MockDAOEnumOrderInformation { get { return ObtenirMock<IDAOEnumOrderInformation>(); } }
        public Mock<IDAOTaxes> MockDAOTaxes { get { return ObtenirMock<IDAOTaxes>(); } }
        public Mock<IDAOOrder> MockDAOOrder { get { return ObtenirMock<IDAOOrder>(); } }
        public Mock<IDAOOrderLine> MockDAOOrderLine { get { return ObtenirMock<IDAOOrderLine>(); } }
        public Mock<IShippingService> MockShippingService { get { return ObtenirMock<IShippingService>(); } }
        public Mock<IProductService> MockProductService { get { return ObtenirMock<IProductService>(); } }
        public Mock<IValidateOrderService> MockValidateOrderService { get { return ObtenirMock<IValidateOrderService>(); } }
        public Mock<ITaxesService> MockTaxesService { get { return ObtenirMock<ITaxesService>(); } }
        public Mock<IStockService> MockStockService { get { return ObtenirMock<IStockService>(); } }
        public Mock<IAddressService> MockAddressService { get { return ObtenirMock<IAddressService>(); } }
        public Mock<ICustomerService> MockCustomerService { get { return ObtenirMock<ICustomerService>(); } }
        public Mock<IPaypalService> MockPaypalService { get { return ObtenirMock<IPaypalService>(); } }


        [TestMethod]
        public void GetOrderInformation_DoitRetournerUneListeAvecUnBlancEnPremier()
        {

            IList<EnumOrderInformation> enumOrderInformations = new List<EnumOrderInformation>();
            enumOrderInformations.Add(new EnumOrderInformation { Code = "A" });
            enumOrderInformations.Add(new EnumOrderInformation { Code = "B" });

            MockDAOEnumOrderInformation.Setup(
                test => test.GetOrderInformation(It.IsAny<Enterprise>(), It.IsAny<string>()))
                                       .Returns(enumOrderInformations);

            IList<EnumOrderInformation> rtn = InstanceTest.GetOrderInformation(It.IsAny<Enterprise>(), It.IsAny<string>());
            rtn.Count.Should().Be(3);

            rtn[0].Code.Should().BeNull();
            rtn[1].Code.Should().Be("A");
            rtn[2].Code.Should().Be("B");
        }

        [TestMethod]
        public void CreateOrder_SiOnLanceCreateOrderAvecUnIdPas0_ThrowEtRetourne0()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();

            int rtn = InstanceTest.CreateOrder(order, shippingParameter);

            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_ORDER_CREATE_NOT_ZERO));
            rtn.Should().Be(0);
        }

        [TestMethod]
        public void CreateOrder_DoitValideOrder()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();

            InstanceTest.CreateOrder(order, shippingParameter);

            MockValidateOrderService.Verify(test => test.IsValidOrder(order), Times.Once());
        }

        [TestMethod]
        public void CreateOrder_SiVraiCreationSauvegarder()
        {
            Order order = AutoFixture.Create<Order>();

            order.Id = 0;
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();
            Taxes taxes = AutoFixture.Create<Taxes>();
            Product product = AutoFixture.Create<Product>();
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);
            MockDAOTaxes.Setup(test => test.GetTaxes(order.Customer.Taxes.Id)).Returns(taxes);

            InstanceTest.CreateOrder(order, shippingParameter);

            MockValidateOrderService.Verify(test => test.IsValidOrder(order), Times.Once());
            MockDAOOrder.Verify(test => test.CreateOrder(order));

        }

        [TestMethod]
        public void CalculateTotal_SubTotalTotalWeightGrandTotalRempli()
        {
            OrderTaxesShippingParameterTest orderTaxesShippingParameterTest = CalculateTotalBasic();

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.SubTotal.Should().Be(200);
            rtn.TotalWeight.Should().Be(100);
            rtn.GrandTotal.Should().Be(200);
        }

        [TestMethod]
        public void CalculateTotal_SiShippingManagedOnRempliShippingTotal()
        {
            OrderTaxesShippingParameterTest orderTaxesShippingParameterTest = CalculateTotalBasic();
            orderTaxesShippingParameterTest.Order.ShippingTotal = 123;
            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingManaged = true;
            MockShippingService.Setup(test => test.GetShippingTotal(It.IsAny<Order>(), It.IsAny<ShippingParameter>()))
                               .Returns(123);

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.ShippingTotal.Should().Be(123);

        }

        [TestMethod]
        public void CalculateTotal_SiShippingManagedEtShippingInclusOnRempliShippingTotal()
        {
            OrderTaxesShippingParameterTest orderTaxesShippingParameterTest = CalculateTotalBasic();

            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingManaged = true;
            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingIncluded = true;
            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingQuotationRequired = false;
            orderTaxesShippingParameterTest.Order.Enterprise.ShippingCostFixed = 0;
            MockShippingService.Setup(test => test.GetShippingTotal(It.IsAny<Order>(), It.IsAny<ShippingParameter>()))
                               .Returns(123);

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.GrandTotal.Should().Be(323);

        }

        [TestMethod]
        public void CalculateTotal_SiCoutShippingFixeShippingTotal()
        {
            OrderTaxesShippingParameterTest orderTaxesShippingParameterTest = CalculateTotalBasic();

            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingManaged = true;
            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingIncluded = true;
            orderTaxesShippingParameterTest.Order.Enterprise.IsShippingQuotationRequired = false;
            orderTaxesShippingParameterTest.Order.Enterprise.ShippingCostFixed = 20;
          

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.GrandTotal.Should().Be(220);

        }


        [TestMethod]
        public void CalculateTotal_CalculTaxeTotal()
        {
            OrderTaxesShippingParameterTest orderTaxesShippingParameterTest = CalculateTotalBasic();


            MockTaxesService.Setup(test => test.GetCountryTaxes(It.IsAny<decimal>(), It.IsAny<string>())).Returns(11);
            MockTaxesService.Setup(test => test.GetRegionTaxes(It.IsAny<decimal>(), It.IsAny<string>())).Returns(12);

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.GrandTotal.Should().Be(223);

        }

        [Ignore]
        [TestMethod]
        public void GetStockControlReport_QuandNexistePasDansStockTransaction_Erreur()
        {
            StockOrderLineOrderStock stockOrderLineOrderStock = GetHappyPathControlReportline();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            orderLine.IsActive = true;
            stockOrderLineOrderStock.OrderLines.Add(orderLine);

            MockStockService.Setup(test => test.GetStockTransaction()).Returns(stockOrderLineOrderStock.StockTransactions);
            MockDAOOrderLine.Setup(test => test.GetAll()).Returns(stockOrderLineOrderStock.OrderLines);

            IList<StockControlReportLine> rtn = InstanceTest.GetStockControlReport();
            rtn.Count.Should().Be(2);
            rtn[0].Problem.Should().Be(ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_NO_MATCH);
        }

        [Ignore]
        [TestMethod]
        public void GetStockControlReport_QuandQuantiteOrderLineEstDifferentDeStockTransaction_Erreur()
        {
            StockOrderLineOrderStock stockOrderLineOrderStock = GetHappyPathControlReportline();
            stockOrderLineOrderStock.OrderLines[0].Quantity = 11;

            MockStockService.Setup(test => test.GetStockTransaction()).Returns(stockOrderLineOrderStock.StockTransactions);
            MockDAOOrderLine.Setup(test => test.GetAll()).Returns(stockOrderLineOrderStock.OrderLines);
            IList<StockControlReportLine> rtn = InstanceTest.GetStockControlReport();
            rtn.Count.Should().Be(1);
            rtn[0].Problem.Should().Be(ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_ORDERLINE_QUANTITY_VS_TRANSACTION_NOT_EQUAL);
            rtn[0].StockTransactionQuantity.Should().Be("-1");
            rtn[0].OrderLineQuantity.Should().Be("11");
        }

        [Ignore]
        [TestMethod]
        public void GetStockControlReport_QuandQuantiteTransactionNexistePasDansOrderLine_Erreur()
        {
            StockOrderLineOrderStock stockOrderLineOrderStock = GetHappyPathControlReportline();
            stockOrderLineOrderStock.OrderLines.Clear();
            Order order = AutoFixture.Create<Order>();

            MockStockService.Setup(test => test.GetStockTransaction()).Returns(stockOrderLineOrderStock.StockTransactions);
            MockDAOOrderLine.Setup(test => test.GetAll()).Returns(stockOrderLineOrderStock.OrderLines);
            MockDAOOrder.Setup(test => test.GetOrderSimple(It.IsAny<int>())).Returns(order);
            IList<StockControlReportLine> rtn = InstanceTest.GetStockControlReport();
            rtn.Count.Should().Be(1);
            rtn[0].Problem.Should().Be(ErrorCode.MESSAGE_CONTROL_STOCK_ORDERLINE_TRANSACTION_NOT_EXISTS_IN_ORDERLINE);
            rtn[0].StockTransactionQuantity.Should().Be("-1");
            rtn[0].OrderLineQuantity.Should().Be(@"N\A");
        }

        [TestMethod]
        public void AddOrderLine_SiLALigneNexistePasOnAjoute()
        {
            Order order = AutoFixture.Create<Order>();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            order.OrderLines = null;
            Order rtn = InstanceTest.AddOrderLine(orderLine, order);
            rtn.OrderLines.Count.Should().Be(1);
            rtn.OrderLines[0].IsActive.Should().Be(true);
        }

        [TestMethod]
        public void AddOrderLine_SiLALigneExisteOnAjouteQuantite()
        {
            Order order = AutoFixture.Create<Order>();
            OrderLine orderLine1 = AutoFixture.Create<OrderLine>();
            OrderLine orderLine2 = AutoFixture.Create<OrderLine>();
            orderLine1.Quantity = 5;
            orderLine2.Quantity = 5;
            order.OrderLines.Clear();
            order.OrderLines.Add(orderLine1);
            orderLine2.Stock.Id = orderLine1.Stock.Id;
            Order rtn = InstanceTest.AddOrderLine(orderLine2, order);
            rtn.OrderLines.Count.Should().Be(1);
            rtn.OrderLines[0].Quantity.Should().Be(10);
        }

        [TestMethod]
        public void Save_SiAucunAdresseFacturationAuClientOnMetCelleChoisiDAnsCommande()
        {
            Order order = AutoFixture.Create<Order>();
            order.Customer.BillingAddress.ComboboxDescription = null;
            InstanceTest.Save(order);

            MockCustomerService.Verify(test => test.SaveCustomer(It.Is<Customer>(a => a.BillingAddress.Id == order.BillingAddress.Id)), Times.Once());

        }

        [TestMethod]
        public void Save_SiAucunAdresseLivraisonAuClientOnMetCelleChoisiDAnsCommande()
        {
            Order order = AutoFixture.Create<Order>();
            order.Customer.ShippingAddress.ComboboxDescription = null;
            InstanceTest.Save(order);

            MockCustomerService.Verify(test => test.SaveCustomer(It.Is<Customer>(a => a.ShippingAddress.Id == order.ShippingAddress.Id)), Times.Once());
        }

        [TestMethod]
        public void FinalizeOrderPaypal_DevraitRemplirLesVariablesCorrectement()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();
            Taxes taxes = AutoFixture.Create<Taxes>();
            Product product = AutoFixture.Create<Product>();

            MockDAOTaxes.Setup(test => test.GetTaxes(It.IsAny<int>())).Returns(taxes);
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("Ohé");
            InstanceTest.FinalizeOrderPaypal(order, shippingParameter);

            string productName = order.OrderLines.Aggregate(string.Empty, (current, line) => current + (line.ProductDescription + " (" + line.Quantity + ") , "));


            MockPaypalService.Verify(test => test.SendPaypalRequest(It.Is<PaypalDto>(a => a.Price == (double)order.GrandTotal)));
            MockPaypalService.Verify(test => test.SendPaypalRequest(It.Is<PaypalDto>(a => a.OrderId == order.Id.ToString())));
            MockPaypalService.Verify(test => test.SendPaypalRequest(It.Is<PaypalDto>(a => a.ProductName == productName.ToString())));
        }
       
        [TestMethod]
        public void CalculateTotal_QuandLeShippingEstInclus()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();
            
            Product product = AutoFixture.Create<Product>();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();

            orderLine.IsActive = true;
            orderLine.Quantity = 1;
            product.UnitPrice = 10;
            order.Enterprise.ShippingCostFixed = 0;
            
            orderLine.Stock.AdjustPrice = 1;
            order.OrderLines.Clear();
            order.OrderLines.Add(orderLine);

            MockTaxesService.Setup(test => test.GetCountryTaxes(It.IsAny<decimal>(),"CAN")).Returns(1);
            MockTaxesService.Setup(test => test.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(1);
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);
            MockShippingService.Setup(test => test.GetShippingTotal(It.IsAny<Order>(), It.IsAny<ShippingParameter>()))
                               .Returns(10);
            order.Enterprise.IsShippingManaged = true;
            order.Enterprise.IsShippingIncluded = true;
            order.Enterprise.IsShippingQuotationRequired = false;

            Order rtn = InstanceTest.CalculateTotal(order, "CAN", shippingParameter);

            rtn.GrandTotal.Should().Be(22);
        }

        [TestMethod]
        public void CalculateTotal_QuandLeShippingNEstPasInclus()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();

            Product product = AutoFixture.Create<Product>();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();

            orderLine.IsActive = true;
            orderLine.Quantity = 1;
            product.UnitPrice = 10;

            order.ShippingTotal = 10;
            orderLine.Stock.AdjustPrice = 1;
            order.OrderLines.Clear();
            order.OrderLines.Add(orderLine);

            MockTaxesService.Setup(test => test.GetCountryTaxes(It.IsAny<decimal>(), "CAN")).Returns(1);
            MockTaxesService.Setup(test => test.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(1);
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);

            order.Enterprise.IsShippingIncluded = false;
            order.Enterprise.IsShippingQuotationRequired = false;

            Order rtn = InstanceTest.CalculateTotal(order, "CAN", shippingParameter);

            rtn.GrandTotal.Should().Be(12);
        }



        private OrderTaxesShippingParameterTest CalculateTotalBasic()
        {
            Order order = AutoFixture.Create<Order>();
            order.ShippingTotal = 0;
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();
            Taxes taxes = AutoFixture.Create<Taxes>();
            Product product = AutoFixture.Create<Product>();
            product.UnitPrice = 10;
            product.Weight = 10;
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            orderLine.Quantity = 10;
            orderLine.Stock.AdjustPrice = 10;
            orderLine.IsActive = true;
            order.IsActive = true;
            order.OrderLines.Clear();
            order.OrderLines.Add(orderLine);
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);

            return new OrderTaxesShippingParameterTest { Order = order, ShippingParameter = shippingParameter, Taxes = taxes };
        }
        private StockOrderLineOrderStock GetHappyPathControlReportline()
        {
            Address address = AutoFixture.Create<Address>();
            StockTransaction stockTransaction = AutoFixture.Create<StockTransaction>();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            Order order = AutoFixture.Create<Order>();
            order.IsActive = true;
            orderLine.IsActive = true;
            Stock stock = AutoFixture.Create<Stock>();
            stock.Id = 1;
            order.Id = 1;
            orderLine.Order = order;
            orderLine.Stock = stock;
            orderLine.Quantity = 1;

            stockTransaction.Transaction = -1;
            stockTransaction.Order = order;
            stockTransaction.Stock = stock;

            MockDAOOrder.Setup(test => test.GetOrder(It.IsAny<int>())).Returns(order);
            MockStockService.Setup(test => test.GetStock(It.IsAny<int>())).Returns(stock);
            MockAddressService.Setup(test => test.GetAddress(It.IsAny<int>())).Returns(address);

            IList<StockTransaction> stockTransactions = new List<StockTransaction>();
            stockTransactions.Add(stockTransaction);
            IList<OrderLine> orderLines = new List<OrderLine>();
            orderLines.Add(orderLine);

            return new StockOrderLineOrderStock { OrderLines = orderLines, StockTransactions = stockTransactions };
        }
        public class StockOrderLineOrderStock
        {
            public IList<StockTransaction> StockTransactions { get; set; }
            public IList<OrderLine> OrderLines { get; set; }
        }
        public class OrderTaxesShippingParameterTest
        {
            public Order Order { get; set; }
            public Taxes Taxes { get; set; }
            public ShippingParameter ShippingParameter { get; set; }
        }

    }
}


