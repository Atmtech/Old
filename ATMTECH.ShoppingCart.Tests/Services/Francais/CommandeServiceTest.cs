using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.Services.Francais
{
    [TestClass]
    public class CommandeServiceTest : BaseTest<CommandeService>
    {
        [TestMethod]
        public void CreerCommande_ValiderClientSinonRetournNull()
        {
            Order creerCommande = InstanceTest.CreerCommande();
            Assert.IsNull(creerCommande);
        }

        [TestMethod]
        public void CreerCommande_SiClientAuthentifieOnEnregistreAvecUneCommandeWishList()
        {

            Customer client = LeClientEstValide();

            Order creerCommande = InstanceTest.CreerCommande();

            Assert.AreEqual(OrderStatus.IsWishList, creerCommande.OrderStatus);
            Assert.AreEqual(client.Enterprise, creerCommande.Enterprise);
            Assert.AreEqual(client, creerCommande.Customer);
        }

        [TestMethod]
        public void AjouterLigneCommande_ValiderClientSinonRetournNull()
        {
            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(1, 1);
            Assert.IsNull(ajouterLigneCommande);
        }

        [TestMethod]
        public void AjouterLigneCommande_ObtenirLaCommandeSouhaiteSiEstNullOnCreerUneNouvelleCommande()
        {
            LeClientEstValide();
            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(20100, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
            Assert.AreEqual(20100, ajouterLigneCommande.OrderLines[0].Stock.Id);
        }

        [TestMethod]
        public void AjouterLigneCommande_ObtenirLaCommandeSouhaiteSiNestPasNullOnAjoute()
        {
            Customer client = LeClientEstValide();
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            order.Customer = client;
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommandeSouhaite(client)).Returns(order);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(20100, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
        }

        [TestMethod]
        public void AjouterLigneCommande_SiLigneCommandeExisteOnChangeLaQuantiteSeulement()
        {
            Customer client = LeClientEstValide();
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            order.OrderLines.Add(new OrderLine { Stock = new Stock { Id = 20100 }, Quantity = 5 });
            order.Customer = client;
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommandeSouhaite(client)).Returns(order);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(20100, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines[0].Quantity);
        }

        [TestMethod]
        public void CalculerTaxe_AffecteLaBonneValeurAuPaysEtRegion()
        {
            Order order = AutoFixture.Create<Order>();
            ObtenirMock<ITaxesService>().Setup(x => x.GetCountryTaxes(It.IsAny<decimal>(), "QBC")).Returns(200);
            ObtenirMock<ITaxesService>().Setup(x => x.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(100);
            Order commande = InstanceTest.CalculerTaxe(order);

            Assert.AreEqual(200, commande.CountryTax);
            Assert.AreEqual(100, commande.RegionalTax);
        }

        [TestMethod]
        public void CalculerTotal_DoitRecalculerLeGrandTotal()
        {
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            order.GrandTotal = 0;
            order.ShippingTotal = 0;
            order.CountryTax = 0;
            order.RegionalTax = 0;

            Product produit = AutoFixture.Create<Product>();
            order.OrderLines.Add(new OrderLine { Stock = new Stock { Product = produit }, Quantity = 1, IsActive = true });
            produit.UnitPrice = 200;
            produit.SalePrice = 0;
            produit.Weight = 12;

            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<ITaxesService>().Setup(x => x.GetCountryTaxes(It.IsAny<decimal>(), "QBC")).Returns(5);
            ObtenirMock<ITaxesService>().Setup(x => x.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(6);
            ObtenirMock<IShippingService>().Setup(x => x.GetShippingTotal(order, It.IsAny<ShippingParameter>())).Returns(50);

            Order calculerTotal = InstanceTest.CalculerTotal(order);

            Assert.AreEqual(261, calculerTotal.GrandTotal);
            Assert.AreEqual(12, calculerTotal.TotalWeight);
        }

        [TestMethod]
        public void CalculerEnvoiPostal_DoitAppelerService()
        {
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            order.GrandTotal = 0;
            order.SubTotal = 0;
            order.ShippingTotal = 0;
            order.CountryTax = 0;
            order.RegionalTax = 0;

            ObtenirMock<IShippingService>()
                .Setup(x => x.GetShippingTotal(order, It.IsAny<ShippingParameter>()))
                .Returns(50);
            Order calculerEnvoiPostal = InstanceTest.CalculerEnvoiPostal(order);
            Assert.AreEqual(50, calculerEnvoiPostal.ShippingTotal);
        }

        private Customer LeClientEstValide()
        {
            Customer client = AutoFixture.Create<Customer>();
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(client);
            ObtenirMock<IValiderCommandeService>().Setup(x => x.EstClientValide(It.IsAny<Customer>())).Returns(true);
            return client;
        }
    }
}
