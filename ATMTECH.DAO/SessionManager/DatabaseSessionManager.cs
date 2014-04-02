using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Data.SqlClient;
using ATMTECH.DAO.Database;
using MySql.Data.MySqlClient;

namespace ATMTECH.DAO.SessionManager
{
    public class DatabaseSessionManager
    {
        public static string ConnectionString { get; set; }

        public static int DatabaseTransactionCount { get; set; }

        private static DbConnection _session;
        public static DbConnection Session
        {
            get
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
        }

    }
}
