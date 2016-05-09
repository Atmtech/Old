using ATMTECH.BaseModule;
using ATMTECH.FishingAtWork.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.FishingAtWork.Services.Validate;

namespace ATMTECH.FishingAtWork.Services.Base
{
    public class FishingAtWorkInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
          

            // Site
            AddDependency<ITripService, TripService>();
            AddDependency<ISiteService, SiteService>();
            AddDependency<IPlayerService, PlayerService>();
            AddDependency<IPlayerLureService, PlayerLureService>();
            AddDependency<IValidatePlayerService, ValidatePlayerService>();
            AddDependency<IWaypointService, WaypointService>();
            AddDependency<IValidateTripService, ValidateTripService>();
            AddDependency<IShoppingService, ShoppingService>();
            AddDependency<IValidateShoppingService, ValidateShoppingService>();
            AddDependency<IWallPostService, WallPostService>();
            AddDependency<ILureService, LureService>();


            AddDependency<IEnumService<EnumWaypointTechniqueType>, EnumService<EnumWaypointTechniqueType>>();
            AddDependency<IEnumService<EnumWallPostType>, EnumService<EnumWallPostType>>();

            AddDependency<IDAOSite, DAOSite>();
            AddDependency<IDAOTrip, DAOTrip>();
            AddDependency<IDAOPlayer, DAOPlayer>();
            AddDependency<IDAOPlayerLure, DAOPlayerLure>();
            AddDependency<IDAOSpeciesCatch, DAOSpeciesCatch>();
            AddDependency<IDAOWayPoint, DAOWayPoint>();
            AddDependency<IDAOBasket, DAOBasket>();
            AddDependency<IDAOWallPost, DAOWallPost>();


            AddDependency<IDAOEnum<EnumWaypointTechniqueType>, DAOEnum<EnumWaypointTechniqueType>>();




        }
    }
}
