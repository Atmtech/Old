using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.DAO
{
    [TestClass]
    public class DAOEmplacementTEst : BaseTestDAOFishingAtWork<DAOEmplacement>
    {
        [TestMethod]
        public void ObtenirEmplacement_DoitRetournerSeulementActif()
        {
            CreerEmplacementInactif();
            CreerEmplacementActif();
            IList<Emplacement> obtenirEmplacement = InstanceTest.ObtenirEmplacement();
            obtenirEmplacement.Count.Should().Be(1);
        }



        private Emplacement CreerEmplacementInactif()
        {
            Emplacement emplacement = AutoFixture.Create<Emplacement>();
            emplacement.Id = 0;
            emplacement.IsActive = false;
            emplacement.Id = InstanceTest.Enregistrer(emplacement);
            emplacement.IsActive = false;
            InstanceTest.Enregistrer(emplacement);
            return emplacement;
        }
        private Emplacement CreerEmplacementActif()
        {
            Emplacement emplacement = AutoFixture.Create<Emplacement>();
            emplacement.Id = 0;
            InstanceTest.Enregistrer(emplacement);
            return emplacement;
        }
    }
}
