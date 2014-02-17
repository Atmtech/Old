using System;
using ATMTECH.Achievement.Tests.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.Achievement.WebSite.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenererDatabase(object sender, EventArgs e)
        {
            InitializeDatabase initializeDatabase = new InitializeDatabase();
            initializeDatabase.InitializeDatabaseSqlite(@"C:\Dev\Atmtech\ATMTECH.Achievement.Tests\Database\Accomplissement.db3", "ATMTECH.Achievement.Entities");

            DatabaseData databaseData = new DatabaseData();
            databaseData.FillData();

            //Initialisation initialisation = new Initialisation();
            //initialisation.CreerDatabase();
        }



    }
}