using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View.Francais
{
    [TestClass]
    public class MerciCommandePresenterTest : BaseTest<MerciCommandePresenter>
    {
        public Mock<IMerciCommandePresenter> ViewMock
        {
            get { return ObtenirMock<IMerciCommandePresenter>(); }
        }


        [TestMethod]
        public void ImprimerCommande_DoitImprimerLacommandePasse()
        {
            Order order = AutoFixture.Create<Order>();

            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommande(It.IsAny<int>())).Returns(order);

            InstanceTest.ImprimerCommande();

            ObtenirMock<ICommandeService>().Verify(x => x.ImprimerCommande(order));
        }

        [TestMethod]
        public void AfficherCommande_RempliCommandeAAfficher()
        {

            Order order = AutoFixture.Create<Order>();
            Customer customer = AutoFixture.Create<Customer>();
            order.Customer = customer;

            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommande(It.IsAny<int>())).Returns(order);

            InstanceTest.AfficherCommande();
            ViewMock.VerifySet(x => x.Commande = order);
        }


        [TestMethod]
        public void AfficherCommande_SiLeClientLoggeNestPasLeMemeQueCommandeOnRedirigeALaccueil()
        {

            Order order = AutoFixture.Create<Order>();
            Customer customer = AutoFixture.Create<Customer>();
          
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommande(It.IsAny<int>())).Returns(order);

            InstanceTest.AfficherCommande();
            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        }

    }
}