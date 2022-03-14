using SongsTrack.Shared.Models.ArtistModels;

namespace SongsTrack.Server.SongArtist
{
    public interface IArtistService
    {
        Task<int> CreateArtistAsync(CreateArtist createArtist);
        Task<IEnumerable<ViewAllArtist>> GetAllArtistAsync();
        Task<ViewArtist> GetArtistAsync(int id);
        Task<bool> UpdateArtistAsync(UpdateArtist updateArtist);
        Task DeleteArtistAsync(int id);
    }
}
