using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.DAO
{
    [TestClass]
    public class DAOAccomplissementTest : BaseDaoTest<DAOAccomplissement>
    {

        [TestInitialize()]
        public void Initialize()
        {
            CreerDatabaseTest("ATMTECH.Achievement.Entities");
        }

        public Mock<IDAOCategorie> MockDAOCategorie { get { return ObtenirMock<IDAOCategorie>(); } }
        public Mock<IDAOFile> MockDAOFile { get { return ObtenirMock<IDAOFile>(); } }
        public Mock<IDAOAccomplissementTrait> MockDAOAccomplissementTrait { get { return ObtenirMock<IDAOAccomplissementTrait>(); } }

        [TestMethod]
        public void ObtenirAccomplissement_DevraitRemplirCategorieImageEtTraits()
        {
            

            Categorie categorie = AutoFixture.Create<Categorie>();
            File file = AutoFixture.Create<File>();
            IList<AccomplissementTrait> accomplissementTraits =
                AutoFixture.CreateMany<AccomplissementTrait>(10).ToList();
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();

            InsererEntite(accomplissement);
            MockDAOCategorie.Setup(x => x.ObtenirParId(It.IsAny<int>())).Returns(categorie);
            MockDAOFile.Setup(x => x.GetFile(It.IsAny<int>())).Returns(file);
            MockDAOAccomplissementTrait.Setup(x => x.ObtenirTousActivePourAccomplissement(It.IsAny<int>()))
                .Returns(accomplissementTraits);
            Accomplissement retour = InstanceTest.ObtenirAccomplissement(accomplissement.Id);

            retour.Titre.Should().Be(accomplissement.Titre);
            retour.Categorie.Description.Should().Be(categorie.Description);
            retour.Image.FileName.Should().Be(file.FileName);
            retour.AccomplissementTraits.Count().Should().Be(10);
        }

        [TestMethod]
        public void ObtenirAccomplissementActifParCategorie_SeulementActif()
        {
            Categorie categorie = AutoFixture.Create<Categorie>();
            InsererEntite(categorie);
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.Categorie = categorie;
            InsererEntite(accomplissement);
            Accomplissement accomplissement1 = InstanceTest.ObtenirTousActive()[0];
            accomplissement1.IsActive = false;
            EnregistrerEntite(accomplissement1);

            IList<Accomplissement> rtn = InstanceTest.ObtenirAccomplissementActifParCategorie(categorie.Id);
            rtn.Count.Should().Be(0);
        }

        [TestMethod]
        public void ObtenirAccomplissementActifParCategorie_SeulementPourCategorie()
        {
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.IsActive = true;
            EnregistrerEntite(accomplissement);

            IList<Accomplissement> rtn = InstanceTest.ObtenirAccomplissementActifParCategorie(1212);
            rtn.Count.Should().Be(0);
        }

        [TestMethod]
        public void ObtenirAccomplissementActifParCategorie_RempliCategorieFileAccomplissementTraits()
        {
            Categorie categorie = AutoFixture.Create<Categorie>();
            InsererEntite(categorie);
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.IsActive = true;
            accomplissement.Categorie = categorie;
            InsererEntite(accomplissement);
            File file = AutoFixture.Create<File>();
            IList<AccomplissementTrait> accomplissementTraits =
              AutoFixture.CreateMany<AccomplissementTrait>(10).ToList();

            MockDAOCategorie.Setup(x => x.ObtenirParId(It.IsAny<int>())).Returns(categorie);
            MockDAOFile.Setup(x => x.GetFile(It.IsAny<int>())).Returns(file);
            MockDAOAccomplissementTrait.Setup(x => x.ObtenirTousActivePourAccomplissement(It.IsAny<int>()))
                .Returns(accomplissementTraits);

            IList<Accomplissement> rtn = InstanceTest.ObtenirAccomplissementActifParCategorie(categorie.Id);
            rtn.Count.Should().Be(1);
            rtn[0].Categorie.Description = categorie.Description;
            rtn[0].Image.Description = file.Description;
            rtn[0].AccomplissementTraits.Count.Should().Be(10);
        }

    }
}

