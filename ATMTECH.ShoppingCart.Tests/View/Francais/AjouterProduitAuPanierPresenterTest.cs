using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
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
            ObtenirMock<IProduitService>().Verify(s => s.ObtenirProduit(10));
        }

        [TestMethod]
        public void AfficherProduit_DevraitEnvoyerALaVuProduit()
        {
            Product product = AutoFixture.Create<Product>();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit(10)).Returns(product);
            InstanceTest.AfficherProduit(10);
            ViewMock.VerifySet(v => v.Produit = product);
        }

        [TestMethod]
        public void AjouterLigneCommande_AjouterLigne()
        {
            InstanceTest.AjouterLigneCommande();
            ObtenirMock<ICommandeService>().Verify(x => x.AjouterLigneCommande(ViewMock.Object.Inventaire, ViewMock.Object.Quantite), Times.Once());
        }

        [TestMethod]
        public void GererAffichage_SiAucunUtilisateurConnecteImpossibleDeCommander()
        {
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns((Customer)null);
            InstanceTest.GererAffichage();
            ViewMock.VerifySet(v => v.EstPossibleDeCommander = false);
        }
    }
}