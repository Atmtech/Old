using ATMTECH.Administration.Services.Interface;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.Shell;
using ATMTECH.ShoppingCart.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Services.Base
{
    public class AdministrationInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<IGenerateControlsService, GenerateControlsService>();
            AddDependency<IParameterService, ParameterService>();
            AddDependency<IOrderService, OrderService>();
            AddDependency<IAuthenticationService, AuthenticationService>();
            AddDependency<IValidateCustomerService, ValidateCustomerService>();
            AddDependency<ICustomerService, CustomerService>();
            AddDependency<IProductService, ProductService>();
            AddDependency<IStockService, StockService>();
            AddDependency<ITaxesService, TaxesService>();
            AddDependency<IEnterpriseService, EnterpriseService>();
            AddDependency<IShippingService, ShippingService>();
            AddDependency<IMailService, MailService>();
            AddDependency<IPurolatorService, PurolatorService>();
            AddDependency<IMessageService, MessageService>();
            AddDependency<INavigationService, NavigationService>();
            AddDependency<IAddressService, AddressService>();
            AddDependency<ILogService, LogService>();
            AddDependency<ILocalizationService, LocalizationService>();
            AddDependency<IUpsService, UpsService>();
            AddDependency<IPaypalService, PaypalService>();
            AddDependency<IReportService, ReportService>();
            AddDependency<IDAOFile, DAOFile>();
            AddDependency<IDAOProductPriceHistory, DAOProductPriceHistory>();
            AddDependency<IFileService, FileService>();
            AddDependency<IDatabaseService, DatabaseService>();

            AddDependency<IDAOLocalization, DAOLocalization>();
            AddDependency<IDAOGroupUser, DAOGroupUser>();
            AddDependency<IDAOGroupProduct, DAOGroupProduct>();
            AddDependency<IDAOMessage, DAOMessage>();
            AddDependency<IDAOLogException, DAOLogException>();
            AddDependency<IDAOParameter, DAOParameter>();
            AddDependency<IDAOUser, DAOUser>();
            AddDependency<IDAOCustomer, DAOCustomer>();
            AddDependency<IDAOEnterpriseAddress, DAOEnterpriseAddress>();
            AddDependency<IDAOEnterprise, DAOEnterprise>();
            AddDependency<IDAOUser, DAOUser>();
            AddDependency<IDAOOrder, DAOOrder>();
            AddDependency<IDAOTaxes, DAOTaxes>();
            AddDependency<IDAOStock, DAOStock>();
            AddDependency<IDAOProduct, DAOProduct>();
            AddDependency<IDAOCountry, DAOCountry>();
            AddDependency<IDAOOrderLine, DAOOrderLine>();
            AddDependency<IDAOSupplier, DAOSupplier>();
            AddDependency<IDAOProductCategory, DAOProductCategory>();
            AddDependency<IDAOProductFile, DAOProductFile>();
            AddDependency<IDAOStock, DAOStock>();
            AddDependency<IDAOAddress, DAOAddress>();
            AddDependency<IDAOStockTransaction, DAOStockTransaction>();
            AddDependency<IDAOLogVisit, DAOLogVisit>();
            AddDependency<IDAOCity, DAOCity>();
            AddDependency<IDAOStockTemplate, DAOStockTemplate>();
            AddDependency<IDAOStockLink, DAOStockLink>();
            AddDependency<IDAOEnumOrderInformation, DAOEnumOrderInformation>();
            AddDependency<IDAOEnterpriseAccess, DAOEnterpriseAccess>();
            

        }
    }
}
