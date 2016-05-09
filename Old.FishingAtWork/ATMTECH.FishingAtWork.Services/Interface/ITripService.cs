using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface ITripService
    {
        int SaveTrip(Trip trip);
        Trip GetTrip(int id);
        Trip GetTripToday(Player player);
        IList<Trip> GetTripList(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetTripCount(Player player);
        IList<Trip> GetAllCurrentTrip();

    }
}
