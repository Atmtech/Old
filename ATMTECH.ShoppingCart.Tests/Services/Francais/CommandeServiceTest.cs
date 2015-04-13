using System;
using ATMTECH.Common.Constant;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
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
            Product produit = AutoFixture.Create<Product>();
            Stock stock = AutoFixture.Create<Stock>();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<IDAOInventaire>().Setup(x => x.ObtenirInventaire(It.IsAny<int>())).Returns(stock);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(stock.Id, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
            Assert.AreEqual(stock.Id, ajouterLigneCommande.OrderLines[0].Stock.Id);
        }

        [TestMethod]
        public void AjouterLigneCommande_ObtenirLaCommandeSouhaiteSiNestPasNullOnAjoute()
        {
            Customer client = LeClientEstValide();
            Order order = AutoFixture.Create<Order>();
            Product produit = AutoFixture.Create<Product>();
            Stock stock = AutoFixture.Create<Stock>();
            order.OrderLines.Clear();
            order.Customer = client;
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommandeSouhaite(client)).Returns(order);
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<IDAOInventaire>().Setup(x => x.ObtenirInventaire(It.IsAny<int>())).Returns(stock);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(20100, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
        }

        [TestMethod]
        public void AjouterLigneCommande_OnAjouteToujoursUneLigneDeCommandeActive()
        {
            Customer client = LeClientEstValide();
            Order order = AutoFixture.Create<Order>();
            Product produit = AutoFixture.Create<Product>();
            Stock stock = AutoFixture.Create<Stock>();
            order.OrderLines.Clear();
            order.Customer = client;
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommandeSouhaite(client)).Returns(order);
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<IDAOInventaire>().Setup(x => x.ObtenirInventaire(It.IsAny<int>())).Returns(stock);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(20100, 1);
            ajouterLigneCommande.OrderLines[0].IsActive.Should().BeTrue();
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
            order.FinalizedDate = null;
            order.OrderLines.Clear();
            order.GrandTotal = 0;
            order.ShippingTotal = 0;
            order.CountryTax = 0;
            order.RegionalTax = 0;
            order.Coupon = null;

            Product produit = AutoFixture.Create<Product>();
            order.OrderLines.Add(new OrderLine { Stock = new Stock { Product = produit }, Quantity = 1, IsActive = true });
            produit.UnitPrice = 200;
            produit.SalePrice = 0;
            produit.Weight = 12;

            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<ITaxesService>().Setup(x => x.GetCountryTaxes(It.IsAny<decimal>(), "QBC")).Returns(5);
            ObtenirMock<ITaxesService>().Setup(x => x.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(6);
            ObtenirMock<IEnvoiPostalService>().Setup(x => x.ObtenirCotationPurolator(order)).Returns(50);

            Order calculerTotal = InstanceTest.CalculerTotal(order);

            Assert.AreEqual(261, calculerTotal.GrandTotal);
            Assert.AreEqual(12, calculerTotal.TotalWeight);
        }

        [TestMethod]
        public void CalculerTotal_RemplirGrandTotalAvecCouponQuandCouponExistantAvecPercentageSave()
        {
            Order order = AutoFixture.Create<Order>();
            order.FinalizedDate = null;
            order.OrderLines.Clear();
            order.GrandTotal = 0;
            order.ShippingTotal = 0;
            order.CountryTax = 0;
            order.RegionalTax = 0;
            order.Coupon.IsShippingSave = false;
            order.Coupon.PercentageSave = 10;

            Product produit = AutoFixture.Create<Product>();
            order.OrderLines.Add(new OrderLine { Stock = new Stock { Product = produit }, Quantity = 1, IsActive = true });
            produit.UnitPrice = 200;
            produit.SalePrice = 0;
            produit.Weight = 0;

            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<ITaxesService>().Setup(x => x.GetCountryTaxes(It.IsAny<decimal>(), "QBC")).Returns(0);
            ObtenirMock<ITaxesService>().Setup(x => x.GetRegionTaxes(It.IsAny<decimal>(), "QBC")).Returns(0);
            ObtenirMock<IShippingService>().Setup(x => x.GetShippingTotal(order, It.IsAny<ShippingParameter>())).Returns(0);

            Order calculerTotal = InstanceTest.CalculerTotal(order);

            Assert.AreEqual(180, calculerTotal.GrandTotalWithCoupon);

        }

        [TestMethod]
        public void CalculerTotal_DoitObtenirProduitDuStockAssocieALaLigneCommande()
        {
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            OrderLine orderLine = AutoFixture.Create<OrderLine>();
            orderLine.IsActive = true;
            order.OrderLines.Add(orderLine);

            ObtenirMock<IProduitService>()
                .Setup(x => x.ObtenirProduit(orderLine.Stock.Product.Id))
                .Returns(orderLine.Stock.Product);
            Order calculerTotal = InstanceTest.CalculerTotal(order);
            calculerTotal.OrderLines[0].Stock.Product.Id.Should().Be(orderLine.Stock.Product.Id);
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
            order.Coupon = null;

            ObtenirMock<IEnvoiPostalService>()
                .Setup(x => x.ObtenirCotationPurolator(order))
                .Returns(50);
            Order calculerEnvoiPostal = InstanceTest.CalculerEnvoiPostal(order);
            Assert.AreEqual(50, calculerEnvoiPostal.ShippingTotal);
        }

        [TestMethod]
        public void CalculerEnvoiPostal_SiUnCouponDitDannulerShippingOnMet0()
        {
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            order.GrandTotal = 0;
            order.SubTotal = 0;
            order.ShippingTotal = 0;
            order.CountryTax = 0;
            order.RegionalTax = 0;
            order.Coupon.IsShippingSave = true;

            ObtenirMock<IShippingService>()
                .Setup(x => x.GetShippingTotal(order, It.IsAny<ShippingParameter>()))
                .Returns(50);
            Order calculerEnvoiPostal = InstanceTest.CalculerEnvoiPostal(order);
            Assert.AreEqual(0, calculerEnvoiPostal.ShippingTotal);
        }


        [TestMethod]
        public void Enregistrer_DoitAffecterLeIdALaCommande()
        {
            Order order = AutoFixture.Create<Order>();
            Product produit = AutoFixture.Create<Product>();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            order.Id = 0;
            ObtenirMock<IDAOCommande>().Setup(x => x.Save(It.IsAny<Order>())).Returns(10);

            Order enregistrer = InstanceTest.Enregistrer(order);

            enregistrer.Id.Should().Be(10);
        }

        [TestMethod]
        public void CalculerTotal_NeDoitPasMettreAJourMontantQuandFinalise()
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
            order.FinalizedDate = DateTime.Now;
            InstanceTest.CalculerTotal(order);

            ObtenirMock<IProduitService>().Verify(x => x.ObtenirProduit(It.IsAny<int>()), Times.Never());
        }

        [TestMethod]
        public void SauvegarderLigneCommande_DoitAvoirLaCommandeDansSonInitialisation()
        {
            LeClientEstValide();
            Product produit = AutoFixture.Create<Product>();
            Stock stock = AutoFixture.Create<Stock>();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<IDAOInventaire>().Setup(x => x.ObtenirInventaire(It.IsAny<int>())).Returns(stock);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(stock.Id, 1);
            Assert.AreEqual(1, ajouterLigneCommande.OrderLines.Count);
            ajouterLigneCommande.OrderLines[0].Order.Id.Should().Be(ajouterLigneCommande.Id);
            Assert.AreEqual(stock.Id, ajouterLigneCommande.OrderLines[0].Stock.Id);
        }

        [TestMethod]
        public void AjouterLigneCommande_SiProduitEstEnRabaisOnPrendLeRabais()
        {
            LeClientEstValide();
            Product produit = AutoFixture.Create<Product>();
            produit.UnitPrice = 10;
            produit.SalePrice = 5;
            Stock stock = AutoFixture.Create<Stock>();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(It.IsAny<int>())).Returns(produit);
            ObtenirMock<IDAOInventaire>().Setup(x => x.ObtenirInventaire(It.IsAny<int>())).Returns(stock);

            Order ajouterLigneCommande = InstanceTest.AjouterLigneCommande(stock.Id, 1);
            Assert.AreEqual(5, ajouterLigneCommande.OrderLines[0].UnitPrice);
        }

        [TestMethod]
        public void FinaliserCommande_DoitMettreUneDateFinaliser()
        {
            Order order = AutoFixture.Create<Order>();
            order.FinalizedDate = null;
            order.OrderStatus = OrderStatus.IsWishList;

            Order finaliserCommande = InstanceTest.FinaliserCommande(order);

            if (finaliserCommande.FinalizedDate != null)
            {
                DateTime finalizedDate = (DateTime)finaliserCommande.FinalizedDate;
                finalizedDate.Year.Should().Be(DateTime.Now.Year);
            }
        }

        [TestMethod]
        public void ImprimerCommande_DevraitAvoirLesBonsParametre()
        {
            Order order = AutoFixture.Create<Order>();
            InstanceTest.ImprimerCommande(order);
            ObtenirMock<ILocalizationService>().Setup(x => x.CurrentLanguage).Returns(LocalizationLanguage.ENGLISH);
            ObtenirMock<IReportService>().Verify(x => x.GetReport(It.IsAny<ReportParameter>()));

            ObtenirMock<IReportService>().Verify(test => test.GetReport(It.Is<ReportParameter>(a => a.Assembly == "ATMTECH.ShoppingCart.Services")), Times.Once());
            ObtenirMock<IReportService>().Verify(test => test.GetReport(It.Is<ReportParameter>(a => a.DataSources.Count == 2)), Times.Once());
            ObtenirMock<IReportService>().Verify(test => test.GetReport(It.Is<ReportParameter>(a => a.DataSources[0].Nom == "dsCommande")), Times.Once());
            ObtenirMock<IReportService>().Verify(test => test.GetReport(It.Is<ReportParameter>(a => a.DataSources[1].Nom == "dsLigneCommande")), Times.Once());
            ObtenirMock<IReportService>().Verify(test => test.GetReport(It.Is<ReportParameter>(a => a.DataSources[1].Valeurs.Equals(order.OrderLines))), Times.Once());

        }

        [TestMethod]
        public void FinaliserCommande_DevraitMettreStatutAEstCommande()
        {
            Order order = AutoFixture.Create<Order>();
            order.FinalizedDate = null;
            order.OrderStatus = OrderStatus.IsWishList;

            InstanceTest.FinaliserCommande(order);

            ObtenirMock<IDAOCommande>().Verify(test => test.Save(It.Is<Order>(a => a.OrderStatus == OrderStatus.IsOrdered)), Times.Once());
        }

        [TestMethod]
        public void ObtenirCommandeSouhaite_TouteCommandeObtenuLorsqueAucuneAdresseDoitPrendreAdresseDuClient()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.ShippingAddress = null;
            order.BillingAddress = null;
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns(order);
            Order obtenirCommandeSouhaite = InstanceTest.ObtenirCommandeSouhaite(customer);
            obtenirCommandeSouhaite.ShippingAddress.Should().Be(customer.ShippingAddress);
            obtenirCommandeSouhaite.BillingAddress.Should().Be(customer.BillingAddress);
        }

        [TestMethod]
        public void AfficherCommande_DevraitSortirLeBonHtml()
        {
            Order commande = AutoFixture.Create<Order>();
            commande.OrderLines.Clear();
            OrderLine orderLine = new OrderLine { Quantity = 1, SubTotal = 10 };
            commande.OrderLines.Add(orderLine);
            ObtenirMock<IDAOCommande>().Setup(x => x.ObtenirCommande(It.IsAny<int>())).Returns(commande);

            string afficherCommande = InstanceTest.AfficherCommande(1);


            String html = "<table>";
            html += "<td></td><td>Qte</td><td></td>";
            foreach (OrderLine test in commande.OrderLines)
            {
                html += "<tr>";
                html += "<td>" + test.ProductDescription + "</td><td>" + test.Quantity + "</td><td>" + test.SubTotal.ToString("C") + "</td>";
                html += "</tr>";
            }

            html += "<tr><td></td><td>S-Total:</td><td>" + commande.SubTotal.ToString("C") + "</td></tr>";
            html += "<tr><td></td><td><b>G-Total:</td><td>" + commande.GrandTotal.ToString("C") + "</b></td></tr>";
            html += "</table>";

            afficherCommande.Should().Be(html);
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
