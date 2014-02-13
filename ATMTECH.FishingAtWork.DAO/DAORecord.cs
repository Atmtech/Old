using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAORecord : BaseDao<Record, int>, IDAORecord
    {
        public IDAOSpecies DAOSpecies { get; set; }
        public IDAOSite DAOSite { get; set; }
        public IDAOPlayer DAOPlayer { get; set; }

        public Record GetRecord(Species species)
        {
            IList<Record> records = GetAllOneCriteria(Record.SPECIES, species.Id.ToString());
            if (records.Count > 0)
            {
                return records[0];
            }

            return null;
        }

        public void UpdateRecord(Record record)
        {
            Save(record);
        }

        public IList<Record> GetRecord(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = Record.SPECIES, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            IList<Record> records = GetAllActive(pagingOperation, orderOperation);
            foreach (Record record in records)
            {
                record.Species = DAOSpecies.GetSpecies(record.Species.Id);
                record.Site = DAOSite.GetSite(record.Site.Id);
                record.Player = DAOPlayer.GetPlayer(record.Player.Id);
            }
            return records;
        }

        public int GetRecordCount()
        {
            return GetCount();
        }
    }
}
