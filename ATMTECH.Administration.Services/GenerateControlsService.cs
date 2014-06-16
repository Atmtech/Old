using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Controls.Edition;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;


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

            if (entityObject != null)
            {
                foreach (PropertyInfo propertyInfo in GetPropertiesToDisplay(nameSpace, entity))
                {
                    if (IsSaveableColumn(propertyInfo))
                    {
                        ControlWithLabel controlWithLabel = new ControlWithLabel();
                        Control controlLabel = CreateLabel(propertyInfo, entity, entityInformations, entityProperties);
                        string value = GetValueFromProperty(entityObject, propertyInfo, isInserting);
                        Control control = GenerateEditingControl(propertyInfo, value, idEnterprise, nameSpace, entity, isInserting, entityInformations, entityProperties);
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

        private string TrouverLibelle(string propertyName, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
        {
            //int id = DAOEntityInformation.GetEntityInformationId(entity);
            int id = entityInformations.FirstOrDefault(x => x.Entity == entity).Id;
            if (id == 0)
                return "Inconnu";
            //return DAOEntityProperty.GetEntityPropertyLabel(id, propertyName);
            EntityProperty firstOrDefault = entityProperties.FirstOrDefault(x => x.EntityInformation.Id == id && x.PropertyName == propertyName);
            if (firstOrDefault != null)
            {
                return firstOrDefault.Label;
            }
            return propertyName;

        }
        private IOrderedEnumerable<PropertyInfo> GetPropertiesToDisplay(string nameSpace, string entity)
        {
            Type type = ManageClass.GetTypeFromNameSpace(nameSpace, entity);
            Activator.CreateInstance(type, null);
            return type.GetProperties().OrderByDescending(x => DataEditorService.IsSystemColumn(x.Name));
        }
        private Control CreateLabel(PropertyInfo propertyInfo, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
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
        private bool IsLanguageProperty(PropertyInfo propertyInfo)
        {
            return propertyInfo.Name == "Language";
        }
        private Control CreateComboboxLanguage(PropertyInfo propertyInfo, string value)
        {
            return null;
            ComboBoxAvance comboBoxAvance = new ComboBoxAvance
            {
                ID = propertyInfo.Name,
                DataValueField = "Id",
                DataTextField = "ComboboxDescription",
                EstObligatoire = true
            };

            ListItem listItemFrancais = new ListItem("Français", "fr");
            ListItem listItemAnglais = new ListItem("Anglais", "en");

            comboBoxAvance.Items.Add(listItemFrancais);
            comboBoxAvance.Items.Add(listItemAnglais);
            comboBoxAvance.SelectedValue = value;
            return comboBoxAvance;
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

                        IList<Stock> rtn = new List<Stock>();
                        foreach (Stock stock in stocks)
                        {
                            stock.Product = ProductService.GetProductSimple(stock.Product.Id);
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

        private Control GenerateEditingControl(PropertyInfo propertyInfo, string value, int idEnterprise, string nameSpace, string entity, bool isInserting, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
        {
            if (propertyInfo.PropertyType.Namespace == "System")
            {
                if (propertyInfo.Name == "OrderStatus")
                {
                    IList<OrderStatusDisplay> orderStatus = new List<OrderStatusDisplay>();
                    OrderStatusDisplay orderStatusDisplay1 = new OrderStatusDisplay();
                    orderStatusDisplay1.Id = 1;
                    orderStatusDisplay1.ComboboxDescription = "Liste de souhait";

                    OrderStatusDisplay orderStatusDisplay2 = new OrderStatusDisplay();
                    orderStatusDisplay2.Id = 2;
                    orderStatusDisplay2.ComboboxDescription = "Commandé par le client";

                    OrderStatusDisplay orderStatusDisplay3 = new OrderStatusDisplay();
                    orderStatusDisplay3.Id = 3;
                    orderStatusDisplay3.ComboboxDescription = "Envoyé au client";

                    orderStatus.Add(orderStatusDisplay1);
                    orderStatus.Add(orderStatusDisplay2);
                    orderStatus.Add(orderStatusDisplay3);
                    return CreateComboBoxSimple(propertyInfo, value, orderStatus, entity, entityInformations, entityPropertiess);
                }
                else
                {
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "DateTime":
                            return CreateDateTextBox(propertyInfo, value, entity, entityInformations, entityPropertiess);
                        case "Boolean":
                            return CreateCheckBox(propertyInfo, value);
                        default:
                            return IsLanguageProperty(propertyInfo) ? CreateComboboxLanguage(propertyInfo, value) : CreateTextBox(propertyInfo, value, isInserting, entity, entityInformations, entityPropertiess);
                    }
                }

            }
            if (propertyInfo.PropertyType.Name.ToLower() != "ilist`1")
            {
                Object datasource = GetDatasourceFromProperty(propertyInfo, idEnterprise, nameSpace, entity);
                return CreateComboBoxSimple(propertyInfo, value, datasource, entity, entityInformations, entityPropertiess);
            }

            return null;
        }

      

        private ComboBoxSimple CreateComboBoxSimple(PropertyInfo propertyInfo, string selectedValue, object dataSource, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
        {
            ComboBoxSimple comboBoxSimple = new ComboBoxSimple
            {
                ID = propertyInfo.Name,
                DataValueField = BaseEntity.ID,
                DataTextField = BaseEntity.COMBOBOX_DESCRIPTION,
                DataSource = dataSource,
                EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess)
            };
            comboBoxSimple.DataBind();

            ListItem listItem = new ListItem("-- N/A --", "null");
            comboBoxSimple.Items.Insert(0, listItem);
            if (selectedValue != "0")
            {
                comboBoxSimple.SelectedValue = selectedValue;
            }
            return comboBoxSimple;
        }

        private CheckBoxAvance CreateCheckBox(PropertyInfo propertyInfo, string value)
        {
            CheckBoxAvance checkBoxAvance = new CheckBoxAvance { ID = propertyInfo.Name };
            if (value.ToLower() == "true")
            {
                checkBoxAvance.Checked = true;
            }
            if (DataEditorService.IsSystemColumn(propertyInfo.Name))
            {
                checkBoxAvance.Enabled = false;
            }

            return checkBoxAvance;
        }
        private Control CreateTextBox(PropertyInfo propertyInfo, string value, bool isInserting, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
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

                ComboBoxAvance comboBoxAvance = new ComboBoxAvance
                {
                    ID = propertyInfo.Name,
                    EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess)
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
                        TextBoxAvance textBoxAvance = new TextBoxAvance
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Pixel(150),
                            TextMode = TextBoxMode.SingleLine,
                            EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess),
                            Enabled = isEnabled
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            textBoxAvance.Enabled = false;
                        }

                        return textBoxAvance;
                    }
                case "System.Int32":
                    {
                        AlphaNumTextBoxAvance alphaNumTextBoxAvance = new AlphaNumTextBoxAvance
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Percentage(80),
                            TypeSaisie =
                                AlphaNumTextBoxAvance.TypeDeChamp.
                                Decimal,
                            NombreDecimaux = 2,
                            NombreEntiers = 15,
                            EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess),
                            Enabled = isEnabled
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            alphaNumTextBoxAvance.Enabled = false;
                        }

                        return alphaNumTextBoxAvance;
                    }
                case "System.DateTime":
                    {
                        TextBoxAvance textBoxAvance = new TextBoxAvance
                        {
                            ID = propertyInfo.Name,
                            Text = value,
                            Width = Unit.Pixel(150),
                            TextMode = TextBoxMode.SingleLine,
                            EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess),
                            Enabled = isEnabled
                        };
                        if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                        {
                            textBoxAvance.Enabled = false;
                        }

                        return textBoxAvance;
                    }

                default:
                    {
                        if (propertyInfo.PropertyType.FullName.IndexOf("System.DateTime") > 0)
                        {
                            TextBoxAvance textBoxAvance = new TextBoxAvance
                            {
                                ID = propertyInfo.Name,
                                Text = value,
                                Width = Unit.Pixel(150),
                                TextMode = TextBoxMode.SingleLine,
                                EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess),
                                Enabled = isEnabled
                            };
                            if (DataEditorService.IsSystemColumn(propertyInfo.Name))
                            {
                                textBoxAvance.Enabled = false;
                            }

                            return textBoxAvance;
                        }
                        else
                        {
                            TextEditorAvance ckEditor = new TextEditorAvance
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
                                ckEditor.Enabled = false;
                            }
                            return ckEditor;

                        }


                    }
            }
        }
        private DateTextBoxAvance CreateDateTextBox(PropertyInfo propertyInfo, string value, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
        {
            DateTextBoxAvance dateTextBoxAvance = new DateTextBoxAvance
            {
                ID = propertyInfo.Name,
                Text = value,
                EstObligatoire = IsRequired(propertyInfo.Name, entity, entityInformations, entityPropertiess)
            };
            if (DataEditorService.IsSystemColumn(propertyInfo.Name))
            {
                dateTextBoxAvance.Enabled = false;
            }
            return dateTextBoxAvance;
        }

        private bool IsRequired(string property, string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityPropertiess)
        {
            IList<EntityProperty> entityProperties = FindEntityInformation(entity, entityInformations, entityPropertiess).EntityProperties;
            entityProperties = entityProperties.Where(x => x.PropertyName == property).ToList();
            if (entityProperties.Count > 0)
                return entityProperties[0].IsRequired;
            else
                return false;
        }
        private EntityInformation FindEntityInformation(string entity, IList<EntityInformation> entityInformations, IList<EntityProperty> entityProperties)
        {
            ManageClass manageClass = new ManageClass();
            EntityInformation entityInformation = null;
            if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", entity))
            {
                entityInformation =
                   entityInformations.Where(x => x.NameSpace == "ATMTECH.ShoppingCart.Entities." + entity)
                       .ToList()[0];
                entityInformation.EntityProperties =
                    entityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
            }
            if (manageClass.IsExistInNameSpace("ATMTECH.Entities", entity))
            {
                entityInformation =
                    entityInformations.Where(x => x.NameSpace == "ATMTECH.Entities." + entity)
                        .ToList()[0];
                entityInformation.EntityProperties =
                    entityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
            }
            return entityInformation;
        }
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
