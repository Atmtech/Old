using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using ATMTECH.DAO.SessionManager;

namespace ATMTECH.DAO.Database
{
    public class MsSql<TModel, TId> : IDatabase<TModel, TId>
    {
        public SqlConnection CurrentDatabaseConnection { get { return (SqlConnection)DatabaseSessionManager.Session; } }
        public Model<TModel, TId> Model { get { return new Model<TModel, TId>(); } }
        public DatabaseOperation<TModel, TId> DatabaseOperation { get { return new DatabaseOperation<TModel, TId>(); } }

        public const string DATE_MODIFIED_COLUMN = "DateModified";
        public const string DATE_CREATED_COLUMN = "DateCreated";
        public const string IS_ACTIVE = "IsActive";
        public const string SQL_SELECT_WHERE = "SELECT {0} FROM [{1}] WHERE {2} ";
        public const string SQL_SELECT = "SELECT {0} FROM [{1}] ";
        public const string SQL_INSERT = "INSERT INTO [{0}] ({1}) VALUES ({2})";
        public const string SQL_UPDATE = "UPDATE [{0}] SET {1} WHERE {3} = {2} ";
        public const string SQL_PAGING = "LIMIT {0},{1}";
        public const string SQL_ORDER_BY = "ORDER BY [{0}] {1} ";
        public const string SQL_RETURN_COLUMN = "SELECT top 1 * FROM {0}";
        public const string SQL_MAX = "SELECT MAX({0}) FROM [{1}]";
        public const string SQL_COUNT = "SELECT COUNT() as counts FROM {0}";

        public DataColumnCollection ReturnAllColumnNameFromTable(string table)
        {
            string sql = string.Format(SQL_RETURN_COLUMN, table);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0].Columns;
        }
        public DataSet ReturnDataSet(PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            return ReturnDataSet("", null, pagingOperation, orderOperation);
        }
        public DataSet ReturnDataSetCount()
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();

            string sql = string.Format(SQL_COUNT, DatabaseOperation.ReturnTableName(type));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);


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


        public DataSet ReturnDataSetMax(string columnName)
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();

            string sql = string.Format(SQL_MAX, columnName, DatabaseOperation.ReturnTableName(type));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);


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

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(sql, CurrentDatabaseConnection);


            if (criterias != null && criterias.Count > 0)
            {
                foreach (Criteria criteria in criterias)
                {
                    sqlCommand.Parameters.Add(criteria.Operator == DatabaseOperator.OPERATOR_LIKE
                                                 ? new SqlParameter(criteria.Column, "%" + criteria.Value + "%")
                                                 : new SqlParameter(criteria.Column, criteria.Value));
                }

            }

            DateTime startDate = DateTime.Now;
            string start = DateTime.Now + " " + DateTime.Now.Millisecond;

            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - startDate;

            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);

            return dataSet;
        }
        public int InsertSql(TModel model)
        {
            int rtn = 0;
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_INSERT, tableName, DatabaseOperation.ReturnColumnInsert(model), DatabaseOperation.ReturnValueInsert(model));
            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.Name == IS_ACTIVE)
                    {
                        // Active = true;
                        command.Parameters.Add(new SqlParameter(propertyInfo.Name, "1"));
                    }
                    else
                    {

                        //Detect DateModified columns
                        if (propertyInfo.Name == DATE_CREATED_COLUMN)
                        {
                            command.Parameters.Add(new SqlParameter(propertyInfo.Name, DateTime.Now.ToString()));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Namespace == "System")
                            {
                                //SqlDateTime test = DateTime.Now;
                                object value = propertyInfo.GetValue(model, null);
                                if (value != null)
                                {
                                    command.Parameters.Add(new SqlParameter(propertyInfo.Name, value.ToString()));
                                }

                            }
                        }
                    }
                }

                command.ExecuteNonQuery();


                command.CommandText = "SELECT IDENT_CURRENT('" + tableName + "')";
                rtn = Convert.ToInt32(command.ExecuteScalar());

            }

            return rtn;
        }
        public void ExecuteSql(string sql)
        {
            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                command.ExecuteScalar();
            }
        }
        public void UpdateSql(TModel model, string id)
        {
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_UPDATE, tableName, DatabaseOperation.ReturnSetClauseUpdate(model, id), Model.GetValueProperty(id, model), id);
            using (SqlCommand command = new SqlCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    //Detect DateModified columns
                    if (propertyInfo.Name == DATE_MODIFIED_COLUMN)
                    {
                        command.Parameters.Add(new SqlParameter(propertyInfo.Name, DateTime.Now.ToString()));
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.Namespace == "System")
                        {
                            command.Parameters.Add(propertyInfo.GetValue(model, null) == null
                                                       ? new SqlParameter(propertyInfo.Name, "")
                                                       : new SqlParameter(propertyInfo.Name,
                                                                          propertyInfo.GetValue(model, null)));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                            {
                                command.Parameters.Add(new SqlParameter(propertyInfo.Name, Model.ExtractValuePropertyPath(model, propertyInfo.Name + "." + id)));
                            }
                        }
                    }
                }
                command.ExecuteScalar();
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

        private IList<string> GetAllTable()
        {
            IList<string> tables = new List<string>();
            DataSet datasetReturn = new DataSet();
            SqlDataAdapter dataAdapterListBackup = new SqlDataAdapter("Select name from sys.sysobjects where xtype = 'U'", CurrentDatabaseConnection);
            dataAdapterListBackup.Fill(datasetReturn, "BackupXML");
            foreach (DataRow dataRow in datasetReturn.Tables[0].Rows)
            {
                tables.Add(dataRow.ItemArray[0].ToString());
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
                    using (SqlDataAdapter sqliteAdapter = new SqlDataAdapter("SELECT * FROM " + dataTableXml.TableName, CurrentDatabaseConnection))
                    {
                        using (sqliteAdapter.InsertCommand = new SqlCommandBuilder(sqliteAdapter).GetInsertCommand())
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
