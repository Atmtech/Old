using System.Collections.Generic;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Investisseurs.Services.Base;
using ATMTECH.Investisseurs.Tests.Builder;

namespace ATMTECH.Investisseurs.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.Investisseurs.Tests\Database\Investisseurs.db3";
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

            const string nameSpace = "ATMTECH.Investisseurs.Entities";
            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpace, s);
            }

            BaseDao<StockQuote, int> dao = new BaseDao<StockQuote, int>();
            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);
        }
        private static void CreateErrorMessage()
        {

        }

        private static void CreateParameter()
        {
            BaseDao<Parameter, int> daoParameter = new BaseDao<Parameter, int>();
            Parameter parameter1 = new Parameter() { Code = Constant.ADMIN_MAIL, Description = "admin@admin.com" };
            daoParameter.Save(parameter1);
            Parameter parameter2 = new Parameter() { Code = Constant.MAIL_BODY_CONFIRM_CREATE, Description = @"Cliquer ici pour confirmer la création de votre compte:<br><br><a href='http:\\www.fishingatwork.com\ConfirmCreate.aspx?ConfirmCreate={0}'>Confirmer la création de mon compte</a>" };
            daoParameter.Save(parameter2);
            Parameter parameter3 = new Parameter() { Code = Constant.MAIL_SUBJECT_CONFIRM_CREATE, Description = "Nouvelle demande de création de compte" };
            daoParameter.Save(parameter3);
            Parameter parameter4 = new Parameter() { Code = Constant.MAIL_SUBJECT_FORGET_PASSWORD, Description = "Une demande d'oubli de mot de passe a été demandé." };
            daoParameter.Save(parameter4);
            Parameter parameter5 = new Parameter() { Code = Constant.MAIL_BODY_FORGET_PASSWORD, Description = "Voici votre mot de passe: {0}" };
            daoParameter.Save(parameter5);
            Parameter parameter7 = new Parameter() { Code = Constant.MAIL_SUBJECT_ORDER_FINALIZED, Description = "La commande a été passé avec succès: {0}" };
            daoParameter.Save(parameter7);
            Parameter parameter8 = new Parameter() { Code = Constant.MAIL_BODY_ORDER_FINALIZED, Description = "Voici le détail de la commande: <br>{0}" };
            daoParameter.Save(parameter8);
            Parameter parameter10 = new Parameter() { Code = "Environment", Description = "DEV" };
            daoParameter.Save(parameter10);
            Parameter parameter11 = new Parameter() { Code = "SmtpServer", Description = "smtp.gmail.com" };
            daoParameter.Save(parameter11);
            Parameter parameter12 = new Parameter() { Code = "SmtpServerLogin", Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter12);
            Parameter parameter13 = new Parameter() { Code = "SmtpServerPassword", Description = "10sagace01" };
            daoParameter.Save(parameter13);
            Parameter parameter14 = new Parameter() { Code = "SmtpServerPort", Description = "587" };
            daoParameter.Save(parameter14);
            Parameter parameter15 = new Parameter() { Code = Constant.STARTING_MONEY, Description = "5000" };
            daoParameter.Save(parameter15);
            Parameter parameter16 = new Parameter() { Code = Constant.TRANSACTION_FEE, Description = "50" };
            daoParameter.Save(parameter16);
        }
        private static void FillData()
        {
            CreateErrorMessage();
            CreateParameter();
            CreatePlayer("riov01", "test", "Vincent", "Rioux");

        }

        private static Player CreatePlayer(string login, string password, string firstName, string lastName)
        {
            BaseDao<Player, int> daoPlayer = new BaseDao<Player, int>();
            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            BaseDao<Transaction, int> daoTransaction = new BaseDao<Transaction, int>();

            User user = UserBuilder.Create().WithLogin(login).WithPassword(password).WithFirstName(firstName).WithLastName(lastName).WithIsAdministrator(true).WithEmail("sagaan@hotmail.com");
            user.Id = daoUser.Save(user);

            Player player = PlayerBuilder.Create().WithUser(user).WithImage("default.png").WithStartingMoney(5000);
            player.Id = daoPlayer.Save(player);

            Transaction transaction = TransactionBuilder.CreateValid().WithPlayer(player);
            daoTransaction.Save(transaction);
            return player;
        }


        public void InitDatabaseForTest()
        {
            CreateDatabase();
            CreateErrorMessage();
            FillData();
        }

    }
}
