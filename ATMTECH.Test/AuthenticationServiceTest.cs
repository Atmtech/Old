using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Shell.Tests;
using ATMTECH.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMTECH.Entities;

namespace ATMTECH.Test
{


    /// <summary>
    ///Classe de test pour AuthenticationServiceTest, destinée à contenir tous
    ///les tests unitaires AuthenticationServiceTest
    ///</summary>
    [TestClass()]
    public class AuthenticationServiceTest : BaseTest<AuthenticationService>
    {
        private readonly BaseDao<User, int> _daoUser = new BaseDao<User, int>();
        private readonly DatabaseOperation<User, int> _databaseOperation = new DatabaseOperation<User, int>();


 
        //[TestMethod]
        //public void GetAuthenticateUserTestForAdminLogin()
        //{
        //    AuthenticationService authenticationService = new AuthenticationService();
        //    authenticationService.SignIn("admin", "test");
        //    Assert.AreEqual(authenticationService.AuthenticateUser.Login, "admin");
        //}

        //[TestMethod]
        //public void GetAuthenticateUserTestForAdminLoginFillLastLogin()
        //{
        //    AuthenticationService authenticationService = new AuthenticationService();
        //    authenticationService.SignIn("admin", "test");
        //    User user = _daoUser.GetById(1);
        //    Assert.IsNotNull(user.LastLogin);
        //}

        //[TestMethod]
        //public void GetAuthenticateUserTestForAdminIfFailReturnNull()
        //{
        //    AuthenticationService authenticationService = new AuthenticationService();
        //    User user = authenticationService.SignIn("admin", "fail");
        //    Assert.IsNull(user);
        //}

        //[TestMethod]
        //public void GetAuthenticateUserWithAuthenticateUserProperty()
        //{
        //    AuthenticationService authenticationService = new AuthenticationService();
        //    authenticationService.SignIn("admin", "test");
        //    Assert.IsNotNull(authenticationService.AuthenticateUser);
        //}

        //private void EmptyDatabase()
        //{
        //    _databaseOperation.ExecuteSql("DELETE FROM User");
        //    _databaseOperation.ExecuteSql("delete from sqlite_sequence where name='User'");
        //}

        //private void FillDatabase()
        //{
        //    User user = new User() { Login = "admin", Password = "test", IsAdministrator = true, Email = "test@test.com" };
        //    _daoUser.Save(user);
        //}

     
    }
}
