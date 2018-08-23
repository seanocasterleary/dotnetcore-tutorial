using System.Collections.Generic;
using System.Threading.Tasks;
using BandApi.Models;

namespace BandApi.Repositories
{
    public interface IBandRepository
    {
        Task<IEnumerable<Band>> GetAllBands();
        Task<Band> GetBand(string name);
        Task Create(Band band);
        Task<bool> Update(Band band);
        Task<bool> Delete(string name);
    }
}