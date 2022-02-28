using AutoMapper;
using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Shared.Models.GenreModels;

namespace SongsTrack.Server.SongGenre
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateGenreAsync(CreateGenre createGenre)
        {
            var genre = _mapper.Map<Genre>(createGenre);
            if (!(await _repository.CheckAsync(genre.Name)))
            {
                genre = await _repository.CreateAsync(genre);
                return genre.Id;
            }
            return -1;
        }

        public async Task DeleteGenreAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViewAllGenre>> GetAllGenreAsync()
        {
            var genres = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ViewAllGenre>>(genres);
        }

        public async Task<ViewGenre> GetGenreAsync(int id)
        {
            var genre = await _repository.GetAsync(id);
            return _mapper.Map<ViewGenre>(genre);
        }

        public async Task UpdateGenreAsync(UpdateGenre updateGenre)
        {
            var genre = _mapper.Map<Genre>(updateGenre);
            await _repository.UpdateAsync(genre);
        }
    }
}
