using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using It = Moq.It;
using Times = Moq.Times;

namespace ATMTECH.ShoppingCart.Tests.View.Francais
{
    [TestClass]
    public class PageMaitrePresenterTest : BaseTest<PageMaitrePresenter>
    {
        public Moq.Mock<IPageMaitrePresenter> ViewMock
        {
            get { return ObtenirMock<IPageMaitrePresenter>(); }
        }

        [TestMethod]
        public void EstSiteHorsLigne_DevraitRedirigerSurPageMaintenanceSiHorsLigne()
        {
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.IS_OFFLINE)).Returns("1");

            InstanceTest.EstSiteHorsLigne();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.MAINTENANCE));
        }

        [TestMethod]
        public void EstSiteHorsLigne_SINullOuRienOnFaitRien()
        {
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.IS_OFFLINE)).Returns((string)null);

            InstanceTest.EstSiteHorsLigne();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.MAINTENANCE), Times.Never());
        }

        [TestMethod]
        public void FermerSession_DoitFaireUnSignOutEtRedirigerAAccueil()
        {
            InstanceTest.FermerSession();

            ObtenirMock<IAuthenticationService>().Verify(x => x.SignOut(), Times.Once());
            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        }

        [TestMethod]
        public void AfficherInformation_SiClientEstNonAuthentifieOnFaitRien()
        {
            InstanceTest.AfficherInformation();

            ObtenirMock<IOrderService>()
                .Verify(x => x.GetGrandTotalFromOrderWishList(It.IsAny<Customer>()), Times.Never());
        }


        [TestMethod]
        public void AfficherInformation_SiClientEstAuthentifieOnRempliSonNom()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            Order order = AutoFixture.Create<Order>();
            order.Coupon = null;
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns(order);
            InstanceTest.AfficherInformation();
            ViewMock.VerifySet(x => x.NomClient = customer.User.FirstNameLastName);
        }



        [TestMethod]
        public void AfficherInformation_SiClientEstAuthentifieOnRempliEstConnecteAVrai()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.Coupon = null;
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns(order);
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);

            InstanceTest.AfficherInformation();
            ViewMock.VerifySet(x => x.EstConnecte = true);
        }

        [TestMethod]
        public void AfficherInformation_SiAucuneLigneCommandeOnAfficheRien()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.OrderLines.Clear();
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns(order);
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);

            InstanceTest.AfficherInformation();
            ViewMock.VerifySet(x => x.AffichagePanier = string.Empty);
        }


        [TestMethod]
        public void AfficherInformation_SiAucuneCommandeToutEstNull()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.GrandTotal = 0;
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns((Order)null);
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            InstanceTest.AfficherInformation();
            string format = string.Format("{0} - {1} item", order.GrandTotal, "0");
            ViewMock.VerifySet(x => x.AffichagePanier = format, Times.Never());
        }

        [TestMethod]
        public void AfficherInformation_DoitAfficheLangue()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.GrandTotal = 0;
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns((Order)null);
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            ObtenirMock<ILocalizationService>().Setup(x => x.CurrentLanguage).Returns("SWAAA");
            InstanceTest.AfficherInformation();
            
            ViewMock.VerifySet(x => x.AffichageLangue = "SWAAA", Times.Once());
        }



        [TestMethod]
        public void AfficherInformation_SiCouponOnAfficheCoupon()
        {
            Customer customer = AutoFixture.Create<Customer>();
            Order order = AutoFixture.Create<Order>();
            order.GrandTotal = 0;
            ObtenirMock<ICommandeService>().Setup(x => x.ObtenirCommandeSouhaite(customer)).Returns(order);
            ObtenirMock<IClientService>().Setup(x => x.ClientAuthentifie).Returns(customer);
            InstanceTest.AfficherInformation();
            string format = string.Format("{0} - {1} item(s)", order.GrandTotalWithCoupon.ToString("C"), order.OrderLines.Count);
            ViewMock.VerifySet(x => x.AffichagePanier = format, Times.Once());
        }


        [TestMethod]
        public void RejoindreListeDiffusion_DoitSauvegarderAvecLECourrielDeLaCase()
        {
            ViewMock.Setup(x => x.CourrielListeDiffusion).Returns("caca");
            InstanceTest.RejoindreListeDiffusion();
            ObtenirMock<IDAOListeDistribution>().Verify(x => x.Save(It.Is<MailingList>(a => a.Email == "caca")));
        }

        [TestMethod]
        public void MettreSiteEnFrancais()
        {
            InstanceTest.MettreSiteEnFrancais();
            ObtenirMock<ILocalizationService>().VerifySet(x => x.CurrentLanguage = LocalizationLanguage.FRENCH);
        }

        [TestMethod]
        public void MettreSiteEnAnglais()
        {
            InstanceTest.MettreSiteEnAnglais();
            ObtenirMock<ILocalizationService>().VerifySet(x => x.CurrentLanguage = LocalizationLanguage.ENGLISH);
        }

    }
}