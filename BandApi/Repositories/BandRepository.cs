using System.Collections.Generic;
using System.Threading.Tasks;
using BandApi.Contexts;
using BandApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Linq;

namespace BandApi.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly IBandContext _context;

        public BandRepository(IBandContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Band>> GetAllBands()
        {
            return await _context.Bands.Find(_ => true).ToListAsync();
        }
        public Task<Band> GetBand(string name)
        {
            FilterDefinition<Band> filter = Builders<Band>.Filter.Eq(m => m.Name, name);
            return _context.Bands.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Create(Band band)
        {
            await _context.Bands.InsertOneAsync(band);
        }
        public async Task<bool> Update(Band band)
        {
            ReplaceOneResult updateResult = await _context
                .Bands
                .ReplaceOneAsync(
                    filter: b => b.Id == band.Id,
                    replacement: band
                );
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Band> filter = Builders<Band>.Filter.Eq(m => m.Name, name);
            DeleteResult deleteResult = await _context.Bands.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}