using System.Collections.Generic;
using ATMTECH.Vachier.Entities;
using ATMTECH.Web.Services.Entities;

namespace ATMTECH.Vachier.DAO.Interface
{
    public interface IDAOCountryIp
    {
        IList<CountryIp> ObtenirListePays();
        IList<CountryIp> ObtenirListeVille();
    }
}
