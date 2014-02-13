using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATMTECH.Test
{
    /// <summary>
    /// Description résumée pour MessageServiceTest
    /// </summary>
    [TestClass]
    public class MessageServiceTest
    {
        private BaseDao<Message, int> _daoMessage = new BaseDao<Message, int>();
        private DatabaseOperation<Message, int> _databaseOperation = new DatabaseOperation<Message, int>();

        [TestInitialize]
        public void Init()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.Test.Website\App_Data\Test.db3";
            EmptyDatabase();
            FillDatabase();
        }

        //[TestMethod]
        //public void GetMessageTest()
        //{
        //    MessageService messageService = new MessageService();
        //    Message message = messageService.GetMessage("0001");
        //    Assert.AreEqual(message.Description, "Erreur");
        //}

        //[TestMethod]
        //public void GetMessageTestFromBaseService()
        //{
        //    NavigationService navigationService = new NavigationService();
        //    Message message = navigationService.MessageService.GetMessage("0001");
        //    Assert.AreEqual(message.Description, "Erreur");
        //}

        private void EmptyDatabase()
        {
            _databaseOperation.ExecuteSql("DELETE FROM Message");
            _databaseOperation.ExecuteSql("delete from sqlite_sequence where name='Message'");
        }

        private void FillDatabase()
        {
            Message message = new Message() { InnerId = "0001", Description = "Erreur" };
            _daoMessage.Save(message);
        }
    }
}
