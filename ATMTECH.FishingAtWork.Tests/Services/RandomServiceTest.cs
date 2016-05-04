using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services;
using ATMTECH.Shell.Tests;
using ATMTECH.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.FishingAtWork.Tests.Services
{
    [TestClass]
    public class RandomServiceTest : BaseTest<RandomService>
    {
        [TestMethod]
        public void RandomCoordinate_PasVide_AvecValeurPlusQue1()
        {
            Coordinate coordinate = InstanceTest.RandomCoordinate(1, 100, 1, 100);
            Assert.IsNotNull(coordinate);
            if (coordinate.X < 1)
            {
                Assert.Fail();
            }
            if (coordinate.Y > 101)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RandomInt_between1and100_returnBetween1and100()
        {
            int random = InstanceTest.RandomLureAttracting(1, 100);
            if (!(random > 1 && random < 100))
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void RandomSpeciesWeight_between1and100_returnBetween1and100()
        {
            double random = InstanceTest.RandomSpeciesWeight(1, 100);
            if (!(random > 1 && random < 100))
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void RandomSpeciesExperience_between1and100_returnBetween1and100()
        {
            double random = InstanceTest.RandomSpeciesExperience(100, 10);
            if (!(random >= 1 && random <= 100))
            {
                Assert.Fail();
            }

        }

    }
}
