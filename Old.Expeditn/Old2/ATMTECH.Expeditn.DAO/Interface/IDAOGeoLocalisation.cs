using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO.Interface
{
    public interface IDAOGeoLocalisation
    {
        GeoLocalisation ObtenirGeoLocalisation(int id);
        IList<GeoLocalisation> ObtenirGeoLocalisation();
        int Enregistrer(GeoLocalisation geoLocalisation);
    }
}
