using System.Collections.Generic;
using System.Data;

namespace ATMTECH.DAO.Database
{
    public interface IDatabase<in TModel,TId>
    {
        
        DataColumnCollection ReturnAllColumnNameFromTable(string table);
        DataSet ReturnDataSet(string sql);
        DataSet ReturnDataSet(PagingOperation pagingOperation, OrderOperation orderOperation);
        DataSet ReturnDataSetMax(string columnName);
        DataSet ReturnDataSetCount();

        DataSet ReturnDataSet(string where, IList<Criteria> criterias, PagingOperation pagingOperation,
                                    OrderOperation orderOperation);

        int InsertSql(TModel model);
        void ExecuteSql(string sql);
        void UpdateSql(TModel model, string id);
        void BackupToXml(string zipFile, bool allTableFromDatabase);
        void RestoreFromXml(string zipFile);

    }
}
