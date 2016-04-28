using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Tests.Builder;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.FishingAtWork.Tests.Presenter
{
    [TestClass]
    public class NewTripPresenterTest : BaseTest<NewTripPresenter>
    {
        public Mock<ISiteService> MockSiteService { get { return ObtenirMock<ISiteService>(); } }
        public Mock<ITripService> MockTripService { get { return ObtenirMock<ITripService>(); } }
        public Mock<IPlayerService> MockPlayerService { get { return ObtenirMock<IPlayerService>(); } }
        public Mock<IPlayerLureService> MockPlayerLureService { get { return ObtenirMock<IPlayerLureService>(); } }
        public Mock<IEnumService<EnumWaypointTechniqueType>> MockEnumService { get { return ObtenirMock<IEnumService<EnumWaypointTechniqueType>>(); } }
        public Mock<IWaypointService> MockWaypointService { get { return ObtenirMock<IWaypointService>(); } }
        public Mock<ILureService> MockLureService { get { return ObtenirMock<ILureService>(); } }

        [TestMethod]
        public void OnViewInitialized_Verify()
        {

            InstanceTest.OnViewInitialized();
            MockSiteService.Verify(test => test.GetSiteList());
            MockPlayerLureService.Verify(test => test.GetLureList(It.IsAny<Player>()));

        }



    }
}
