using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Database
{
    public class InitializeDatabase
    {
        public void InitializeDatabaseSqlite(string sqliteFile, string nameSpaceEntities)
        {
            DatabaseSessionManager.ConnectionString = @"data source=" + sqliteFile + ";";
            string sqlDropTable = string.Empty;
            ManageClass manageClass = new ManageClass();
            string sql = string.Empty;

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }

            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpaceEntities);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceEntities, s);
            }

            BaseDao<User, int> dao = new BaseDao<User, int>();
            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);

        }
        public void InitializeDatabaseSqliteEnMemoire(string nameSpaceEntities)
        {
            DatabaseSessionManager.ConnectionString = @"data source=:memory:";
            string sqlDropTable = string.Empty;
            ManageClass manageClass = new ManageClass();
            string sql = string.Empty;

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }

            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpaceEntities);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceEntities, s);
            }

            BaseDao<User, int> dao = new BaseDao<User, int>();
            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);

        }

    }
}
