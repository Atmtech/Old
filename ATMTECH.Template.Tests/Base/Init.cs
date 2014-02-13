using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO.SessionManager;

namespace ATMTECH.Template.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.Template.Tests\Database\Template.db3";
            string sqlDropTable = string.Empty;
            ManageClass manageClass = new ManageClass();

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }

            const string nameSpace = "ATMTECH.Template.Entities";
            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                manageClass.GenerateCreateTableSqlFromClass(nameSpace, s);
            }

            //BaseDao<StockQuote, int> dao = new BaseDao<StockQuote, int>();
            //dao.ExecuteSql(sqlDropTable);
            //dao.ExecuteSql(sql);
        }
        private static void CreateErrorMessage()
        {

        }

        private static void CreateParameter()
        {
        
        }
        private static void FillData()
        {
            CreateErrorMessage();
            CreateParameter();
        }

        public void InitDatabaseForTest()
        {
            CreateDatabase();
            CreateErrorMessage();
            FillData();
        }

    }
}
