using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class RecordPresenter : BaseFishingAtWorkPresenter<IRecordPresenter>
    {
        public IRecordService RecordService { get; set; }
        public RecordPresenter(IRecordPresenter view)
            : base(view)
        {
        }

        public IList<Record> GetRecord(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return RecordService.GetRecord(parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetRecordCount()
        {
            return RecordService.GetRecordCount();
        }
    }
}
