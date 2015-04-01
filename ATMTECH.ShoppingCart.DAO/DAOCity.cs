using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOCity : BaseDao<City, int>, IDAOCity
    {
        public IList<City> Cities
        {
            get
            {
                if (ContextSessionManager.Context.Session["Cities"] == null)
                {
                    ContextSessionManager.Context.Session["Cities"] = GetAll();
                }
                return (IList<City>)ContextSessionManager.Context.Session["Cities"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["Cities"] == null)
                    ContextSessionManager.Context.Session["Cities"] = value;
            }
        }

        public City GetCity(int id)
        {
            City firstOrDefault = Cities.FirstOrDefault(x => x.Id == id);
            if (firstOrDefault == null)
            {
                ContextSessionManager.Context.Session["Cities"] = GetAll();
            }
            return Cities.FirstOrDefault(x => x.Id == id);
        }

        public City FindCity(string cityName)
        {
            IList<City> cities = Cities.Where(x => x.Description == cityName).ToList();
            return cities.Count > 0 ? cities[0] : null;
        }

        public int CreateCity(City city)
        {
            Cities = null;
            return Save(city);
        }
    }
}
