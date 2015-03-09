using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View.Francais
{
    [TestClass]
    public class AccueilPresenterTest : BaseTest<AccueilPresenter>
    {
        public Mock<IAccueilPresenter> ViewMock
        {
            get { return ObtenirMock<IAccueilPresenter>(); }
        }

        [TestMethod]
        public void AfficherListeProduitEnVente_()
        {
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)).Returns("1");

            IList<Product> produits = AutoFixture.CreateMany<Product>().ToList();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEnVente(1)).Returns(produits);
            InstanceTest.AfficherListeProduitEnVente();

            ObtenirMock<IProduitService>().Verify(x=>x.ObtenirListeProduitEnVente(1), Times.Once());
        }
    }
}