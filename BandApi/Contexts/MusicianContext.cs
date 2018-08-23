using BandApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BandApi.Contexts{
    public class MusicianContext : IMusicianContext
    {
        private readonly IMongoDatabase _database;
        public MusicianContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Musician> Musicians => _database.GetCollection<Musician>("Musicians");
    }
}