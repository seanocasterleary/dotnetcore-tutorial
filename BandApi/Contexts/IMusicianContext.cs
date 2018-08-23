using MongoDB.Driver;
using BandApi.Models;

namespace BandApi.Contexts
{
    public interface IMusicianContext
    {
        IMongoCollection<Musician> Musicians { get; }
    }
}