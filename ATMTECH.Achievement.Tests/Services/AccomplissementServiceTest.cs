using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.Achievement.Services;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.Services
{
    [TestClass]
    public class AccomplissementServiceTest : BaseTest<AcomplissementService>
    {

        public Mock<IDAOAccomplissement> MockDAOAccomplissement { get { return ObtenirMock<IDAOAccomplissement>(); } }
        public Mock<IDAOCategorie> MockDAOCategorie { get { return ObtenirMock<IDAOCategorie>(); } }
        public Mock<IDAOAccomplissementTrait> MockDAOAccomplissementTrait { get { return ObtenirMock<IDAOAccomplissementTrait>(); } }
        public Mock<IDAOFile> MockDAOFile { get { return ObtenirMock<IDAOFile>(); } }
        public Mock<IDAOAccomplissementUtilisateur> MockDAOAccomplissementUtilisateur { get { return ObtenirMock<IDAOAccomplissementUtilisateur>(); } }

        [TestMethod]
        public void ValidationAccomplissement_LancerErreur_SurTraitsVide()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.AccomplissementTraits = new List<AccomplissementTrait>();

            InstanceTest.ValidationAccomplissement(accomplissement);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_AUCUNE_QUALITE_ASSOCIE_ACCOMPLISSEMENT));
        }

        [TestMethod]
        public void ValidationAccomplissement_LancerErreur_SurDescriptionVide()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            AccomplissementTrait accomplissementTrait = AutoFixture.Create<AccomplissementTrait>();
            IList<AccomplissementTrait> accomplissementTraits = new List<AccomplissementTrait>();
            accomplissementTraits.Add(accomplissementTrait);
            accomplissement.Description = string.Empty;

            accomplissement.AccomplissementTraits = accomplissementTraits;

            InstanceTest.ValidationAccomplissement(accomplissement);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_DESCRIPTION_OBLIGATOIRE_CREATION_ACCOMPLISSEMENT));
        }

        [TestMethod]
        public void ValidationAccomplissement_LancerErreur_SurTitreVide()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            AccomplissementTrait accomplissementTrait = AutoFixture.Create<AccomplissementTrait>();
            IList<AccomplissementTrait> accomplissementTraits = new List<AccomplissementTrait>();
            accomplissementTraits.Add(accomplissementTrait);
            accomplissement.Titre = string.Empty;

            accomplissement.AccomplissementTraits = accomplissementTraits;

            InstanceTest.ValidationAccomplissement(accomplissement);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_TITRE_OBLIGATOIRE_CREATION_ACCOMPLISSEMENT));
        }

        [TestMethod]
        public void Creer_LancerValidation()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.AccomplissementTraits = new List<AccomplissementTrait>();

            InstanceTest.Creer(accomplissement);

            MockMessageService.Verify(test => test.ThrowMessage(Achievement.Services.ErrorCode.ErrorCode.ACH_AUCUNE_QUALITE_ASSOCIE_ACCOMPLISSEMENT));
        }

        [TestMethod]
        public void Creer_DoitLAncer_Enregistrer()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            AccomplissementTrait accomplissementTrait = AutoFixture.Create<AccomplissementTrait>();
            IList<AccomplissementTrait> accomplissementTraits = new List<AccomplissementTrait>();
            accomplissementTraits.Add(accomplissementTrait);

            InstanceTest.Creer(accomplissement);

            MockDAOAccomplissement.Verify(x => x.Enregistrer(accomplissement), Times.Once());
        }

        [TestMethod]
        public void Creer_DoitLAncer_EnregistrerPourChaqueTrait()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            AccomplissementTrait accomplissementTrait1 = AutoFixture.Create<AccomplissementTrait>();
            AccomplissementTrait accomplissementTrait2 = AutoFixture.Create<AccomplissementTrait>();
            IList<AccomplissementTrait> accomplissementTraits = new List<AccomplissementTrait>();
            accomplissementTraits.Add(accomplissementTrait1);
            accomplissementTraits.Add(accomplissementTrait2);
            accomplissement.AccomplissementTraits = accomplissementTraits;

            MockDAOAccomplissement.Setup(x => x.Enregistrer(accomplissement)).Returns(1);

            InstanceTest.Creer(accomplissement);

            MockDAOAccomplissement.Verify(x => x.ObtenirAccomplissement(It.IsAny<int>()), Times.Exactly(2));
            MockDAOAccomplissementTrait.Verify(x => x.Enregistrer(accomplissementTrait1), Times.Once());
            MockDAOAccomplissementTrait.Verify(x => x.Enregistrer(accomplissementTrait2), Times.Once());
        }

        [TestMethod]
        public void VoterAccomplissement_Doit_IncrementDe1Vote()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            int voteinitial = accomplissement.NombreVote;
            InstanceTest.VoterAccomplissement(accomplissement);

            MockDAOAccomplissement.Verify(x => x.Enregistrer(accomplissement), Times.Once());
            int votefinal = accomplissement.NombreVote;
            votefinal.Should().Be(voteinitial + 1);
        }

        [TestMethod]
        public void ObtenirListeFichierBadge_Doit_SortirJusteFichierAvecCategorieBadge()
        {
            IList<File> files = AutoFixture.CreateMany<File>(10).ToList();
            files[0].Category = "badge";
            MockDAOFile.Setup(x => x.GetAllFile()).Returns(files);
            IList<File> rtn = InstanceTest.ObtenirListeFichierBadge();

            rtn.Count.Should().Be(1);
        }

        [TestMethod]
        public void ObtenirListeAccomplissementAccompli_DoitSortirJusteLesAccomplis()
        {

            User user = AutoFixture.Create<User>();

            IList<AccomplissementUtilisateur> accomplissementUtilisateurs =
                AutoFixture.CreateMany<AccomplissementUtilisateur>(1).ToList();
            accomplissementUtilisateurs[0].Utilisateur = user;
            MockAuthenticationService.Setup(x => x.AuthenticateUser).Returns(user);
            MockDAOAccomplissementUtilisateur.Setup(x => x.ObtenirListeAccomplissementUtilisateur(user.Id))
                                             .Returns(accomplissementUtilisateurs);

            IList<Accomplissement> accomplissements =
                InstanceTest.ObtenirListeAccomplissementAccompli();
            accomplissements.Count.Should().Be(1);
        }

        [TestMethod]
        public void AjouterAccomplissementUtilisateur_SaveAvecValeurs()
        {

            User user = AutoFixture.Create<User>();
            AccomplissementUtilisateur accomplissementUtilisateur = AutoFixture.Create<AccomplissementUtilisateur>();
            accomplissementUtilisateur.Utilisateur = user;
            MockAuthenticationService.Setup(test => test.AuthenticateUser).Returns(user);
            InstanceTest.AjouterAccomplissementUtilisateur(accomplissementUtilisateur.Accomplissement, accomplissementUtilisateur.EstPublic, accomplissementUtilisateur.EstPourAmi, accomplissementUtilisateur.EstPrive);
            MockDAOAccomplissementUtilisateur.Verify(test => test.Enregistrer(It.Is<AccomplissementUtilisateur>(it => it.EstPublic == accomplissementUtilisateur.EstPublic)), Times.Once());
            MockDAOAccomplissementUtilisateur.Verify(test => test.Enregistrer(It.Is<AccomplissementUtilisateur>(it => it.EstPrive == accomplissementUtilisateur.EstPrive)), Times.Once());
            MockDAOAccomplissementUtilisateur.Verify(test => test.Enregistrer(It.Is<AccomplissementUtilisateur>(it => it.EstPourAmi == accomplissementUtilisateur.EstPourAmi)), Times.Once());
            MockDAOAccomplissementUtilisateur.Verify(test => test.Enregistrer(It.Is<AccomplissementUtilisateur>(it => it.Utilisateur.FirstNameLastName == accomplissementUtilisateur.Utilisateur.FirstNameLastName)), Times.Once());
        }

        [TestMethod]
        public void ObtenirCategorieActive_RempliNombreAccomplissement()
        {
            IList<Categorie> categories = AutoFixture.CreateMany<Categorie>(15).ToList();
            IList<Accomplissement> accomplissements = AutoFixture.CreateMany<Accomplissement>(15).ToList();
            foreach (Accomplissement accomplissement in accomplissements)
            {
                accomplissement.Categorie = categories[0];
            }

            MockDAOAccomplissement.Setup(test => test.ObtenirTousActive()).Returns(accomplissements);
            MockDAOCategorie.Setup(test => test.ObtenirTousActive()).Returns(categories);

            IList<Categorie> categories2 = InstanceTest.ObtenirCategorieActive();

            categories2[0].NombreAccomplissement.Should().Be(15);

        }
    }
}

