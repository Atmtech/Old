using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Services.Validate
{
    public class ValidateTripService : BaseService, IValidateTripService
    {
        public IMessageService MessageService { get; set; }
        public IDAOTrip DAOTrip { get; set; }

        public bool Validate(Trip trip)
        {
            IList<Trip> trips = DAOTrip.GetTripList(trip.Player);
            foreach (Trip trip1 in trips)
            {
                if (trip1.DateStart == trip.DateStart)
                {
                    MessageService.ThrowMessage(ErrorCode.ErrorCode.FW_TRIP_EXIST_FOR_THIS_DATE);
                    return false;
                }
            }

            return true;
        }
    }
}
