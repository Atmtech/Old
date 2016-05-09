using ATMTECH.BaseModule;

namespace ATMTECH.FishingAtWork.Services.Base
{
    public class FishingAtWorkInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            EnregistrerParAssembly("ATMTECH.FishingAtWork.DAO");
            EnregistrerParAssembly("ATMTECH.FishingAtWork.Services");
            EnregistrerParAssembly("ATMTECH.DAO");
        }
    }
}

