using System;
using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Exception;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.ErrorCode;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.FishingAtWork.Tests.Builder;
using ATMTECH.Shell.Tests;
using ATMTECH.Test;
using ATMTECH.Web.Services.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.FishingAtWork.Tests.Services
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class PlayerServiceTest : BaseTest<PlayerService>
    {
        public Mock<IDAOPlayer> MockDAOPlayer { get { return ObtenirMock<IDAOPlayer>(); } }
        public Mock<IMailService> MockMailService { get { return ObtenirMock<IMailService>(); } }
        public Mock<IParameterService> MockParameterService { get { return ObtenirMock<IParameterService>(); } }

        public Mock<IValidatePlayerService> MockValidatePlayerService { get { return ObtenirMock<IValidatePlayerService>(); } }
        public Mock<IDAOUser> MockDAOUser { get { return ObtenirMock<IDAOUser>(); } }

        private Player _player;

        [TestInitialize]
        public void init()
        {
            _player = PlayerBuilder.CreateValid();
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(_player.User);
        }
        [TestMethod]
        public void CreatePlayer_ValidatePlayerCalled()
        {
            InstanceTest.CreatePlayer(_player);
            MockValidatePlayerService.Verify(test => test.IsValidPlayerOnCreate(It.IsAny<Player>()));
        }


        [TestMethod]
        public void CreatePlayer_MoneySetTo100()
        {
            InstanceTest.CreatePlayer(_player);
            _player.Money.Should().BeGreaterOrEqualTo(100);
        }

        [TestMethod]
        public void CreatePlayer_WayPointSetTo3()
        {
            InstanceTest.CreatePlayer(_player);
            _player.MaximumWaypoint.Should().BeGreaterOrEqualTo(3);
        }

        [TestMethod]
        public void CreatePlayer_SetUserInactive()
        {
            InstanceTest.CreatePlayer(_player);
            _player.User.IsActive.Should().BeFalse();
        }

        [TestMethod]
        public void CreatePlayer_SaveUserInactive()
        {
            InstanceTest.CreatePlayer(_player);
            MockDAOUser.Verify(test => test.UpdateUser(_player.User));
        }

        [TestMethod]
        public void CreatePlayer_CreateUser_Called()
        {
            InstanceTest.CreatePlayer(_player);
            MockDAOUser.Verify(test => test.CreateUser(_player.User));
        }

        [TestMethod]
        public void CreatePlayer_CreateUserSucess_CallMailService()
        {
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("");
            MockDAOPlayer.Setup(test => test.CreatePlayer(It.IsAny<Player>())).Returns(1);
            InstanceTest.CreatePlayer(_player);
            MockMailService.Verify(test => test.SendEmail(_player.User.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
            MockParameterService.Verify(test => test.GetValue(Constant.ADMIN_MAIL));
            MockParameterService.Verify(test => test.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE));
            MockParameterService.Verify(test => test.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE));
        }

        [TestMethod]
        public void CreatePlayer_CreateUserSucessAndMailServiceFailed_ThrowException()
        {
            MockParameterService.Setup(test => test.GetValue(It.IsAny<string>())).Returns("");
            MockDAOPlayer.Setup(test => test.CreatePlayer(It.IsAny<Player>())).Returns(1);
            MockMailService.Setup(
                test => test.SendEmail(_player.User.Email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).
                Returns(false);

            InstanceTest.CreatePlayer(_player);

            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_SEND_MAIL_FAILED));

        }


        [TestMethod]
        public void ConfirmCreate_GetUserReturnNull_throwMessage()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns((User)null);

            InstanceTest.ConfirmCreate(It.IsAny<int>());

            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM));
        }

        [TestMethod]
        public void ConfirmCreate_GetUserIsActive_TrueAndSave()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(_player.User);

            InstanceTest.ConfirmCreate(It.IsAny<int>());

            _player.User.IsActive.Should().BeTrue();
            MockDAOUser.Verify(test => test.UpdateUser(_player.User));
        }


        [TestMethod]
        public void ConfirmCreate_SuccessReturnTrue()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(_player.User);

            bool ret = InstanceTest.ConfirmCreate(It.IsAny<int>());
            ret.Should().BeTrue();
        }

        [TestMethod]
        public void ConfirmCreate_FailedReturnFalse()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns((User)null);

            bool ret = InstanceTest.ConfirmCreate(It.IsAny<int>());
            ret.Should().BeFalse();
        }

        [TestMethod]
        public void SavePlayer_ShouldValidate()
        {
            InstanceTest.SavePlayer(_player);
            MockValidatePlayerService.Verify(test=>test.IsValidPlayerOnUpdate(_player));
        }


        [TestMethod]
        public void DeletePlayer_SetInactive()
        {
            InstanceTest.DeletePlayer(_player);
            _player.IsActive.Should().BeFalse();
        }
    }
}
