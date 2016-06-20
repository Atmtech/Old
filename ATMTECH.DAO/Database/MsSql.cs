using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using ATMTECH.Common.Utils;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Database
{
    public class MsSql<TModel, TId> : IDatabase<TModel, TId>
    {
        public SqlConnection CurrentDatabaseConnection { get { return (SqlConnection)DatabaseSessionManager.Session; } }
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
        public const string SQL_PAGING = "DECLARE @RowsPerPage INT = {0}, @PageNumber INT = {1} SELECT * FROM (SELECT {2},ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM {3} ) AS SOD WHERE SOD.RowNum BETWEEN ((@PageNumber-1)*@RowsPerPage)+1 AND @RowsPerPage*(@PageNumber)";
        public const string SQL_ORDER_BY = "ORDER BY [{0}] {1} ";
        public const string SQL_RETURN_COLUMN = "SELECT top 1 * FROM [{0}]";
        public const string SQL_MAX = "SELECT MAX({0}) FROM [{1}]";
        public const string SQL_COUNT = "SELECT COUNT(1) as counts FROM [{0}]";

        public DataColumnCollection ReturnAllColumnNameFromTable(string table)
        {
            string sql = string.Format(SQL_RETURN_COLUMN, table);
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection)
                    {
                        Connection = CurrentDatabaseConnection,
                        CommandType = CommandType.Text
                    };

                SetTransactionUnitTesting(sqlCommand);

                sqlDataAdapter.SelectCommand = sqlCommand;

                sqlDataAdapter.Fill(dataSet);
            }
            return dataSet.Tables[0].Columns;
        }
        public DataSet ReturnDataSet(string sql)
        {
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection))
                {
                    SetTransactionUnitTesting(sqlCommand);

                    DateTime startDate = DateTime.Now;
                    string start = DateTime.Now + " " + DateTime.Now.Millisecond;

                    sqlCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    sqlDataAdapter.Fill(dataSet);

                    DateTime endDate = DateTime.Now;
                    string end = DateTime.Now + " " + DateTime.Now.Millisecond;
                    TimeSpan diffResult = endDate - startDate;

                    // Show sql debug
                    Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
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
            string sql = string.Format(SQL_MAX, columnName, tableName);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);

            SetTransactionUnitTesting(sqlCommand);

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
            Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);
            return dataSet;
        }
        public DataSet ReturnDataSetCount()
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_COUNT, tableName);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);

            SetTransactionUnitTesting(sqlCommand);
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
            Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);
            return dataSet;
        }
        public DataSet ReturnDataSet(string where, IList<Criteria> criterias, PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();

            var sql = DatabaseOperation.ConstructSqlFromModel(@where, pagingOperation, orderOperation, type);
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection))
                {
                    SetTransactionUnitTesting(sqlCommand);
                    if (criterias != null && criterias.Count > 0)
                    {
                        foreach (Criteria criteria in criterias)
                        {
                            if (criteria.Operator == DatabaseOperator.OPERATOR_IS_NOT_NULL) continue;
                            if (criteria.ClearText)
                            {
                                sqlCommand.Parameters.Add(new SqlParameter(criteria.Column,
                                                                           "'" + criteria.Value + "'"));
                            }
                            else if (criteria.Operator == DatabaseOperator.OPERATOR_LIKE)
                            {
                                sqlCommand.Parameters.Add(new SqlParameter(criteria.Column,
                                                                           "%" + criteria.Value + "%"));
                            }
                            else
                            {
                                sqlCommand.Parameters.Add(new SqlParameter(criteria.Column, criteria.Value));
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
                    Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                           diffResult.Milliseconds.ToString() + "ms) :: " + sql);

                    //DatabaseSessionManager.
                }
            }
            return dataSet;
        }


        private void SetTransactionUnitTesting(SqlCommand sqlCommand)
        {
            if (DatabaseSessionManager.IsUnitTesting)
            {
                if (DatabaseSessionManager.CurrentSqlTransactionUnitTesting == null)
                {
                    DatabaseSessionManager.CurrentSqlTransactionUnitTesting = CurrentDatabaseConnection.BeginTransaction("UnitTestingTransaction");
                }
                sqlCommand.Transaction = DatabaseSessionManager.CurrentSqlTransactionUnitTesting;

            }
        }
        public int InsertSql(TModel model)
        {
            int rtn = 0;
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);

            string sql = string.Format(SQL_INSERT, tableName, DatabaseOperation.ReturnColumnInsert(model), DatabaseOperation.ReturnValueInsert(model));



            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                SetTransactionUnitTesting(command);

                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (sql.IndexOf(propertyInfo.Name) >= 0)
                    {
                        if (propertyInfo.Name == IS_ACTIVE)
                        {
                            // Active = true;
                            command.Parameters.Add(new SqlParameter(propertyInfo.Name, "1"));
                        }
                        else
                        {


                            if (propertyInfo.PropertyType.Namespace == "System")
                            {
                                object value = propertyInfo.GetValue(model, null);
                                command.Parameters.Add(value == null
                                                           ? new SqlParameter(propertyInfo.Name, DBNull.Value)
                                                           : new SqlParameter(propertyInfo.Name, value));
                            }
                            else
                            {
                                if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                                {

                                    object value = Model.ExtractValuePropertyPath(model, propertyInfo.Name +
                                                                                         "." +
                                                                                         Model.GetIdKeyColumnFromModel());

                                    command.Parameters.Add(value == null
                                                               ? new SqlParameter(propertyInfo.Name, DBNull.Value)
                                                               : new SqlParameter(propertyInfo.Name, value));
                                }
                            }
                        }
                    }

                }
                SendToTransactionLog(command);
                command.ExecuteNonQuery();
                command.CommandText = "SELECT IDENT_CURRENT('" + tableName + "')";
                rtn = Convert.ToInt32(command.ExecuteScalar());
            }


            return rtn;
        }
        public void ExecuteSql(string sql)
        {

            DateTime startDate = DateTime.Now;
            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                SetTransactionUnitTesting(command);

                command.ExecuteScalar();
            }

            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - startDate;

            // Show sql debug
            Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " +
                                   diffResult.Milliseconds.ToString() + "ms) :: " + sql);
        }
        public void UpdateSql(TModel model, string id)
        {
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_UPDATE, tableName, DatabaseOperation.ReturnSetClauseUpdate(model, id), Model.GetValueProperty(id, model), id);
            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                SetTransactionUnitTesting(command);

                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (sql.IndexOf(propertyInfo.Name) >= 0)
                    {
                        if (propertyInfo.PropertyType.Namespace == "System")
                        {
                            object value = propertyInfo.GetValue(model, null);
                            command.Parameters.Add(value == null
                                                       ? new SqlParameter(propertyInfo.Name, DBNull.Value)
                                                       : new SqlParameter(propertyInfo.Name, value));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                            {
                                object value = Model.ExtractValuePropertyPath(model, propertyInfo.Name +
                                                                                         "." +
                                                                                         Model.GetIdKeyColumnFromModel());

                                command.Parameters.Add(value == null
                                                           ? new SqlParameter(propertyInfo.Name, DBNull.Value)
                                                           : new SqlParameter(propertyInfo.Name, value));
                            }
                        }
                    }
                }
                command.ExecuteScalar();
                SendToTransactionLog(command);
                command.Dispose();
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

        private void SendToTransactionLog(SqlCommand commandInit)
        {
            if (AuthenticateUser != null)
            {
                using (SqlCommand command = new SqlCommand("IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionLog]') AND type in (N'U')) create table TransactionLog (Sql varchar(8000),Parameter varchar(8000), [User] int, DateExecute datetime)", CurrentDatabaseConnection))
                {
                    command.ExecuteScalar();
                }


                string parameter = string.Empty;
                if (commandInit.Parameters != null)
                {
                    foreach (SqlParameter sqlParameter in commandInit.Parameters)
                    {
                        if (sqlParameter.Value != null)
                        {
                            parameter += string.Format("{0}={1}", sqlParameter.ParameterName, sqlParameter.Value.ToString().Replace("'", "_"));
                        }

                    }
                }
                try
                {
                    string sqlInsert = string.Format("INSERT INTO TransactionLog ([Sql],[Parameter], [User], [DateExecute]) VALUES ('{0}','{1}',{2},getdate())", commandInit.CommandText, parameter, AuthenticateUser.Id);
                    using (SqlCommand command = new SqlCommand(sqlInsert, CurrentDatabaseConnection))
                    {
                        command.ExecuteScalar();
                    }
                }
                catch (Exception)
                {

                }


            }
        }
        private IList<string> GetAllTable()
        {
            IList<string> tables = new List<string>();
            DataSet datasetReturn = new DataSet();
            using (SqlDataAdapter dataAdapterListBackup = new SqlDataAdapter("Select name from sys.sysobjects where xtype = 'U'", CurrentDatabaseConnection))
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
                        columnType = "NVARCHAR";
                        break;
                    case "system.int32":
                        columnType = "INT";
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
                        columnType = "INT";
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
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from " + tableName, CurrentDatabaseConnection))
                {
                    sqlDataAdapter.Fill(setBackup, tableName);
                }

                string path = Path.GetDirectoryName(zipFile);

                setBackup.WriteXml(path + "\\" + tableName + ".xml", XmlWriteMode.WriteSchema);
            }
        }
        private void RestoreXmlFile(DataTable dataTableXml)
        {
            using (SqlCommand commandCreate = new SqlCommand(string.Format("DROP TABLE {0}", dataTableXml.TableName), CurrentDatabaseConnection))
            {
                commandCreate.ExecuteScalar();
            }

            string sqlCreate = CreateTable(dataTableXml);
            using (SqlCommand commandCreate = new SqlCommand(sqlCreate, CurrentDatabaseConnection))
            {
                commandCreate.ExecuteScalar();
            }

            using (SqlCommand commandFill = new SqlCommand("select * from " + dataTableXml.TableName, CurrentDatabaseConnection))
            {
                DataSet setBackup = new DataSet();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandFill))
                {
                    sqlDataAdapter.Fill(setBackup, dataTableXml.TableName);
                    DataTable table = setBackup.Tables[0];
                    foreach (DataRow row in dataTableXml.Rows)
                    {
                        table.NewRow();
                        table.Rows.Add(row.ItemArray);
                    }

                    using (SqlTransaction transaction = (CurrentDatabaseConnection).BeginTransaction())
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM " + dataTableXml.TableName, CurrentDatabaseConnection))
                    {
                        using (dataAdapter.InsertCommand = new SqlCommandBuilder(dataAdapter).GetInsertCommand())
                        {
                            dataAdapter.Update(setBackup, dataTableXml.TableName);
                        }
                        transaction.Commit();
                    }
                }
            }
        }
    }
}
