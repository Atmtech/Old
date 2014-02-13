using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Shell;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.BillardLoretteville.Services.Base
{
    public class BillardLorettevilleInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<IPurolatorService, PurolatorService>();
            
            AddDependency<IDAOFile, DAOFile>();
            AddDependency<IAuthenticationService, AuthenticationService>();
            AddDependency<IDAOUser, DAOUser>();
            
        }
    }
}
