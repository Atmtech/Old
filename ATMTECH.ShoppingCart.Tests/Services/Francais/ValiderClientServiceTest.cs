using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.ShoppingCart.Tests.Services.Francais
{
    [TestClass]
    public class ValiderClientServiceTest : BaseTest<ValiderClientService>
    {
        [TestMethod]
        public void EstCourrielValide_QuandInvalideRetourneFalseEtEnvoiMessage()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.User.Email = "tapoche";
            bool estCourrielValide = InstanceTest.EstCourrielValide(customer);
            estCourrielValide.Should().BeFalse();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(ErrorCode.SC_INVALID_EMAIL));
        }

        [TestMethod]
        public void EstCourrielValide_REtourneVraiQuandValide()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.User.Email = "tapoche@test.cp";
            bool estCourrielValide = InstanceTest.EstCourrielValide(customer);
            estCourrielValide.Should().BeTrue();
        }

        [TestMethod]
        public void EstClientExistant_QuandExisteRetourneVrai()
        {
             Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(customer.User.Login)).Returns(customer.User);
            bool estClientExistant = InstanceTest.EstClientExistant(customer);
            estClientExistant.Should().BeTrue();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(ErrorCode.SC_THIS_USER_ALREADY_EXIST));
        }

        [TestMethod]
        public void EstClientExistant_QuandExistePasRetourneFalse()
        {
            Customer customer = AutoFixture.Create<Customer>();
            ObtenirMock<IDAOUser>().Setup(x => x.GetUser(customer.User.Login)).Returns((User) null);
            bool estClientExistant = InstanceTest.EstClientExistant(customer);
            estClientExistant.Should().BeFalse();
        }
        [TestMethod]
        public void EstNomUtilisateurValide_SiVideREtourneFalseEtmmessage()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.User.Login = string.Empty;
            bool estNomUtilisateurValide = InstanceTest.EstNomUtilisateurValide(customer);
            estNomUtilisateurValide.Should().BeFalse();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY));
        }

        [TestMethod]
        public void EstNomUtilisateurValide_RetourneVrai()
        {
            Customer customer = AutoFixture.Create<Customer>();
            bool estNomUtilisateurValide = InstanceTest.EstNomUtilisateurValide(customer);
            estNomUtilisateurValide.Should().BeTrue();
        }

        [TestMethod]
        public void EstMotPasseValide_RetourneVrai()
        {
            Customer customer = AutoFixture.Create<Customer>();
            bool estNomUtilisateurValide = InstanceTest.EstMotPasseValide(customer);
            estNomUtilisateurValide.Should().BeTrue();
        }

        [TestMethod]
        public void EstMotPasseValide_RetourneFaux()
        {
            Customer customer = AutoFixture.Create<Customer>();
            customer.User.Password = string.Empty;
            bool estNomUtilisateurValide = InstanceTest.EstMotPasseValide(customer);
            estNomUtilisateurValide.Should().BeFalse();
            ObtenirMock<IMessageService>().Verify(x => x.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY));
        }
    }
}
