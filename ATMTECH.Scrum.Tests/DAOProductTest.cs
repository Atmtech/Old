using ATMTECH.Scrum.DAO;
using ATMTECH.Scrum.Entities;
using ATMTECH.Shell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Scrum.Tests
{
    [TestClass]
    public class DAOProductTest : BaseTest<DAOProduct>
    {
        [TestMethod]
        public void Product_EstBienRempl()
        {
            Product product = InstanceTest.GetProduct(1);
            Assert.AreEqual(product.Description, "Produit Test");
        }
    }
}
