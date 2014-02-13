using System;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.Services
{
    [TestClass]
    public class UtilisateurServiceTest : BaseTest<UtilisateurService>
    {
        public Mock<IDAOUser> MockDAOUser { get { return ObtenirMock<IDAOUser>(); } }
        public Mock<IDAOAmitie> MockDAOAmitie { get { return ObtenirMock<IDAOAmitie>(); } }

        [TestMethod]
        public void Creer_SiObjetEstNull_RetourneFaux()
        {
            bool ret = InstanceTest.Creer(null);
            ret.Should().BeFalse();
        }

        [TestMethod]
        public void Creer_SiObjetNEstPasNull_RetourneVrai()
        {
            User user = AutoFixture.Create<User>();
            MockDAOUser.Setup(test => test.CreateUser(user)).Returns(0);
            MockMailService.Setup(
                test => test.SendEmail(user.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(true);
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("Youppi");

            bool ret = InstanceTest.Creer(user);
            ret.Should().BeTrue();
        }

        [TestMethod]
        public void Creer_SiSendMailREtourneFaux_Throw()
        {
            User user = AutoFixture.Create<User>();
            MockDAOUser.Setup(test => test.CreateUser(user)).Returns(0);
            MockMailService.Setup(
                test => test.SendEmail(user.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(false);
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("Youppi");

            bool ret = InstanceTest.Creer(user);

            MockMessageService.Verify(test => test.ThrowMessage(Common.ErrorCode.ADM_SEND_MAIL_FAILED));
            ret.Should().BeFalse();
        }

        [TestMethod]
        public void Creer_SiCreerOk_EnvoiCourriel()
        {
            User user = AutoFixture.Create<User>();
            MockDAOUser.Setup(test => test.CreateUser(user)).Returns(0);
            MockMailService.Setup(
                test => test.SendEmail(user.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                           .Returns(false);
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("Youppi");

            bool ret = InstanceTest.Creer(user);

            MockMailService.Verify(test => test.SendEmail(user.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            ret.Should().BeFalse();
        }

        [TestMethod]
        public void ConfirmerCreation_SiIsActiveFalse_REtourneVrai()
        {
            User user = AutoFixture.Create<User>();
            user.IsActive = false;

            bool ret = InstanceTest.ConfirmerCreation(user);

            ret.Should().BeTrue();
        }

        [TestMethod]
        public void ConfirmerCreation_SiIsActiveFalse_DoitFaireUneSauvegardeActive()
        {
            User user = AutoFixture.Create<User>();
            user.IsActive = false;

            bool ret = InstanceTest.ConfirmerCreation(user);

            MockDAOUser.Verify(s => s.UpdateUser(It.Is<User>(it => it.IsActive)));

        }

        [TestMethod]
        public void ConfirmerCreation_SiIsActiveFalse_DoitSauthentifierAutomatiquement()
        {
            User user = AutoFixture.Create<User>();
            user.IsActive = false;

            bool ret = InstanceTest.ConfirmerCreation(user);

            MockDAOUser.Verify(s => s.UpdateUser(It.Is<User>(it => it.IsActive)));

            MockAuthenticationService.Verify(test => test.SignIn(user.Login, user.Password));


        }

        [TestMethod]
        public void ConfirmerCreation_SiUtilisateurNull_Throw()
        {
            User user = null;


            bool ret = InstanceTest.ConfirmerCreation(user);

            MockMessageService.Verify(test => test.ThrowMessage(Common.ErrorCode.ADM_USER_NOT_EXIST_ON_CONFIRM));

            ret.Should().BeFalse();

        }

        [TestMethod]
        public void DemandeAmitie_DoitCreerDemande_NonConfirme()
        {
            User userMoi = AutoFixture.Create<User>();
            User userAmi = AutoFixture.Create<User>();

            InstanceTest.DemandeAmitie(userMoi, userAmi);

            MockDAOAmitie.Verify(x => x.Update(It.Is<Amitie>(it => it.EstConfirme == false)));
        }

        [TestMethod]
        public void ConfirmerAmitie_DoitMettre_Confirme()
        {
            User userMoi = AutoFixture.Create<User>();
            User userAmi = AutoFixture.Create<User>();

            Amitie amitie = new Amitie { Ami = userAmi, Utilisateur = userMoi, EstConfirme = false };

            InstanceTest.ConfirmerAmitie(amitie);

            MockDAOAmitie.Verify(x => x.Update(It.Is<Amitie>(it => it.EstConfirme)));
        }
    }
}
