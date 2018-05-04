using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.GestionMultimedia.Twiggy
{
    public class DAOGestionMultimediaTwiggy : BaseDAO
    {
        public void AjouterMultimedia(string noGroupe, string etudiants, string style, string urlMedia)
        {
            IMongoCollection<Multimedia> mongoCollection = Database.GetCollection<Multimedia>("Multimedia");
            Multimedia multimedia = new Multimedia
            {
                DateCreation = DateTime.Now,
                Style = style,
                NoGroupe = noGroupe,
                Etudiants = etudiants,
                UrlMedia = urlMedia
            };

            mongoCollection.InsertOneAsync(multimedia);
        }

        public void SupprimerMultimedia(string id)
        {
            IMongoCollection<Multimedia> mongoCollection = Database.GetCollection<Multimedia>("Multimedia");
            FilterDefinition<Multimedia> filterDefinition = Builders<Multimedia>.Filter.Eq("_id", ObjectId.Parse(id));
            mongoCollection.DeleteOne(filterDefinition);
        }

        public IList<Multimedia> ObtenirMultimedia()
        {
            IMongoCollection<Multimedia> mongoCollection = Database.GetCollection<Multimedia>("Multimedia");
            return mongoCollection.AsQueryable().ToList();
        }

    }
}