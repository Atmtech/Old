using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOCoordinateTry : BaseDao<CoordinateTry, int>, IDAOCoordinateTry
    {
        public IDAOSpecies DAOSpecies { get; set; }
        public int CreateCoordinateTry(CoordinateTry coordinateTry)
        {
            ExecuteSql("DELETE FROM CoordinateTry where DateCreated < '" + DateTime.Now.AddDays(-1) + "'");

            return Save(coordinateTry);
        }

        public IList<CoordinateTry> GetAllCoordinate(Site site)
        {
            IList<CoordinateTry> coordinateTries = GetAllOneCriteria(CoordinateTry.SITE, site.Id.ToString());
            coordinateTries = coordinateTries.Take(1000).ToList();
            foreach (CoordinateTry coordinateTry in coordinateTries)
            {
                coordinateTry.Species = DAOSpecies.GetSpecies(coordinateTry.Species.Id);
            }
            return coordinateTries;
        }
    }
}
