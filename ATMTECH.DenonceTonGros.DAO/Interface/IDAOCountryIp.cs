using System.Collections.Generic;
using ATMTECH.DenonceTonGros.Entities;
using ATMTECH.Web.Services.DTO;

namespace ATMTECH.DenonceTonGros.DAO.Interface
{
    public interface IDAOCountryIp
    {
        IList<CountryIp> ObtenirListePays();
        IList<CountryIp> ObtenirListeVille();
    }
}
