using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOCoordinateTry
    {
        int CreateCoordinateTry(CoordinateTry coordinateTry);
        IList<CoordinateTry> GetAllCoordinate(Site site);
    }
}
