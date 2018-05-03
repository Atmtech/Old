using ATMTECH.BaseModule;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Vachier.DAO;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Vachier.Services.Base
{
    public class VachierInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<IMessageService, MessageService>();
            AddDependency<INavigationService, NavigationService>();
            AddDependency<ILogService, LogService>();
            AddDependency<ILocalizationService, LocalizationService>();
            AddDependency<IDAOLocalization, DAOLocalization>();
            AddDependency<IDAOMessage, DAOMessage>();
            AddDependency<IDAOLogException, DAOLogException>();
            AddDependency<IDAOLogVisit, DAOLogVisit>();


            AddDependency<IDAOVachier, DAOVachier>();
        }
    }
}
