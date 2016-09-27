using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ImageTechnoSportService : BaseService, IImageTechnoSportService
    {
        public IDAOImageTechnoSport DAOImageTechnoSport { get; set; }
        public IList<ImageTechnoSport> ObtenirImageTechnoSport(string ident)
        {
            return DAOImageTechnoSport.ObtenirImageTechnoSport(ident);
        }
    }
}
