using System.Collections.Generic;
using ATMTECH.Scrum.DAO;
using ATMTECH.Scrum.Entities;
using ATMTECH.Shell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Scrum.Tests
{
    [TestClass]
    public class DAOStoryTest : BaseTest<DAOStory>
    {
        [TestMethod]
        public void GetByProduct_retourne2ligne()
        {
            IList<Story> stories = InstanceTest.GetByProduct(1);
            Assert.AreEqual(stories.Count, 2);
        }

        [TestMethod]
        public void GetBySprint_retourne1ligne()
        {
            IList<Story> stories = InstanceTest.GetBySprint(1);
            Assert.AreEqual(stories.Count, 1);
        }
    }
}
