using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Web;

namespace ATMTECH.Common.Utilities
{
    public class ManageClass
    {
        public List<string> GetAllNameSpaceEntitie(string binDirectory)
        {
            List<string> list = new List<string>();
            string[] filePaths = Directory.GetFiles(binDirectory, "*Entities*.dll");
            foreach (string filePath in filePaths)
            {
                list.Add(Path.GetFileName(filePath).Replace(".dll", ""));
            }
            return list;
        }

        public Type GetTypeFromNameSpace(string nameSpace, string className)
        {
            if (!string.IsNullOrEmpty(nameSpace))
            {
                Assembly assembly = Assembly.Load(nameSpace);
                return
                assembly.GetTypes()
                        .Where(x => x.IsClass)
                        .FirstOrDefault(type => type.Name.ToLower() == className.ToLower());
            }

            return null;


        }

        public List<string> GetAllClassesFromNameSpace(string nameSpace)
        {
            Assembly asm = Assembly.Load(nameSpace);
            return asm.GetTypes().Select(type => type.Name).ToList();
        }
        public List<string> GetAllClassesFromNameSpace(string nameSpace, IList<string> excluded)
        {
            Assembly asm = Assembly.Load(nameSpace);
            return (from type in asm.GetTypes() where type.Name != "Codes" select type.Name).ToList();
        }

        public bool IsExistInNameSpace(string nameSpace, string className)
        {
            return GetAllClassesFromNameSpace(nameSpace, null).Any(c => c == className);
        }

