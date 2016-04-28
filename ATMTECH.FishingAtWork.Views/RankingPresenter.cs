using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class RankingPresenter : BaseFishingAtWorkPresenter<IRankingPresenter>
    {
        public IPlayerService PlayerService { get; set; }
        public RankingPresenter(IRankingPresenter view)
            : base(view)
        {
        }

        public IList<PlayerDTO> GetRanking(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return PlayerService.GetRanking(parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetPlayerCount()
        {
            return PlayerService.GetPlayerCount();
        }
    }
}
