using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View
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
            Customer customer = AutoFixture.Create<Customer>();
            ViewMock.Setup(x => x.Recherche).Returns("test");
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProductService>().Verify(x => x.GetProducts(customer.Enterprise.Id, customer.User.Id, "test"));
        }

        [TestMethod]
        public void AfficherListeProduit_SiAucuneRechercheOnRenvoitTout()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);
            InstanceTest.AfficherListeProduit();
            ObtenirMock<IProductService>().Verify(x => x.GetProducts(customer.Enterprise.Id, customer.User.Id));
        }
    }
}