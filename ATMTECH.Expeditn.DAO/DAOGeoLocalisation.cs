using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOGeoLocalisation : BaseDao<GeoLocalisation, int>, IDAOGeoLocalisation
    {
        public IDAOPays DaoPays { get; set; }
        public GeoLocalisation ObtenirGeoLocalisation(int id)
        {
            GeoLocalisation geoLocalisation = GetById(id);
            geoLocalisation.Pays = DaoPays.ObtenirPays(geoLocalisation.Pays.Id);
            return geoLocalisation;
        }

        public IList<GeoLocalisation> ObtenirGeoLocalisation()
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            IList<GeoLocalisation> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn : null;
        }

        public int Enregistrer(GeoLocalisation geoLocalisation)
        {
            return Save(geoLocalisation);
        }
    }
}
