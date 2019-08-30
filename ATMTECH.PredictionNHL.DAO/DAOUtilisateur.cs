using System.Collections.Generic;
using ATMTECH.PredictionNHL.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.PredictionNHL.DAO
{
    public class DAOUtilisateur : BaseDAO<Utilisateur>
    {
        public IList<Utilisateur> Obtenir(string id)
        {
            var collection = Database.GetCollection<Utilisateur>("Utilisateur");
            var list = collection.Find(x => x.Id == ObjectId.Parse(id));
            return list.ToList();
        }
    }
}