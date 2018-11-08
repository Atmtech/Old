using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.StockGame.Entites
{
    public class Tabarnak : Entite
    {
        [BsonElement("a")]

        public string a { get; set; }
    }
}
