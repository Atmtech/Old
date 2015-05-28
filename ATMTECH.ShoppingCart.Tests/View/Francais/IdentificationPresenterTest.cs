using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Test;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.View.Francais
{
    [TestClass]
    public class IdentificationPresenterTest : BaseTest<IdentificationPresenter>
    {
        public Mock<IIdentificationPresenter> ViewMock
        {
            get { return ObtenirMock<IIdentificationPresenter>(); }
        }

        [TestMethod]
        public void Identification_DoitLancerSignInAvecUtilisateurIdentificationEtMotPasseIdentification()
        {
            ViewMock.Setup(x => x.NomUtilisateurIdentification).Returns("Test");
            ViewMock.Setup(x => x.MotPasseIdentification).Returns("Test");

            InstanceTest.Identification();

            ObtenirMock<IAuthenticationService>().Verify(x => x.SignIn("Test", "Test"), Times.Once());
        }

        [TestMethod]
        public void Identification_DoitNeRienFaireSurEchecIdentification()
        {
            ObtenirMock<IAuthenticationService>()
                .Setup(x => x.SignIn(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((User) null);

            InstanceTest.Identification();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Never());
        }

        //[TestMethod]
        //public void Identification_DoitDoitAllerSurLaPageDaccueilSurReussite()
        //{
        //    User user = AutoFixture.Create<User>();

        //    ObtenirMock<IAuthenticationService>()
        //        .Setup(x => x.SignIn(It.IsAny<string>(), It.IsAny<string>()))
        //        .Returns(user);

        //    InstanceTest.Identification();

        //    ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        //}


        [TestMethod]
        public void CreerUtilisateur_SiMotPasseEstDifferentConfirmationLancerErreur()
        {
            ViewMock.Setup(x => x.CourrielCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmationCreation).Returns("xna");
            InstanceTest.CreerUtilisateur();
            ObtenirMock<IMessageService>()
                .Verify(x => x.ThrowMessage(ShoppingCart.Services.ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM),
                        Times.Once());
        }

        [TestMethod]
        public void CreerUtilisateur_SitoutEstOkOnCreerUtilisateurEtClient()
        {
            ViewMock.Setup(x => x.PrenomCreation).Returns("test");
            ViewMock.Setup(x => x.NomCreation).Returns("test");
            ViewMock.Setup(x => x.CourrielCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmationCreation).Returns("test");
            ObtenirMock<IParameterService>()
                .Setup(x => x.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))
                .Returns("1");

            InstanceTest.CreerUtilisateur();

            ObtenirMock<IClientService>()
                .Verify(test => test.Creer(It.Is<Customer>(a => a.Enterprise.Id == 1)), Times.Once());
            ObtenirMock<IClientService>()
                .Verify(test => test.Creer(It.Is<Customer>(a => a.User.FirstName == "test")), Times.Once());
            ObtenirMock<IClientService>()
                .Verify(test => test.Creer(It.Is<Customer>(a => a.User.Password == "test")), Times.Once());
        }

        [TestMethod]
        public void CreerUtilisateur_SiCreationDuClientEstOkMessageSucces()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ViewMock.Setup(x => x.PrenomCreation).Returns("test");
            ViewMock.Setup(x => x.NomCreation).Returns("test");
            ViewMock.Setup(x => x.CourrielCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmationCreation).Returns("test");
            ObtenirMock<IClientService>()
                .Setup(x => x.Creer(It.IsAny<Customer>()))
                .Returns(customer);

            InstanceTest.CreerUtilisateur();

            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(CodeErreur.ADM_CREATION_UTILISATEUR_EST_UN_SUCCES), Times.Once());
        }

       
    }
}