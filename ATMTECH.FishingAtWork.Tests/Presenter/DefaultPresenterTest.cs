using ATMTECH.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Tests.Builder;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.Shell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.FishingAtWork.Tests.Presenter
{
    [TestClass]
    public class DefaultPresenterTest : BaseTest<DefaultPresenter>
    {
        public Mock<ISiteService> MockSiteService { get { return ObtenirMock<ISiteService>(); } }
        public Mock<ITripService> MockTripService { get { return ObtenirMock<ITripService>(); } }
        public Mock<IPlayerService> MockPlayerService { get { return ObtenirMock<IPlayerService>(); } }

        public Mock<IDAOUser> MockDAOUser { get { return ObtenirMock<IDAOUser>(); } }

        private Player _player;
        private Trip _trip;


        [TestInitialize]
        public void init()
        {
            _trip = TripBuilder.CreateValid();
            _player = PlayerBuilder.CreateValid();
            MockDAOUser.Setup(test => test.GetUser(It.IsAny<int>())).Returns(_player.User);
        }
        [TestMethod]
        public void OnViewLoaded()
        {
            MockTripService.Setup(test => test.GetTripToday(It.IsAny<Player>())).Returns(_trip);
            InstanceTest.OnViewLoaded();
            //InstanceTest.View.GoogleMapValue.Should().NotBeNull();
        }



    }
}
