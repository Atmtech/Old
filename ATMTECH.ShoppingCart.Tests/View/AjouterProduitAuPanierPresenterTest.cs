using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View
{
    [TestClass]
    public class AjouterProduitAuPanierPresenterTest : BaseTest<AjouterProduitAuPanierPresenter>
    {
        public Mock<IAjouterProduitAuPanierPresenter> ViewMock
        {
            get { return ObtenirMock<IAjouterProduitAuPanierPresenter>(); }
        }


        [TestMethod]
        public void AfficherProduit_QuandAucunIdProduitOnRedirigeALaccueil()
        {
            ViewMock.Setup(x => x.IdProduit).Returns(0);
            InstanceTest.OnViewInitialized();
            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        }

        [TestMethod]
        public void AfficherProduit_DevraitFaireAppelAGetProduct()
        {
            InstanceTest.AfficherProduit(10);
            ObtenirMock<IProductService>().Verify(s => s.GetProduct(10));
        }

        [TestMethod]
        public void AfficherProduit_DevraitEnvoyerALaVuProduit()
        {
            Product product = AutoFixture.Create<Product>();
            ObtenirMock<IProductService>().Setup(x => x.GetProduct(10)).Returns(product);
            InstanceTest.AfficherProduit(10);
            ViewMock.VerifySet(v => v.Produit = product);
        }

        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecStatutIsWishList()
        {
            Customer customer = AutoFixture.Create<Customer>();
            IList<Order> orders = new List<Order>();
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);

            InstanceTest.AjouterLigneCommande();

            ObtenirMock<IOrderService>().Verify(test => test.CreateOrder(It.Is<Order>(a => a.OrderStatus == OrderStatus.IsWishList), null), Times.Once());
        }

        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecBonClient()
        {
            Customer customer = AutoFixture.Create<Customer>();
            IList<Order> orders = new List<Order>();
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AjouterLigneCommande();
            ObtenirMock<IOrderService>().Verify(test => test.CreateOrder(It.Is<Order>(a => a.Customer == customer), null), Times.Once());
        }

        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecEntrepriseCourante()
        {
            Customer customer = AutoFixture.Create<Customer>();
            IList<Order> orders = new List<Order>();
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AjouterLigneCommande();
            ObtenirMock<IOrderService>().Verify(test => test.CreateOrder(It.Is<Order>(a => a.Enterprise == customer.Enterprise), null), Times.Once());
        }

        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecAdresseLivraisonDuClient()
        {
            Customer customer = AutoFixture.Create<Customer>();
            IList<Order> orders = new List<Order>();
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AjouterLigneCommande();
            ObtenirMock<IOrderService>().Verify(test => test.CreateOrder(It.Is<Order>(a => a.ShippingAddress == customer.ShippingAddress), null), Times.Once());
        }


        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecUneLigneCommandeAssocieAInventaireSelectionne()
        {
            IList<OrderLine> orderLines = new List<OrderLine>();
            IList<Order> orders = new List<Order>();
            Customer customer = AutoFixture.Create<Customer>();
            OrderLine orderLine = new OrderLine();
            Stock stock = AutoFixture.Create<Stock>();
            Order order = AutoFixture.Create<Order>();

            ViewMock.Setup(x => x.Inventaire).Returns(10);
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IStockService>().Setup(x => x.GetStock(10)).Returns(stock);
            ObtenirMock<IOrderService>().Setup(x => x.GetOrder(It.IsAny<int>())).Returns(order);

            orderLine.Stock = stock;
            orderLines.Add(orderLine);

            InstanceTest.AjouterLigneCommande();
            ObtenirMock<IOrderService>().Verify(test => test.AddOrderLine(It.Is<OrderLine>(a => a.Stock == stock), order), Times.Once());
        }

        [TestMethod]
        public void AjouterLigneCommande_SiAucuneCommandeActiveCreerUneCommandeAvecUneLigneCommandeAvecBonneQuantite()
        {
            IList<OrderLine> orderLines = new List<OrderLine>();
            IList<Order> orders = new List<Order>();
            Customer customer = AutoFixture.Create<Customer>();
            OrderLine orderLine = new OrderLine();
            Stock stock = AutoFixture.Create<Stock>();
            Order order = AutoFixture.Create<Order>();

            ViewMock.Setup(x => x.Inventaire).Returns(10);

            ViewMock.Setup(x => x.Quantite).Returns(101);

            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IStockService>().Setup(x => x.GetStock(10)).Returns(stock);
            ObtenirMock<IOrderService>().Setup(x => x.GetOrder(It.IsAny<int>())).Returns(order);

            orderLine.Stock = stock;
            orderLines.Add(orderLine);

            InstanceTest.AjouterLigneCommande();
            ObtenirMock<IOrderService>().Verify(test => test.AddOrderLine(It.Is<OrderLine>(a => a.Quantity == 101), order), Times.Once());
        }

        [TestMethod]
        public void AjouterLigneCommande_SiUneCommandeActiveOnAjouteUneLigneCommande()
        {
            Customer customer = AutoFixture.Create<Customer>();
            IList<Order> orders = new List<Order>();
            Order order = AutoFixture.Create<Order>();
            Stock stock = AutoFixture.Create<Stock>();

            order.OrderStatus = OrderStatus.IsWishList;

            ViewMock.Setup(x => x.Inventaire).Returns(10);
            ViewMock.Setup(x => x.Quantite).Returns(101);

            orders.Add(order);
            ObtenirMock<IDAOOrder>().Setup(x => x.GetOrderFromCustomer(customer, OrderStatus.IsWishList)).Returns(orders);
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            ObtenirMock<IOrderService>().Setup(x => x.GetOrder(It.IsAny<int>())).Returns(order);
            ObtenirMock<IStockService>().Setup(x => x.GetStock(10)).Returns(stock);

            InstanceTest.AjouterLigneCommande();

            ObtenirMock<IOrderService>().Verify(test => test.AddOrderLine(It.Is<OrderLine>(a => a.Quantity == 101), order), Times.Once());
            ObtenirMock<IOrderService>().Verify(test => test.AddOrderLine(It.Is<OrderLine>(a => a.Stock == stock), order), Times.Once());
        }

        [TestMethod]
        public void GererAffichage_SiAucunUtilisateurConnecteImpossibleDeCommander()
        {
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns((Customer) null);
            InstanceTest.GererAffichage();
            ViewMock.VerifySet(v => v.EstPossibleDeCommander = false);
        }

    }
}
