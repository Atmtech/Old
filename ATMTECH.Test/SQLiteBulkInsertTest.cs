using System.Data.SQLite;
using ATMTECH.DAO.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.IO;
using System;

namespace ATMTECH.Test
{
    /// 
    ///This is a test class for SQLiteBulkInsertTest and is intended
    ///to contain all SQLiteBulkInsertTest Unit Tests
    ///
    /// 
    [Ignore]
    [TestClass()]
    public class SQLiteBulkInsertTest
    {
        private static string _mTestDir;
        private static string _mTestFile;
        private const string M_TEST_TABLE_NAME = "test_table";
        private static string _mConnectionString;

        private const string M_DELETE_ALL_QUERY = "DELETE FROM [{0}]";
        private const string M_COUNT_ALL_QUERY = "SELECT COUNT(id) FROM [{0}]";
        private const string M_SELECT_ALL_QUERY = "SELECT * FROM [{0}]";

        private static SQLiteConnection _mDbCon;
        private static SQLiteCommand _mDeleteAllCmd;
        private static SQLiteCommand _mCountAllCmd;
        private static SQLiteCommand _mSelectAllCmd;

        /// 
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Random rand = new Random(Environment.TickCount);
            int rn = rand.Next(0, int.MaxValue);
            _mTestDir = @"C:\SqliteBulkInsertTest-" + rn + @"\";
            _mTestFile = _mTestDir + "db.sqlite";

            if (!Directory.Exists(_mTestDir))
                Directory.CreateDirectory(_mTestDir);

            if (!File.Exists(_mTestFile))
            {
                FileStream fs = File.Create(_mTestFile);
                fs.Close();
            }

            _mConnectionString = string.Format(@"data source={0};datetimeformat=Ticks", _mTestFile);
            _mDbCon = new SQLiteConnection(_mConnectionString);
            _mDbCon.Open();

            SQLiteCommand cmd = _mDbCon.CreateCommand();
            string query = "CREATE TABLE IF NOT EXISTS [{0}] (id INTEGER PRIMARY KEY AUTOINCREMENT, somestring VARCHAR(16), somereal REAL, someint INTEGER(4), somedt DATETIME)";
            query = string.Format(query, M_TEST_TABLE_NAME);
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            _mDbCon.Close();

            File.Delete(_mTestFile);
            Directory.Delete(_mTestDir);
        }
        #endregion

        private void AddParameters(SQLiteBulkInsert target)
        {
            target.AddParameter("somestring", DbType.String);
            target.AddParameter("somereal", DbType.String);
            target.AddParameter("someint", DbType.Int32);
            target.AddParameter("somedt", DbType.DateTime);
        }

        private long CountRecords()
        {
            _mCountAllCmd = _mDbCon.CreateCommand();
            _mCountAllCmd.CommandText = string.Format(M_COUNT_ALL_QUERY, M_TEST_TABLE_NAME);

            long ret = (long)_mCountAllCmd.ExecuteScalar();
            _mCountAllCmd.Dispose();

            return ret;
        }

        private void DeleteRecords()
        {
            _mDeleteAllCmd = _mDbCon.CreateCommand();
            _mDeleteAllCmd.CommandText = string.Format(M_DELETE_ALL_QUERY, M_TEST_TABLE_NAME);

            _mDeleteAllCmd.ExecuteNonQuery();
            _mDeleteAllCmd.Dispose();
        }

        private SQLiteDataReader SelectAllRecords()
        {
            _mSelectAllCmd = _mDbCon.CreateCommand();
            _mSelectAllCmd.CommandText = string.Format(M_SELECT_ALL_QUERY, M_TEST_TABLE_NAME);
            return _mSelectAllCmd.ExecuteReader();
        }

        [TestMethod()]
        public void AddParameterTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
            AddParameters(target);

