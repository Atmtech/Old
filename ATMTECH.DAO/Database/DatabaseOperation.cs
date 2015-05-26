using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Database
{
    public class DatabaseOperation<TModel, TId>
    {
        public MsSql<TModel, TId> MsSql { get { return new MsSql<TModel, TId>(); } }
        public Model<TModel, TId> Model { get { return new Model<TModel, TId>(); } }

        public DatabaseVendor.DatabaseVendorType CurrentDatabaseVendor
        {
            get { return DatabaseVendor.GetCurrentDatabaseVendorType(); }
        }

        public bool IsColumnExist(string column, DataColumnCollection dataColumnCollection)
        {
            foreach (DataColumn dataColumn in dataColumnCollection)
            {
                if (dataColumn.ColumnName == column)
                {
                    return true;
                }
            }

            return false;
        }
        public DataColumnCollection ReturnAllColumnNameFromTable(string table)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnAllColumnNameFromTable(table);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string ConstructSqlPaging(PagingOperation pagingOperation, string sql)
        {
            string rtn = string.Empty;
            if (pagingOperation.PageSize != 0)
            {
                switch (CurrentDatabaseVendor)
                {
                    case DatabaseVendor.DatabaseVendorType.MsSql:

                        //                        DECLARE @RowsPerPage INT = 10, @PageNumber INT = 1 SELECT * FROM (SELECT *,ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM Product ) AS SOD WHERE SOD.RowNum BETWEEN ((@PageNumber-1)*@RowsPerPage)+1 AND @RowsPerPage*(@PageNumber)
                        int pagingIndex = pagingOperation.PageIndex;
                        if (pagingIndex == 0)
                        {
                            pagingIndex = 1;
                        }
                        string from = sql.Substring(sql.IndexOf("FROM [") + 5, sql.Length - sql.IndexOf("FROM [") - 5);
                        from = from.Substring(0, from.IndexOf("ORDER BY"));
                        string colonne = sql.Substring(6, sql.IndexOf("FROM [") - 6);
                        rtn = string.Format(MsSql<TModel, TId>.SQL_PAGING, pagingOperation.PageSize, pagingIndex, colonne, from);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            return rtn;
        }
        public string ExtractColumnsFromDatabase(Type type)
        {
            string columns = string.Empty;
            DataColumnCollection dataColumnCollection = ReturnAllColumnNameFromTable(ReturnTableName(type));
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (IsColumnExist(propertyInfo.Name, dataColumnCollection))
                {
                    columns += "[" + propertyInfo.Name + "],";
                }
            }

            // remove last ,
            columns = columns.Remove(columns.Length - 1, 1);
            return columns;
        }
        public string ConstructSqlOrderBy(OrderOperation orderOperation)
        {
            string sql = string.Empty;
            if (orderOperation.OrderByType == OrderBy.Type.Ascending)
            {
                switch (CurrentDatabaseVendor)
                {
                    case DatabaseVendor.DatabaseVendorType.MsSql:
                        sql = string.Format(MsSql<TModel, TId>.SQL_ORDER_BY, orderOperation.OrderByColumn, "ASC");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            else
            {
                if (orderOperation.OrderByType == OrderBy.Type.Descending)
                {
                    switch (CurrentDatabaseVendor)
                    {
                        case DatabaseVendor.DatabaseVendorType.MsSql:
                            sql = string.Format(MsSql<TModel, TId>.SQL_ORDER_BY, orderOperation.OrderByColumn, "DESC");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return sql;
        }
        public string ReturnTableName(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.Name == "EST_UN_ALIAS_DE")
                {
                    return fieldInfo.GetValue(type).ToString();
                }
            }
            return type.Name;
        }
        public string ConstructSqlWhere(string @where, Type type, string columns)
        {
            string sql;
            string tableName = ReturnTableName(type);

            if (!String.IsNullOrEmpty(where))
            {
                switch (CurrentDatabaseVendor)
                {
                    case DatabaseVendor.DatabaseVendorType.MsSql:
                        sql = String.Format(MsSql<TModel, TId>.SQL_SELECT_WHERE, columns, tableName, where);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                switch (CurrentDatabaseVendor)
                {
                    case DatabaseVendor.DatabaseVendorType.MsSql:
                        sql = String.Format(MsSql<TModel, TId>.SQL_SELECT, columns, tableName);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return sql;
        }
        public string ConstructSqlFromModel(string @where, PagingOperation pagingOperation, OrderOperation orderOperation, Type type)
        {
            string columns = ExtractColumnsFromDatabase(type);
            string sql = ConstructSqlWhere(@where, type, columns) + ConstructSqlOrderBy(orderOperation);
            string paging = ConstructSqlPaging(pagingOperation, sql);
            if (!string.IsNullOrEmpty(paging))
            {
                sql = paging;
            }
            return sql;
        }
        public string ReturnSetClauseUpdate(TModel model, string id)
        {
            Type type = model.GetType();
            string tableName = ReturnTableName(type);
            DataColumnCollection dataColumnCollection = ReturnAllColumnNameFromTable(tableName);
            PropertyInfo[] properties = type.GetProperties();

            string setClause = null;
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name != id)
                {
                    if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                    {
                        if (IsColumnExist(propertyInfo.Name, dataColumnCollection))
                        {
                            setClause += "[" + propertyInfo.Name + "]= @" + propertyInfo.Name + ",";
                        }
                    }
                }
            }

            if (setClause != null) setClause = setClause.Remove(setClause.Length - 1, 1);

            return setClause;
        }
        public string ReturnColumnInsert(TModel model)
        {
            Type type = model.GetType();
            string tableName = ReturnTableName(type);
            DataColumnCollection dataColumnCollection = ReturnAllColumnNameFromTable(tableName);
            PropertyInfo[] properties = type.GetProperties();

            string columnInsert = null;
            foreach (var propertyInfo in properties)
            {
                if (IsColumnExist(propertyInfo.Name, dataColumnCollection))
                {
                    if (propertyInfo.Name != Model.GetIdKeyColumnFromModel())
                    {
                        columnInsert += "[" + propertyInfo.Name + "],";
                    }
                }
            }

            if (columnInsert != null) columnInsert = columnInsert.Remove(columnInsert.Length - 1, 1);

            return columnInsert;
        }
        public string ReturnValueInsert(TModel model)
        {
            Type type = model.GetType();
            string tableName = ReturnTableName(type);
            DataColumnCollection dataColumnCollection = ReturnAllColumnNameFromTable(tableName);
            PropertyInfo[] properties = type.GetProperties();

            string valueInsert = null;
            foreach (var propertyInfo in properties)
            {
                if (IsColumnExist(propertyInfo.Name, dataColumnCollection))
                {
                    if (propertyInfo.Name != Model.GetIdKeyColumnFromModel())
                    {
                        valueInsert += "@" + propertyInfo.Name + ",";
                    }
                }
            }

            if (valueInsert != null) valueInsert = valueInsert.Remove(valueInsert.Length - 1, 1);

            return valueInsert;
        }

        public DataSet ReturnDataSetCount()
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnDataSetCount();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public DataSet ReturnDataSetMax(string columnName)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnDataSetMax(columnName);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DataSet ReturnDataSet(PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnDataSet(pagingOperation, orderOperation);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DataSet ReturnDataset(string sql)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnDataSet(sql);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DataSet ReturnDataSet(string where, IList<Criteria> criterias, PagingOperation pagingOperation, OrderOperation orderOperation)
        {
            DatabaseSessionManager.DatabaseTransactionCount += 1;

            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.ReturnDataSet(where, criterias, pagingOperation, orderOperation);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void ExecuteSql(string sql)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    MsSql.ExecuteSql(sql);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void UpdateSql(TModel model, string id)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    MsSql.UpdateSql(model, id);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int InsertSql(TModel model)
        {
            switch (CurrentDatabaseVendor)
            {
                case DatabaseVendor.DatabaseVendorType.MsSql:
                    return MsSql.InsertSql(model);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public class DatabaseOperator
    {
        public const int NO_PAGING = 0;
        public const string OPERATOR_EQUAL = "=";
        public const string OPERATOR_LIKE = "Like";
        public const string OPERATOR_NOT_EQUAL = "<>";
        public const string OPERATOR_GREATER_THAN = ">";
        public const string OPERATOR_GREATER_EQUAL_THAN = ">=";
        public const string OPERATOR_LOWER_THAN = "<";
        public const string OPERATOR_LOWER_EQUAL_THAN = "<=";
        public const string OPERATOR_IS_NOT_NULL = "is not null";
        public const string OPERATOR_WHERE_STRING = "DIRECT STRING";
    }
}
