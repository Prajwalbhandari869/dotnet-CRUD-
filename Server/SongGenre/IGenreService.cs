using SongsTrack.Shared.Models.GenreModels;

namespace SongsTrack.Server.SongGenre
{
    public interface IGenreService
    {
        Task<int> CreateGenreAsync(CreateGenre createGenre);
        Task<IEnumerable<ViewAllGenre>> GetAllGenreAsync();
        Task<ViewGenre> GetGenreAsync(int id);
        Task UpdateGenreAsync(UpdateGenre updateGenre);
        Task DeleteGenreAsync(int id);
    }
}
