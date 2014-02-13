using System;
using ATMTECH.DAO;

namespace ATMTECH.Administration.Services.Interface
{
    public interface IDataEditorService
    {
        bool IsSystemColumn(string column);
        Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string column, string value, string search);
        Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string search);

        Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string search,
                             Criteria newCriteria);
        Object GetById(string nameSpace, string className, int id);
        int? Save(string nameSpace, string className, Object entity);
        string FindValue(Object entity, string propertyName);
        
    }
}
