using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain.CardDomain
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }
        public int Cantitate {  get; set; }

    }
}
