using ATMTECH.Expeditn.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOExpedition : BaseDAO<Expedition>
    {
        public Expedition Obtenir(string id)
        {
            if (id != null)
            {
                var collection = Database.GetCollection<Expedition>("Expedition");
                var list = collection.Find(x => x.Id == ObjectId.Parse(id));
                return list.FirstOrDefault();
            }
            return null;
        }

    }
}