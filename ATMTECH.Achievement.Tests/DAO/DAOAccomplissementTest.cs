using System.Collections.Generic;
using System.Linq;
using ATMTECH.Achievement.DAO;
using ATMTECH.Achievement.Entities;
using ATMTECH.Shell.Tests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace ATMTECH.Achievement.Tests.DAO
{
    [TestClass]
    public class DAOAccomplissementTest : BaseDaoTest<DAOAccomplissement>
    {
        [TestInitialize()]
        public void Initialize()
        {
            CreerDatabaseTest("ATMTECH.Achievement.Entities");
        }

   
    }
}

