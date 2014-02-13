using System;
using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.BillardLoretteville.Tests.Base
{
    [TestClass]
    public class EntityTest
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            Init initDatabase = new Init();
            initDatabase.InitDatabaseForTest();
        }

        [TestMethod]
        public void CreateTableReturnNoExceptionTest()
        {
            bool noException = true;
            try
            {
                ManageClass manageClass = new ManageClass();

                const string nameSpaceAtmtech = "ATMTECH.Entities";
                IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
                foreach (string s in listAtmtech)
                {
                    System.Diagnostics.Debug.WriteLine(manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s));
                }
            }
            catch (Exception)
            {
                noException = false;
            }
            Assert.IsTrue(noException);
        }

      
    }
}
