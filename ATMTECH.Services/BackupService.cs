using System;
using System.Data;
using System.Data.SQLite;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Services.Interface;

namespace ATMTECH.Services
{
    public class BackupService : IBackupService
    {
        public void CopyTableFromSqlite(string tableNameSource, string tableNameDestination, string sqliteSource, string sqliteDestination)
        {
            DatabaseSessionManager.ConnectionString = @"data source=" + sqliteSource;
            DataSet setBackup = new DataSet();
            using (SQLiteCommand commandFill = new SQLiteCommand("select * from " + tableNameSource, (SQLiteConnection) DatabaseSessionManager.Session))
            {
                using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter(commandFill))
                {
                    sqlDataAdapter.Fill(setBackup, tableNameDestination);

                    DatabaseSessionManager.ConnectionString = @"data source=" + sqliteDestination;
                    setBackup.Tables[0].TableName = tableNameDestination;
                    string sqlCreate = CreateTableSqlite(setBackup.Tables[0]);
                    using (SQLiteCommand commandCreate = new SQLiteCommand(sqlCreate, (SQLiteConnection) DatabaseSessionManager.Session))
                    {
                        commandCreate.ExecuteScalar();
                    }

                    using (SQLiteTransaction transaction = (SQLiteTransaction) DatabaseSessionManager.Session.BeginTransaction())
                    {
                        SQLiteDataAdapter test = new SQLiteDataAdapter("SELECT * FROM " + tableNameDestination, (SQLiteConnection)DatabaseSessionManager.Session);
                        
                        test.InsertCommand = new SQLiteCommandBuilder(test).GetInsertCommand();

                        
                        test.Update(setBackup, tableNameDestination);
                        transaction.Commit();
                    }
                }
            }

        }

        public void RestoreXmlToSqliteDatabase(string xml, string sqliteDatabasePath)
        {
            DatabaseSessionManager.ConnectionString = @"data source=" + sqliteDatabasePath;

            DataSet set = new DataSet();
            set.ReadXml(xml, XmlReadMode.ReadSchema);
            DataTable dataTableXml = set.Tables[0];
            string sqlCreate = CreateTableSqlite(dataTableXml);
            using (SQLiteCommand commandCreate = new SQLiteCommand(sqlCreate, (SQLiteConnection)DatabaseSessionManager.Session))
            {
                commandCreate.ExecuteScalar();
            }

            using (SQLiteCommand commandFill = new SQLiteCommand("select * from " + set.Tables[0].TableName, (SQLiteConnection)DatabaseSessionManager.Session))
            {
                DataSet setBackup = new DataSet();
                using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter(commandFill))
                {
                    sqlDataAdapter.Fill(setBackup, dataTableXml.TableName);
                    DataTable table = setBackup.Tables[0];
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        table.NewRow();
                        table.Rows.Add(row.ItemArray);
                    }


                    using (SQLiteTransaction transaction = ((SQLiteConnection) DatabaseSessionManager.Session).BeginTransaction())
                    using (SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM " + set.Tables[0].TableName, (SQLiteConnection)DatabaseSessionManager.Session))
                    {
                        using (sqliteAdapter.InsertCommand = new SQLiteCommandBuilder(sqliteAdapter).GetInsertCommand())
                        {
                            sqliteAdapter.Update(setBackup, set.Tables[0].TableName);
                        }
                        transaction.Commit();
                    }
                }
            }

        }

        private string CreateTableSqlite(DataTable dataTable)
        {
            const string sql = "CREATE TABLE [{0}] ({1})";
            string tableName = dataTable.TableName;
            string column = string.Empty;

            DataColumnCollection dataColumnCollection = dataTable.Columns;

            foreach (DataColumn dataColumn in dataColumnCollection)
            {
                column += "[" + dataColumn.ColumnName + "] ";

                string columnType;

                switch (dataColumn.DataType.FullName.ToLower())
                {
                    case "system.string":
                        columnType = "VARCHAR(1000)";
                        break;
                    case "system.int32":
                        columnType = "INTEGER";
                        break;
                    case "system.boolean":
                        columnType = "TINYINT";
                        break;
                    case "system.datetime":
                        columnType = "DATETIME";
                        break;
                    case "system.decimal":
                        columnType = "FLOAT";
                        break;
                    case "system.double":
                        columnType = "FLOAT";
                        break;
                    default:
                        columnType = "INTEGER";
                        break;

                }

                if (dataColumnCollection[dataColumnCollection.Count - 1].ColumnName == dataColumn.ColumnName)
                {
                    column += columnType;
                }
                else
                {
                    column += columnType + ", ";
                }
            }
            return String.Format(sql, tableName, column);
        }
    }
}
