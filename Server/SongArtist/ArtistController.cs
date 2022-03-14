using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongsTrack.Shared.Models.ArtistModels;

namespace SongsTrack.Server.SongArtist
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _service;

        public ArtistController(IArtistService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateAristAsync(CreateArtist createArtist)
        {
            var id = await _service.CreateArtistAsync(createArtist);
            if (id > 0) return id;
            return BadRequest("Artist already exists");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewArtist>> GetArtistAsync(int id)
        {
            return await _service.GetArtistAsync(id);
        }
        [HttpGet("allartist")]
        public async Task<ActionResult<IEnumerable<ViewAllArtist>>> GetAllArtistAsync()
        {
            return Ok(await _service.GetAllArtistAsync());
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteArtistAsync(int id)
        {
            var artistDto = await _service.GetArtistAsync(id);
            if (artistDto == null) return false;
            await _service.DeleteArtistAsync(id);
            return true;
        }
        [HttpPut("update")]
        public async Task<bool> UpdateArtistAsync(UpdateArtist updateArtist)
        {
            return await _service.UpdateArtistAsync(updateArtist);
        }
    }
}