        public object GetClassObject(string nameSpace, string className)
        {
            Assembly asm = Assembly.Load(nameSpace);
            Object o = asm.CreateInstance(nameSpace + "." + className, true);
            return o;
        }
        public string GenerateAlterTableSqlFromClass(string nameSpace, string classname)
        {
            string rtn = string.Empty;
            IList<PropertyInfo> propertyInfos = GetPropertiesFromClass(nameSpace, classname);
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                string columnType;
                string lastProperty = propertyInfos[propertyInfos.Count - 1].Name;
                switch (propertyInfo.PropertyType.Name.ToLower())
                {
                    case "string":
                        columnType = "VARCHAR(1000)";
                        break;
                    case "int32":
                        columnType = "INTEGER";
                        break;
                    case "boolean":
                        columnType = "TINYINT";
                        break;
                    case "datetime":
                        columnType = "DATETIME";
                        break;
                    case "decimal":
                        columnType = "FLOAT";
                        break;
                    default:
                        columnType = "INTEGER";
                        break;

                }

                if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                {
                    if (lastProperty != propertyInfo.Name)
                    {
                        //ALTER TABLE employee ADD newcol CHAR(25) NOT NUL
                        rtn += "ALTER TABLE [" + classname + "] ADD " + propertyInfo.Name + " " + columnType + ";" + Environment.NewLine;
                    }
                    else
                    {
                        //ALTER TABLE employee ADD newcol CHAR(25) NOT NUL
                        rtn += "ALTER TABLE [" + classname + "] ADD " + propertyInfo.Name + " " + columnType + Environment.NewLine;
                    }
                }
            }
            return rtn;
        }
        public string GenerateCreateTableSqlFromClass(string nameSpace, string classname)
        {
            if (classname.ToLower() == "baseentity" || classname.ToLower() == "baseenumeration")
            {
                return string.Empty;
            }

            IList<PropertyInfo> propertyInfos = RemovePropertiesFromPropertyList(GetPropertiesFromClass(nameSpace, classname));

            if (propertyInfos != null)
            {
                string rtn = "CREATE TABLE " + "[" + classname + "] (" + Environment.NewLine;
                rtn += "[Id] INTEGER PRIMARY KEY AUTOINCREMENT," + Environment.NewLine;
                rtn += "[Description] TEXT," + Environment.NewLine;
                rtn += "[IsActive] TINYINT," + Environment.NewLine;
                rtn += "[DateCreated] DATETIME," + Environment.NewLine;
                rtn += "[DateModified] DATETIME," + Environment.NewLine;
                rtn += "[Language] VARCHAR(10)," + Environment.NewLine;
                rtn += "[OrderId] INTEGER," + Environment.NewLine;
                rtn += "[Search] TEXT," + Environment.NewLine;
                rtn += "[ComboboxDescription] VARCHAR(255)," + Environment.NewLine;

                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    string columnType;
                    switch (propertyInfo.PropertyType.Name.ToLower())
                    {
                        case "string":
                            columnType = "VARCHAR(1000)";
                            break;
                        case "int32":
                            columnType = "INTEGER";
                            break;
                        case "boolean":
                            columnType = "TINYINT";
                            break;
                        case "datetime":
                            columnType = "DATETIME";
                            break;
                        case "decimal":
                            columnType = "FLOAT";
                            break;
                        case "ilist`1":
                            columnType = "ilist";
                            break;
                        case "double":
                            columnType = "FLOAT";
                            break;
                        default:
                            columnType = "INTEGER";
                            break;

                    }

                    if (propertyInfo.Name != "SearchUpdate")
                    {
                        if (propertyInfo.Name != "ComboboxDescriptionUpdate")
                        {
                            if (columnType != "ilist")
                            {
                                rtn += "[" + propertyInfo.Name + "] " + columnType + "," + Environment.NewLine;
                            }
                        }
                    }
                }

                rtn = rtn.Substring(0, rtn.Length - 3);
                rtn += ");";

                return rtn;
            }
            else
            {
                return "";
            }
        }
        public PropertyInfo[] GetPropertiesFromClass(string nameSpace, string classname)
        {
            object o = GetClassObject(nameSpace, classname);
            if (o != null)
            {
                Type type = o.GetType();
                PropertyInfo[] propertyList = type.GetProperties();
                return propertyList;
            }
            else return null;

        }

        public void AssignValue(Type type, object entity, string propertyValue, string propertyName)
        {
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (propertyInfo.Name == propertyName)
                {
                    if (propertyInfo.PropertyType.Namespace == "System")
                    {
                        AssignValueToProperty(propertyInfo, propertyValue, entity);
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
                        {
                            // Affect to entity the ID
                            if (propertyInfo.PropertyType.Namespace != null)
                            {
                                if (propertyInfo.PropertyType.FullName != null)
                                {
                                    ObjectHandle myobj = Activator.CreateInstance(propertyInfo.PropertyType.Namespace,
                                                                                  propertyInfo.PropertyType.FullName);
                                    Object unwrapped = myobj.Unwrap();
                                    Type typeUnwrap = unwrapped.GetType();
                                    PropertyInfo property = typeUnwrap.GetProperty(GetIdKeyColumnFromModel(entity));
                                    AssignValueToProperty(property, propertyValue, unwrapped);
                                    propertyInfo.SetValue(entity, Convert.ChangeType(unwrapped, propertyInfo.PropertyType), null);
                                }
                            }
                        }
                    }
                }
            }
        }


        public string GetIdKeyColumnFromModel(Object entity)
        {
            Type type = entity.GetType();
            return (from propertyInfo in type.GetProperties()
                    from customAttribute in propertyInfo.GetCustomAttributes(true)
                    let categoryAttribute = customAttribute as CategoryAttribute
                    where customAttribute is CategoryAttribute
                    where categoryAttribute != null && categoryAttribute.Category == "UniqueKey"
                    select propertyInfo.Name).FirstOrDefault();
        }
        public string GetPropertyValue(Type type, PropertyInfo property, Object entity)
        {
            var propert = type.GetProperty(property.Name);
            if (propert != null)
            {
                var value = propert.GetValue(entity, null);
                if (value != null)
                {
                    return value.ToString();
                }
            }
            return string.Empty;
        }

        public static string HtmlDecode(string value)
        {
            return HttpUtility.HtmlDecode(value);
        }

        public void AssignValueToProperty(PropertyInfo pi, string propertyValue, Object instance)
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
                            if (pi.PropertyType.FullName.IndexOf("System.DateTime") > 0)
                            {
                                pi.SetValue(instance, Convert.ChangeType(HtmlDecode(propertyValue), TypeCode.DateTime), null);
                            }
                            else
                            {
                                if (propertyValue != "null")
                                {
                                    pi.SetValue(instance, Convert.ChangeType(HtmlDecode(propertyValue), pi.PropertyType), null);
                                }

                            }

                        }



                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        private IList<PropertyInfo> RemovePropertiesFromPropertyList(PropertyInfo[] propertyList)
        {
            if (propertyList != null)
            {
                IList<PropertyInfo> propertyInfos = new List<PropertyInfo>();
                // Remove ID, DEscription et IsActive
                foreach (var propertyInfo in propertyList)
                {
                    if (propertyInfo.DeclaringType.Name.ToLower() != "baseentity")
                    {
                        if (propertyInfo.CanWrite)
                        {
                            propertyInfos.Add(propertyInfo);
                        }
                    }
                }
                return propertyInfos;
            }
            else
            {
                return null;
            }
        }
    }
}
