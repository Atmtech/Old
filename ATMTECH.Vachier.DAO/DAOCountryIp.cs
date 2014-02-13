using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Vachier.DAO.Interface;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.Vachier.DAO
{
    public class DAOCountryIp : BaseDao<CountryIp, int>, IDAOCountryIp
    {
        public IList<CountryIp> ObtenirListePays()
        {
            return GetBySql("SELECT '' as Ip, '' as CountryCode, CountryName as CountryName, '' as City, '' as PostalCode, '' as Region, Count(id) as Compte FROM Vachier WHERE CountryName is not null and CountryName <> '' GROUP BY CountryName order by Count(id) desc LIMIT 20");
        }
        public IList<CountryIp> ObtenirListeVille()
        {
            return GetBySql("SELECT '' as Ip, '' as CountryCode, '' as CountryName, City, '' as PostalCode, '' as Region, Count(id) as Compte FROM Vachier WHERE City is not null and City <> '' GROUP BY City order by Count(id) desc LIMIT 20");
        }
    }


}
