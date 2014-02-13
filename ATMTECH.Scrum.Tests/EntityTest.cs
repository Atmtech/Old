using System;
using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.Scrum.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Scrum.Tests
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

                const string nameSpace = "ATMTECH.Scrum.Entities";
                IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
                foreach (string s in list)
                {
                    System.Diagnostics.Debug.WriteLine(manageClass.GenerateCreateTableSqlFromClass(nameSpace, s));
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
