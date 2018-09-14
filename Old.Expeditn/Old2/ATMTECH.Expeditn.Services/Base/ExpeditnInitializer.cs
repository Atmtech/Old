using ATMTECH.BaseModule;

namespace ATMTECH.Expeditn.Services.Base
{
    public class ExpeditnInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            EnregistrerParAssembly("ATMTECH.Expeditn.DAO");
            EnregistrerParAssembly("ATMTECH.Expeditn.Services");
            EnregistrerParAssembly("ATMTECH.DAO");
        }
    }
}

