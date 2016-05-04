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
using ATMTECH.FishingAtWork.Services.Validate;
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
    public class ValidatePlayerServiceTest : BaseTest<ValidatePlayerService>
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
        public void IsValidPlayerOnCreate_ValidateIfUserAlreadyExist_throwMessageIfFound()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<string>())).Returns(_player.User);
            InstanceTest.IsValidPlayerOnCreate(_player);
            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_THIS_USER_ALREADY_EXIST));
        }

        [TestMethod]
        public void IsValidPlayerOnCreate_ValidateMail_ThrowMessageIfEmailInvalid()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<string>())).Returns((User)null);
            _player.User.Email = "badmail";
            InstanceTest.IsValidPlayerOnCreate(_player);
            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_INVALID_EMAIL));
        }


        [TestMethod]
        public void IsValidPlayerOnUpdate_ValidateMail_Called()
        {
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<string>())).Returns((User)null);
            _player.User.Email = "badmail";
            InstanceTest.IsValidPlayerOnUpdate(_player);
            MockMessageService.Verify(test => test.ThrowMessage(ErrorCode.SC_INVALID_EMAIL));
        }
    }
}
