using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface ILureService
    {
        IList<LurePlayerLure> GetLureList(string parametreTrie, int nbEnreg, int indexDebutRangee);
        IList<Lure> GetLureList();
        Lure GetLure(int id);
    }
}
