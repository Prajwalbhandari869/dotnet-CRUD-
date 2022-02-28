using SongsTrack.Shared.Models.AlbumModels;

namespace SongsTrack.Server.SongAlbum
{
    public interface IAlbumService
    {
        Task<int> CreateAlbumAsync(CreateAlbum createAlbum);
        Task<IEnumerable<ViewAllAlbum>> GetAllAlbumAsync();
        Task<ViewAlbum> GetAlbumAsync(int id);
        Task UpdateAlbumAsync(UpdateAlbum updateAlbum);
        Task DeleteAlbumAsync(int id);
    }
}
