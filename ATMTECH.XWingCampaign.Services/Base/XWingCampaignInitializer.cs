using ATMTECH.BaseModule;

namespace ATMTECH.XWingCampaign.Services.Base
{
    public class XWingCampaignInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            EnregistrerParAssembly("ATMTECH.XWingCampaign.DAO");
            EnregistrerParAssembly("ATMTECH.XWingCampaign.Services");
            EnregistrerParAssembly("ATMTECH.DAO");
        }
    }
}

