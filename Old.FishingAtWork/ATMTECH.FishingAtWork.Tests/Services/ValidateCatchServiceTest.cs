using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Validate;
using ATMTECH.FishingAtWork.Tests.Builder;
using ATMTECH.Shell.Tests;
using ATMTECH.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ATMTECH.FishingAtWork.Tests.Services
{
    [TestClass]
    public class ValidateCatchServiceTest : BaseTest<ValidateCatchService>
    {
        public Lure LureRapala { get { return LureBuilder.Create().WithId(1).WithName("Rapala"); } }
        public Lure LureJig { get { return LureBuilder.Create().WithId(2).WithName("Jig"); } }

        public Mock<IRandomService> MockRandomService { get { return ObtenirMock<IRandomService>(); } }
        public SpeciesLure SpeciesLureRapala { get { return SpeciesLureBuilder.Create().WithLure(LureRapala).WithAttractingPercentage(50); } }
        public SpeciesLure SpeciesLureJig { get { return SpeciesLureBuilder.Create().WithLure(LureJig).WithAttractingPercentage(50); } }
        public Player Vincent { get { return PlayerBuilder.Create().WithUser(UserBuilder.Create().WithLogin("Vincent")); } }

        [TestMethod]
        public void Validate_LureOk_RetourneVrai()
        {
            SpeciesCatch speciesCatch = new SpeciesCatch();
            speciesCatch.Species = SpeciesBuilder.Create().WithName("Truite").AddSpeciesLure(SpeciesLureRapala);
            speciesCatch.Player = Vincent;
            speciesCatch.Lure = LureRapala;

            MockRandomService.Setup(test => test.RandomLureAttracting(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            bool rtn = InstanceTest.Validate(speciesCatch);
            Assert.AreEqual(rtn, true);
        }

        [TestMethod]
        public void Validate_LureOk_AppelRandomAttracting()
        {
            SpeciesCatch speciesCatch = new SpeciesCatch
                                            {
                                                Species =
                                                    SpeciesBuilder.Create().WithName("Truite").AddSpeciesLure(
                                                        SpeciesLureRapala),
                                                Player = Vincent,
                                                Lure = LureRapala
                                            };
            bool rtn = InstanceTest.Validate(speciesCatch);
            MockRandomService.Verify(test => test.RandomLureAttracting(It.IsAny<int>(), It.IsAny<int>()));
        }


        [TestMethod]
        public void Validate_LurePasOK_RetourneFalse()
        {
            SpeciesCatch speciesCatch = new SpeciesCatch
                                            {
                                                Species = SpeciesBuilder.Create().WithName("Truite").AddSpeciesLure(SpeciesLureJig),
                                                Player = Vincent,
                                                Lure = LureRapala
                                            };

            MockRandomService.Setup(test => test.RandomLureAttracting(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            bool rtn = InstanceTest.Validate(speciesCatch);
            Assert.AreEqual(rtn, false);
        }
    }
}
