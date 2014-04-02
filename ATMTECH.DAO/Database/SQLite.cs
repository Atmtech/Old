using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Database
{
    public class SQLite<TModel, TId> : IDatabase<TModel, TId>
    {
        public SQLiteConnection CurrentDatabaseConnection { get { return (SQLiteConnection)DatabaseSessionManager.Session; } }
        public Model<TModel, TId> Model { get { return new Model<TModel, TId>(); } }
        public DatabaseOperation<TModel, TId> DatabaseOperation { get { return new DatabaseOperation<TModel, TId>(); } }
        public User AuthenticateUser
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session["Internal_LoggedUser"] != null)
                    {
                        return (User)HttpContext.Current.Session["Internal_LoggedUser"];
                    }
                }
                return null;
            }
        }

        public const string DATE_MODIFIED_COLUMN = "DateModified";
        public const string DATE_CREATED_COLUMN = "DateCreated";
        public const string IS_ACTIVE = "IsActive";
        public const string SQL_SELECT_WHERE = "SELECT {0} FROM [{1}] WHERE {2} ";
        public const string SQL_SELECT = "SELECT {0} FROM [{1}] ";
        public const string SQL_INSERT = "INSERT INTO [{0}] ({1}) VALUES ({2})";
        public const string SQL_UPDATE = "UPDATE [{0}] SET {1} WHERE {3} = {2} ";
        public const string SQL_PAGING = "LIMIT {0},{1}";
        public const string SQL_ORDER_BY = "ORDER BY [{0}] {1} ";
        public const string SQL_RETURN_COLUMN = "SELECT * FROM [{0}] LIMIT 1";
        public const string SQL_MAX = "SELECT MAX({0}) FROM [{1}]";
        public const string SQL_COUNT = "SELECT COUNT() as counts FROM {0}";

        public DataColumnCollection ReturnAllColumnNameFromTable(string table)
        {
            string sql = string.Format(SQL_RETURN_COLUMN, table);
            DataSet dataSet = new DataSet();
            using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter())
            {
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, CurrentDatabaseConnection);

                sqlCommand.Connection = CurrentDatabaseConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlDataAdapter.SelectCommand = sqlCommand;

                sqlDataAdapter.Fill(dataSet);
            }
            return dataSet.Tables[0].Columns;
        }
        public DataSet ReturnDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter())
            {
                using (SQLiteCommand sqlCommand = new SQLiteCommand(sql, CurrentDatabaseConnection))
                {
                    DateTime startDate = DateTime.Now;
                    string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    sqlDataAdapter.Fill(dataSet);

                    DateTime endDate = DateTime.Now;
                    string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                    TimeSpan diffResult = endDate - startDate;

                    // Show sql debug
                    Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                           diffResult.Milliseconds.ToString() + "ms) :: " + sql);
                }
            }
            return dataSet;
        }
        public DataSet ReturnDataSet(PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            return ReturnDataSet("", null, pagingOperation, orderOperation);
        }
        public DataSet ReturnDataSetMax(string columnName)
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_COUNT, tableName);
            SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
            SQLiteCommand sqlCommand = new SQLiteCommand(sql, CurrentDatabaseConnection);


            DateTime startDate = DateTime.Now;
            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - startDate;

            // Show sql debug
            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);
            return dataSet;
        }
        public DataSet ReturnDataSetCount()
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_COUNT, tableName);
            SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter();
            SQLiteCommand sqlCommand = new SQLiteCommand(sql, CurrentDatabaseConnection);


            DateTime startDate = DateTime.Now;
            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - startDate;

            // Show sql debug
            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);
            return dataSet;
        }
        public DataSet ReturnDataSet(string where, IList<Criteria> criterias, PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();

            var sql = DatabaseOperation.ConstructSqlFromModel(@where, pagingOperation, orderOperation, type);
            DataSet dataSet = new DataSet();
            using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter())
            {
                using (SQLiteCommand sqlCommand = new SQLiteCommand(sql, CurrentDatabaseConnection))
                {
                    if (criterias != null && criterias.Count > 0)
                    {
                        foreach (Criteria criteria in criterias)
                        {
                            if (criteria.ClearText)
                            {
                                sqlCommand.Parameters.Add(new SQLiteParameter(criteria.Column, "'" + criteria.Value + "'"));
                            }
                            else if (criteria.Operator == DatabaseOperator.OPERATOR_LIKE)
                            {
                                sqlCommand.Parameters.Add(new SQLiteParameter(criteria.Column,
                                                                              "%" + criteria.Value + "%"));
                            }
                            else if (criteria.DbType == DbType.DateTime)
                            {
                                sqlCommand.Parameters.Add(new SQLiteParameter(criteria.Column, criteria.DbType, criteria.Value));
                            }
                            else
                            {
                                sqlCommand.Parameters.Add(new SQLiteParameter(criteria.Column, criteria.Value));
                            }
                        }

                    }

                    DateTime startDate = DateTime.Now;
                    string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    sqlDataAdapter.Fill(dataSet);

                    DateTime endDate = DateTime.Now;
                    string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                    TimeSpan diffResult = endDate - startDate;

                    // Show sql debug
                    Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                           diffResult.Milliseconds.ToString() + "ms) :: " + sql);

                   //DatabaseSessionManager.
                }
            }
            return dataSet;
        }
        public int InsertSql(TModel model)
        {
            int rtn = 0;
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);

            string sql = string.Format(SQL_INSERT, tableName, DatabaseOperation.ReturnColumnInsert(model), DatabaseOperation.ReturnValueInsert(model));

            using (SQLiteCommand command = new SQLiteCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.Name == IS_ACTIVE)
                    {
                        // Active = true;
                        command.Parameters.Add(new SQLiteParameter(propertyInfo.Name, "1"));
                    }
                    else
                    {


                        if (propertyInfo.PropertyType.Namespace == "System")
                        {
                            command.Parameters.Add(new SQLiteParameter(propertyInfo.Name,
                                                                       propertyInfo.GetValue(model, null)));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                            {
                                command.Parameters.Add(new SQLiteParameter(propertyInfo.Name,
                                                                           Model.ExtractValuePropertyPath(model,
                                                                                                    propertyInfo.Name +
                                                                                                    "." + Model.GetIdKeyColumnFromModel())));
                            }
                        }
                    }

                }
                SendToTransactionLog(command);
                command.ExecuteNonQuery();
                command.CommandText = "select last_insert_rowid();";
                rtn = Convert.ToInt32(command.ExecuteScalar());
            }


            return rtn;
        }
        public void ExecuteSql(string sql)
        {

            DateTime startDate = DateTime.Now;
            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

            using (SQLiteCommand command = new SQLiteCommand(sql, CurrentDatabaseConnection))
            {
                command.ExecuteScalar();
            }

            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - startDate;

            // Show sql debug
            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                   diffResult.Milliseconds.ToString() + "ms) :: " + sql);

        }
        public void UpdateSql(TModel model, string id)
        {
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_UPDATE, tableName, DatabaseOperation.ReturnSetClauseUpdate(model, id), Model.GetValueProperty(id, model), id);
            using (SQLiteCommand command = new SQLiteCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.PropertyType.Namespace == "System")
                    {
                        command.Parameters.Add(propertyInfo.GetValue(model, null) == null
                                                   ? new SQLiteParameter(propertyInfo.Name, "")
                                                   : new SQLiteParameter(propertyInfo.Name,
                                                                         propertyInfo.GetValue(model, null)));
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                        {
                            command.Parameters.Add(new SQLiteParameter(propertyInfo.Name, Model.ExtractValuePropertyPath(model, propertyInfo.Name + "." + id)));
                        }
                    }
                }
                command.ExecuteScalar();
                SendToTransactionLog(command);
            }
        }
        public void BackupToXml(string zipFile, bool allTableFromDatabase)
        {
            string path = Path.GetDirectoryName(zipFile);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (allTableFromDatabase)
            {
                foreach (string table in GetAllTable())
                {
                    CreateXmlFile(table, zipFile);
                }
            }
            else
            {
                TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
                Type type = model.GetType();
                CreateXmlFile(type.Name, zipFile);
            }

            ManageZipBackup manageZipBackup = new ManageZipBackup();
            manageZipBackup.CreateZipFile(zipFile);
        }
        public void RestoreFromXml(string zipFile)
        {
            ManageZipBackup manageZipBackup = new ManageZipBackup();
            manageZipBackup.UnzipFile(zipFile);

            string path = Path.GetDirectoryName(zipFile);
            string[] extensionFilters = new[] { ".xml" };
            String[] files = Directory.GetFiles(path).Where(filename => extensionFilters.Any(x => filename.EndsWith(x, StringComparison.OrdinalIgnoreCase))).ToArray();
            foreach (string file in files)
            {
                DataSet set = new DataSet();
                set.ReadXml(file, XmlReadMode.ReadSchema);
                RestoreXmlFile(set.Tables[0]);
            }

        }


        private void SendToTransactionLog(SQLiteCommand commandInit)
        {
            if (AuthenticateUser != null)
            {
                using (SQLiteCommand command = new SQLiteCommand("create table if not exists TransactionLog (Sql varchar(8000),Parameter varchar(8000), User int, DateExecute datetime)", CurrentDatabaseConnection))
                {
                    command.ExecuteScalar();
                }


                string parameter = string.Empty;
                if (commandInit.Parameters != null)
                {
                    foreach (SQLiteParameter sqLiteParameter in commandInit.Parameters)
                    {
                        if (sqLiteParameter.Value != null)
                        { parameter += sqLiteParameter.ParameterName + "=" + sqLiteParameter.Value.ToString().Replace("'", "_") + Environment.NewLine; }

                    }
                }
                string sqlInsert = string.Format("INSERT INTO TransactionLog (Sql,Parameter, User, DateExecute) VALUES ('{0}','" + parameter + "'," + AuthenticateUser.Id + ",datetime('now','-5 hour'))", commandInit.CommandText);
                using (SQLiteCommand command = new SQLiteCommand(sqlInsert, CurrentDatabaseConnection))
                {
                    command.ExecuteScalar();
                }
            }
        }
        private IList<string> GetAllTable()
        {
            IList<string> tables = new List<string>();
            DataSet datasetReturn = new DataSet();
            using (SQLiteDataAdapter dataAdapterListBackup = new SQLiteDataAdapter("SELECT name FROM sqlite_master WHERE type='table'", CurrentDatabaseConnection))
            {
                dataAdapterListBackup.Fill(datasetReturn, "BackupXML");
                foreach (DataRow dataRow in datasetReturn.Tables[0].Rows)
                {
                    tables.Add(dataRow.ItemArray[0].ToString());
                }
            }
            return tables;
        }
        private string CreateTable(DataTable dataTable)
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
        private void CreateXmlFile(string tableName, string zipFile)
        {
            using (DataSet setBackup = new DataSet())
            {
                using (SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter("select * from " + tableName, CurrentDatabaseConnection))
                {
                    sqLiteDataAdapter.Fill(setBackup, tableName);
                }

                string path = Path.GetDirectoryName(zipFile);

                setBackup.WriteXml(path + "\\" + tableName + ".xml", XmlWriteMode.WriteSchema);
            }
        }
        private void RestoreXmlFile(DataTable dataTableXml)
        {
            using (SQLiteCommand commandCreate = new SQLiteCommand(string.Format("DROP TABLE {0}", dataTableXml.TableName), CurrentDatabaseConnection))
            {
                commandCreate.ExecuteScalar();
            }

            string sqlCreate = CreateTable(dataTableXml);
            using (SQLiteCommand commandCreate = new SQLiteCommand(sqlCreate, CurrentDatabaseConnection))
            {
                commandCreate.ExecuteScalar();
            }

            using (SQLiteCommand commandFill = new SQLiteCommand("select * from " + dataTableXml.TableName, CurrentDatabaseConnection))
            {
                DataSet setBackup = new DataSet();
                using (SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter(commandFill))
                {
                    sqlDataAdapter.Fill(setBackup, dataTableXml.TableName);
                    DataTable table = setBackup.Tables[0];
                    foreach (DataRow row in dataTableXml.Rows)
                    {
                        table.NewRow();
                        table.Rows.Add(row.ItemArray);
                    }

                    using (SQLiteTransaction transaction = (CurrentDatabaseConnection).BeginTransaction())
                    using (SQLiteDataAdapter sqliteAdapter = new SQLiteDataAdapter("SELECT * FROM " + dataTableXml.TableName, CurrentDatabaseConnection))
                    {
                        using (sqliteAdapter.InsertCommand = new SQLiteCommandBuilder(sqliteAdapter).GetInsertCommand())
                        {
                            sqliteAdapter.Update(setBackup, dataTableXml.TableName);
                        }
                        transaction.Commit();
                    }
                }
            }
        }


    }
}
