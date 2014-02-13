using ATMTECH.Shell;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Template.Services.Base
{
    public class TemplateInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<ILocalizationService, LocalizationService>();
        }
    }
}
