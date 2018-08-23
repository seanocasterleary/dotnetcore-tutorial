using MongoDB.Driver;
using BandApi.Models;

namespace BandApi.Contexts
{
    public interface IBandContext
    {
        IMongoCollection<Band> Bands { get; }
    }
}