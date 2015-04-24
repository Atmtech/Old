using System.Collections.Generic;
using System.Linq;
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
    public class CatalogueProduitPresenterTest : BaseTest<CatalogueProduitPresenter>
    {
        public Mock<ICatalogueProduitPresenter> ViewMock
        {
            get { return ObtenirMock<ICatalogueProduitPresenter>(); }
        }

        [TestMethod]
        public void AfficherListeProduit_SiAvecUneRechercheOnDoitFiltrerAvec()
        {
            IList<Product> products = AutoFixture.CreateMany<Product>(3).ToList();
            ViewMock.Setup(x => x.Recherche).Returns("test");
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduit("test")).Returns(products);
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProduitService>().Verify(x => x.ObtenirProduit("test"));
        }
        [TestMethod]
        public void AfficherListeProduit_SiAvecUneMarqueOnDoitFiltrerAvec()
        {
            IList<Product> products = AutoFixture.CreateMany<Product>(3).ToList();
            ViewMock.Setup(x => x.Marque).Returns("test");
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirProduitParMarque("test")).Returns(products);
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProduitService>().Verify(x => x.ObtenirProduitParMarque("test"));
        }


        [TestMethod]
        public void AfficherListeProduit_SiAucuneRechercheOnRetourneALaccueil()
        {
            InstanceTest.AfficherListeProduit();
            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT));
        }
    }
}