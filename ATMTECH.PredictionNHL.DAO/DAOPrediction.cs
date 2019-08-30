using ATMTECH.PredictionNHL.Entites;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ATMTECH.PredictionNHL.DAO
{
    public class DAOPrediction : BaseDAO<Prediction>
    {
        public IList<Prediction> ObtenirPrediction(string  id)
        {
            var collection = Database.GetCollection<Prediction>("Prediction");
            var list = collection.Find(x => x.Id == ObjectId.Parse(id));
            return list.ToList();
        }

        public IList<Classement> CalculerClassement()
        {
            return null;
        }
    }
}
