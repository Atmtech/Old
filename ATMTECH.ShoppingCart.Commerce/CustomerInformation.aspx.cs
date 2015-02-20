using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class CustomerInformation : PageBaseShoppingCart<InformationClientPresenter, IInformationClientPresenter>, IInformationClientPresenter
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Courriel { get; set; }
        public string MotPasse { get; set; }
        public string MotPasseConfirmation { get; set; }
        public string NoCiviqueLivraison { get; set; }
        public string RueLivraison { get; set; }
        public string CodePostalLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public int PaysLivraison { get; set; }
        public string NoCiviqueFacturation { get; set; }
        public string RueFacturation { get; set; }
        public string CodePostalFacturation { get; set; }
        public string VilleFacturation { get; set; }
        public int PaysFacturation { get; set; }
    }
}