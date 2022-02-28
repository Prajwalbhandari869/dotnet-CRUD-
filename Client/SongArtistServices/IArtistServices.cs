using SongsTrack.Shared.Models.ArtistModels;

namespace SongsTrack.Client.SongArtistServices
{
    public interface IArtistServices
    {
        Task<ViewArtist> GetArtistAsync(int id);
        Task<int> CreateArtistAsync(CreateArtist createArtist);
        Task<IEnumerable<ViewAllArtist>> GetAllArtistAsync();
        Task<bool> UpdateArtistAsync(UpdateArtist artist);
        Task<bool> DeleteArtistAsync(int id);
    }
}
