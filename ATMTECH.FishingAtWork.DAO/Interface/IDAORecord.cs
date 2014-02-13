using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAORecord
    {
        Record GetRecord(Species species);
        void UpdateRecord(Record record);
        IList<Record> GetRecord(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetRecordCount();
    }
}
