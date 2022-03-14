using AutoMapper;
using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Shared.Models.ArtistModels;

namespace SongsTrack.Server.SongArtist
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _repository;
        private readonly IMapper _mapper;

        public ArtistService(IRepository<Artist> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateArtistAsync(CreateArtist createArtist)
        {
            var artist = _mapper.Map<Artist>(createArtist);
            if (!(await _repository.CheckAsync(artist.Name)))
            {
                artist = await _repository.CreateAsync(artist);
                return artist.Id;
            }
            return -1;
        }

        public async Task DeleteArtistAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViewAllArtist>> GetAllArtistAsync()
        {
            var artists = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ViewAllArtist>>(artists);
        }

        public async Task<ViewArtist> GetArtistAsync(int id)
        {
            var artist = await _repository.GetAsync(id);
            return _mapper.Map<ViewArtist>(artist);
        }

        public async Task<bool> UpdateArtistAsync(UpdateArtist updateArtist)
        {
            var artist = _mapper.Map<Artist>(updateArtist);
            if (!(await _repository.CheckAsync(artist.Name)) || await _repository.CheckAsync(artist.Id, artist.Name))
            {
                await _repository.UpdateAsync(artist);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
