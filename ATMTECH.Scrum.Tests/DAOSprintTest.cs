using System.Collections.Generic;
using ATMTECH.Scrum.DAO;
using ATMTECH.Scrum.Entities;
using ATMTECH.Shell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Scrum.Tests
{
    [TestClass]
    public class DAOSprintTest : BaseTest<DAOSprint>
    {
        [TestMethod]
        public void GetByProduct_Return1Product()
        {
            IList<Sprint> sprint = InstanceTest.GetByProduct(1);
            Assert.AreEqual(sprint.Count, 1);
        }
    }
}
