using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.Test
{
    [TestClass]
    public class BaseDaoTest
    {
        private readonly BaseDao<User, int> _daoUser = new BaseDao<User, int>();
        private readonly Model<User, int> _model = new Model<User, int>();

        [TestInitialize]
        public void Initialize()
        {
            InitializeDatabase initializeDatabase = new InitializeDatabase();
            initializeDatabase.InitializeDatabaseSqliteEnMemoire();

            RemplirBaseDonnee();
        }

        public Fixture AutoFixture
        {
            get
            {
                Fixture fixture = (Fixture)new Fixture().Customize(new MultipleCustomization());
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                return fixture;
            }
        }

        private void RemplirBaseDonnee()
        {
            User user1 = AutoFixture.Create<User>();
            user1.Id = 0;
            user1.IsActive = true;
            user1.FirstName = "Vincent";
            User user2 = AutoFixture.Create<User>();
            user2.Id = 0;
            user2.IsActive = false;
            _daoUser.Save(user1);
            _daoUser.Save(user2);
        }

        [TestMethod]
        public void GetIdKeyColumnFromModel_RetourneLaCleId()
        {
            string idKey = _model.GetIdKeyColumnFromModel();
            idKey.Should().Be("Id");
        }
        [TestMethod]
        public void ExecuteSql_DoitExecuterLaLigneCommande()
        {
            _daoUser.ExecuteSql("DELETE FROM User");
            _daoUser.ExecuteSql("INSERT INTO User (Description) VALUES ('TEST')");
            _daoUser.GetAll().Count.Should().Be(1);
        }
        [TestMethod]
        public void GetById_DevraitRetournerObjetRempli()
        {
            User user = _daoUser.GetById(1);
            user.FirstName.Should().Be("Vincent");
        }
        [TestMethod]
        public void GetById_SiObtientAvecParametre0OnRetourneObjetVide()
        {
            User user = _daoUser.GetById(0);
            user.Should().Be(null);
        }
        [TestMethod]
        public void GetById_SiObtientAvecParametreQuiRetourne0Rangee_REtourneNull()
        {
            User user = _daoUser.GetById(5);
            user.Should().Be(null);
        }
        [TestMethod]
        public void GetAllActive_RetourneSeulementLesActif()
        {
            _daoUser.ExecuteSql("DELETE FROM User");
            _daoUser.ExecuteSql("INSERT INTO User (Description, IsActive) VALUES ('TEST', 0)");
            _daoUser.ExecuteSql("INSERT INTO User (Description, IsActive) VALUES ('TEST', 1)");
            IList<User> users = _daoUser.GetAllActive();
            users.Count.Should().Be(1);
        }

    }
}
