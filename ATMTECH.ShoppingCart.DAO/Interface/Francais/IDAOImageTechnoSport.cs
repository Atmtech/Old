using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOImageTechnoSport
    {
        IList<ImageTechnoSport> ObtenirImageTechnoSport(string ident);
    }
}
