using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
   public interface IImageTechnoSportService
   {
       IList<ImageTechnoSport> ObtenirImageTechnoSport(string ident);
   }
}
