using BandApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BandApi.Contexts{
    public class BandContext : IBandContext
    {
        private readonly IMongoDatabase _database;
        public BandContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Band> Bands => _database.GetCollection<Band>("Bands");
    }
}