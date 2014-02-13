using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace ATMTECH.DAO.Utilities
{
    public class SQLiteBulkInsert
    {
        private readonly SQLiteConnection _mDbCon;
        private SQLiteCommand _mCmd;
        private SQLiteTransaction _mTrans;
        private Dictionary<string, SQLiteParameter> _mParameters = new Dictionary<string, SQLiteParameter>();
        private uint _mCounter = 0;
        private readonly string _mBeginInsertText;

        public SQLiteBulkInsert(SQLiteConnection dbConnection, string tableName)
        {
            _mDbCon = dbConnection;
            _mTableName = tableName;

            StringBuilder query = new StringBuilder(255);
            query.Append("INSERT INTO ["); query.Append(tableName); query.Append("] (");
            _mBeginInsertText = query.ToString();
        }

        private bool _mAllowBulkInsert = true;
        public bool AllowBulkInsert { get { return _mAllowBulkInsert; } set { _mAllowBulkInsert = value; } }

        public string CommandText
        {
            get
            {
                if (_mParameters.Count < 1)
                    throw new SQLiteException("You must add at least one parameter.");

                StringBuilder sb = new StringBuilder(255);
                sb.Append(_mBeginInsertText);

                foreach (string param in _mParameters.Keys)
                {
                    sb.Append('[');
                    sb.Append(param);
                    sb.Append(']');
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);

                sb.Append(") VALUES (");

                foreach (string param in _mParameters.Keys)
                {
                    sb.Append(PARAM_DELIM);
                    sb.Append(param);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);

                sb.Append(")");

                return sb.ToString();
            }
        }

        private uint _mCommitMax = 10000;
        public uint CommitMax { get { return _mCommitMax; } set { _mCommitMax = value; } }

        private readonly string _mTableName;
        public string TableName { get { return _mTableName; } }

        private const string PARAM_DELIM = ":";
        public string ParamDelimiter { get { return PARAM_DELIM; } }

        public void AddParameter(string name, DbType dbType)
        {
            SQLiteParameter param = new SQLiteParameter(PARAM_DELIM + name, dbType);
            _mParameters.Add(name, param);
        }

        public void Flush()
        {
            try
            {
                if (_mTrans != null)
                    _mTrans.Commit();
            }
            catch (Exception ex) { throw new Exception("Could not commit transaction. See InnerException for more details", ex); }
            finally
            {
                if (_mTrans != null)
                    _mTrans.Dispose();

                _mTrans = null;
                _mCounter = 0;
            }
        }

        public void Insert(object[] paramValues)
        {
            if (paramValues.Length != _mParameters.Count)
                throw new Exception("The values array count must be equal to the count of the number of parameters.");

            _mCounter++;

            if (_mCounter == 1)
            {
                if (_mAllowBulkInsert)
                    _mTrans = _mDbCon.BeginTransaction();

                _mCmd = _mDbCon.CreateCommand();
                foreach (SQLiteParameter par in _mParameters.Values)
                    _mCmd.Parameters.Add(par);

                _mCmd.CommandText = this.CommandText;
            }

            int i = 0;
            foreach (SQLiteParameter par in _mParameters.Values)
            {
                par.Value = paramValues[i];
                i++;
            }

            _mCmd.ExecuteNonQuery();

            if (_mCounter == _mCommitMax)
            {
                try
                {
                    if (_mTrans != null)
                        _mTrans.Commit();
                }
                catch (Exception) { }
                finally
                {
                    if (_mTrans != null)
                    {
                        _mTrans.Dispose();
                        _mTrans = null;
                    }

                    _mCounter = 0;
                }
            }
        }
    }
}

