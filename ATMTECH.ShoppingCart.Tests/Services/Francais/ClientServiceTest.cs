using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.Services.Francais
{
    [TestClass]
    public class ClientServiceTest : BaseTest<ClientService>
    {
        [TestMethod]
        public void ClientConnecte_RetourneNullSiPasAuthentifie()
        {
            Customer clientAuthentifie = InstanceTest.ClientAuthentifie;
            Assert.IsNull(clientAuthentifie);
        }

        [TestMethod]
        public void ClientConnecte_RetourneClientSiAuthentifie()
        {
            User user = AutoFixture.Create<User>();
            Customer customer = AutoFixture.Create<Customer>();

            ObtenirMock<IAuthenticationService>().Setup(x => x.AuthenticateUser).Returns(user);
            ObtenirMock<IDAOClient>().Setup(x => x.ObtenirClient(user)).Returns(customer);
            Customer clientAuthentifie = InstanceTest.ClientAuthentifie;
            Assert.IsNotNull(clientAuthentifie);
        }

        [TestMethod]
        public void Creer_SiInvalideClientRetourneNull()
        {
            Customer client = AutoFixture.Create<Customer>();

            Customer customer = InstanceTest.Creer(client);

            Assert.IsNull(customer);
        }

        [TestMethod]
        public void Creer_DoitCreerUserInactif()
        {
            Customer client = AutoFixture.Create<Customer>();
            User user = AutoFixture.Create<User>();
            user.IsActive = true;
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(It.IsAny<int>())).Returns(user);
            ObtenirMock<IValiderClientService>().Setup(x => x.EstClientValide(It.IsAny<Customer>())).Returns(true);
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(It.IsAny<string>())).Returns("mensacre");
            ObtenirMock<IDAOClient>().Setup(x => x.ObtenirClient(It.IsAny<int>())).Returns(client);
            Customer customer = InstanceTest.Creer(client);
            customer.User.IsActive.Should().BeFalse();
        }

        [TestMethod]
        public void Creer_DoitEnvoyerCourriel()
        {
            Customer client = AutoFixture.Create<Customer>();
            User user = AutoFixture.Create<User>();
            user.IsActive = true;
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(It.IsAny<int>())).Returns(user);
            ObtenirMock<IValiderClientService>().Setup(x => x.EstClientValide(It.IsAny<Customer>())).Returns(true);
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(It.IsAny<string>())).Returns("mensacre");
            ObtenirMock<IDAOClient>().Setup(x => x.ObtenirClient(It.IsAny<int>())).Returns(client);
            
            Customer customer = InstanceTest.Creer(client);

            ObtenirMock<IMailService>().Verify(x => x.SendEmail(user.Email, "mensacre", "mensacre", "mensacre"), Times.Once());
        }

    }
}
