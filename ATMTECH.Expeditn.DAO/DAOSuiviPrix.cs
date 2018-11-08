using ATMTECH.Expeditn.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOSuiviPrix : BaseDAO<SuiviPrix>
    {

        public SuiviPrix Obtenir(string id)
        {
            if (id != null)
            {
                var collection = Database.GetCollection<SuiviPrix>("SuiviPrix");
                var list = collection.Find(x => x.Id == ObjectId.Parse(id));
                return list.FirstOrDefault();
            }
            return null;
        }

    }
}
