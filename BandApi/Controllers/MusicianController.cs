using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BandApi.Models;
using BandApi.Repositories;

namespace BandApi.Controllers
{
    [Produces("application/json")]
    [Route("api/musician")]
    public class MusicianController : Controller
    {
        private readonly IMusicianRepository _musicianRepository;
        public MusicianController(IMusicianRepository musicianRepository)
        {
            _musicianRepository = musicianRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _musicianRepository.GetAllMusicians());
        }
        [HttpGet("{name}", Name = "GetMusician")]
        public async Task<IActionResult> Get(string name)
        {
            var musician = await _musicianRepository.GetMusician(name);
            if(musician == null) return new NotFoundResult();
            return new OkObjectResult(musician);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Musician musician)
        {
            await _musicianRepository.Create(musician);
            return new OkObjectResult(musician);
        }
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Musician musician)
        {
            var bandFromDb = await _musicianRepository.GetMusician(name);
            if(bandFromDb == null) return new NotFoundResult();
            musician.Id = bandFromDb.Id;
            await _musicianRepository.Update(musician);
            return new OkObjectResult(musician);
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var gameFromDb = await _musicianRepository.GetMusician(name);
            if(gameFromDb == null) return new NotFoundResult();
            await _musicianRepository.Delete(name);
            return new OkResult();
        }
    }
}
