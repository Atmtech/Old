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
        public void ObtenirAccomplissementActifParCategorie()
        {
            Categorie categorie = AutoFixture.Create<Categorie>();

            IList<Accomplissement> accomplissements = AutoFixture.CreateMany<Accomplissement>(10).ToList()  ;

            InstanceTest.ObtenirAccomplissementActifParCategorie(categorie.Id);
        }

    }
}

