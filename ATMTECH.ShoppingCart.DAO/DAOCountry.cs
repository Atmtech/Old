using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOCountry : BaseDao<Country, int>, IDAOCountry
    {
        public IList<Country> Countries
        {
            get
            {
                if (ContextSessionManager.Context.Session["Countries"] == null)
                {
                    ContextSessionManager.Context.Session["Countries"] = GetAll();
                }
                return (IList<Country>)ContextSessionManager.Context.Session["Countries"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["Countries"] == null)
                    ContextSessionManager.Context.Session["Countries"] = value;
            }
        }


        public Country GetCountry(int id)
        {
            return Countries.FirstOrDefault(x => x.Id == id);
        }

        public Country FindCountry(string countryName)
        {
            IList<Country> countries = Countries.Where(x => x.Description == countryName).ToList();
            return countries.Count > 0 ? countries[0] : null;
        }

        public IList<Country> GetAllCountries()
        {
            Countries = null;
            return Countries.Where(x => x.Code != null).ToList();
        }
    }
}
