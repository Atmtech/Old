using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class PlayerListPresenter : BaseFishingAtWorkPresenter<IPlayerListPresenter>
    {
        public IPlayerService PlayerService { get; set; }
        public PlayerListPresenter(IPlayerListPresenter view)
            : base(view)
        {
        }

        public IList<PlayerListDTO> GetPlayerWithSite(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return PlayerService.GetPlayerWithSite(parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetPlayerCount()
        {
            return PlayerService.GetPlayerCount();
        }
    }
}
