using ATMTECH.BaseModule;

namespace ATMTECH.Administration.Services.Base
{
    public class AdministrationInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            EnregistrerParAssembly("ATMTECH.Administration.DAO");
            EnregistrerParAssembly("ATMTECH.ShoppingCart.Services");
            EnregistrerParAssembly("ATMTECH.ShoppingCart.DAO");
        }
    }
}
