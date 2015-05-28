using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
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
        public void AfficherListeProduitEnVente_ObtienLaListe()
        {
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)).Returns("1");

            IList<Product> produits = AutoFixture.CreateMany<Product>().ToList();
            ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEnVente(1)).Returns(produits);
            InstanceTest.AfficherListeProduitEnVente();

            ObtenirMock<IProduitService>().Verify(x => x.ObtenirListeProduitEnVente(1), Times.Once());
        }

        //[TestMethod]
        //public void AfficherListeProduitSlideShow_SeulementLesItemDePourcentage35SonPermis()
        //{
        //    ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)).Returns("1");
        //    IList<Product> produits = new List<Product>();
        //    IList<Product> produitsVide = new List<Product>();
        //    Product product1 = AutoFixture.Create<Product>();
        //    Product product2 = AutoFixture.Create<Product>();

        //    product1.UnitPrice = 100;
        //    product1.SalePrice = 50;

        //    product2.UnitPrice = 100;
        //    product2.SalePrice = 99;

        //    produits.Add(product1);
        //    produits.Add(product2);

        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEnVente(1)).Returns(produits);
        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEstSlideShow(1)).Returns(produitsVide);
        //    IList<Product> afficherListeProduitSlideShow = InstanceTest.AfficherListeProduitSlideShow();

        //    afficherListeProduitSlideShow.Count.Should().Be(1);
        //}

        //[TestMethod]
        //public void AfficherListeProduitSlideShow_SiProduitEstSlideShowOnLaffiche()
        //{
        //    ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)).Returns("1");
        //    IList<Product> produits = new List<Product>();
        //    IList<Product> produitsVide = new List<Product>();
        //    Product product1 = AutoFixture.Create<Product>();
        //    Product product2 = AutoFixture.Create<Product>();

        //    produits.Add(product1);
        //    produits.Add(product2);

        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEnVente(1)).Returns(produitsVide);
        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEstSlideShow(1)).Returns(produits);
        //    IList<Product> afficherListeProduitSlideShow = InstanceTest.AfficherListeProduitSlideShow();

        //    afficherListeProduitSlideShow.Count.Should().Be(2);
        //}


        //[TestMethod]
        //public void AfficherListeProduitSlideShow_SiSlideShiowEt35OnDedeboublePas()
        //{
        //    ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)).Returns("1");
        //    IList<Product> produits = new List<Product>();
        //    Product product1 = AutoFixture.Create<Product>();
        //    Product product2 = AutoFixture.Create<Product>();

        //    product1.UnitPrice = 100;
        //    product1.SalePrice = 50;

        //    product2.UnitPrice = 100;
        //    product2.SalePrice = 99;

        //    produits.Add(product1);
        //    produits.Add(product2);

        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEnVente(1)).Returns(produits);
        //    ObtenirMock<IProduitService>().Setup(x => x.ObtenirListeProduitEstSlideShow(1)).Returns(produits);
        //    IList<Product> afficherListeProduitSlideShow = InstanceTest.AfficherListeProduitSlideShow();

        //    afficherListeProduitSlideShow.Count.Should().Be(2);
        //}

       

    }
}