using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Shell;
using ATMTECH.DenonceTonGros.DAO;
using ATMTECH.DenonceTonGros.DAO.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.DenonceTonGros.Services.Base
{

    public class DenonceTonGrosInitializer : BaseModuleInitializer
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


            AddDependency<IDAODenonceTonGros, DAODenonceTonGros>();
        }
    }
}
