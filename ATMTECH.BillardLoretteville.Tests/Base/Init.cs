using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;

namespace ATMTECH.BillardLoretteville.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.BillardLoretteville.Website\App_Data\BillardLoretteville.db3";
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

            BaseDao<ContentCms, int> dao = new BaseDao<ContentCms, int>();
            //dao.ExecuteSql(sqlDropTable);
            //dao.ExecuteSql(sql);
        }

        private void InitDependancy()
        {

        }

        private void FillData()
        {
            User user = new User { Login = "riov01", Password = "test", IsAdministrator = true };
            new BaseDao<User, int>().Save(user);

            Language language1 = new Language() { Code = "fr", Description = "Francais" };
            Language language2 = new Language() { Code = "en", Description = "Anglais" };
            new BaseDao<Language, int>().Save(language1);
            new BaseDao<Language, int>().Save(language2);

            ContentCms contentCms1 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Billard", Value = "Billard" };
            ContentCms contentCms2 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Contact", Value = "Contact" };
            ContentCms contentCms3 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Poker", Value = "Poker" };
            ContentCms contentCms4 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Photo", Value = "Photo" };
            ContentCms contentCms5 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Tarif", Value = "Tarif" };
            ContentCms contentCms6 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Tournoi", Value = "Tournoi" };
            ContentCms contentCms7 = new ContentCms() { IsActive = true, Language = "fr", PageName = "Default", Value = "Default" };

            new BaseDao<ContentCms, int>().Save(contentCms1);
            new BaseDao<ContentCms, int>().Save(contentCms2);
            new BaseDao<ContentCms, int>().Save(contentCms3);
            new BaseDao<ContentCms, int>().Save(contentCms4);
            new BaseDao<ContentCms, int>().Save(contentCms5);
            new BaseDao<ContentCms, int>().Save(contentCms6);
            new BaseDao<ContentCms, int>().Save(contentCms7);

            File file1 = new File() { Description = "Test1", ServerPath = "1.jpg", Title = "Titre", Size = 100};
            File file2 = new File() { Description = "Test2", ServerPath = "2.jpg", Title = "Titre", Size = 100 };
            File file3 = new File() { Description = "Test3", ServerPath = "3.jpg", Title = "Titre", Size = 100 };

            new BaseDao<File, int>().Save(file1);
            new BaseDao<File, int>().Save(file2);
            new BaseDao<File, int>().Save(file3);
        }

        public void InitDatabaseForTest()
        {
            CreateDatabase();
            FillData();
            InitDependancy();
        }

    }
}
