using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

namespace ATMTECH.DAO.Database
{
    public class Model<TModel, TId>
    {
        private const string IDENT_UNIQUE_KEY = "UniqueKey";
        
        public DatabaseOperation<TModel, TId> DatabaseOperation { get { return new DatabaseOperation<TModel, TId>(); } }

        public void AssignValueToProperty(PropertyInfo pi, string propertyValue, TModel instance)
        {
            {
                try
                {
                    if (!String.IsNullOrEmpty(propertyValue))
                    {
                        if (pi.PropertyType.Name == "Boolean")
                        {
                            if (propertyValue == "1")
                            {
                                pi.SetValue(instance, Convert.ChangeType("True", pi.PropertyType), null);
                            }
                            else
                            {
                                pi.SetValue(instance,
                                            propertyValue.ToLower() == "true"
                                                ? Convert.ChangeType("True", pi.PropertyType)
                                                : Convert.ChangeType("False", pi.PropertyType), null);
                            }
                        }
                        else
                        {
                            pi.SetValue(instance, Convert.ChangeType(propertyValue, pi.PropertyType), null);
                        }
                    }
                }
                catch
                {

                }

            }
        }
        public void AssignValueToProperty(PropertyInfo pi, string propertyValue, Object instance)
        {
            {
                try
                {
                    if (!String.IsNullOrEmpty(propertyValue))
                    {
                        if (pi.PropertyType.Name != "Boolean")
                        {
                            pi.SetValue(instance, Convert.ChangeType(propertyValue, pi.PropertyType), null);
                        }
                    }
                }
                catch
                {

                }
            }
        }
        public Object GetValueProperty(string property, TModel model)
        {
            Type type = model.GetType();
            var propert = type.GetProperty(property);
            return propert == null ? null : propert.GetValue(model, null);
        }

        public void SetValueProperty(string property, string value, TModel model)
        {
            Type type = model.GetType();
            var propert = type.GetProperty(property);
            AssignValueToProperty(propert, value, model);
        }

        public TModel FillModel(DataRow dataRow)
        {
            // Check each property if exist against Datarow
            TModel model = (TModel)Activator.CreateInstance(typeof(TModel), null);

            Type type = model.GetType();

            DataColumnCollection dataColumnCollection = DatabaseOperation.ReturnAllColumnNameFromTable(DatabaseOperation.ReturnTableName(type));
            PropertyInfo[] properties = type.GetProperties();

            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.PropertyType.Namespace == "System")
                {
                    if (DatabaseOperation.IsColumnExist(propertyInfo.Name, dataColumnCollection))
                    {
                        string propertyValue = dataRow[propertyInfo.Name].ToString();
                        AssignValueToProperty(propertyInfo, propertyValue, model);
                    }
                }
                else
                {
                    if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                    {
                        if (DatabaseOperation.IsColumnExist(propertyInfo.Name, dataColumnCollection))
                        {
                            // Affect to entity the ID
                            String propertyValue = dataRow[propertyInfo.Name].ToString();
                            ObjectHandle myobj = Activator.CreateInstance(propertyInfo.PropertyType.Namespace, propertyInfo.PropertyType.FullName);
                            Object unwrapped = myobj.Unwrap();
                            Type typeUnwrap = unwrapped.GetType();
                            PropertyInfo property = typeUnwrap.GetProperty(GetIdKeyColumnFromModel());
                            AssignValueToProperty(property, propertyValue, unwrapped);
                            propertyInfo.SetValue(model, Convert.ChangeType(unwrapped, propertyInfo.PropertyType), null);


                        }
                    }
                    else
                    {
                        // We dont manage this 
                    }
                }
            }

            return model;
        }
        public object ExtractValuePropertyPath(object value, string path)
        {
            Type currentType = value.GetType();

            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                if (value != null)
                {
                    value = property.GetValue(value, null);
                }
                currentType = property.PropertyType;
            }
            return value;
        }
        public string GetIdKeyColumnFromModel()
        {
            Type type = typeof(TModel);
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                foreach (object customAttribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (customAttribute is CategoryAttribute)
                    {
                        if ((customAttribute as CategoryAttribute).Category == IDENT_UNIQUE_KEY)
                        {
                            return propertyInfo.Name;
                        }
                    }
                }
            }

            return null;
        }
        public IList<TModel> FillModelFromDataSet(DataSet dataSet)
        {
            return (from DataRow row in dataSet.Tables[0].Rows select FillModel(row)).ToList();
        }
    }
}
