using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Services
{
    public class PlayerService : BaseService, IPlayerService
    {

        public IDAOPlayer DAOPlayer { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IMessageService MessageService { get; set; }
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAORecord DAORecord { get; set; }
        public IDAOPlayerCatch DAOPlayerCatch { get; set; }
        public IDAOTrip DAOTrip { get; set; }

        public Player AuthenticatePlayer
        {
            get
            {
                // TEmporaire
                //Player player1 = GetPlayer(1);
                //player1.User = DAOUser.GetUser(1);
                //return player1;

                if (AuthenticationService.AuthenticateUser != null)
                {
                    Player player = GetPlayer(AuthenticationService.AuthenticateUser.Id);
                    player.User = AuthenticationService.AuthenticateUser;
                    return player;
                }
                return null;


            }
        }


        public IValidatePlayerService ValidatePlayerService { get; set; }
        public Player GetPlayer(int id)
        {
            return DAOPlayer.GetPlayer(id);
        }
        public Player SavePlayer(Player player)
        {
            ValidatePlayerService.IsValidPlayerOnUpdate(player);
            return DAOPlayer.SavePlayer(player);
        }
        public Player DeletePlayer(Player player)
        {
            player.IsActive = false;
            return SavePlayer(player);
        }
        public bool ConfirmCreate(int idUser)
        {
            User user = DAOUser.GetUser(idUser);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    user.IsActive = true;
                    DAOUser.UpdateUser(user);
                    return true;
                }
            }
            else
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM);
            }
            return false;
        }
        public bool CreatePlayer(Player player)
        {
            player.Money = 100;
            player.MaximumWaypoint = 3;

            ValidatePlayerService.IsValidPlayerOnCreate(player);

            int rtn = DAOUser.CreateUser(player.User);
            player.User.Id = rtn;
            player.User.IsActive = false;

            int t = DAOPlayer.CreatePlayer(player);

            bool ret = t > 0;

            SetUserInactive(rtn);

            if (ret)
            {
                ret = MailService.SendEmail(player.User.Email,
                                  ParameterService.GetValue(Constant.ADMIN_MAIL),
                                        ParameterService.GetValue(Constant.MAIL_SUBJECT_CONFIRM_CREATE),
                                      string.Format(ParameterService.GetValue(Constant.MAIL_BODY_CONFIRM_CREATE), player.User.Id));
                if (ret == false)
                {
                    MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_SEND_MAIL_FAILED);
                }
            }
            return ret;
        }
        private void SetUserInactive(int id)
        {
            User user = DAOUser.GetUser(id);
            user.IsActive = false;
            DAOUser.UpdateUser(user);
        }

        public IList<PlayerDTO> GetRanking(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return DAOPlayer.GetRanking(parametreTrie, nbEnreg, indexDebutRangee);
        }
        public int GetRankingCount()
        {
            return DAOPlayer.GetPlayerCount();
        }

        public void UpdateRecord(SpeciesCatch speciesCatch)
        {
            Record record = DAORecord.GetRecord(speciesCatch.Species) ?? new Record { Player = speciesCatch.Player, Site = speciesCatch.Site, Species = speciesCatch.Species };

            if (record.Weight < speciesCatch.Weight)
            {
                record.Weight = speciesCatch.Weight;
            }
            DAORecord.UpdateRecord(record);
        }

        public void UpdatePlayerCatch(SpeciesCatch speciesCatch)
        {
            PlayerCatch playerCatch = DAOPlayerCatch.GetPlayerCatch(speciesCatch.Species, speciesCatch.Site,
                                                                    speciesCatch.Player) ?? new PlayerCatch
                                                                                                {
                                                                                                    Site = speciesCatch.Site,
                                                                                                    Player = speciesCatch.Player,
                                                                                                    Species = speciesCatch.Species
                                                                                                };
            playerCatch.NumberOfCatch += 1;
            DAOPlayerCatch.SavePlayerCatch(playerCatch);
        }

        public IList<PlayerListDTO> GetPlayerWithSite(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<PlayerListDTO> playerListDtos = new List<PlayerListDTO>();
            IList<Player> players = DAOPlayer.GetPlayer();
            IList<Trip> trips = DAOTrip.GetAllCurrentTrip();
            foreach (Player player in players)
            {
                Trip trip = trips.SingleOrDefault(test => test.Player.Id == player.Id);
                Site site = new Site() {Name = ""};
                playerListDtos.Add(trip != null
                                       ? new PlayerListDTO { Player = player, Site = trip.Site, Id = player.Id }
                                       : new PlayerListDTO { Player = player, Site = site, Id = player.Id });
            }
            return playerListDtos;
        }

        public int GetPlayerCount()
        {
            return DAOPlayer.GetPlayerCount();
        }
    }
}
