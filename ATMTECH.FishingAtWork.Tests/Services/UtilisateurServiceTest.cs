using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services;
using ATMTECH.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.Services
{
    [Ignore]
    [TestClass]
    public class UtilisateurServiceTest : BaseTest<UtilisateurService>
    {
        [TestMethod]
        public void ObtenirUtilisateur_NeDoitPasEtreNull()
        {
            Utilisateur utilisateur = AutoFixture.Create<Utilisateur>();
            ObtenirMock<IDAOUtilisateur>().Setup(x => x.ObtenirUtilisateur(utilisateur.Courriel)).Returns(utilisateur);
            Utilisateur retour = InstanceTest.ObtenirUtilisateur(utilisateur.Courriel);
            retour.Nom.Should().Be(utilisateur.Nom);
        }

        [TestMethod]
        public void ApprouverUtilisateur_EstAppeler()
        {
            Utilisateur utilisateur = AutoFixture.Create<Utilisateur>();
            ObtenirMock<IDAOUtilisateur>().Setup(x => x.ApprouverUtilisateur(utilisateur.Courriel)).Returns(utilisateur);
            Utilisateur retour = InstanceTest.ApprouverUtilisateur(utilisateur.Courriel);
            retour.Id.Should().Be(utilisateur.Id);
        }
    }
}
