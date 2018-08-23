using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BandApi.Models
{
    public class Band{
        [BsonId]
        public ObjectId Id {get;set;}
        public string Name {get;set;}
        public List<string> Members {get;set;}
        public DateTime DateFormed {get;set;}
    }
}