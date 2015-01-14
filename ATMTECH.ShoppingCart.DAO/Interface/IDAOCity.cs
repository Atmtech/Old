using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOCity
    {
        City GetCity(int id);
        City FindCity(string city);
        int CreateCity(City city);
        IList<City> GetAll();
    }
}
