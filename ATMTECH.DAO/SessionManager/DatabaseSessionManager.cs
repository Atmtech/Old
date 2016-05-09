using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Database;

namespace ATMTECH.DAO.SessionManager
{
    public class DatabaseSessionManager
    {
        public static string ConnectionString { get; set; }
        public static int DatabaseTransactionCount { get; set; }
        public static DbConnection Session
        {
            get {
                return ContextSessionManager.Context == null ? GetLocalSession() : GetWebSession();
            }
        }
        public static bool IsUnitTesting { get; set; }
        public static SqlTransaction CurrentSqlTransactionUnitTesting { get; set; }

        private static DbConnection _session;
        private static DbConnection GetLocalSession()
        {
            switch (DatabaseVendor.GetCurrentDatabaseVendorType())
            {
              
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    if (_session == null)
                    {
                        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                        _session = sqlConnection;
                    }

                    if (ConnectionString != _session.ConnectionString)
                    {
                        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                        _session = sqlConnection;
                    }

                    if (_session.State != ConnectionState.Open)
                    {
                        _session.Open();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

//server=SD-57207\\MEDIATOR;Initial Catalog=mediator;Integrated security=SSPI;Trusted_Connection=True;


            return _session;
        }
        private static DbConnection GetWebSession()
        {
            DbConnection dbConnection = null;
            if (ContextSessionManager.Context.Session != null)
            {
                if (ContextSessionManager.Context.Session["DatabaseSession"] is DbConnection)
                {
                    dbConnection = (DbConnection)ContextSessionManager.Context.Session["DatabaseSession"];
                }

                switch (DatabaseVendor.GetCurrentDatabaseVendorType())
                {

                    case DatabaseVendor.DatabaseVendorType.MsSql:
                        if (dbConnection == null)
                        {
                            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                            dbConnection = sqlConnection;
                            ContextSessionManager.Context.Session["DatabaseSession"] = sqlConnection;
                        }

                        if (ConnectionString != dbConnection.ConnectionString)
                        {
                            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                            dbConnection = sqlConnection;
                            ContextSessionManager.Context.Session["DatabaseSession"] = sqlConnection;
                        }

                        if (dbConnection.State != ConnectionState.Open)
                        {
                            dbConnection.Open();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return dbConnection;
        }

    }

}
