using System;
using System.Collections.Generic;
using ATMTECH.StockGame.Entites;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.StockGame.DAO
{
    public class BaseDAO<T>
    {
        public IMongoDatabase Database
        {
            get
            {
                var connectionString = "mongodb://127.0.0.1:27017/db";
                MongoClient client = new MongoClient(connectionString);
                IMongoDatabase mongoDatabase = client.GetDatabase("StockGame");
                return mongoDatabase;
            }
        }

        public IMongoCollection<T> ObtenirCollection()
        {
            Type type = typeof(T);
            IMongoCollection<T> mongoCollection = Database.GetCollection<T>(type.Name);
            return mongoCollection;
        }

        public IList<T> Obtenir()
        {
            return ObtenirCollection().AsQueryable().ToList();
        }


        public void Supprimer(string id)
        {
            ObtenirCollection().DeleteOne(x => (x as Entite).Id == ObjectId.Parse(id));
        }

        public ObjectId Enregistrer(T objet)
        {
            if ((objet as Entite).Id.Pid == 0)
            {
                 ObtenirCollection().InsertOneAsync(objet);
            }
            else
            {
                ObtenirCollection().ReplaceOneAsync(x => (x as Entite).Id == (objet as Entite).Id, objet);
            }

            return (objet as Entite).Id;
        }
    }
}