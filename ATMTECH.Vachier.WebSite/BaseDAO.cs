using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace ATMTECH.Vachier.WebSite
{
    public class BaseDAO
    {
        public IMongoDatabase Database
        {
            get
            {
                var connectionString = "mongodb://127.0.0.1:27017/db";
                MongoClient client = new MongoClient(connectionString);
                IMongoDatabase mongoDatabase = client.GetDatabase("Vachier");
                return mongoDatabase;
            }
        }
    }
}