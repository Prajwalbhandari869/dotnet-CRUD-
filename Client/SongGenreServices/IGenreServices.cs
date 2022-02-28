using SongsTrack.Shared.Models.GenreModels;

namespace SongsTrack.Client.SongGenreServices
{
    public interface IGenreServices
    {
        Task<IEnumerable<ViewAllGenre>> GetAllGenreAsync();
        Task<int> CreateGenreAsync(CreateGenre createGenre);
        Task<ViewGenre> GetGenreAsync(int id);
        Task<bool> UpdateGenreAsync(UpdateGenre updateGenre);
        Task<bool> DeleteGenreAsync(int id);
    }
}
