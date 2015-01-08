using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using ATMTECH.WebControls;


namespace ATMTECH.Administration.Services
{
    public class GenerateControlsService : BaseService, IGenerateControlsService
    {
        public IDataEditorService DataEditorService { get; set; }
        public IStockService StockService { get; set; }
        public IProductService ProductService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public ManageClass ManageClass { get { return new ManageClass(); } }
        public IList<PropertyWithLabel> ListeProprieteSansCelleSysteme(string nameSpace, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
        {
            ManageClass manageClass = new ManageClass();

            IList<PropertyInfo> list = manageClass.GetPropertiesFromClass(nameSpace, entity).Where(propertyInfo => !DataEditorService.IsSystemColumn(propertyInfo.Name)).ToList();
            list = list.Where(x => x.Name != "SearchUpdate").ToList();
            list = list.Where(x => x.Name != "ComboboxDescriptionUpdate").ToList();
            return list.Select(propertyInfo => new PropertyWithLabel { Label = TrouverLibelle(propertyInfo.Name, entity, entityInformations, entityProperties), PropertyInfo = propertyInfo }).ToList();
        }
        public IList<ControlWithLabel> CreateControls(string nameSpace, string entity, bool isInserting, int id, int idEnterprise, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
        {
            Object entityObject = GetEntity(id, nameSpace, entity);

            if (isInserting)
            {
                ManageClass manageClass = new ManageClass();
                Type type = manageClass.GetTypeFromNameSpace(nameSpace, entity);
                entityObject = Activator.CreateInstance(type, null);
            }
            IList<ControlWithLabel> controlWithLabels = new List<ControlWithLabel>();

            ControlWithLabel controlWithLabelEntete = new ControlWithLabel();
            Control label = new Label() { Text = "<h2>Édition / Insertion</h2>" };
            Control labelEntite = new Label() { Text = "<h2>" + entity + "</h2>" };

            controlWithLabelEntete.Label = label;
            controlWithLabelEntete.Control = labelEntite;
            controlWithLabels.Add(controlWithLabelEntete);



            if (entityObject != null)
            {
                foreach (PropertyInfo propertyInfo in GetPropertiesToDisplay(nameSpace, entity))
                {
                    if (IsSaveableColumn(propertyInfo))
                    {
                        ControlWithLabel controlWithLabel = new ControlWithLabel();
                        Control controlLabel = CreateLabel(propertyInfo, entity, entityInformations, entityProperties);
                        string value = GetValueFromProperty(entityObject, propertyInfo, isInserting);
                        Control control = GenerateEditingControl(propertyInfo, value, idEnterprise, nameSpace, entity, isInserting);
                        if (control != null)
                        {
                            controlWithLabel.Label = controlLabel;
                            controlWithLabel.Control = control;
                            controlWithLabels.Add(controlWithLabel);
                        }
                    }
                }
            }


            return controlWithLabels;
        }

        private static bool IsSaveableColumn(PropertyInfo propertyInfo)
        {
            if (propertyInfo.Name == BaseEntity.COMBOBOX_DESCRIPTION || propertyInfo.Name == BaseEntity.SEARCH)
                return false;

            if (propertyInfo.Name == "SearchUpdate" || propertyInfo.Name == "ComboboxDescriptionUpdate")
                return false;

            MethodInfo setMethod = propertyInfo.GetSetMethod();
            if (setMethod == null)
                return false;

            return true;
        }

        private string TrouverLibelle(string propertyName, string entity, IEnumerable<EntityInformation> entityInformations, IEnumerable<EntityProperty> entityProperties)
        {
            //int id = DAOEntityInformation.GetEntityInformationId(entity);
            var entityInformation = entityInformations.FirstOrDefault(x => x.Entity == entity);
            if (entityInformation != null)
            {
                int id = entityInformation.Id;
                if (id == 0)
                    return "Inconnu";
                //return DAOEntityProperty.GetEntityPropertyLabel(id, propertyName);
                EntityProperty firstOrDefault = entityProperties.FirstOrDefault(x => x.EntityInformation.Id == id && x.PropertyName == propertyName);
                if (firstOrDefault != null)
                {
                    return firstOrDefault.Label;
                }
            }
            return propertyName;

        }
        private IOrderedEnumerable<PropertyInfo> GetPropertiesToDisplay(string nameSpace, string entity)
        {
            Type type = ManageClass.GetTypeFromNameSpace(nameSpace, entity);
            Activator.CreateInstance(type, null);
            return type.GetProperties().OrderByDescending(x => DataEditorService.IsSystemColumn(x.Name));
        }
        private Control CreateLabel(PropertyInfo propertyInfo, string entity, IEnumerable<EntityInformation> entityInformations, IEnumerable<EntityProperty> entityProperties)
        {
            return new Label
            {
                ID = propertyInfo.Name + "Label",
                Text = string.Format("<b>{0}</b>", TrouverLibelle(propertyInfo.Name, entity, entityInformations, entityProperties))
            };
        }
        private Object GetEntity(int id, string nameSpace, string entity)
        {
            return DataEditorService.GetById(nameSpace, entity, id);
        }
        private string GetValueFromProperty(Object entityObject, PropertyInfo propertyInfo, bool isInserting)
        {
            if (isInserting)
            {
                switch (propertyInfo.Name)
                {
                    case "Id":
                        return "0";
                    case "IsActive":
                        return "True";
                    default:
                        return string.Empty;
                }
            }
            if (entityObject != null)
            {
                if (propertyInfo.PropertyType.Namespace != "System")
                {
                    object valeurPropriete = propertyInfo.GetValue(entityObject, null);
                    if (valeurPropriete != null)
                    {
                        PropertyInfo propertyInfoId = valeurPropriete.GetType().GetProperty("Id");
                        return propertyInfoId.GetValue(valeurPropriete, null).ToString();
                    }
                }
            }
            return DataEditorService.FindValue(entityObject, propertyInfo.Name);
        }


        private Object GetDatasourceFromProperty(PropertyInfo propertyInfo, int idEnterprise, string nameSpace, string entity)
        {
            switch (propertyInfo.PropertyType.Name.ToLower())
            {

                case "product":
                    return ProductService.GetProductsSimple(idEnterprise);
                case "enterprise":
                    return EnterpriseService.GetEnterpriseByAccess(AuthenticationService.AuthenticateUser);
                case "stock":
                    {
                        IList<Stock> stocks = StockService.GetAllStock();
                        IList<Product> listProduct = ProductService.GetProducts(idEnterprise);

                        IList<Stock> rtn = new List<Stock>();
                        foreach (Stock stock in stocks)
                        {
                            if (stock.Product != null)
                                stock.Product = listProduct.FirstOrDefault(x => x.Id == stock.Product.Id);
                            if (stock.Product != null)
                            {
                                if (stock.Product.Enterprise.Id == idEnterprise)
                                {
                                    rtn.Add(stock);
                                }
                            }
                        }

                        return rtn;
                    }
                case "productcategory":
                    {
                        return ProductService.GetProductCategoryWithoutLanguage(idEnterprise);
                    }
                case "productcategoryenglish":
                    {
                        return ProductService.GetProductCategoryWithoutLanguage(idEnterprise);
                    }
                case "productcategoryfrench":
                    {
                        return ProductService.GetProductCategoryWithoutLanguage(idEnterprise);
                    }
                case "user":
                case "file":
                    if ((propertyInfo.Name == "Image" && entity == "Enterprise"))
                    {
                        Criteria criteria = new Criteria
                        {
                            Column = File.CATEGORY,
                            Operator = DatabaseOperator.OPERATOR_LIKE,
                            Value = "Enterprise"
                        };

                        return DataEditorService.GetByCriteria("ATMTECH.Entities", propertyInfo.PropertyType.Name, 5000, 0, "", criteria);
                    }

                    return DataEditorService.GetByCriteria("ATMTECH.Entities", propertyInfo.PropertyType.Name, 5000, 0, "");

                default:
                    return DataEditorService.GetByCriteria(propertyInfo.PropertyType.Namespace != nameSpace ? propertyInfo.PropertyType.Namespace : nameSpace, propertyInfo.PropertyType.Name, 5000, 0, "");
            }
        }
        private Control GenerateOrderStatusDisplay(PropertyInfo propertyInfo, string value)
        {
            IList<OrderStatusDisplay> orderStatus = new List<OrderStatusDisplay>();
            OrderStatusDisplay orderStatusDisplay1 = new OrderStatusDisplay
                {
                    Id = 1,
                    ComboboxDescription = "Liste de souhait"
                };

            OrderStatusDisplay orderStatusDisplay2 = new OrderStatusDisplay
                {
                    Id = 2,
                    ComboboxDescription = "Commandé par le client"
                };

            OrderStatusDisplay orderStatusDisplay3 = new OrderStatusDisplay
                {
                    Id = 3,
                    ComboboxDescription = "Envoyé au client"
                };

            orderStatus.Add(orderStatusDisplay1);
            orderStatus.Add(orderStatusDisplay2);
            orderStatus.Add(orderStatusDisplay3);
            return CreateComboBox(propertyInfo, value, orderStatus);
        }
        private Control GenerateEditingControl(PropertyInfo propertyInfo, string value, int idEnterprise, string nameSpace, string entity, bool isInserting)
        {
            if (propertyInfo.PropertyType.Namespace == "System")
            {
                if (propertyInfo.Name == "OrderStatus")
                {
                    return GenerateOrderStatusDisplay(propertyInfo, value);
                }
                return CreateTextBox(propertyInfo, value, isInserting);
            }

            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
            {
                Object datasource = GetDatasourceFromProperty(propertyInfo, idEnterprise, nameSpace, entity);
                return CreateComboBox(propertyInfo, value, datasource);
            }

            return null;
        }
        private ComboBox CreateComboBox(PropertyInfo propertyInfo, string selectedValue, object dataSource)
        {
            ComboBox comboBoxSimple = new ComboBox
            {
                ID = propertyInfo.Name,
            };
            DropDownList dropDownList = new DropDownList
                {
                    DataValueField = BaseEntity.ID,
                    DataTextField = BaseEntity.COMBOBOX_DESCRIPTION,
                    DataSource = dataSource
                };
            dropDownList.DataBind();

            comboBoxSimple.AjouterItemsNull();

            foreach (ListItem item in dropDownList.Items)
            {
                comboBoxSimple.Items.Add(item);
            }

            // comboBoxSimple.AjouterItemsNull();

            if (selectedValue != "0")
            {
                if (!string.IsNullOrEmpty(selectedValue))
                    comboBoxSimple.SelectedValue = selectedValue;
            }


            return comboBoxSimple;
        }

        private Control CreateTextBox(PropertyInfo propertyInfo, string value, bool isInserting)
        {
            bool isEnabled = true;
            if (propertyInfo.Name == "InitialState")
            {
                if (!isInserting)
                {
                    isEnabled = false;
                }
            }

            if (propertyInfo.Name == "ProductDescription")
            {
                isEnabled = false;
            }

            if (propertyInfo.Name == "AddressType")
            {
                ListItem listItem1 = new ListItem("Facturation", EnterpriseAddress.CODE_ADRESS_TYPE_BILLING);
                ListItem listItem2 = new ListItem("Livraison", EnterpriseAddress.CODE_ADRESS_TYPE_SHIPPING);

                ComboBox comboBoxAvance = new ComboBox
                {
                    ID = propertyInfo.Name,

                };
                comboBoxAvance.Items.Add(listItem1);
                comboBoxAvance.Items.Add(listItem2);
                comboBoxAvance.SelectedValue = value;
                return comboBoxAvance;
            }

            switch (propertyInfo.PropertyType.FullName)
            {
                case "System.Decimal":
                    {
                        Numeric numeric = new Numeric
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Pixel(150),
                            Enabled = isEnabled
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            numeric.Enabled = false;
                        }

                        return numeric;
                    }
                case "System.Int32":
                    {
                        Numeric numeric = new Numeric
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Pixel(150),
                            Enabled = isEnabled,
                            NoDecimal = true
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            numeric.Enabled = false;
                        }

                        return numeric;
                    }
                case "System.DateTime":
                    {
                        DatePicker datePicker = new DatePicker
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Pixel(150),
                            Enabled = isEnabled
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            datePicker.Enabled = false;
                        }

                        return datePicker;
                    }
                case "System.Boolean":
                    CheckBox checkBox = new CheckBox { ID = propertyInfo.Name };
                    if (value.ToLower() == "true")
                    {
                        checkBox.Checked = true;
                    }
                    if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                    {
                        checkBox.Enabled = false;
                    }
                    return checkBox;

                default:
                    {
                        Editor editor = new Editor
                            {
                                ID = propertyInfo.Name,
                                Text = value,
                                Width = Unit.Percentage(90),
                                Enabled = isEnabled,
                                Toolbar = "Source|Bold|Italic|Underline|Strike|-|Subscript|Superscript|NumberedList|BulletedList|-|Outdent|Indent|Table/Styles|Format|Font|FontSize|TextColor|BGColor|",
                                Height = Unit.Pixel(50)

                            };

                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            editor.Enabled = false;
                        }
                        return editor;
                    }
            }
        }
        //private DatePicker CreateDateTextBox(PropertyInfo propertyInfo, string value)
        //{
        //    DatePicker dateTextBoxAvance = new DatePicker
        //    {
        //        ID = propertyInfo.Name,
        //        Text = value,
        //        //EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess)
        //    };
        //    if (DataEditorService.IsSystemColumn(propertyInfo.Name))
        //    {
        //        dateTextBoxAvance.Enabled = false;
        //    }
        //    return dateTextBoxAvance;
        //}
        //private bool IsRequired(string property, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
        //{
        //    IList<EntityProperty> entityProperties = FindEntityInformation(entity, entityInformations, entityPropertiess).EntityProperties;
        //    entityProperties = entityProperties.Where(x => x.PropertyName == property).ToList();
        //    if (entityProperties.Count > 0)
        //        return entityProperties[0].IsRequired;
        //    else
        //        return false;
        //}
        //private EntityInformation FindEntityInformation(string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
        //{
        //    ManageClass manageClass = new ManageClass();
        //    EntityInformation entityInformation = null;
        //    if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", entity))
        //    {
        //        entityInformation =
        //           entityInformations.Where(x => x.NameSpace == "ATMTECH.ShoppingCart.Entities." + entity)
        //               .ToList()[0];
        //        entityInformation.EntityProperties =
        //            entityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
        //    }
        //    if (manageClass.IsExistInNameSpace("ATMTECH.Entities", entity))
        //    {
        //        entityInformation =
        //            entityInformations.Where(x => x.NameSpace == "ATMTECH.Entities." + entity)
        //                .ToList()[0];
        //        entityInformation.EntityProperties =
        //            entityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
        //    }
        //    return entityInformation;
        //}
        //private Control CreateComboboxLanguage()
        //{
        //    return null;
        //    //ComboBoxAvance comboBoxAvance = new ComboBoxAvance
        //    //{
        //    //    ID = propertyInfo.Name,
        //    //    DataValueField = "Id",
        //    //    DataTextField = "ComboboxDescription",
        //    //    EstObligatoire = true
        //    //};

        //    //ListItem listItemFrancais = new ListItem("Français", "fr");
        //    //ListItem listItemAnglais = new ListItem("Anglais", "en");

        //    //comboBoxAvance.Items.Add(listItemFrancais);
        //    //comboBoxAvance.Items.Add(listItemAnglais);
        //    //comboBoxAvance.SelectedValue = value;
        //    //return comboBoxAvance;
        //}

        //private bool IsLanguageProperty(PropertyInfo propertyInfo)
        //{
        //    return propertyInfo.Name == "Language";
        //}
    }

    public class ControlWithLabel
    {
        public Control Label { get; set; }
        public Control Control { get; set; }
        public Control Message { get; set; }
    }
    public class PropertyWithLabel
    {
        public PropertyInfo PropertyInfo { get; set; }
        public string Label { get; set; }
    }
}
