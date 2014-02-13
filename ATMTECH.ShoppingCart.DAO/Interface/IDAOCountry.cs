using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOCountry
    {
        Country GetCountry(int id);
        Country FindCountry(string countryName);
        IList<Country> GetAllCountries();
    }
}
