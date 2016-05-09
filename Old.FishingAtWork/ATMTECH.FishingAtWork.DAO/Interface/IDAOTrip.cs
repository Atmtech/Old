using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOTrip
    {
        Trip GetTrip(int id);
        int SaveTrip(Trip trip);
        IList<Trip> GetTripList(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee);
        IList<Trip> GetTripList(Player player);
        int GetTripCount(Player player);
        Trip GetTripToday(Player player);
        IList<Trip> GetAllCurrentTrip();
    }
}
