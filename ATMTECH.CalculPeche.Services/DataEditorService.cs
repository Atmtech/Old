using System;
using System.Collections.Generic;
using System.Reflection;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Common.Utils;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.CalculPeche.Services
{
    public class DataEditorService : BaseService, IDataEditorService
    {
        public bool IsSystemColumn(string column)
        {
            if (column.ToLower() == "id") return true;
            if (column.ToLower() == "datemodified") return true;
            if (column.ToLower() == "datecreated") return true;
            if (column.ToLower() == "search") return true;
            if (column.ToLower() == "isactive") return true;
            if (column.ToLower() == "comboboxdescription") return true;

            return false;
        }
        public string FindValue(Object entity, string propertyName)
        {
            if (entity != null)
            {
                Type type = entity.GetType();
                Activator.CreateInstance(type, null);

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo propertyInfo in properties)
                {
                    if (propertyName != propertyInfo.Name) continue;
                    var valeurPropriete = propertyInfo.GetValue(entity, null);
                    string valeur = string.Empty;
                    if (valeurPropriete != null)
                    {
                        valeur = valeurPropriete.ToString();
                    }

                    return valeur;
                }
            }
            return string.Empty;
        }
        public Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string search, Criteria newCriteria)
        {
            ManageClass manageClass = new ManageClass();
            Type d1 = typeof(BaseDao<,>);
            Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
            Type[] typeArgs = { type, typeof(int) };
            Type constructed = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(constructed, null);
            IList<Criteria> criterias = new List<Criteria>();
            if (!String.IsNullOrEmpty(search))
            {
                criterias.Add(new Criteria { Column = BaseEntity.SEARCH, Operator = DatabaseOperator.OPERATOR_LIKE, Value = search });
            }

            criterias.Add(newCriteria);
            criterias.Add(new Criteria { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" });

            PagingOperation pagingOperation = new PagingOperation { PageIndex = pageIndex, PageSize = pageSize };
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            object criteria = criterias;
            Object paging = pagingOperation;
            Object order = orderOperation;
            object[] parametersArray = new[] { criteria, paging, order };
            Type[] typeArgs2 = { typeof(IList<Criteria>), typeof(PagingOperation), typeof(OrderOperation) };
            MethodInfo theMethod = constructed.GetMethod("GetByCriteria", typeArgs2);
            return theMethod.Invoke(o, parametersArray);
        }
        public Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string search)
        {
            ManageClass manageClass = new ManageClass();
            Type d1 = typeof(BaseDao<,>);
            Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
            Type[] typeArgs = { type, typeof(int) };
            Type constructed = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(constructed, null);
            IList<Criteria> criterias = new List<Criteria>();
            if (!String.IsNullOrEmpty(search))
            {
                criterias.Add(new Criteria { Column = BaseEntity.SEARCH, Operator = DatabaseOperator.OPERATOR_LIKE, Value = search });
            }

            criterias.Add(new Criteria { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" });

            PagingOperation pagingOperation = new PagingOperation { PageIndex = pageIndex, PageSize = pageSize };
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            object criteria = criterias;
            Object paging = pagingOperation;
            Object order = orderOperation;
            object[] parametersArray = new[] { criteria, paging, order };
            Type[] typeArgs2 = { typeof(IList<Criteria>), typeof(PagingOperation), typeof(OrderOperation) };
            MethodInfo theMethod = constructed.GetMethod("GetByCriteria", typeArgs2);
            return theMethod.Invoke(o, parametersArray);
        }
        public Object GetByCriteria(string nameSpace, string className, int pageSize, int pageIndex, string column, string value, string search)
        {
            ManageClass manageClass = new ManageClass();
            Type d1 = typeof(BaseDao<,>);
            Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
            Type[] typeArgs = { type, typeof(int) };
            Type constructed = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(constructed, null);
            IList<Criteria> criterias = new List<Criteria>();
            if (!String.IsNullOrEmpty(search))
            {
                criterias.Add(new Criteria { Column = BaseEntity.SEARCH, Operator = DatabaseOperator.OPERATOR_LIKE, Value = search });
            }
            criterias.Add(new Criteria { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" });
            criterias.Add(new Criteria { Column = column, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = value });
            PagingOperation pagingOperation = new PagingOperation { PageIndex = pageIndex, PageSize = pageSize };
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            object criteria = criterias;
            Object paging = pagingOperation;
            Object order = orderOperation;
            object[] parametersArray = new[] { criteria, paging, order };
            Type[] typeArgs2 = { typeof(IList<Criteria>), typeof(PagingOperation), typeof(OrderOperation) };
            MethodInfo theMethod = constructed.GetMethod("GetByCriteria", typeArgs2);
            return theMethod.Invoke(o, parametersArray);
        }
        public Object GetById(string nameSpace, string className, int id)
        {
            if (id != 0 && !String.IsNullOrEmpty(nameSpace))
            {
                ManageClass manageClass = new ManageClass();
                Type d1 = typeof(BaseDao<,>);
                Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
                Type[] typeArgs = { type, typeof(int) };
                Type constructed = d1.MakeGenericType(typeArgs);
                object o = Activator.CreateInstance(constructed, null);
                Type[] typeArgs2 = { typeof(int) };
                Object test = id;
                object[] parametersArray = new[] { test };
                MethodInfo theMethod = constructed.GetMethod("GetById", typeArgs2);
                return theMethod.Invoke(o, parametersArray);
            }
            return null;
        }
        public int? Save(string nameSpace, string className, Object entity)
        {
            ManageClass manageClass = new ManageClass();
            Type d1 = typeof(BaseDao<,>);
            Type type = manageClass.GetTypeFromNameSpace(nameSpace, className);
            Type[] typeArgs = { type, typeof(int) };
            Type constructed = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(constructed, null);
            Type[] typeArgs2 = { type };
            object[] parametersArray = new[] { entity };
            MethodInfo theMethod = constructed.GetMethod("Save", typeArgs2);
            return (int)theMethod.Invoke(o, parametersArray);
        }
    }
}
