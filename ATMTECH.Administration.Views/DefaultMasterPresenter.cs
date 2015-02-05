using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Common.Utils;
using ATMTECH.Entities;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;

namespace ATMTECH.Administration.Views
{
    public class DefaultMasterPresenter : BaseAdministrationPresenter<IDefaultMasterPresenter>
    {

        public IReportService ReportService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }
        public IStockService StockService { get; set; }

        public IDAOEntityInformation DAOEntityInformation { get; set; }
        public IDAOEntityProperty DAOEntityProperty { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }


        public override void OnViewLoaded()
        {
            User user = AuthenticationService.AuthenticateUser;
            View.IsLogged = user != null && user.IsAdministrator;
            if (user != null)
                View.FullName = user.FirstNameLastName;
        }
        public void FillData(User user)
        {
            if (user != null)
            {
                View.FullName = user.FirstNameLastName;
                View.IsLogged = true;
                View.IsAdministrator = user.IsAdministrator;
            }
            else
            {
                View.IsLogged = false;
            }

        }
        public void SignIn(string homePage)
        {
            User user = AuthenticationService.SignIn(View.UserName, View.Password);
            if (user != null)
            {
                FillData(user);
                NavigationService.Redirect(homePage);
            }
        }
        public void GenerateStockControlReport()
        {

            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.StockControl.rdlc",
                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };


            IList<StockControlReportLine> stockControlReportLines = OrderService.GetStockControlReport();

            reportParameter.AddDatasource("dsStockControl", stockControlReportLines);
            ReportService.SaveReport("StockControl.pdf", ReportService.GetReport(reportParameter));
        }
        public void SignOut(string homePage)
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(homePage);
        }


        private void SetEntityInformation(string nameSpace)
        {
            ManageClass manageClass = new ManageClass();
            List<string> allClassesFromNameSpace = manageClass.GetAllClassesFromNameSpace(nameSpace);
            IList<EntityInformation> allEntityInformation = DAOEntityInformation.GetAllEntityInformation();
            foreach (string classe in allClassesFromNameSpace)
            {
                if (allEntityInformation.FirstOrDefault(x => x.Entity == classe) == null)
                {
                    EntityInformation entityInformation = new EntityInformation
                    {
                        IsActive = true,
                        Description = classe,
                        PageTitle = classe,
                        PageAspx = classe,
                        NameSpace = nameSpace + "." + classe,
                        Entity = classe

                    };
                    DAOEntityInformation.SaveEntity(entityInformation);
                }
            }
        }

        private void SetEntityProperty(string nameSpace)
        {
            ManageClass manageClass = new ManageClass();
            IList<EntityInformation> allEntitySaved = DAOEntityInformation.GetAllEntityInformation();
            IList<EntityProperty> gEtAllEntityProperty = DAOEntityProperty.GEtAllEntityProperty();
            foreach (EntityInformation entityInformation in allEntitySaved)
            {
                PropertyInfo[] propertyEntities = manageClass.GetPropertiesFromClass(nameSpace, entityInformation.Entity);
                if (propertyEntities != null)
                {
                    foreach (PropertyInfo propertyEntity in propertyEntities)
                    {
                        int id = entityInformation.Id;
                        if (gEtAllEntityProperty.FirstOrDefault(x => x.EntityInformation.Id == id && x.PropertyName == propertyEntity.Name) == null)
                        {
                            EntityInformation entitySave = new EntityInformation { Id = id };
                            EntityProperty entityProperty = new EntityProperty
                            {
                                IsActive = true,
                                EntityInformation = entitySave,
                                Label = propertyEntity.Name,
                                PropertyName = propertyEntity.Name
                            };
                            DAOEntityProperty.SaveEntityProperty(entityProperty);
                        }
                    }
                }
            }
        }
        public void SetAllEntityInformation()
        {
            SetEntityInformation("ATMTECH.Entities");
            SetEntityInformation("ATMTECH.ShoppingCart.Entities");
            SetEntityProperty("ATMTECH.Entities");
            //SetEntityProperty("ATMTECH.ShoppingCart.Entities");
        }

    }
}

