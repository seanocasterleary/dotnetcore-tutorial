using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BandApi.Models;
using BandApi.Repositories;

namespace BandApi.Controllers
{
    [Produces("application/json")]
    [Route("api/band")]
    public class BandController : Controller
    {
        private readonly IBandRepository _bandRepository;
        public BandController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _bandRepository.GetAllBands());
        }
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var band = await _bandRepository.GetBand(name);
            if(band == null) return new NotFoundResult();
            return new OkObjectResult(band);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Band band)
        {
            await _bandRepository.Create(band);
            return new OkObjectResult(band);
        }
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Band band)
        {
            var bandFromDb = await _bandRepository.GetBand(name);
            if(bandFromDb == null) return new NotFoundResult();
            band.Id = bandFromDb.Id;
            await _bandRepository.Update(band);
            return new OkObjectResult(band);
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var gameFromDb = await _bandRepository.GetBand(name);
            if(gameFromDb == null) return new NotFoundResult();
            await _bandRepository.Delete(name);
            return new OkResult();
        }
    }
}
