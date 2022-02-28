﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server.SongTrack
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _service;

        public TrackController(ITrackService trackService)
        {
            _service = trackService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateTrackAsync(CreateTrack createTrack)
        {
            var id = await _service.CreateTrackAsync(createTrack);
            if (id > 0) return id;
            return BadRequest("Track already exists");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewTrack>> GetTrackAsync(int id)
        {
            return await _service.GetTrackAsync(id);
        }
        [HttpGet("alltrack")]
        public async Task<ActionResult<IEnumerable<ViewAllTrack>>> GetAllTrackAsync()
        {
            var val = Ok(await _service.GetAllTrackAsync());
            return val;
        }
        [HttpPut("update")]
        public async Task<bool> UpdateTrackAsync(UpdateTrack updateTrack)
        {
            await _service.UpdateTrackAsync(updateTrack);
            return true;
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteTrackAsync(int id)
        {
            var track = await _service.GetTrackAsync(id);
            if (track == null) return false;
            await _service.DeleteTrackAsync(id);
            return true;
        }
    }
}
