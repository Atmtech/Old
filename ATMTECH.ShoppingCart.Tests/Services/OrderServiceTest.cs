using System.Collections.Generic;
using ATMTECH.Shell.Tests;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Tests.Builder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.Services
{
    [TestClass]
    public class OrderServiceTest : BaseTest<OrderService>
    {
        public Mock<IDAOEnumOrderInformation> MockDAOEnumOrderInformation { get { return ObtenirMock<IDAOEnumOrderInformation>(); } }
        public Mock<IDAOTaxes> MockDAOTaxes { get { return ObtenirMock<IDAOTaxes>(); } }
        public Mock<IDAOOrder> MockDAOOrder { get { return ObtenirMock<IDAOOrder>(); } }
        public Mock<IShippingService> MockShippingService { get { return ObtenirMock<IShippingService>(); } }
        public Mock<IProductService> MockProductService { get { return ObtenirMock<IProductService>(); } }
        public Mock<IValidateOrderService> MockValidateOrderService { get { return ObtenirMock<IValidateOrderService>(); } }
        public Mock<ITaxesService> MockTaxesService { get { return ObtenirMock<ITaxesService>(); } }

        [TestMethod]
        public void GetOrderInformationDoitRetournerUneListeAvecUnBlancEnPremier()
        {
            IList<EnumOrderInformation> enumOrderInformations = new List<EnumOrderInformation>();
            enumOrderInformations.Add(new EnumOrderInformation() { Code = "A" });
            enumOrderInformations.Add(new EnumOrderInformation() { Code = "B" });

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
        public void UpdateOrder_DEvraitSauvegarderBonneAffaire()
        {
            Taxes taxes = TaxesBuilder.CreateValid();
            Order order = OrderBuilder.CreateValid();
            order.Enterprise.IsShippingManaged = true;
            order.Enterprise.IsShippingIncluded = true;

            ShippingParameter shippingParameter = ShippingParameterBuilder.Create();
            MockDAOTaxes.Setup(test => test.GetTaxes(It.IsAny<int>())).Returns(taxes);
            MockShippingService.Setup(test => test.GetShippingTotal(It.IsAny<Order>(), It.IsAny<ShippingParameter>()))
                               .Returns(200);

            InstanceTest.UpdateOrder(order, shippingParameter);

            MockDAOOrder.Verify(v => v.UpdateOrder(
                    It.Is<Order>(test => test.GrandTotal == 200)));

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

            int rtn = InstanceTest.CreateOrder(order, shippingParameter);

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

            int rtn = InstanceTest.CreateOrder(order, shippingParameter);

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
            MockShippingService.Setup(test => test.GetShippingTotal(It.IsAny<Order>(), It.IsAny<ShippingParameter>()))
                               .Returns(123);

            Order rtn = InstanceTest.CalculateTotal(orderTaxesShippingParameterTest.Order, orderTaxesShippingParameterTest.Taxes.Type, orderTaxesShippingParameterTest.ShippingParameter);

            rtn.GrandTotal.Should().Be(323);

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

        [TestMethod]
        public void Test()
        {
            //AddOrderLine
        }

        private OrderTaxesShippingParameterTest CalculateTotalBasic()
        {
            Order order = AutoFixture.Create<Order>();
            ShippingParameter shippingParameter = AutoFixture.Create<ShippingParameter>();
            Taxes taxes = AutoFixture.Create<Taxes>();
            Product product = AutoFixture.Create<Product>();
            product.UnitPrice = 10;
            product.Weight = 10;
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            orderLine.Quantity = 10;
            orderLine.Stock.AdjustPrice = 10;
            order.OrderLines.Clear();
            order.OrderLines.Add(orderLine);
            MockProductService.Setup(test => test.GetProduct(It.IsAny<int>())).Returns(product);

            return new OrderTaxesShippingParameterTest() { Order = order, ShippingParameter = shippingParameter, Taxes = taxes };
        }


        public class OrderTaxesShippingParameterTest
        {
            public Order Order { get; set; }
            public Taxes Taxes { get; set; }
            public ShippingParameter ShippingParameter { get; set; }
        }

    }
}


