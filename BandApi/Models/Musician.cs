using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BandApi.Models
{
    public class Musician{
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public List<string> Instruments { get; set; }
    }
}