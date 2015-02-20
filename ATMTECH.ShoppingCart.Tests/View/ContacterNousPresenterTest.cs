using ATMTECH.Entities;
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
    public class ContacterNousPresenterTest : BaseTest<ContacterNousPresenter>
    {
        public Mock<IContacterNousPresenter> ViewMock
        {
            get { return ObtenirMock<IContacterNousPresenter>(); }
        }

        [TestMethod]
        public void OnViewInitialized_DevraitRemplirCourrielAutomatiquementSiAuthentifie()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<ICustomerService>().Setup(x => x.AuthenticateCustomer).Returns(customer);

            InstanceTest.OnViewInitialized();

            ViewMock.VerifySet(x => x.Courriel = customer.User.Email);
        }

        [TestMethod]
        public void EnvoyerMessage_EnvoiCourrielAAdministrateurAvecTexteSaisieParClient()
        {
            ViewMock.Setup(x => x.Courriel).Returns("test@test.com");
            ViewMock.Setup(x => x.Message).Returns("Je ne suis pas satisfait du tout !");
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(Constant.ADMIN_MAIL)).Returns("admin@admin.com");
            InstanceTest.EnvoyerMessage();

            ObtenirMock<IMailService>().Verify(x => x.SendEmail(It.Is<string>(a => a == "admin@admin.com"),
                It.Is<string>(a => a == "test@test.com"), It.IsAny<string>(), It.Is<string>(a => a == "Je ne suis pas satisfait du tout !")));
        }


    }
}
