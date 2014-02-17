using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.Entities;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.DAO
{
    [TestClass]
    public class DAOTraitTest : BaseDaoTest<DAOTrait>
    {
        [TestInitialize()]
        public void Initialize()
        {
            CreerDatabaseTest("ATMTECH.Achievement.Entities");
        }

        [TestMethod]
        public void crevette()
        {
            Trait traitSauvegarde = AutoFixture.Create<Trait>();
            traitSauvegarde.Id = 0;
            EnregistrerEntite(traitSauvegarde);
            Trait trait = InstanceTest.ObtenirTraitParCode(traitSauvegarde.Code);
            trait.Description.Should().Be(traitSauvegarde.Description);
        }
    }
}

