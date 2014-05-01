using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Reflection;
using ATMTECH.DAO.SessionManager;
using MySql.Data.MySqlClient;

namespace ATMTECH.DAO.Database
{
    public class MySql<TModel, TId> : IDatabase<TModel, TId>
    {
        public MySqlConnection CurrentDatabaseConnection { get { return (MySqlConnection)DatabaseSessionManager.Session; } }
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
        public const string SQL_RETURN_COLUMN = "SELECT * FROM [{0}] LIMIT 1";
        public const string SQL_MAX = "SELECT MAX({0}) FROM [{1}]";

        public DataColumnCollection ReturnAllColumnNameFromTable(string table)
        {
            string sql = string.Format(SQL_RETURN_COLUMN, table);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand sqlCommand = new MySqlCommand(sql, CurrentDatabaseConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            return dataSet.Tables[0].Columns;
        }

        public DataSet ReturnDataSet(string sql)
        {
            throw new NotImplementedException();
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
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand sqlCommand = new MySqlCommand(sql, CurrentDatabaseConnection);


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
            throw new NotImplementedException();
        }

        public DataSet ReturnDataSet(string where, IList<Criteria> criterias, PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);
            Type type = model.GetType();

            var sql = DatabaseOperation.ConstructSqlFromModel(@where, pagingOperation, orderOperation, type);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            MySqlCommand sqlCommand = new MySqlCommand(sql, CurrentDatabaseConnection);

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

            // Show sql debug
            Utils.Debug.WriteDebug("(Start: " + start + " End: " + end + " TimeSpent: " + diffResult.Milliseconds.ToString() + "ms) :: " + sql);
            return dataSet;
        }
        public int InsertSql(TModel model)
        {
            int rtn = 0;
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_INSERT, tableName, DatabaseOperation.ReturnColumnInsert(model), DatabaseOperation.ReturnValueInsert(model));
            using (MySqlCommand command = new MySqlCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.Name == IS_ACTIVE)
                    {
                        // Active = true;
                        command.Parameters.Add(new MySqlParameter(propertyInfo.Name, "1"));
                    }
                    else
                    {

                        //Detect DateModified columns
                        if (propertyInfo.Name == DATE_CREATED_COLUMN)
                        {
                            command.Parameters.Add(new MySqlParameter(propertyInfo.Name, DateTime.Now.ToString()));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Namespace == "System")
                            {
                                command.Parameters.Add(new MySqlParameter(propertyInfo.Name,
                                                                           propertyInfo.GetValue(model, null)));
                            }
                            else
                            {
                                if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                                {
                                    command.Parameters.Add(new MySqlParameter(propertyInfo.Name,
                                                                               Model.ExtractValuePropertyPath(model,
                                                                                                        propertyInfo.Name +
                                                                                                        "." + Model.GetIdKeyColumnFromModel())));
                                }
                            }
                        }
                    }
                }

                command.ExecuteNonQuery();
                command.CommandText = "select last_insert_rowid();";
                rtn = Convert.ToInt32(command.ExecuteScalar());

            }

            return rtn;
        }
        public void ExecuteSql(string sql)
        {
            using (MySqlCommand command = new MySqlCommand(sql, CurrentDatabaseConnection))
            {
                command.ExecuteScalar();
            }
        }
        public void UpdateSql(TModel model, string id)
        {
            Type type = model.GetType();
            string tableName = DatabaseOperation.ReturnTableName(type);
            string sql = string.Format(SQL_UPDATE, tableName, DatabaseOperation.ReturnSetClauseUpdate(model, id), Model.GetValueProperty(id, model), id);
            using (MySqlCommand command = new MySqlCommand(sql, CurrentDatabaseConnection))
            {
                PropertyInfo[] properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    //Detect DateModified columns
                    if (propertyInfo.Name == DATE_MODIFIED_COLUMN)
                    {
                        command.Parameters.Add(new MySqlParameter(propertyInfo.Name, DateTime.Now.ToString()));
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.Namespace == "System")
                        {
                            command.Parameters.Add(propertyInfo.GetValue(model, null) == null
                                                       ? new MySqlParameter(propertyInfo.Name, "")
                                                       : new MySqlParameter(propertyInfo.Name,
                                                                             propertyInfo.GetValue(model, null)));
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                            {
                                command.Parameters.Add(new MySqlParameter(propertyInfo.Name, Model.ExtractValuePropertyPath(model, propertyInfo.Name + "." + id)));
                            }
                        }
                    }
                }
                command.ExecuteScalar();
            }
        }

        public void BackupToXml(string zipFile, bool allTableFromDatabase)
        {
            throw new NotImplementedException();
        }

        public void RestoreFromXml(string zipFile)
        {
            throw new NotImplementedException();
        }
    }
}
