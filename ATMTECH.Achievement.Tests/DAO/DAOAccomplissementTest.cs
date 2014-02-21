using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.DAO.Interface;
using ATMTECH.Achievement.Entities;
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

        [TestMethod]
        public void ObtenirAccomplissement_DevraitRemplirCategorieImageEtTraits()
        {
            Categorie categorie = AutoFixture.Create<Categorie>();
            Accomplissement accomplissement = AutoFixture.Create<Accomplissement>();
            accomplissement.Id = 0;
            InsererEntite(accomplissement);
            MockDAOCategorie.Setup(x => x.ObtenirParId(It.IsAny<int>())).Returns(categorie);

            Accomplissement retour = InstanceTest.ObtenirAccomplissement(accomplissement.Id);

            retour.Titre.Should().Be(accomplissement.Titre);
            retour.Categorie.Description.Should().Be(categorie.Description);
        }


    }
}

