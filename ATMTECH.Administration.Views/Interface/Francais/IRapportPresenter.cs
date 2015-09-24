using System;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface.Francais
{
    public interface IRapportPresenter : IViewBase
    {
        string TitreRapport { set; }
        string NomRapport { get; }
        DateTime DateDepart { get; }
        DateTime DateFin { get;  }
        int NoCommande { get; }
        Enterprise Entreprise { get; }
        string ResultatValidationPayPal { set; }
    }
}
