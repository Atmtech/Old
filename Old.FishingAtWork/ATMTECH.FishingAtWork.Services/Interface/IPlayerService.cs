using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IPlayerService
    {
        Player GetPlayer(int id);
        Player SavePlayer(Player player);
        Player DeletePlayer(Player player);
        bool ConfirmCreate(int idUser);
        bool CreatePlayer(Player player);

        Player AuthenticatePlayer { get; }

        IList<PlayerDTO> GetRanking(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetRankingCount();
        void UpdateRecord(SpeciesCatch speciesCatch);
        void UpdatePlayerCatch(SpeciesCatch speciesCatch);
        IList<PlayerListDTO> GetPlayerWithSite(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetPlayerCount();
    }
}
