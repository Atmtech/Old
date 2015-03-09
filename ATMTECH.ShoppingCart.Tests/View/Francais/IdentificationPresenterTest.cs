using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
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
    [Ignore]
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

        [TestMethod]
        public void Identification_DoitDoitAllerSurLaPageDaccueilSurReussite()
        {
            User user = AutoFixture.Create<User>();

            ObtenirMock<IAuthenticationService>()
                .Setup(x => x.SignIn(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user);

            InstanceTest.Identification();

            ObtenirMock<INavigationService>().Verify(x => x.Redirect(Pages.DEFAULT), Times.Once());
        }

        [TestMethod]
        public void CreationUtilisateur_SiCourrielEstInexistantLancerErreur()
        {
            ViewMock.Setup(x => x.MotPasseCreation).Returns("zzz");
            InstanceTest.CreerUtilisateur();
            ObtenirMock<IMessageService>()
                .Verify(x => x.ThrowMessage(ErrorCode.ADM_CREATE_USER_MANDATORY), Times.Once());
        }

        [TestMethod]
        public void CreationUtilisateur_SiMotPasseEstInexistantLancerErreur()
        {
            ViewMock.Setup(x => x.CourrielCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseCreation).Returns("");
            InstanceTest.CreerUtilisateur();
            ObtenirMock<IMessageService>()
                .Verify(x => x.ThrowMessage(ErrorCode.ADM_CREATE_USER_MANDATORY), Times.Once());
        }

        [TestMethod]
        public void CreationUtilisateur_SiMotPasseEstDifferentConfirmationLancerErreur()
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
        public void CreationUtilisateur_SitoutEstOkOnCreerUtilisateurEtClient()
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

            ObtenirMock<ICustomerService>()
                .Verify(test => test.CreateCustomer(It.Is<Customer>(a => a.Enterprise.Id == 1)), Times.Once());
            ObtenirMock<ICustomerService>()
                .Verify(test => test.CreateCustomer(It.Is<Customer>(a => a.User.FirstName == "test")), Times.Once());
            ObtenirMock<ICustomerService>()
                .Verify(test => test.CreateCustomer(It.Is<Customer>(a => a.User.Password == "test")), Times.Once());
        }

        [TestMethod]
        public void CreationUtilisateur_SiCreationDuClientEstOkMessageSucces()
        {
            ViewMock.Setup(x => x.PrenomCreation).Returns("test");
            ViewMock.Setup(x => x.NomCreation).Returns("test");
            ViewMock.Setup(x => x.CourrielCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseCreation).Returns("test");
            ViewMock.Setup(x => x.MotPasseConfirmationCreation).Returns("test");
            ObtenirMock<ICustomerService>()
                .Setup(x => x.CreateCustomer(It.IsAny<Customer>()))
                .Returns(true);

            InstanceTest.CreerUtilisateur();

            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(ErrorCode.ADM_CREATE_SUCCESS), Times.Once());
        }

       
    }
}