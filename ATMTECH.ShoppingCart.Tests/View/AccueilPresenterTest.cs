using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View
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
            IList<Product> products = AutoFixture.CreateMany<Product>(5).ToList();
            ObtenirMock<IProductService>().Setup(x => x.GetProducts(1)).Returns(products);

            IList<Product> liste = null;
            //ObtenirMock<IAccueilPresenter>().Setup(x => x.ListeProduitEnVente).Callback<IList<Product>>((a) =>{liste = a;});

            
            InstanceTest.AfficherListeProduitEnVente();

            //ViewMock.VerifySet(x => x.ListeProduitEnVente.Count() = 5);
        }
    }
}