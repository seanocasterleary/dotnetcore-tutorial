using System.Collections.Generic;
using System.Threading.Tasks;
using BandApi.Models;

namespace BandApi.Repositories
{
    public interface IMusicianRepository
    {
        Task<IEnumerable<Musician>> GetAllMusicians();
        Task<Musician> GetMusician(string name);
        Task Create(Musician musician);
        Task<bool> Update(Musician musician);
        Task<bool> Delete(string name);
    }
}