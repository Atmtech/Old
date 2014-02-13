using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOCountry : BaseDao<Country, int>, IDAOCountry
    {
        public Country GetCountry(int id)
        {
            return GetById(id);
        }

        public Country FindCountry(string countryName)
        {
            IList<Country> countries = GetAllOneCriteria(BaseEntity.DESCRIPTION, countryName);
            if (countries.Count > 0)
            {
                return countries[0];
            }
            return null;
        }

        public IList<Country> GetAllCountries()
        {
            return GetAllActive().Where(x => x.Code != null).ToList();
        }
    }
}
