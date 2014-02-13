using System;
using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Tests.Builder;
using ATMTECH.Test.Builder;

namespace ATMTECH.Scrum.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.Scrum.Tests\Database\Scrum.db3";
            string sqlDropTable = string.Empty;
            string sql = string.Empty;
            ManageClass manageClass = new ManageClass();

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }

            const string nameSpace = "ATMTECH.Scrum.Entities";
            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpace, s);
            }

            BaseDao<Product, int> dao = new BaseDao<Product, int>();
            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);
        }
        private static void CreateErrorMessage()
        {

        }

        private static void FillData()
        {
            User user = UserBuilder.Create().WithLogin("riov01").WithPassword("test").WithFirstName("Vincent").WithLastName("R");
            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            daoUser.Save(user);
            user.Id = 1;

            BaseDao<Product, int> daoProduct = new BaseDao<Product, int>();
            Product product = ProductBuilder.Create().WithDescription("Produit Test").WithProductOwner(user);
            daoProduct.Save(product);
            product.Id = 1;

            BaseDao<Sprint, int> daoSprint = new BaseDao<Sprint, int>();
            Sprint sprint =
                SprintBuilder.Create().WithProduct(product).WithDescription("Sprint #1").WithDateStart(
                    Convert.ToDateTime("2001-01-01")).WithDateEnd(Convert.ToDateTime("2001-01-10"));
            daoSprint.Save(sprint);
            sprint.Id = 1;

            BaseDao<Story, int> daoStory = new BaseDao<Story, int>();
            Story story1 = StoryBuilder.Create().WithComment("Un commentaire").WithDescription("En tant que chef je suis un chef").WithPoint(5).WithProduct(product).WithStatus("Undone");
            daoStory.Save(story1);
            story1.Id = 1;

            Story story2 = StoryBuilder.Create().WithComment("Un commentaire").WithDescription("En tant que patate je serai une patate").WithPoint(2).WithProduct(product).WithSprint(sprint).WithStatus("Undone"); 
            daoStory.Save(story2);
            story2.Id = 2;

            BaseDao<Task, int> daoTask = new BaseDao<Task, int>();
            Task task = TaskBuilder.Create().WithEstimateTime(10).WithUser(user).WithStory(story1).WithDescription("Détruire");
            daoTask.Save(task);
        }

        public void InitDatabaseForTest()
        {
            CreateDatabase();
            CreateErrorMessage();
            FillData();
        }

    }
}
