using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOCity : BaseDao<City, int>, IDAOCity
    {
        public City GetCity(int id)
        {
            return GetById(id);
        }

        public City FindCity(string cityName)
        {
            IList<City> cities = GetAllOneCriteria(City.DESCRIPTION, cityName);
            if (cities.Count > 0)
            {
                return cities[0];
            }
            return null;
        }

        public int CreateCity(City city)
        {
            return Save(city);
        }
    }
}
