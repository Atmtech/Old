using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.FishingAtWork.Tests.Builder;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.FishingAtWork.Tests.Services
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class CatchServiceTest : BaseTest<CatchService>
    {
        public Mock<IRandomService> MockRandomService { get { return ObtenirMock<IRandomService>(); } }
        public Mock<IValidateCatchService> MockValidateCatchService { get { return ObtenirMock<IValidateCatchService>(); } }
        public Mock<IPlayerService> MockPlayerService { get { return ObtenirMock<IPlayerService>(); } }
        public Mock<IDAOSpeciesCatch> MockDAOSpeciesCatch { get { return ObtenirMock<IDAOSpeciesCatch>(); } }
        public Mock<IDAOSiteSpecies> MockDAOSiteSpecies { get { return ObtenirMock<IDAOSiteSpecies>(); } }

        public Player Vincent { get { return PlayerBuilder.Create().WithUser(UserBuilder.Create().WithLogin("Vincent")); } }
        public SiteSpecies SiteTruite { get { return SiteSpeciesBuilder.Create().WithArea(SetSiteSpeciesCoordinate()).WithSpecies(SpeciesBuilder.Create().WithName("Truite").WithMaximumExperience(5).WithMoneyRatio(10)); } }
        public SiteSpecies SiteSaumon { get { return SiteSpeciesBuilder.Create().WithArea(SetSiteSpeciesCoordinate()).WithSpecies(SpeciesBuilder.Create().WithName("Saumon").WithMaximumExperience(5).WithMoneyRatio(10)); } }

        [TestMethod]
        public void Catch_SiJai2Species_RetourneUnSpeciesCatchDe2()
        {
            Site site = SiteBuilder.Create().WithName("St-Laurent").AddSiteSpecies(SiteSaumon).AddSiteSpecies(SiteTruite);
            SetMockRandomServiceCoordinate(3, 2);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches.Count, 2);
        }

        [TestMethod]
        public void Catch_Site_RempliToujours()
        {
            Site site = SiteBuilder.Create().WithName("St-Laurent").AddSiteSpecies(SiteSaumon).AddSiteSpecies(SiteTruite);
            SetMockRandomServiceCoordinate(3, 2);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.IsNotNull(speciesCatches[0].Site);
        }

        [TestMethod]
        public void Catch_Species_RempliToujours()
        {
            Site site = SiteBuilder.Create().WithName("St-Laurent").AddSiteSpecies(SiteSaumon).AddSiteSpecies(SiteTruite);
            SetMockRandomServiceCoordinate(3, 2);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.IsNotNull(speciesCatches[0].Species);
        }

        [TestMethod]
        public void Catch_PickCoordinate_RempliToujours()
        {
            Site site = SiteBuilder.Create().WithName("St-Laurent").AddSiteSpecies(SiteSaumon).AddSiteSpecies(SiteTruite);
            SetMockRandomServiceCoordinate(3, 2);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.IsNotNull(speciesCatches[0].X);
        }

        [TestMethod]
        public void Catch_LePlayerSajouteALaListe_SiBonneCoordonne()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                 .AddWayPoint(waypoint);
            SetMockRandomServiceCoordinate(3, 2);

            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].Player.User.Login, "Vincent");
        }

        [TestMethod]
        public void Catch_SiValidatePassePas_IssucessfulcathEstFalse()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint);

            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(false);

            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].IsSuccessfulCatch, false);
        }

        [TestMethod]
        public void Catch_SiValidatePasse_IsSucessfull_Vrai()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint);
            SetMockRandomServiceCoordinate(3.5, 2.5);

            SetMockSiteSpecies();

            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].IsSuccessfulCatch, true);
        }
        [TestMethod]
        public void Catch_SiValidatePasse_RempliWeight()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint);
            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            MockRandomService.Setup(test => test.RandomSpeciesWeight(It.IsAny<int>(), It.IsAny<int>())).Returns(10);
            SetMockSiteSpecies();
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].Weight, 10);
        }

        [TestMethod]
        public void Catch_SiValidatePasse_RempliExperience()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint);
            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            MockRandomService.Setup(test => test.RandomSpeciesExperience(It.IsAny<int>(), It.IsAny<double>())).Returns(10);
            SetMockSiteSpecies();
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].Experience, 10);
        }

        [TestMethod]
        public void Catch_SiValidatePasse_SiPasTournoiMoney0()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint);
            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            MockRandomService.Setup(test => test.RandomSpeciesExperience(It.IsAny<int>(),It.IsAny<double>())).Returns(10);
            SetMockSiteSpecies();
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].Money, 0);
        }

        [TestMethod]
        public void Catch_SiValidatePasse_SiTournoi_RempliMoney()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();
            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            MockRandomService.Setup(test => test.RandomSpeciesExperience(It.IsAny<int>(),It.IsAny<double>())).Returns(10);
            SetMockSiteSpecies();
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            // Experience * MoneyValueInTournament
            Assert.AreEqual(speciesCatches[0].Money, 100);
        }

        [TestMethod]
        public void Catch_RanomCoordinateDoitEtreAppele()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate());

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();

            SetMockRandomServiceCoordinate(3, 2);
            InstanceTest.Catch(site);
            MockRandomService.Verify(test => test.RandomCoordinate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()));
        }


        [TestMethod]
        public void Catch_ValiderDoitEtreAppele()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();
            SetMockRandomServiceCoordinate(3, 2);
            InstanceTest.Catch(site);
            MockValidateCatchService.Verify(test => test.Validate(It.IsAny<SpeciesCatch>()));
        }

        [TestMethod]
        public void Catch_SiValidatePasse_CallAddCatch_Et_SauvegardePlayer()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();
            SetMockRandomServiceCoordinate(3, 2);
            MockValidateCatchService.Setup(test => test.Validate(It.IsAny<SpeciesCatch>())).Returns(true);
            SetMockSiteSpecies();
            InstanceTest.Catch(site);

            MockPlayerService.Verify(test => test.SavePlayer(It.IsAny<Player>()));
            MockDAOSpeciesCatch.Verify(test => test.AddCatch(It.IsAny<SpeciesCatch>()));
        }

        [TestMethod]
        public void Catch_IfPlayerIsInTargetWithFractionalDouble_CatchResultAddPlayer()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();

            SetMockRandomServiceCoordinate(3.4, 2.5);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.AreEqual(speciesCatches[0].Player.User.Login, "Vincent");
        }

        [TestMethod]
        public void Catch_IfPlayerNotInTarget_CatchResultPlayersEmpty()
        {
            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(SetSitePlayerCoordinate()).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();
            SetMockRandomServiceCoordinate(1, 4);
            IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
            Assert.IsNull(speciesCatches[0].Player);
        }

        [TestMethod]
        public void Catch_EvaluerPourcentageChance()
        {

            IList<WaypointCoordinate> sitePlayerCoordinates = new List<WaypointCoordinate>();
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(2).WithY(2));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(2).WithY(4));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(4).WithY(2));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(4).WithY(4));

            Waypoint waypoint = WaypointBuilder.Create().WithPlayer(Vincent).WithSitePlayerCoordinate(sitePlayerCoordinates).WithDateStart(DateTime.Now.AddHours(-1)).WithDateEnd(DateTime.Now.AddHours(1));

            Site site =
                 SiteBuilder.Create().WithName("St-Laurent")
                 .AddSiteSpecies(SiteSaumon)
                 .AddSiteSpecies(SiteTruite)
                  .AddWayPoint(waypoint)
                  .EnabledTournament();

            int nombreFoisCatchSuccess = 0;
            RandomService randomService = new RandomService();

            IList<SiteSpeciesCoordinate> siteSpeciesCoordinates = new List<SiteSpeciesCoordinate>();
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(1).WithY(1)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(1).WithY(4)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(5).WithY(1)));
            siteSpeciesCoordinates.Add(SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(5).WithY(4)));
            SiteSpecies siteTruite = SiteSpeciesBuilder.CreateValid().WithArea(siteSpeciesCoordinates);
            site.SiteSpecies.Clear();
            site.SiteSpecies.Add(siteTruite);

            for (int i = 0; i < 100; i++)
            {
                SetMockRandomServiceCoordinate(randomService.RandomCoordinate(1, 5, 1, 4));
                IList<SpeciesCatch> speciesCatches = InstanceTest.Catch(site);
                foreach (SpeciesCatch speciesCatch in speciesCatches)
                {
                    if (speciesCatch.IsSuccessArea)
                    {
                        nombreFoisCatchSuccess += 1;
                    }
                }
            }
            nombreFoisCatchSuccess.Should().BeGreaterThan(25);
        }

        private IList<WaypointCoordinate> SetSitePlayerCoordinate()
        {
            IList<WaypointCoordinate> sitePlayerCoordinates = new List<WaypointCoordinate>();
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(3).WithY(2));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(3).WithY(3));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(4).WithY(3));
            sitePlayerCoordinates.Add(WaypointCoordinateBuilder.Create().WithX(4).WithY(2));
            return sitePlayerCoordinates;
        }
        private IList<SiteSpeciesCoordinate> SetSiteSpeciesCoordinate()
        {
            SiteSpecies siteSpecies = SiteSpeciesBuilder.CreateValid();
            return siteSpecies.Area;
        }
        private void SetMockRandomServiceCoordinate(double x, double y)
        {
            MockRandomService.Setup(test => test.RandomCoordinate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(new Coordinate(x, y));
        }

        private void SetMockRandomServiceCoordinate(Coordinate coordinate)
        {
            MockRandomService.Setup(test => test.RandomCoordinate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(coordinate);
        }

        private void SetMockSiteSpecies()
        {
            IList<SiteSpecies> siteSpecieses = new List<SiteSpecies>();
            siteSpecieses.Add(SiteSpeciesBuilder.CreateValid());
            MockDAOSiteSpecies.Setup(test => test.GetSiteSpecies(It.IsAny<Site>())).Returns(siteSpecieses);

        }

    }
}
