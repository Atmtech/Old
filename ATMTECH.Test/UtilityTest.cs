using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Test
{
    /// <summary>
    /// Summary description for UtilityTest
    /// </summary>
    [Ignore]
    [TestClass]
    public class UtilityTest
    {
        private ManageClass _manageClass = new ManageClass();
        [TestMethod]
        public void GetClassObjectFromString()
        {
            object test = _manageClass.GetClassObject("ATMTECH.Test.Entities", "EntityTest");
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void GetAlterTableFromEntityManageClass()
        {
            string rtn = _manageClass.GenerateAlterTableSqlFromClass("ATMTECH.Test.Entities", "EntityManageClass");
            Assert.AreEqual(rtn, "ALTER TABLE [EntityManageClass] ADD A VARCHAR(1000);\r\nALTER TABLE [EntityManageClass] ADD B INTEGER;\r\nALTER TABLE [EntityManageClass] ADD C FLOAT;\r\nALTER TABLE [EntityManageClass] ADD D DATETIME;\r\nALTER TABLE [EntityManageClass] ADD E INTEGER;\r\nALTER TABLE [EntityManageClass] ADD F TINYINT\r\n");
        }

        [TestMethod]
        public void GetCreateTableFromEntityTest()
        {
            string rtn = _manageClass.GenerateCreateTableSqlFromClass("ATMTECH.Test.Entities", "EntityTest");


            Assert.AreEqual(rtn,
                            "CREATE TABLE [EntityTest] (\r\n[Id] INTEGER PRIMARY KEY AUTOINCREMENT,\r\n[Description] TEXT,\r\n[IsActive] TINYINT,\r\n[DateCreated] DATETIME,\r\n[DateModified] DATETIME,\r\n[Language] VARCHAR(10),\r\n[OrderId] INTEGER,\r\n[EntityTestSon] INTEGER,\r\n[A] VARCHAR(1000),\r\n[B] INTEGER,\r\n[C] TINYINT,\r\n[D] FLOAT,\r\n[E] DATETIME,\r\n[Order] INTEGER);");
        }

        [TestMethod]
        public void GetAllClasseFromANameSpace()
        {
            Assert.AreEqual(_manageClass.GetAllClassesFromNameSpace("ATMTECH.Test.Entities").Count, 5);
        }

        [TestMethod]
        public void GetAllNameSpaceEntitieTest()
        {
            List<string> liste = _manageClass.GetAllNameSpaceEntitie(@"C:\dev\Atmtech\ATMTECH.Test\bin\Debug");
            Assert.AreEqual(liste[0], "ATMTECH.Entities");
        }

    }
}
