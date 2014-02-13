using System.Collections.Generic;
using ATMTECH.Investisseurs.DAO.Interface;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Investisseurs.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Investisseurs.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
      public IAuthenticationService AuthenticationService { get; set; }
      public IDAOPlayer DAOPlayer { get; set; }

      public Player AuthenticatePlayer
      {
          get
          {
              if (AuthenticationService.AuthenticateUser != null)
              {
                  Player player = GetPlayer(AuthenticationService.AuthenticateUser.Id);
                  player.User = AuthenticationService.AuthenticateUser;
                  return player;
              }
              return null;
          }
      }

      public Player GetPlayer(int id)
      {
          return DAOPlayer.GetPlayer(id);
      }

    }
}
