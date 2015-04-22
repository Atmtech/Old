using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class InventaireService : BaseService, IInventaireService
    {
        public IDAOInventaire DAOInventaire { get; set; }

        public IList<Stock> ObtenirInventaire()
        {
            return DAOInventaire.GetAllActive();
        }
    }
}

