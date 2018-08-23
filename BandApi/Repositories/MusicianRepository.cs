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
    public class MusicianRepository : IMusicianRepository
    {
        private readonly IMusicianContext _context;

        public MusicianRepository(IMusicianContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Musician>> GetAllMusicians()
        {
            return await _context.Musicians.Find(_ => true).ToListAsync();
        }
        public Task<Musician> GetMusician(string name)
        {
            FilterDefinition<Musician> filter = Builders<Musician>.Filter.Eq(m => m.FirstName, name);
            return _context.Musicians.Find(filter).FirstOrDefaultAsync();
        }
        public async Task Create(Musician Musician)
        {
            await _context.Musicians.InsertOneAsync(Musician);
        }
        public async Task<bool> Update(Musician Musician)
        {
            ReplaceOneResult updateResult = await _context
                .Musicians
                .ReplaceOneAsync(
                    filter: b => b.Id == Musician.Id,
                    replacement: Musician
                );
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(string name)
        {
            FilterDefinition<Musician> filter = Builders<Musician>.Filter.Eq(m => m.FirstName, name);
            DeleteResult deleteResult = await _context.Musicians.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}