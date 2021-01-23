﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Shop.Api.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
