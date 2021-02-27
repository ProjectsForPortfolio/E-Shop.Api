using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Shop.Persistence.Models
{
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
