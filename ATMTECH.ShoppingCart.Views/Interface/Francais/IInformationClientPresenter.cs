using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IInformationClientPresenter : IViewBase
    {
        string Nom { get; set; }
        string Prenom { get; set; }
        string Courriel { get; set; }
        string MotPasse { get; set; }
        string MotPasseConfirmation { get; set; }

        string NoCiviqueLivraison { get; set; }
        string RueLivraison { get; set; }
        string CodePostalLivraison { get; set; }
        string VilleLivraison { get; set; }
        int PaysLivraison { get; set; }

        string NoCiviqueFacturation { get; set; }
        string RueFacturation { get; set; }
        string CodePostalFacturation { get; set; }
        string VilleFacturation { get; set; }
        int PaysFacturation { get; set; }

        bool EstAucuneAdresseLivraison { get; set; }
        bool EstAucuneAdresseFacturation { get; set; }

        IList<Country> ListePaysLivraison {  set; }
        IList<Country> ListePaysFacturation {  set; }

        IList<Order> ListeCommandePasse { set; }
    }
}
