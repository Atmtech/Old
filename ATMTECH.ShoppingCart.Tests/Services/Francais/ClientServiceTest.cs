using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
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

            InstanceTest.Creer(client);
            ObtenirMock<IMailService>().Verify(x => x.SendEmail(user.Email, "mensacre", "mensacre", "mensacre"), Times.Once());
        }

        [TestMethod]
        public void Enregistrer_SiClientInvalideOnNEnregistrepas()
        {
            Customer client = AutoFixture.Create<Customer>();
            ObtenirMock<IValiderClientService>().Setup(x => x.EstClientValide(client)).Returns(false);
            InstanceTest.Enregistrer(client);
            ObtenirMock<IDAOClient>().Verify(x => x.Save(client), Times.Never());
        }

        [TestMethod]
        public void Enregistrer_SiClientInvalideOnEnregistre()
        {
            Customer client = AutoFixture.Create<Customer>();
            ObtenirMock<IValiderClientService>().Setup(x => x.EstClientValide(client)).Returns(true);
            InstanceTest.Enregistrer(client);
            ObtenirMock<IDAOClient>().Verify(x => x.Save(client), Times.Once());
        }

        [TestMethod]
        public void EstConfirme_SiAucunUserTrouveRetourneFalseEtThrow()
        {
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(1)).Returns((User)null);

            bool estConfirme = InstanceTest.EstConfirme(1);

            estConfirme.Should().BeFalse();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM), Times.Once());
        }

        [TestMethod]
        public void EstConfirme_SiUserDejaActiveOnRetourneFalseSansErreur()
        {
            User user = AutoFixture.Create<User>();
            user.IsActive = true;
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(1)).Returns(user);

            bool estConfirme = InstanceTest.EstConfirme(1);

            estConfirme.Should().BeFalse();

        }


        [TestMethod]
        public void EstConfirme_SiUserEstInactifOnLeReactiveEtOnLeConnecte()
        {
            User user = AutoFixture.Create<User>();
            user.IsActive = false;
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(1)).Returns(user);

            bool estConfirme = InstanceTest.EstConfirme(1);

            estConfirme.Should().BeTrue();

            ObtenirMock<IDAOUser>().Verify(x => x.UpdateUser(It.Is<User>(a => a.IsActive)));
            ObtenirMock<IAuthenticationService>().Verify(x => x.SignIn(user.Login, user.Password), Times.Once());

        }

        [TestMethod]
        public void EnvoyerMotPasseOublie_SiAucunRetrouveRetourneFalse()
        {
            bool envoyerMotPasseOublie = InstanceTest.EnvoyerMotPasseOublie("test");
            envoyerMotPasseOublie.Should().BeFalse();
        }

        [TestMethod]
        public void EnvoyerMotPasseOublie_SiClientPasRetrouveRetourneFalse()
        {
            User user = AutoFixture.Create<User>();
            ObtenirMock<IDAOUser>().Setup(x => x.GetUserByEmail("test")).Returns(user);

            bool envoyerMotPasseOublie = InstanceTest.EnvoyerMotPasseOublie("test");
            envoyerMotPasseOublie.Should().BeFalse();
        }

        [TestMethod]
        public void EnvoyerMotPasseOublie_EnvoiUnCourriel()
        {
            User user = AutoFixture.Create<User>();
            Customer customer = AutoFixture.Create<Customer>();

            ObtenirMock<IDAOUser>().Setup(x => x.GetUserByEmail("test")).Returns(user);
            ObtenirMock<IDAOClient>().Setup(x => x.ObtenirClient(user)).Returns(customer);
            ObtenirMock<IParameterService>().Setup(x => x.GetValue(It.IsAny<string>())).Returns("{0}{1}{2}");

            bool envoyerMotPasseOublie = InstanceTest.EnvoyerMotPasseOublie("test");

            ObtenirMock<IMailService>().Verify(x => x.SendEmail("test", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}
