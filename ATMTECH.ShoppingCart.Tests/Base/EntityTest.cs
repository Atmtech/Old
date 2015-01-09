using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.ShoppingCart.Tests.Base
{
    [TestClass]
    public class EntityTest
    {
        [ClassInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            //Init initDatabase = new Init();
            //initDatabase.InitDatabaseForTest();
        }

        [TestMethod]
        public void CreateTableReturnNoExceptionTest()
        {
            
            //bool noException = true;
            //try
            //{
            //    ManageClass manageClass = new ManageClass();

            //    const string nameSpaceAtmtech = "ATMTECH.Entities";
            //    IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            //    foreach (string s in listAtmtech)
            //    {
            //        System.Diagnostics.Debug.WriteLine(manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s));
            //    }

            //    const string nameSpace = "ATMTECH.ShoppingCart.Entities";
            //    IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            //    foreach (string s in list)
            //    {
            //        System.Diagnostics.Debug.WriteLine(manageClass.GenerateCreateTableSqlFromClass(nameSpace, s));
            //    }
            //}
            //catch (System.Exception)
            //{
            //    noException = false;
            //}
            //Assert.IsTrue(noException);
        }

      
    }
}
