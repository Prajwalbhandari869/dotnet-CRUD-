using AutoMapper;
using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Shared.Models.AlbumModels;

namespace SongsTrack.Server.SongAlbum
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _repository;
        private readonly IMapper _mapper;

        public AlbumService(IRepository<Album> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateAlbumAsync(CreateAlbum createAlbum)
        {
            var album = _mapper.Map<Album>(createAlbum);
            if (!(await _repository.CheckAsync(album.Title)))
            {
                album = await _repository.CreateAsync(album);
                return album.Id;
            }
            return -1;
        }

        public async Task DeleteAlbumAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ViewAlbum> GetAlbumAsync(int id)
        {
            var album = await _repository.GetAsync(id);
            return _mapper.Map<ViewAlbum>(album);
        }

        public async Task<IEnumerable<ViewAllAlbum>> GetAllAlbumAsync()
        {
            var albums = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ViewAllAlbum>>(albums);
        }

        public async Task<bool> UpdateAlbumAsync(UpdateAlbum updateAlbum)
        {
            var album = _mapper.Map<Album>(updateAlbum);
            if (!(await _repository.CheckAsync(album.Title)) || await _repository.CheckAsync(album.Id, album.Title))
            {
                await _repository.UpdateAsync(album);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