            string pd = target.ParamDelimiter;
            string expectedStmnt = "INSERT INTO [{0}] ([somestring], [somereal], [someint], [somedt]) VALUES ({1}somestring, {2}somereal, {3}someint, {4}somedt)";
            expectedStmnt = string.Format(expectedStmnt, M_TEST_TABLE_NAME, pd, pd, pd, pd);
            Assert.AreEqual(expectedStmnt, target.CommandText);
        }

        [TestMethod()]
        public void SQLiteBulkInsertConstructorTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
            Assert.AreEqual(M_TEST_TABLE_NAME, target.TableName);

            bool wasException = false;
            try
            {
                string a = target.CommandText;
            }
            catch { wasException = true; }

            Assert.IsTrue(wasException);
        }

        [TestMethod()]
        public void CommandTextTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
            AddParameters(target);

            string pd = target.ParamDelimiter;
            string expectedStmnt = "INSERT INTO [{0}] ([somestring], [somereal], [someint], [somedt]) VALUES ({1}somestring, {2}somereal, {3}someint, {4}somedt)";
            expectedStmnt = string.Format(expectedStmnt, M_TEST_TABLE_NAME, pd, pd, pd, pd);
            Assert.AreEqual(expectedStmnt, target.CommandText);
        }

        [TestMethod()]
        public void TableNameTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
            Assert.AreEqual(M_TEST_TABLE_NAME, target.TableName);
        }

        [TestMethod()]
        public void InsertTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);

            bool didThrow = false;
            try
            {
                target.Insert(new object[] { "hello" }); //object.length must equal the number of parameters added
            }
            catch { didThrow = true; }
            Assert.IsTrue(didThrow);

            AddParameters(target);

            target.CommitMax = 4;
            DateTime dt1 = DateTime.Now; DateTime dt2 = DateTime.Now; DateTime dt3 = DateTime.Now; DateTime dt4 = DateTime.Now;
            target.Insert(new object[] { "john", 3.45f, 10, dt1 });
            target.Insert(new object[] { "paul", -0.34f, 100, dt2 });
            target.Insert(new object[] { "ringo", 1000.98f, 1000, dt3 });
            target.Insert(new object[] { "george", 5.0f, 10000, dt4 });

            long count = CountRecords();
            Assert.AreEqual(4, count);

            //SQLiteDataReader reader = SelectAllRecords();

            //Assert.IsTrue(reader.Read());
            //Assert.AreEqual("john", reader.GetString(1)); Assert.AreEqual(3.45f, reader.GetFloat(2));
            //Assert.AreEqual(10, reader.GetInt32(3)); Assert.AreEqual(dt1, reader.GetDateTime(4));

            //Assert.IsTrue(reader.Read());
            //Assert.AreEqual("paul", reader.GetString(1)); Assert.AreEqual(-0.34f, reader.GetFloat(2));
            //Assert.AreEqual(100, reader.GetInt32(3)); Assert.AreEqual(dt2, reader.GetDateTime(4));

            //Assert.IsTrue(reader.Read());
            //Assert.AreEqual("ringo", reader.GetString(1)); Assert.AreEqual(1000.98f, reader.GetFloat(2));
            //Assert.AreEqual(1000, reader.GetInt32(3)); Assert.AreEqual(dt3, reader.GetDateTime(4));

            //Assert.IsTrue(reader.Read());
            //Assert.AreEqual("george", reader.GetString(1)); Assert.AreEqual(5.0f, reader.GetFloat(2));
            //Assert.AreEqual(10000, reader.GetInt32(3)); Assert.AreEqual(dt4, reader.GetDateTime(4));

            //Assert.IsFalse(reader.Read());

            DeleteRecords();

            count = CountRecords();
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void FlushTest() {
			string[] names = new string[] { "metalica", "beatles", "coldplay", "tiesto", "t-pain", "blink 182", "plain white ts", "staind", "pink floyd" };
			Random rand = new Random(Environment.TickCount);

			SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
			AddParameters(target);

			target.CommitMax = 1000;

			//Insert less records than commitmax
			for (int x = 0; x < 50; x++)
				target.Insert(new object[] { names[rand.Next(names.Length)], (float)rand.NextDouble(), rand.Next(50), DateTime.Now });

			//Close connect to verify records were not inserted
			_mDbCon.Close();

			_mDbCon = new SQLiteConnection(_mConnectionString);
			_mDbCon.Open();

			long count = CountRecords();
			Assert.AreEqual(0, count);

			//Now actually verify flush worked
			target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
			AddParameters(target);

			target.CommitMax = 1000;

			//Insert less records than commitmax
			for (int x = 0; x < 50; x++)
				target.Insert(new object[] { names[rand.Next(names.Length)], (float)rand.NextDouble(), rand.Next(50), DateTime.Now });

			target.Flush();

			count = CountRecords();
			Assert.AreEqual(50, count);

			//Close connect to verify flush worked
			_mDbCon.Close();

			_mDbCon = new SQLiteConnection(_mConnectionString);
			_mDbCon.Open();

			count = CountRecords();
			Assert.AreEqual(50, count);

			DeleteRecords();
			count = CountRecords();
			Assert.AreEqual(0, count);
		}

        [TestMethod()]
        public void CommitMaxTest()
        {
            SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);

            target.CommitMax = 4;
            Assert.AreEqual( Convert.ToUInt32(4), target.CommitMax);

            target.CommitMax = 1000;
            Assert.AreEqual(Convert.ToUInt32(1000), target.CommitMax);
        }

        //SPEED TEST
        [TestMethod()]
        public void AllowBulkInsertTest() {
			string[] names = new string[] { "metalica", "beatles", "coldplay", "tiesto", "t-pain", "blink 182", "plain white ts", "staind", "pink floyd"};
			Random rand = new Random(Environment.TickCount);

			SQLiteBulkInsert target = new SQLiteBulkInsert(_mDbCon, M_TEST_TABLE_NAME);
			AddParameters(target);

			const int count = 100;

			target.CommitMax = count;

			DateTime start1 = DateTime.Now;
			for (int x = 0; x < count; x++)
				target.Insert(new object[] { names[rand.Next(names.Length)], (float)rand.NextDouble(), rand.Next(count), DateTime.Now });

			DateTime end1 = DateTime.Now;
			TimeSpan delta1 = end1 - start1;

			DeleteRecords();

			target.AllowBulkInsert = false;
			DateTime start2 = DateTime.Now;
			for (int x = 0; x < count; x++)
				target.Insert(new object[] { names[rand.Next(names.Length)], (float)rand.NextDouble(), rand.Next(count), DateTime.Now });

			DateTime end2 = DateTime.Now;
			TimeSpan delta2 = end2 - start2;

			//THIS MAY FAIL DEPENDING UPON THE MACHINE THE TEST IS RUNNING ON.
			Assert.IsTrue(delta1.TotalSeconds < 0.1); //approx true for 100 recs 			
            Assert.IsTrue(delta2.TotalSeconds > 1.0); //approx true for 100 recs;

			//UNCOMMENT THIS TO MAKE IT FAIL AND SEE ACTUAL NUMBERS IN FAILED REPORT
			//Assert.AreEqual(delta1.TotalSeconds, delta2.TotalSeconds);

			DeleteRecords();
		}
    }
}