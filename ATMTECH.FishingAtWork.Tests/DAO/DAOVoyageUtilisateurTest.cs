using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.DAO
{
   [Ignore]
    [TestClass]
    public class DAOVoyageUtilisateurTest : BaseTestDAOFishingAtWork<DAOVoyageUtilisateur>
    {
        [TestMethod]
        public void ObtenirVoyageUtilisateur_DoitRetournerSeulementCeuxDeUtilisateur()
        {
            VoyageUtilisateur voyageUtilisateur1 = CreerVoyageUtilisateur();
            CreerVoyageUtilisateur();
            IList<VoyageUtilisateur> voyageUtilisateurs = InstanceTest.ObtenirVoyageUtilisateur(voyageUtilisateur1.Utilisateur);

            voyageUtilisateurs.Count.Should().Be(1);
        }


        private VoyageUtilisateur CreerVoyageUtilisateur()
        {
            VoyageUtilisateur voyage = AutoFixture.Create<VoyageUtilisateur>();
            voyage.Id = 0;
            voyage.Id = InstanceTest.Enregistrer(voyage);
            return voyage;
        }

    }
}
