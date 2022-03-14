using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongsTrack.Shared.Models.GenreModels;

namespace SongsTrack.Server.SongGenre
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateGenreAsync(CreateGenre createGenre)
        {
            var id = await _service.CreateGenreAsync(createGenre);
            if (id > 0) return id;
            return BadRequest("Genre already exists");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewGenre>> GetGenreAsync(int id)
        {
            return await _service.GetGenreAsync(id);
        }
        [HttpGet("allgenre")]
        public async Task<ActionResult<IEnumerable<ViewAllGenre>>> GetAllGenreAsync()
        {
            return Ok(await _service.GetAllGenreAsync());
        }
        [HttpPut("update")]
        public async Task<bool> UpdateGenreAsync(UpdateGenre updateGenre)
        {
            return await _service.UpdateGenreAsync(updateGenre); ;
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteGenreAsync(int id)
        {
            var genreEach = await _service.GetGenreAsync(id);
            if (genreEach == null) return false;
            await _service.DeleteGenreAsync(id);
            return true;
        }
    }
}
