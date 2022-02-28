using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server.SongTrack
{
    public interface ITrackService
    {
        Task<int> CreateTrackAsync(CreateTrack trackCreate);
        Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync();
        Task<ViewTrack> GetTrackAsync(int id);
        Task UpdateTrackAsync(UpdateTrack updateTrack);
        Task DeleteTrackAsync(int id);
    }
}
