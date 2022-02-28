using SongsTrack.Shared.Models.AlbumModels;

namespace SongsTrack.Client.SongAlbumServices
{
    public interface IAlbumServices
    {
        Task<IEnumerable<ViewAllAlbum>> GetAllAlbumAsync();
        Task<int> CreateAlbumAsync(CreateAlbum createAlbum);
        Task<ViewAlbum> GetAlbumAsync(int id);
        Task<bool> UpdateAlbumAsync(UpdateAlbum updateAlbum);
        Task<bool> DeleteAlbumAsync(int id);
    }
}
