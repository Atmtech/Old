using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.Shell;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Services.Base
{
    public class AchievementInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<IParameterService, ParameterService>();
            AddDependency<IAuthenticationService, AuthenticationService>();
            AddDependency<IMailService, MailService>();
            AddDependency<IPurolatorService, PurolatorService>();
            AddDependency<IMessageService, MessageService>();
            AddDependency<INavigationService, NavigationService>();
            AddDependency<ILogService, LogService>();
            AddDependency<ILocalizationService, LocalizationService>();
            AddDependency<IUpsService, UpsService>();
            AddDependency<IPaypalService, PaypalService>();
            AddDependency<IFileService, FileService>();

            AddDependency<IDAOFile, DAOFile>();
            AddDependency<IDAOLocalization, DAOLocalization>();
            AddDependency<IDAOGroupUser, DAOGroupUser>();
            AddDependency<IDAOMessage, DAOMessage>();
            AddDependency<IDAOLogException, DAOLogException>();
            AddDependency<IDAOParameter, DAOParameter>();
            AddDependency<IDAOUser, DAOUser>();
            AddDependency<IDAOUser, DAOUser>();
            AddDependency<IDAOLogVisit, DAOLogVisit>();
        }
    }
}
