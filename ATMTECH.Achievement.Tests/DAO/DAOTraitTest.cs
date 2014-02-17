using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Tests.Database;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Achievement.Tests.DAO
{
    [TestClass]
    public class DAOTraitTest : BaseDaoTest<DAOTrait>
    {
        [TestInitialize()]
        public void Initialize()
        {
           
        }


        [TestMethod]
        public void crevette()
        {
            Initialisation initialisation = new Initialisation();
            initialisation.CreerDatabaseTest();

            Trait trait = InstanceTest.ObtenirTrait(1);
            trait.Description.Should().Be("A l'écoute");
        }
    }
}

