using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IEntrepriseService
    {
        Enterprise ObtenirEntreprise(int id);
        IList<Enterprise> ObtenirEntreprise();
    }
}
