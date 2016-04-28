using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class RecordService : BaseService, IRecordService
    {
        public IDAORecord DAORecord { get; set; }

        public IList<Record> GetRecord(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return DAORecord.GetRecord(parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetRecordCount()
        {
            return DAORecord.GetRecordCount();
        }
    }
}
