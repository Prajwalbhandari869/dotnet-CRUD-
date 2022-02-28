using AutoMapper;
using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server.SongTrack
{
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _repository;
        private readonly IMapper _mapper;

        public TrackService(IRepository<Track> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateTrackAsync(CreateTrack trackCreate)
        {
            var track = _mapper.Map<Track>(trackCreate);
            if (!(await _repository.CheckAsync(track.Title)))
            {
                track = await _repository.CreateAsync(track);
                return track.Id;
            }
            return -1;
        }

        public async Task DeleteTrackAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync()
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ViewAllTrack>>(tracks);
        }

        public async Task<ViewTrack> GetTrackAsync(int id)
        {
            var track = await _repository.GetAsync(id);
            return _mapper.Map<ViewTrack>(track);
        }

        public async Task UpdateTrackAsync(UpdateTrack updateTrack)
        {
            var track = _mapper.Map<Track>(updateTrack);
            await _repository.UpdateAsync(track);
        }
    }
}
