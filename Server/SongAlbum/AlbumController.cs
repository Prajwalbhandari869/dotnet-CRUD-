using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongsTrack.Shared.Models.AlbumModels;

namespace SongsTrack.Server.SongAlbum
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }
        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateAlbumAsync(CreateAlbum createAlbum)
        {
            var id = await _service.CreateAlbumAsync(createAlbum);
            if (id > 0) return id;
            return BadRequest("Album already exists");
        }
        [HttpGet("allalbum")]
        public async Task<ActionResult<IEnumerable<ViewAllAlbum>>> GetAllAlbumAsync()
        {
            var all = await _service.GetAllAlbumAsync();
            return Ok(all);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewAlbum>> GetAlbumAsync(int id)
        {
            return await _service.GetAlbumAsync(id);
        }
        [HttpPut("update")]
        public async Task<bool> UpdateAlbumAsync(UpdateAlbum updateAlbum)
        {
            await _service.UpdateAlbumAsync(updateAlbum);
            return true;
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAlbumAsync(int id)
        {
            var albumDto = await _service.GetAlbumAsync(id);
            if (albumDto == null) return false;
            await _service.DeleteAlbumAsync(id);
            return true;
        }
    }
}
