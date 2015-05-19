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
        string AdresseLongueLivraison { get; set; }
        string AdresseLongueFacturation { get; set; }
        bool EstAucuneAdresseLivraison { get; set; }
        bool EstAucuneAdresseFacturation { get; set; }
        IList<Order> ListeCommandePasse { set; }
    }
}
