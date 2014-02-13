using System;
using System.Collections;
using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Shell.Tests;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.ShoppingCart.Tests.Builder;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.ShoppingCart.Tests.Services
{
    [TestClass]
    public class OrderServiceTest : BaseTest<OrderService>
    {
        public Mock<IDAOEnumOrderInformation> MockDAOEnumOrderInformation { get { return ObtenirMock<IDAOEnumOrderInformation>(); } }
        public Mock<IDAOTaxes> MockDAOTaxes { get { return ObtenirMock<IDAOTaxes>(); } }
        public Mock<IDAOOrder> MockDAOOrder { get { return ObtenirMock<IDAOOrder>(); } }
        public Mock<IShippingService> MockShippingService { get { return ObtenirMock<IShippingService>(); } }

        [TestMethod]
        public void GetOrderInformationDoitRetournerUneListeAvecUnBlancEnPremier()
        {
            IList<EnumOrderInformation> enumOrderInformations = new List<EnumOrderInformation>();
            enumOrderInformations.Add(new EnumOrderInformation(){Code = "A"});
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
        public void test()
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
                    It.Is<Order>(test =>test.GrandTotal == 200)));

        }



    }
}

