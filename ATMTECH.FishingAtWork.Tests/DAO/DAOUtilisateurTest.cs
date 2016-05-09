using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.DAO
{
    [Ignore]
    [TestClass]
    public class DAOUtilisateurTest : BaseTestDAOFishingAtWork<DAOUtilisateur>
    {
        [TestMethod]
        public void EstUtilisateurValide_DoitRetournerVraiSiTrouve()
        {
            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            voyageUtilisateurs.Add(AutoFixture.Create<VoyageUtilisateur>());
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);
            Utilisateur utilisateur = CreerUtilisateurActif();
            bool test = InstanceTest.EstUtilisateurValide(utilisateur.Courriel, utilisateur.MotPasse);
            test.Should().Be(true);
        }

        [TestMethod]
        public void ObtenirUtilisateur_DoitRetournerJusteActif()
        {
            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            voyageUtilisateurs.Add(AutoFixture.Create<VoyageUtilisateur>());
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);

            CreerUtilisateurActif();
            CreerUtilisateurInactif();
            IList<Utilisateur> utilisateurs = InstanceTest.ObtenirUtilisateur();
            utilisateurs.Count.Should().Be(1);
        }

        [TestMethod]
        public void ObtenirUtilisateur_DoitRetournerUtilisateurAvecCourrielValide()
        {

            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            voyageUtilisateurs.Add(AutoFixture.Create<VoyageUtilisateur>());
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);


            Utilisateur utilisateur1 = CreerUtilisateurActif();
            CreerUtilisateurActif();
            Utilisateur retour1 = InstanceTest.ObtenirUtilisateur(utilisateur1.Courriel);
            retour1.Should().NotBeNull();
        }

        [TestMethod]
        public void Enregistrer_QuandOnEnregistreUnUtilisateurIlEstInactif()
        {
            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            voyageUtilisateurs.Add(AutoFixture.Create<VoyageUtilisateur>());
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);

            Utilisateur utilisateur = CreerUtilisateurInactif();
            Utilisateur retour = InstanceTest.ObtenirUtilisateur(utilisateur.Courriel);
            retour.IsActive.Should().BeFalse();
        }

        [TestMethod]
        public void ApprouverCreationUtilisateur_DoitRendreUtilisateurActif()
        {
            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            voyageUtilisateurs.Add(AutoFixture.Create<VoyageUtilisateur>());
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);

            Utilisateur utilisateur = CreerUtilisateurInactif();
            InstanceTest.ApprouverUtilisateur(utilisateur.Courriel);
            Utilisateur obtenirUtilisateur = InstanceTest.ObtenirUtilisateur(utilisateur.Courriel);
            obtenirUtilisateur.IsActive.Should().BeTrue();
        }

        [TestMethod]
        public void ObtenirUtilisateur_DoitRemplirListeVoyages()
        {
            IList<VoyageUtilisateur> voyageUtilisateurs = new List<VoyageUtilisateur>();
            VoyageUtilisateur voyageUtilisateur = AutoFixture.Create<VoyageUtilisateur>();
            voyageUtilisateurs.Add(voyageUtilisateur);
            ObtenirMock<IDAOVoyageUtilisateur>().Setup(x => x.ObtenirVoyageUtilisateur(It.IsAny<Utilisateur>())).Returns(voyageUtilisateurs);

            Utilisateur utilisateur = CreerUtilisateurActif();
            Utilisateur obtenirUtilisateur = InstanceTest.ObtenirUtilisateur(utilisateur.Courriel);
            obtenirUtilisateur.Voyages[0].Id.Should().Be(voyageUtilisateur.Voyage.Id);
        }


        private Utilisateur CreerUtilisateurInactif()
        {
            Utilisateur utilisateur = AutoFixture.Create<Utilisateur>();
            utilisateur.Id = 0;
            InstanceTest.Enregistrer(utilisateur);
            return utilisateur;
        }
        private Utilisateur CreerUtilisateurActif()
        {
            Utilisateur utilisateur = AutoFixture.Create<Utilisateur>();
            utilisateur.Id = 0;
            InstanceTest.Enregistrer(utilisateur);
            Utilisateur obtenirUtilisateur = InstanceTest.ObtenirUtilisateur(utilisateur.Courriel);
            InstanceTest.ApprouverUtilisateur(obtenirUtilisateur.Courriel);
            return utilisateur;
        }
    }
}
