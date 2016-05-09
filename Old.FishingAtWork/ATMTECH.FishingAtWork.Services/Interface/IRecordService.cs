using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IRecordService
    {
        IList<Record> GetRecord(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetRecordCount();
    }
}
