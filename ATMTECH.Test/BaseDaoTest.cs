using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ATMTECH.Common;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Test.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Test
{
    [Ignore]
    [TestClass]
    public class BaseDaoTest
    {
        private readonly BaseDao<EntityTest, int> _daoEntityTest = new BaseDao<EntityTest, int>();
        private readonly BaseDao<EntityTestSon, int> _daoEntityTestSon = new BaseDao<EntityTestSon, int>();
        private readonly BaseDao<EntityEmpty, int> _daoEntityEmpty = new BaseDao<EntityEmpty, int>();

        private readonly Model<EntityTest, int> _model = new Model<EntityTest, int>();
        private readonly Model<EntityEmpty, int> _model2 = new Model<EntityEmpty, int>();
        private readonly DatabaseOperation<EntityEmpty, int> _databaseOperation = new DatabaseOperation<EntityEmpty, int>();

        [TestInitialize]
        public void Init()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.Test.Website\App_Data\Test.db3";
            EmptyDatabase();
            FillDatabase();
        }

        [TestMethod]
        public void GetIdKeyWithCategoryUniqueKey()
        {
            string idKey = _model.GetIdKeyColumnFromModel();
            Assert.AreEqual(idKey, "Id");
        }

        [TestMethod]
        public void GetIdKeyWithoutCategoryUniqueKey()
        {
            string idKey = _model2.GetIdKeyColumnFromModel();
            Assert.IsNull(idKey);
        }

        [TestMethod]
        public void ExecuteSqlInsertOneLineCount3()
        {
            int result = 0;
            _databaseOperation.ExecuteSql("INSERT INTO EntityTest (Description) VALUES ('TEST')");
            result = _daoEntityTest.GetAll().Count;
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void GetDataOrderByAscendingWhenActive()
        {
            IList<EntityTest> entities = _daoEntityTest.GetAllActive(new OrderOperation()
                                            {
                                                OrderByColumn = BaseEntity.DESCRIPTION,
                                                OrderByType = OrderBy.Type.Ascending
                                            });
            string description = entities[1].Description;
            Assert.AreEqual(description, "Row2");
        }

        [TestMethod]
        public void GetDataOrderByDescendingWhenActive()
        {
            IList<EntityTest> entities = _daoEntityTest.GetAllActive(new OrderOperation()
            {
                OrderByColumn = BaseEntity.DESCRIPTION,
                OrderByType = OrderBy.Type.Descending
            });
            string description = entities[1].Description;
            Assert.AreEqual(description, "Row1");
        }

        [TestMethod]
        public void GetDataPagingWhenActive()
        {
            IList<EntityTest> entitiesPageOne = _daoEntityTest.GetAllActive(new PagingOperation() { PageIndex = 0, PageSize = 1 });
            string rtn1 = entitiesPageOne[0].Description;
            IList<EntityTest> entitiesPageTwo = _daoEntityTest.GetAllActive(new PagingOperation() { PageIndex = 1, PageSize = 1 });
            string rtn2 = entitiesPageTwo[0].Description;
            Assert.AreEqual(rtn1, "Row1");
            Assert.AreEqual(rtn2, "Row2");
        }

        [TestMethod]
        public void GetAllDataFrom1Criteria()
        {
            int rtn = _daoEntityTest.GetAllOneCriteria(BaseEntity.DESCRIPTION, "Row1").Count;
            Assert.AreEqual(rtn, 1);
        }

        [TestMethod]
        public void GetAllDataFrom1CriteriaAndPaging()
        {
            IList<EntityTest> entitiesPageOne = _daoEntityTest.GetAllOneCriteria(BaseEntity.IS_ACTIVE, "1", new PagingOperation() { PageIndex = 0, PageSize = 1 });
            IList<EntityTest> entitiesPageTwo = _daoEntityTest.GetAllOneCriteria(BaseEntity.IS_ACTIVE, "1", new PagingOperation() { PageIndex = 1, PageSize = 1 });
            Assert.AreEqual(entitiesPageOne[0].Description, "Row1");
            Assert.AreEqual(entitiesPageTwo[0].Description, "Row2");
        }

        [TestMethod]
        public void GetAllDataFrom1CriteriaAndOrderAscending()
        {
            IList<EntityTest> entities = _daoEntityTest.GetAllOneCriteria(BaseEntity.IS_ACTIVE, "1", new OrderOperation()
            {
                OrderByColumn = BaseEntity.DESCRIPTION,
                OrderByType = OrderBy.Type.Ascending
            });
            string description = entities[0].Description;
            Assert.AreEqual(description, "Row1");
        }

        [TestMethod]
        public void GetAllDataFrom1CriteriaAndOrderDescending()
        {
            IList<EntityTest> entities = _daoEntityTest.GetAllOneCriteria(BaseEntity.IS_ACTIVE, "1", new OrderOperation()
            {
                OrderByColumn = BaseEntity.DESCRIPTION,
                OrderByType = OrderBy.Type.Descending
            });
            string description = entities[0].Description;
            Assert.AreEqual(description, "Row2");
        }

        [TestMethod]
        public void GetAllWithOneCriteria()
        {
            Criteria criteria = new Criteria();
            criteria.Column = BaseEntity.IS_ACTIVE;
            criteria.Operator = DatabaseOperator.OPERATOR_EQUAL;
            criteria.Value = "1";

            IList<Criteria> test = new ReadOnlyCollectionBuilder<Criteria>();
            test.Add(criteria);

            int rtn = _daoEntityTest.GetByCriteria(test).Count;
            Assert.AreEqual(rtn, 2);
        }

        //[TestMethod]
        //public void GetByIdReturn1RowWithIdEqual1()
        //{
        //    EntityTest entity = _daoEntityTest.GetById(1);
        //    Assert.AreEqual(entity.Description, "Row1");
        //}

        [TestMethod]
        public void GetByIdReturn1RowWithIdEqual0()
        {
            EntityTest entity = _daoEntityTest.GetById(0);
            Assert.IsNull(entity);
        }

        //[TestMethod]
        //public void OnSaveModelDescriptionIsChanged()
        //{
        //    EntityTest entity = _daoEntityTest.GetById(1);
        //    entity.Description = "Changing";
        //    _daoEntityTest.Save(entity);
        //    EntityTest entityFromDatabase = _daoEntityTest.GetById(1);
        //    Assert.AreEqual(entityFromDatabase.Description, "Changing");
        //}

        [TestMethod]
        public void GetDataWithLikeOnDescriptionLikeRow()
        {
            Criteria criteria = new Criteria();
            criteria.Column = BaseEntity.DESCRIPTION;
            criteria.Operator = DatabaseOperator.OPERATOR_LIKE;
            criteria.Value = "Row";

            IList<Criteria> test = new ReadOnlyCollectionBuilder<Criteria>();
            test.Add(criteria);

            int rtn = _daoEntityTest.GetByCriteria(test).Count;
            Assert.AreEqual(rtn, 2);

        }

        [TestMethod]
        public void GetAllActiveReturn2Row()
        {
            int rtn = _daoEntityTest.GetAllActive().Count;
            Assert.AreEqual(rtn, 2);
        }

        [TestMethod]
        public void BackupToXml_FichierZipResultat()
        {
            _daoEntityTest.BackupToXml(@"C:\DEV\Atmtech\TempTest\test.zip", true);
            if (!System.IO.File.Exists(@"C:\DEV\Atmtech\TempTest\test.zip"))
            {
                Assert.Fail();
            }
            System.IO.File.Delete(@"C:\DEV\Atmtech\TempTest\test.zip");
        }
        //[TestMethod]
        //public void RestoreXml_OneFile()
        //{
        //    _daoEntityTest.BackupToXml(@"C:\DEV\Atmtech\TempTest\test.zip", false);

        //    EntityTest entityTest1 = _daoEntityTest.GetById(1);
        //    entityTest1.Description = "Test";
        //    _daoEntityTest.Save(entityTest1);

        //    _daoEntityTest.RestoreFromXml(@"C:\DEV\Atmtech\TempTest\test.zip");
        //    EntityTest entityTest2 = _daoEntityTest.GetById(1);
        //    Assert.AreEqual(entityTest2.Description, "Row1");
        //}

        private void EmptyDatabase()
        {
            _databaseOperation.ExecuteSql("DELETE FROM EntityTest");
            _databaseOperation.ExecuteSql("DELETE FROM EntityTestSon");
            _databaseOperation.ExecuteSql("delete from sqlite_sequence where name='EntityTest'");
            _databaseOperation.ExecuteSql("delete from sqlite_sequence where name='EntityTestSon'");
        }

        private void FillDatabase()
        {
            EntityTest rowOne = new EntityTest() { DateCreated = DateTime.Now, DateModified = Convert.ToDateTime("2000-01-01"), Description = "Row1", EntityTestSon = new EntityTestSon() { Id = 1 } };
            EntityTest rowTwo = new EntityTest() { DateCreated = DateTime.Now, DateModified = Convert.ToDateTime("2000-01-01"), Description = "Row2", EntityTestSon = new EntityTestSon() { Id = 1 } };
            _daoEntityTest.Save(rowOne);
            _daoEntityTest.Save(rowTwo);

            EntityTestSon rowOneSon = new EntityTestSon() { DateCreated = DateTime.Now, DateModified = Convert.ToDateTime("2000-01-01"), Description = "Row1Son" };
            _daoEntityTestSon.Save(rowOneSon);


        }
    }
}
