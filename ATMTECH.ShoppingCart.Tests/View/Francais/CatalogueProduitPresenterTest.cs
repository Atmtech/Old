using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            ViewMock.Setup(x => x.Recherche).Returns("test");
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProduitService>().Verify(x => x.ObtenirProduit("test"));
        }

        [TestMethod]
        public void AfficherListeProduit_SiAucuneRechercheOnRenvoitTout()
        {
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProduitService>().Verify(x => x.ObtenirProduit());
        }
    }
}