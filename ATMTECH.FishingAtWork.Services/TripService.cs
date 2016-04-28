using System.Collections.Generic;

using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class TripService : BaseService, ITripService
    {
        public IDAOTrip DAOTrip { get; set; }
        public IValidateTripService ValidateTripService { get; set; }
        public int SaveTrip(Trip trip)
        {
            if (ValidateTripService.Validate(trip))
            {
                return DAOTrip.SaveTrip(trip);
            }
            else
                return 0;
        }

        public Trip GetTrip(int id)
        {
            return DAOTrip.GetTrip(id);
        }

        public Trip GetTripToday(Player player)
        {
            return DAOTrip.GetTripToday(player);
        }

        public IList<Trip> GetTripList(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return DAOTrip.GetTripList(player, parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetTripCount(Player player)
        {
            return DAOTrip.GetTripCount(player);
        }

        public IList<Trip> GetAllCurrentTrip()
        {
            return DAOTrip.GetAllCurrentTrip();
        }
    }
}
