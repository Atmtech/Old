﻿using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Francais;
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
    public class PanierPresenterTest : BaseTest<PanierPresenter>
    {
        public Mock<IPanierPresenter> ViewMock
        {
            get { return ObtenirMock<IPanierPresenter>(); }
        }

        [TestMethod]
        public void AfficherPanier_SiPasIdentifieOnRedirigeALAccueil()
        {
            InstanceTest.AfficherPanier();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT));
        }


        [TestMethod]
        public void AfficherPanier_QuandIdentifierRetournerLaCommande()
        {
            Customer customer = AutoFixture.Create<Customer>();

            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherPanier();

            ObtenirMock<IOrderService>().Verify(x => x.GetWishListFromCustomer(customer));
        }

        [TestMethod]
        public void ModifierAdresse_DoitRedirigerVersInformationClient()
        {
            InstanceTest.ModifierAdresse();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.CUSTOMER_INFORMATION));
        }

        [TestMethod]
        public void ImprimerCommande_DoitImprimerLacommandePasse()
        {
            Order order = AutoFixture.Create<Order>();
            ViewMock.Setup(x => x.CommandeFinalise).Returns(order);


            InstanceTest.ImprimerCommande();

            ObtenirMock<IOrderService>().Verify(x => x.PrintOrder(order));
        }

        [TestMethod]
        public void FinaliserCommande_EnToutTempsFinalizeOrder()
        {
            Order order = AutoFixture.Create<Order>();

            ViewMock.Setup(x => x.Commande).Returns(order);

            InstanceTest.FinaliserCommande();

            ObtenirMock<IOrderService>().Verify(x => x.FinalizeOrder(order, null), Times.Once());
        }

        [TestMethod]
        public void FinaliserCommande_EnToutTempsRempliCommandeFinalise()
        {
            Order order = AutoFixture.Create<Order>();

            ViewMock.Setup(x => x.Commande).Returns(order);
            InstanceTest.FinaliserCommande();

            ViewMock.VerifySet(v => v.CommandeFinalise = order);
        }

        [TestMethod]
        public void RecalculerPanier_EnToutTempsSauvegardeLePanier()
        {
            Order order = AutoFixture.Create<Order>();
            Dictionary<int, int> listeQuantite = new Dictionary<int, int>();
            ViewMock.Setup(x => x.Commande).Returns(order);

            InstanceTest.RecalculerPanier(listeQuantite);

            ObtenirMock<IOrderService>().Verify(x => x.UpdateOrder(order, null), Times.Once());
        }

        [TestMethod]
        public void RecalculerPanier_EnToutTempsLanceAffichePanier()
        {
            Dictionary<int, int> listeQuantite = new Dictionary<int, int>();
            InstanceTest.RecalculerPanier(listeQuantite);
            ObtenirMock<ICustomerService>().Verify(x => x.AuthenticateCustomer, Times.Once());
        }

        [TestMethod]
        public void RecalculerPanier_EnToutTempsDevraitReajusterLesQuantitesCommandeAvecLeNouveauChiffre()
        {
            Dictionary<int, int> listeQuantite = new Dictionary<int, int>();
            listeQuantite.Add(0, 10);
            Order order = AutoFixture.Create<Order>();
            ViewMock.Setup(x => x.Commande).Returns(order);

            InstanceTest.RecalculerPanier(listeQuantite);

            ObtenirMock<IOrderService>()
                .Verify(x => x.UpdateOrder(It.Is<Order>(a => a.OrderLines[0].Quantity == 10), null));
        }
    }
}