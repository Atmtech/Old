using System.Collections.Generic;
using System.Linq;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.DAO
{
    [Ignore]
    [TestClass]
    public class DAOVoyageTest : BaseTestDAOFishingAtWork<DAOVoyage>
    {
        [TestMethod]
        public void ObtenirVoyage_DoitRetournerSeulementActif()
        {
            CreerVoyage();
            CreerVoyage();
            IList<Voyage> test = InstanceTest.ObtenirVoyage();
            test.Count.Should().Be(2);
        }

        private Voyage CreerVoyage()
        {
            Voyage voyage = AutoFixture.Create<Voyage>();
            voyage.Id = 0;
            InstanceTest.Enregistrer(voyage);
            return voyage;
        }

    }
}
