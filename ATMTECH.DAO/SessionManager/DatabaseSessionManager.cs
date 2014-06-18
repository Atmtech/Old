using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Data.SqlClient;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Database;
using MySql.Data.MySqlClient;

namespace ATMTECH.DAO.SessionManager
{
    public class DatabaseSessionManager
    {

        public static string ConnectionString { get; set; }


        public static int DatabaseTransactionCount { get; set; }

        // private static DbConnection _session;
        public static DbConnection Session
        {
            get {
                return ContextSessionManager.Context == null ? GetLocalSession() : GetWebSession();
            }
        }

        private static DbConnection _session;
        private static DbConnection GetLocalSession()
        {
            switch (DatabaseVendor.GetCurrentDatabaseVendorType())
            {
                case DatabaseVendor.DatabaseVendorType.Sqlite:
                    if (_session == null)
                    {
                        SQLiteConnection sqLiteConnection = new SQLiteConnection(ConnectionString);
                        _session = sqLiteConnection;
                    }

                    if (ConnectionString != _session.ConnectionString)
                    {
                        SQLiteConnection sqLiteConnection = new SQLiteConnection(ConnectionString);
                        _session = sqLiteConnection;
                    }

                    if (_session.State != ConnectionState.Open)
                    {
                        if (_session.ConnectionString != "")
                        {
                            _session.Open();
                        }

                    }
                    break;
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
                case DatabaseVendor.DatabaseVendorType.MySql:
                    if (_session == null)
                    {
                        MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                        _session = sqlConnection;
                    }

                    if (ConnectionString != _session.ConnectionString)
                    {
                        MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
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
                    case DatabaseVendor.DatabaseVendorType.Sqlite:
                        if (dbConnection == null)
                        {
                            SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString);
                            dbConnection = sqlConnection;
                            ContextSessionManager.Context.Session["DatabaseSession"] = sqlConnection;
                        }

                        if (ConnectionString != dbConnection.ConnectionString)
                        {
                            SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString);
                            dbConnection = sqlConnection;
                            ContextSessionManager.Context.Session["DatabaseSession"] = sqlConnection;
                        }

                        if (dbConnection.State != ConnectionState.Open)
                        {
                            if (dbConnection.ConnectionString != "")
                            {
                                dbConnection.Open();
                            }

                        }
                        break;
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
                    case DatabaseVendor.DatabaseVendorType.MySql:
                        if (dbConnection == null)
                        {
                            MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                            dbConnection = sqlConnection;
                            ContextSessionManager.Context.Session["DatabaseSession"] = sqlConnection;
                        }

                        if (ConnectionString != dbConnection.ConnectionString)
                        {
                            MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
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
